using Microsoft.EntityFrameworkCore;
using ModelToBase.Models.Data;

namespace ModelToBase.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }
        public DbSet<Personnes> Personnes { get; set; }
    }
}
