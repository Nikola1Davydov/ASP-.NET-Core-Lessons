using OnlineShopWebApp.Areas.Admin.Models;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public class UsersManager : IUsersManager
    {
        private readonly List<UserAccount> users = new List<UserAccount>();
        public void Add(UserAccount user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null");
            }
            if (users.Any(u => u.Name == user.Name))
            {
                throw new InvalidOperationException("User with this username already exists");
            }
            users.Add(user);
        }
        public UserAccount TryGetByName(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentException("Username cannot be null or empty", nameof(username));
            }
            return users.FirstOrDefault(u => u.Name.Equals(username, StringComparison.OrdinalIgnoreCase));
        }
        public List<UserAccount> GetAll()
        {
            return users;
        }

        public void ChangePasswort(string userName, string newPassword)
        {
            UserAccount account = TryGetByName(userName);
            account.Password = newPassword;
        }

        public void Edit(UserAccount newUserAccount)
        {
            UserAccount account = TryGetByName(newUserAccount.Name);
            if (account == null)
            {
                return;
            } 
            account.Email = newUserAccount.Email;
            account.PhoneNumber = newUserAccount.PhoneNumber;
            account.Address = newUserAccount.Address;
            account.DateOfBirth = newUserAccount.DateOfBirth;
        }

        public void Delete(string userName)
        {
            UserAccount account = TryGetByName(userName);
            users.Remove(account);
        }

        public void EditRole(string userName, Role role)
        {
            return;
        }
    }
}
