using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace likeWorkApp.Models
{
    public class UserLogin
    {
        [Key]
        public int UserLoginID {get; set;}
        [DataType(DataType.EmailAddress, ErrorMessage = "Not a valid email address")]
        [Required]
        public string Username { get; set; }

        [DataType(DataType.Password, ErrorMessage = "Not a valid password")]
        [Required]
        public string Password { get; set; }

        [ForeignKey("Role")]
        public int RoleID { get; set; }
        public Role Role { get; set; }
    }
}