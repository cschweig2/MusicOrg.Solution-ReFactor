using Microsoft.EntityFrameworkCore;

namespace MusicOrg.Models
{
    public class MusicOrgContext : DbContext
    {
        public virtual DbSet<Artist> Artists { get; set; }
        public DbSet<Vinyl> Vinyls { get; set; }
        public DbSet<ArtistVinyl> ArtistVinyl { get; set; }

        public MusicOrgContext(DbContextOptions options) : base(options) { }
    }
}