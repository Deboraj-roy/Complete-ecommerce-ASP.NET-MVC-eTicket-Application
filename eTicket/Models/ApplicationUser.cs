using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace eTicket.Models
{
    public class ApplicationUser : IdentityUser 
    {
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
    }
}
