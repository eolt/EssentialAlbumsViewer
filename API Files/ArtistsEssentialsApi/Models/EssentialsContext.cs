using System;
using Microsoft.EntityFrameworkCore;

namespace ArtistsEssentialsApi.Models
{
    public class EssentialsContext : DbContext
    {
        public EssentialsContext(DbContextOptions<EssentialsContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder model)
        {
            //  An artist or band can have many albums, but an album usually belongs to one artist/band
            model.Entity<EssentialArtist>()
                .HasMany(b => b.EssentialAlbums)
                .WithOne();
        }

        public DbSet<EssentialAlbum> EssentialAlbums { get; set; }
        public DbSet<EssentialArtist> EssentialArtists { get; set; }
    }
}
