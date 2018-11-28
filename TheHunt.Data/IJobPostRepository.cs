using System.Threading.Tasks;
using TheHunt.Host;

namespace TheHunt.Data
{
    public interface IJobPostRepository
    {
        Task<JobType> SaveJobType(JobType jobType);

        Task<JobLocation> SaveJobLocation(JobLocation jobLocation);

        Task<JobPostActivity> SaveJobPostActivity(JobPostActivity jobPostActivity);
    }
}