using System.Threading.Tasks;
using TheHunt.Host;

namespace TheHunt.Data
{
    public interface ICompanyRepository
    {
        Task<BusinessStream> CreateBusinessStream(BusinessStream businessStream);

        Task<Company> CreateCompany(Company company);
    }
}