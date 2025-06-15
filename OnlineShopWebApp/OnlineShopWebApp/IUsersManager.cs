using OnlineShopWebApp.Areas.Admin.Models;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public interface IUsersManager
    {
        void Add(UserAccount user);
        void ChangePasswort(string userName, string password);
        List<UserAccount> GetAll();
        UserAccount TryGetByName(string username);
        void Edit(UserAccount userAccount);
        void Delete(string userName);
        void EditRole(string userName, Role role);
    }
}