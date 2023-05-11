using Microsoft.AspNetCore.Identity;

namespace IdentityManager.Models
{
    public class AppUser : IdentityUser
    {
        public string WhoAdded { get; set; }        
    }
}
