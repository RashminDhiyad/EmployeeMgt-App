using EmployeeManagementAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EmployeeManagementAPI.Data
{
    public class EmployeeManagementDBContext : DbContext
    {
        public EmployeeManagementDBContext(DbContextOptions options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<DesignationMst> designations { get; set; }
    }
}
