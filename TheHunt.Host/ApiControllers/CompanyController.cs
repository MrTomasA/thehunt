using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using TheHunt.Data;

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

        [HttpGet]
        [SwaggerOperation("SaveBusinessStream")]
        [ProducesResponseType(typeof(BusinessStream), 201)]
        public async Task<ActionResult<BusinessStream>> SaveBusinessStream(BusinessStream businessStream) => await companyRepository.CreateBusinessStream(businessStream);
    }
}