using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace likeWorkApp.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public char Gender { get; set; }
        [ForeignKey("UserLogin")]
        public int UserLoginID { get; set; }
        public UserLogin UserLogin { get; set; }
        [ForeignKey("Department")]
        public int DepartmentID { get; set; }
        public Department Department { get; set; }
        public string Surname { get; internal set; }
        public string EmployeeIdNumber { get; internal set; }
    }
}