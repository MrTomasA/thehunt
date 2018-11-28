using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TheHunt.Host;

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

        public async Task<BusinessStream> CreateBusinessStream(BusinessStream businessStream)
        {
            if (businessStream.Id <= 0)
            {
                var bs = new BusinessStream();
                bs.BusinessStreamName = businessStream.BusinessStreamName;

                context.BusinessStream.Add(bs);
                await context.SaveChangesAsync();
            }

            return businessStream;
        }

        public async Task<Company> CreateCompany(Company company)
        {
            context.Company.Add(company);
            await context.SaveChangesAsync();

            return company;
        }
    }
}