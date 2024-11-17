using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace OnlineShopWebApp.Helper
{
    public class EnumHelper
    {
        public static string GetDisplayName(Enum enumValue)
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttributes<DisplayAttribute>()
                            .FirstOrDefault().Name;
        }
    }
}
