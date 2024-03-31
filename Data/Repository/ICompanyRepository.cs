using Domain.Entities;

namespace Data.Repository
{
    public interface ICompanyRepository
    {
        IList<Company> GetAll();
        Company GetById(int id);
        void Add(Company product);
        void Update(Company product);
        void Delete(int id);
    }
}
