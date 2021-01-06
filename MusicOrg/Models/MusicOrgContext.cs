using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MusicOrg.Models
{
    public class MusicOrgContext : DbContext
    {
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Vinyl> Vinyls { get; set; }

        public MusicOrgContext(DbContextOptions options) : base(options) { }
    }
}