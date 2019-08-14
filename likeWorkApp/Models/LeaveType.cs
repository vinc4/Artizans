using System.ComponentModel.DataAnnotations;

namespace likeWorkApp.Models
{
    public class LeaveType
    {
        [Key]
        public int LeaveTypeID { get; set; }
        public string LeaveTypeName { get; set; }
        public int AddedByID { get; set; }  
    }
}