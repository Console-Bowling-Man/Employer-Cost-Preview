using EmployerCostPreview.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployerCostPreview.Data
{
    public class EcpData : DbContext
    {
        public EcpData(DbContextOptions<EcpData> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Dependent> Dependents { get; set; }
    }
}
