using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EmployeeDetail.Model
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        
        public DbSet<EmployeeDetails> EmployeesDetails { get; set; }
    }

}
