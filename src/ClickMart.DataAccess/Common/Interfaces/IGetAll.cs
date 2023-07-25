using ClickMart.DataAccess.Utils;

namespace ClickMart.DataAccess.Common.Interfaces;

public interface IGetAll<TModel>
{
    public Task<IList<TModel>> GetAllAsync(PaginationParams @params); 
}
