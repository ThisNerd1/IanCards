using Microsoft.AspNetCore.Identity;

namespace VideoGameLibrary7._0.Areas.Identity.Data
{
    public class GameUser : IdentityUser
    {
        public bool IsAdmin { get; set; }

        public GameUser() { }

        public GameUser(bool isAdmin)
        {
            IsAdmin = isAdmin;
        }
    }
}
