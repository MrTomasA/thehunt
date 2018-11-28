using System.Threading.Tasks;
using TheHunt.EntityFrameworkGenerator.Models;

namespace TheHunt.Data
{
    public interface IJobPostRepository
    {
        Task<JobType> SaveJobType(JobType jobType);

        Task<JobLocation> SaveJobLocation(JobLocation jobLocation);

        Task<JobPostActivity> SaveJobPostActivity(JobPostActivity jobPostActivity);
    }
}