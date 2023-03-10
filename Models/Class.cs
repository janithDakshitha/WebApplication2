
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication2.Areas.Identity.Data;

namespace WebApplication2.Models
{
    public class Class
    {
        [Key,ForeignKey("WebApplication2User")]
        public string UserId { get; set; }
        public string? Uniname { get; set; } 
        public string? UniFullname{ get; set; }
        public string? ProfilPic_URL { get; set; }
        [NotMapped]
        public IFormFile UploadedProfilePic { get; set; }
        //public string UserId { get; set; }
        public virtual WebApplication2User WebApplication2User { get; set; }
    }
}
