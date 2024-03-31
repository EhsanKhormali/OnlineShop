using Microsoft.AspNetCore.Identity;
using Domain.Common;

namespace Data
{
    public class OnlineShopUser:IdentityUser,IUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
