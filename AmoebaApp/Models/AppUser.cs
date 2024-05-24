using Microsoft.AspNetCore.Identity;

namespace AmoebaApp.Models
{
    public class AppUser :IdentityUser
    {
        public string  Name { get; set; }
        public string Surmame { get; set; }
    }
}
