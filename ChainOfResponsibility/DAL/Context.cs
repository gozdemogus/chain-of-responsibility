using Microsoft.EntityFrameworkCore;
using UpSchool_ChainOfResponsibility.DAL.Entities;

namespace UpSchool_ChainOfResponsibility.DAL
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:127.0.0.1,1433;Database=ChainOfResponsibility;MultipleActiveResultSets=true;User=SA;Password=MyPass@word;");
        }
        public DbSet<BankProcess> BankProcesses { get; set; }
    }
}
