using Microsoft.EntityFrameworkCore;

namespace Poiner_Task.Models
{
    public class PoinerTaskContext : DbContext
    {
        public PoinerTaskContext() : base()
        { }
        public PoinerTaskContext(DbContextOptions<PoinerTaskContext> options) : base(options) { }
        public  DbSet<Employee> Employees { get; set; }
        public DbSet<PropertyForEmployee> propirtyForEmployees { get; set; }
        public DbSet<PropertyValues> propirtyValues { get; set; }
        

    }
}
