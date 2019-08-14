using System.ComponentModel.DataAnnotations;

namespace likeWorkApp.Models
{
    public class Status
    {
        [Key]
        public int StatusID { get; set; }
        public string StatusName { get; set; }
    }
}