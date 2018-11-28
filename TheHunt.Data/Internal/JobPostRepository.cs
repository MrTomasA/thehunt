using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TheHunt.Host;

namespace TheHunt.Data.Internal
{
    internal class JobPostRepository : IJobPostRepository
    {
        private readonly TheHuntContext context;
        private readonly ILogger<JobPostRepository> logger;

        public JobPostRepository(TheHuntContext context, ILogger<JobPostRepository> logger)
        {
            this.context = context ?? throw new System.ArgumentNullException(nameof(context));
            this.logger = logger ?? throw new System.ArgumentNullException(nameof(logger));
        }

        public async Task<JobType> SaveJobType(JobType jobType)
        {
            context.JobType.Add(jobType);
            await context.SaveChangesAsync();

            return jobType;
        }

        public async Task<JobLocation> SaveJobLocation(JobLocation jobLocation)
        {
            context.JobLocation.Add(jobLocation);
            await context.SaveChangesAsync();

            return jobLocation;
        }

        public async Task<JobPostActivity> SaveJobPostActivity(JobPostActivity jobPostActivity)
        {
            context.JobPostActivity.Add(jobPostActivity);
            await context.SaveChangesAsync();

            return jobPostActivity;
        }
    }
}