using MarchCrudPractice.Models;
using Microsoft.EntityFrameworkCore;

namespace MarchCrudPractice.Data
{
    public class BatchmateDbContext : DbContext
    {
        public BatchmateDbContext(DbContextOptions<BatchmateDbContext> options) : base(options) { }
        public DbSet<Batchmates> Batchmate { get; set;}
    }
}
