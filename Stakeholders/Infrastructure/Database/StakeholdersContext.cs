using Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database
{
    public class StakeholdersContext:DbContext
    {
        public DbSet<UserProfile> UserProfiles { get; set; }
        public StakeholdersContext(DbContextOptions<StakeholdersContext> options):base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("stakeholders");

            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.FirstName)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(e => e.LastName)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(e => e.ProfilePictureUrl)
                      .HasMaxLength(300);

                entity.Property(e => e.Biography)
                      .HasMaxLength(1000);

                entity.Property(e => e.Moto)
                      .HasMaxLength(200);
            });
        }
    }
}
