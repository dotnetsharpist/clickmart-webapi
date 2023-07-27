using ClickMart.DataAccess.Utils;
using ClickMart.Domain.Entities.Companies;
using ClickMart.Service.Dtos.Companies;

namespace ClickMart.Service.Interfaces.Companies;

public interface ICompanyService
{
    public Task<bool> CreateAsync(CompanyCreateDto dto);

    public Task<IList<Company>> GetAllAsync(PaginationParams @params);

    public Task<Company> GetByIdAsync(long companyId);

    public Task<bool> UpdateAsync(long companyId, CompanyUpdateDto dto);

    public Task<bool> DeleteAsync(long companyId);
}

