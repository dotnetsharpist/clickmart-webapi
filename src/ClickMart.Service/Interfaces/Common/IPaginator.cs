using ClickMart.DataAccess.Utils;

namespace ClickMart.Service.Interfaces.Common;

public interface IPaginator
{
    public void Paginate(long itemsCount, PaginationParams @params);
}
