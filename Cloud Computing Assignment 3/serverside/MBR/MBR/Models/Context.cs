using Microsoft.EntityFrameworkCore;

namespace MBR.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        public DbSet<InsuranceCallbackURL> insuranceUrls{get;set;}
        public DbSet<EmployeeCallbackURL> employeeUrls { get; set; }

        public DbSet<Employee> employerEmployees { get; set; }
        public DbSet<BrokerCustomer> brokerCustomers { get; set; }
        public DbSet<InsuranceCustomer> insuranceCustomers { get; set; }

    }
}
