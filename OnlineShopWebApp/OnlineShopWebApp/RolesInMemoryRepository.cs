using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public class RolesInMemoryRepository : IRolesRepository
    {
        private List<Role> _rolles;
        public RolesInMemoryRepository()
        {
            _rolles = new List<Role>()
            {
                new Role(){Name = "Admin"}
            };
        }
        public List<Role> GetAllRoles()
        {
            return _rolles;
        }
        public Role TryGetByUserId(string userId)
        {
            return _rolles.FirstOrDefault(x => x.UserId == userId);
        }
        public Role TryGetByName(string roleName)
        {
            return _rolles.FirstOrDefault(x => x.Name == roleName);
        }
        public void Add(Role role)
        {
            _rolles.Add(role);
        }
        public void Remove(string rolleName)
        {
            Role rolle = TryGetByName(rolleName);
            _rolles.Remove(rolle);
        }
        public void CleanRolesRepository()
        {
            _rolles.Clear();
        }
    }
}
