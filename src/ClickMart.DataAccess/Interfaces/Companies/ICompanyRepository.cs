using ClickMart.DataAccess.Common.Interfaces;
using ClickMart.DataAccess.Interfaces;
using ClickMart.Domain.Entities.Companies;

public interface ICompanyRepository : IRepository<Company, Company>,
    IGetAll<Company>
{

}
