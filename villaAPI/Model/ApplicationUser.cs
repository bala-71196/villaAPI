using Microsoft.AspNetCore.Identity;

namespace villaAPI.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }

    }
}
