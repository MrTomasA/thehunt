using System.Collections.Generic;
using System.Threading.Tasks;

namespace TheHunt.Data
{
    public interface ICompanyRepository
    {
        Task<DomainModel.Models.BusinessStream> CreateBusinessStream(DomainModel.Models.BusinessStream businessStream);

        IEnumerable<DomainModel.Models.BusinessStream> GetBusinessStreams();

        Task<DomainModel.Models.Company> CreateCompany(DomainModel.Models.Company company);

        IEnumerable<DomainModel.Models.Company> GetCompanies();
    }
}