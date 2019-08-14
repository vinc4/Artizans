using System.ComponentModel.DataAnnotations;

namespace likeWorkApp.Models
{
    public class Role
    {
        [Key]
        public int RoleID {get; set;}
        public string RoleName { get; set; }
    }
}