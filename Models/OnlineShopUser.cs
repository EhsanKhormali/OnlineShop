using Microsoft.AspNetCore.Identity;

namespace OnlineShop.Models
{
    public class OnlineShopUser:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
