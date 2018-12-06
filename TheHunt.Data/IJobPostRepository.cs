using System.Collections.Generic;
using System.Threading.Tasks;
using TheHunt.EntityFrameworkGenerator.Models;

namespace TheHunt.Data
{
    public interface IJobPostRepository
    {
        Task<DomainModel.Models.JobPost> CreateJobPost(DomainModel.Models.JobPost jobPost);

        Task<DomainModel.Models.JobType> CreateJobType(DomainModel.Models.JobType jobType);

        Task<DomainModel.Models.JobLocation> CreateJobLocation(DomainModel.Models.JobLocation jobLocation);

        Task<JobPostActivity> CreateJobPostActivity(JobPostActivity jobPostActivity);

        IEnumerable<DomainModel.Models.JobType> GetJobTypes();

        IEnumerable<DomainModel.Models.JobLocation> GetJobLocations();
    }
}