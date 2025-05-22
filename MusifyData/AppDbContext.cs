using Microsoft.EntityFrameworkCore;
using MusifyModel;

namespace MusifyData
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Musica> Musicas { get; set; }
    }
}
