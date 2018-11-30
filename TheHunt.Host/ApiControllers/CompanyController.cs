using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using TheHunt.Data;
using TheHunt.DomainModel.Models;

namespace TheHunt.Host.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository companyRepository;

        public CompanyController(ICompanyRepository companyRepository)
        {
            this.companyRepository = companyRepository ?? throw new ArgumentNullException(nameof(companyRepository));
        }

        [HttpPost]
        [Route("business-stream")]
        [SwaggerOperation(nameof(CreateBusinessStream))]
        [ProducesResponseType(typeof(BusinessStream), 201)]
        public async Task<ActionResult<BusinessStream>> CreateBusinessStream([FromBody]BusinessStream businessStream) => await companyRepository.CreateBusinessStream(businessStream);

        [HttpGet]
        [Route("business-stream")]
        [SwaggerOperation(nameof(GetAllBusinessStreams))]
        [ProducesResponseType(typeof(IEnumerable<BusinessStream>), 200)]
        public IEnumerable<BusinessStream> GetAllBusinessStreams() => companyRepository.GetBusinessStreams();

        [HttpPost]
        [SwaggerOperation(nameof(CreateCompany))]
        [ProducesResponseType(typeof(Company), 201)]
        public async Task<ActionResult<Company>> CreateCompany([FromBody]Company company) => await companyRepository.CreateCompany(company);
    }
}