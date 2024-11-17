using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public interface IRolesRepository
    {
        Role TryGetByUserId(string userId);
        Role TryGetByName(string roleName);
        void Add(Role role);
        void Remove(string roleName);
        void CleanRolesRepository();
        List<Role> GetAllRoles();
    }
}