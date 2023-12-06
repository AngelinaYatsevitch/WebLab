using Microsoft.AspNetCore.Identity;

namespace WebLab.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public byte[] AvatarImage { get; set; }
    }
}
