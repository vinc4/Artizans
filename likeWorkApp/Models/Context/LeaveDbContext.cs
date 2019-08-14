using System.Data.Entity;

namespace likeWorkApp.Models
{
    public class LeaveDbContext : DbContext
    {
        public LeaveDbContext() :
              base("Artisans")
        {

        }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserLogin> UserLogins { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<Leave> Leaves { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}