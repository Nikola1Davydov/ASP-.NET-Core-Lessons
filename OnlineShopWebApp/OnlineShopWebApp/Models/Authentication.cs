namespace OnlineShopWebApp.Models
{
    public class Authentication
    {
        public string Login { get; set; }
        public string Passwort { get; set; }
        public string PasswortRepeat { get; set; }
        public bool RememberMe { get; set; }
        public string UserId { get; set; }
    }
}
