using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using TheHunt.Data;
using TheHunt.DomainModel.Models;

namespace TheHunt.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobPostController : ControllerBase
    {
        private readonly IJobPostRepository jobPostRepository;

        public JobPostController(IJobPostRepository jobPostRepository)
        {
            this.jobPostRepository = jobPostRepository ?? throw new System.ArgumentNullException(nameof(jobPostRepository));
        }

        [HttpPost]
        [SwaggerOperation(nameof(CreateJobPost))]
        [ProducesResponseType(typeof(JobPost), 201)]
        public async Task<JobPost> CreateJobPost([FromBody]JobPost jobPost) => await jobPostRepository.CreateJobPost(jobPost);

        [HttpPost]
        [Route("job-type")]
        [SwaggerOperation(nameof(CreateJobType))]
        [ProducesResponseType(typeof(JobType), 201)]
        public async Task<JobType> CreateJobType([FromBody]JobType jobType) => await jobPostRepository.CreateJobType(jobType);

        [HttpGet]
        [Route("job-type")]
        [SwaggerOperation(nameof(GetJobTypes))]
        [ProducesResponseType(typeof(IEnumerable<JobType>), 200)]
        public IEnumerable<JobType> GetJobTypes() => jobPostRepository.GetJobTypes();

        [HttpPost]
        [Route("job-location")]
        [SwaggerOperation(nameof(CreateJobLocation))]
        [ProducesResponseType(typeof(JobLocation), 201)]
        public async Task<JobLocation> CreateJobLocation([FromBody]JobLocation jobLocation) => await jobPostRepository.CreateJobLocation(jobLocation);

        [HttpGet]
        [Route("job-location")]
        [SwaggerOperation(nameof(GetJobLocations))]
        [ProducesResponseType(typeof(IEnumerable<JobLocation>), 200)]
        public IEnumerable<JobLocation> GetJobLocations() => jobPostRepository.GetJobLocations();
    }
}