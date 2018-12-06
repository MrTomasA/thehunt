using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TheHunt.EntityFrameworkGenerator.Models;

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

        public async Task<DomainModel.Models.JobPost> CreateJobPost(DomainModel.Models.JobPost jobPost)
        {
            if (jobPost.Id == null)
            {
                var jp = new JobPost
                {
                    IsActive = jobPost.IsActive,
                    CompanyId = jobPost.CompanyId,
                    CreatedDate = jobPost.CreatedDate,
                    PostedById = jobPost.PostedById,
                    JobTypeId = jobPost.JobTypeId,
                    JobLocationId = jobPost.JobLocationId,
                    JobDescription = jobPost.JobDescription,
                    IsCompanyNameHidden = jobPost.IsCompanyNameHidden
                };

                context.JobPost.Add(jp);
                await context.SaveChangesAsync();

                jobPost.Id = jp.Id;
            }

            return jobPost;
        }

        public async Task<DomainModel.Models.JobType> CreateJobType(DomainModel.Models.JobType jobType)
        {
            if (jobType.Id == null)
            {
                var jt = new JobType
                {
                    Name = jobType.Name
                };

                context.JobType.Add(jt);
                await context.SaveChangesAsync();

                jobType.Id = jt.Id;
            }

            return jobType;
        }

        public async Task<DomainModel.Models.JobLocation> CreateJobLocation(DomainModel.Models.JobLocation jobLocation)
        {
            if (jobLocation.Id == null)
            {
                var jl = new JobLocation
                {
                    StreetAddress = jobLocation.StreetAddress,
                    City = jobLocation.City,
                    State = jobLocation.State,
                    Country = jobLocation.Country,
                    Zip = jobLocation.Zip
                };

                context.JobLocation.Add(jl);
                await context.SaveChangesAsync();

                jobLocation.Id = jl.Id;
            }

            return jobLocation;
        }

        public async Task<JobPostActivity> CreateJobPostActivity(JobPostActivity jobPostActivity)
        {
            context.JobPostActivity.Add(jobPostActivity);
            await context.SaveChangesAsync();

            return jobPostActivity;
        }

        public IEnumerable<DomainModel.Models.JobType> GetJobTypes()
        {
            var results = new List<DomainModel.Models.JobType>();

            var jobTypeEf = context.JobType.ToList();

            foreach (var item in jobTypeEf)
            {
                results.Add(new DomainModel.Models.JobType
                {
                    Id = item.Id,
                    Name = item.Name
                });
            }

            return results;
        }

        public IEnumerable<DomainModel.Models.JobLocation> GetJobLocations()
        {
            var results = new List<DomainModel.Models.JobLocation>();

            var jobLocationEf = context.JobLocation.ToList();

            foreach (var item in jobLocationEf)
            {
                results.Add(new DomainModel.Models.JobLocation
                {
                    Id = item.Id,
                    StreetAddress = item.StreetAddress,
                    City = item.City,
                    State = item.State,
                    Country = item.Country,
                    Zip = item.Zip
                });
            }

            return results;
        }
    }
}