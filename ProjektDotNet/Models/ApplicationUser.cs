using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjektDotNet.Models
{
    
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Numer licencji")]
        [Required]
        [StringLength(255)]
        public string DrivingLicense { get; set; }

        [Display(Name = "Numer telefonu")]
        [Required]
        [StringLength(50)]
        public string Phone { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
           
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            
            return userIdentity;
        }
    }
}