using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TheHunt.EntityFrameworkGenerator.Models;

namespace TheHunt.Data.Internal
{
    internal class CompanyRepository : ICompanyRepository
    {
        private readonly TheHuntContext context;
        private readonly ILogger<CompanyRepository> logger;

        public CompanyRepository(TheHuntContext context, ILogger<CompanyRepository> logger)
        {
            this.context = context ?? throw new System.ArgumentNullException(nameof(context));
            this.logger = logger ?? throw new System.ArgumentNullException(nameof(logger));
        }

        public async Task<DomainModel.Models.BusinessStream> CreateBusinessStream(DomainModel.Models.BusinessStream businessStream)
        {
            if (businessStream.Id == null)
            {
                var bs = new BusinessStream
                {
                    BusinessStreamName = businessStream.BusinessStreamName
                };

                context.BusinessStream.Add(bs);
                await context.SaveChangesAsync();

                businessStream.Id = bs.Id;
            }

            return businessStream;
        }

        public IEnumerable<DomainModel.Models.BusinessStream> GetBusinessStreams()
        {
            var results = new List<DomainModel.Models.BusinessStream>();

            var businessStreamsEf = context.BusinessStream.ToList();

            foreach (var item in businessStreamsEf)
            {
                results.Add(new DomainModel.Models.BusinessStream
                {
                    Id = item.Id,
                    BusinessStreamName = item.BusinessStreamName
                });
            }

            return results;
        }

        public async Task<DomainModel.Models.Company> CreateCompany(DomainModel.Models.Company company)
        {
            if (company.Id == null)
            {
                var comp = new Company
                {
                    CompanyName = company.CompanyName,
                    BusinessStreamId = company.BusinessStreamId,
                    ProfileDescription = company.ProfileDescription,
                    EstablishmentDate = company.EstablishmentDate,
                    CompanyWebsiteUrl = company.CompanyWebsiteUrl
                };

                context.Company.Add(comp);
                await context.SaveChangesAsync();

                company.Id = comp.Id;
            }

            return company;
        }

        public IEnumerable<DomainModel.Models.Company> GetCompanies()
        {
            var results = new List<DomainModel.Models.Company>();

            var companyEf = context.Company.ToList();

            foreach (var item in companyEf)
            {
                results.Add(new DomainModel.Models.Company
                {
                    Id = item.Id,
                    CompanyName = item.CompanyName,
                    BusinessStreamId = item.BusinessStreamId,
                    CompanyWebsiteUrl = item.CompanyWebsiteUrl,
                    EstablishmentDate = item.EstablishmentDate,
                    ProfileDescription = item.ProfileDescription
                });
            }

            return results;
        }
    }
}