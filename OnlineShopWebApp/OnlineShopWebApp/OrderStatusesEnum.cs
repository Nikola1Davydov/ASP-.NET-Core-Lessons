using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp
{
    public enum OrderStatusesEnum
    {
        [Display(Name = "Erstellt")]
        Created,
        [Display(Name = "Bearbeitet")]
        Processed,
        [Display(Name = "wurde bestellt")]
        Delivering,
        [Display(Name = "geliefert")]
        Delivered,
        [Display(Name = "Abgesagt")]
        Canceled
    }
}
