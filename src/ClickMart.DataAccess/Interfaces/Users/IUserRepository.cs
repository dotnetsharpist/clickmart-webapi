using ClickMart.DataAccess.Common.Interfaces;
using ClickMart.DataAccess.ViewModels.Users;
using ClickMart.Domain.Entities.Users;

namespace ClickMart.DataAccess.Interfaces.Users;


public interface IUserRepository : IRepository<User, UserViewModel>,
    IGetAll<UserViewModel>, ISearchable<UserViewModel>
{
    public Task<User?> GetByPhoneAsync(string phone);
}

