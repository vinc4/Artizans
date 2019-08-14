using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace likeWorkApp.Models
{
    public class Users
    {
        [Key]
        public int UserID {get; set;}
        [DataType(DataType.EmailAddress, ErrorMessage = "Not a valid email address")]
        [Required]
        public string Email { get; set; }

        [DataType(DataType.Password, ErrorMessage = "Not a valid password")]
        [Required]
        public string Password { get; set; }
        public string MobileNo { get; set; }
        public string IsCvUploaded { get; set; }


    }
}