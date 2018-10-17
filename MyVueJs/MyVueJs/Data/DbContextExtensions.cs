using Microsoft.AspNetCore.Identity;
using MyVueJs.Data.Entities;

namespace MyVueJs.Data
{
    public static class DbContextExtensions
    {
        public static UserManager<AppUser> UserManager { get; set; }
        public static void EnsureSeeded(this ECommerceContext context)
        {
            if (UserManager.FindByEmailAsync("stu@ratcliffe.io").GetAwaiter().GetResult() == null)
            {
                var user = new AppUser
                {
                    FirstName = "Stu",
                    LastName = "Ratcliffe",
                    UserName = "stu@ratcliffe.io",
                    Email = "stu@ratcliffe.io",
                    EmailConfirmed = true,
                    LockoutEnabled = false
                };

                UserManager.CreateAsync(user, "Password1").GetAwaiter().GetResult();
            }
        }
    }
}