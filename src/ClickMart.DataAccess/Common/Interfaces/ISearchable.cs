using ClickMart.DataAccess.Utils;

namespace ClickMart.DataAccess.Common.Interfaces;

public interface ISearchable<Tmodel>
{
    public Task<IList<Tmodel>> SearchAsync(
        string search,
        PaginationParams @params);
}
