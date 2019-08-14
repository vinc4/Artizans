using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace likeWorkApp.Models
{
    public class Leave
    {
        [Key]
        public int LeaveID { get; set; }
        [DataType(DataType.Date, ErrorMessage = "Please select appropriate date")]
        public DateTime AppliedOn { get; set; }
        [DataType(DataType.Date, ErrorMessage = "Please select appropriate date")]
        [Required]
        public DateTime DateFrom { get; set; }
        [Required]
        [DataType(DataType.Date, ErrorMessage = "Please select appropriate date")]
        public DateTime DateTo { get; set; }
        [Required]
        [MinLength(20, ErrorMessage = "'Reason For Leave' cannot be less than 20 characters")]
        public string ReasonForLeave { get; set; }
        [ForeignKey("LeaveType")]
        public int LeaveTypeID { get; set; }
        public LeaveType LeaveType { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }
        public Employee Employee { get; set; }
        public int DepartmentID { get; set; }
        [ForeignKey("Status")]
        public int StatusID { get; set; }
        public Status Status { get; set; }
        public int AssessedBy { get; set; }     
        public DateTime AssessedOn { get; set; }
    }
}