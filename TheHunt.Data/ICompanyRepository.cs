using System.Threading.Tasks;
using TheHunt.EntityFrameworkGenerator.Models;

namespace TheHunt.Data
{
    public interface ICompanyRepository
    {
        Task<DomainModel.Models.BusinessStream> CreateBusinessStream(DomainModel.Models.BusinessStream businessStream);

        Task<Company> CreateCompany(Company company);
    }
}