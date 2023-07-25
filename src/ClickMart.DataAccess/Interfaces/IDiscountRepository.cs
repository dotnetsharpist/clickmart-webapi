using ClickMart.DataAccess.Common.Interfaces;
using ClickMart.DataAccess.Utils;
using ClickMart.Domain.Entities.Discounts;

namespace ClickMart.DataAccess.Interfaces;

public interface IDiscountRepository : IRepository<Discount, Discount>,
    IGetAll<Discount>
{
    public Task<IList<Discount>> GetAllByDurationAsync(DateTime startAt, DateTime endAt, PaginationParams @params);
}
