using System.Collections.Generic;
using System.Data.Entity;

namespace likeWorkApp.Models.Context
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<LeaveDbContext>
    {
        protected override void Seed(LeaveDbContext context)
        {
            base.Seed(context);
            var roles = new List<Role>
            {
                new Role {RoleName = "RegularUser"},
                new Role {RoleName = "Admin"}
            };
            context.Roles.AddRange(roles);
            var users = new List<UserLogin>
            {
                new UserLogin {
                    Role = roles[0],
                    RoleID = 1,
                    Username = "ndodangcani6@gmail.com",
                    Password = "R.user01"
                },
                new UserLogin {
                    Role = roles[1],
                    RoleID = 2,
                    Username = "ngcanindoda9.nd@gmail.com",
                    Password = "A.user01"
                }
            };
            context.UserLogins.AddRange(users);
            var departments = new List<Department>
            {
                new Department{DepartmentName = "Information Technology"},
                new Department{DepartmentName = "Human Resources"},
                new Department{DepartmentName = "Finance"}
            };
            context.Departments.AddRange(departments);
            var statuses = new List<Status>
            {
                new Status{ StatusName = "Pending"},
                new Status{ StatusName = "Declined"},
                new Status{ StatusName = "Approved"}
            };
            context.Statuses.AddRange(statuses);
            var leaveTypes = new List<LeaveType>
            {
                new LeaveType{LeaveTypeName = "Annual Leave"},
                new LeaveType{LeaveTypeName = "Study Leave"},
                new LeaveType{LeaveTypeName = "Maternity Leave"},
                new LeaveType{LeaveTypeName = "Unpaid Leave"}
            };
            context.LeaveTypes.AddRange(leaveTypes);
            var employee = new Employee
            {
                Age = 23,
                Department = departments[0],
                EmployeeIdNumber = "9602136293085",
                DepartmentID = 1,
                Gender = 'M',
                Name = "Ndoda",
                Surname = "Ngcani",
                UserLogin = users[1],
                UserLoginID = 2
            };
            context.Employees.Add(employee);
            context.SaveChanges();
        }
    }
}