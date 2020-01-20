using Microsoft.EntityFrameworkCore;
using System.IO;

namespace TagsPlugin
{
    public class TagDatabase : DbContext
    {
        public DbSet<Tag> Tags { get; set; }

        public TagDatabase()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string baseDir = TagsPlugin.GetPluginDirectory();
            if (!Directory.Exists(baseDir))
                Directory.CreateDirectory(baseDir);

            string datadir = Path.Combine(baseDir, "_tags.sqlite.db");
            optionsBuilder.UseSqlite($"Filename={datadir}");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Tag>()
                .HasKey(x => x.Name);
        }
    }
}
