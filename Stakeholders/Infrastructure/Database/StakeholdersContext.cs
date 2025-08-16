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

                entity.Property(e => e.ProfilePicureUrl)
                      .HasMaxLength(300);

                entity.Property(e => e.Biography)
                      .HasMaxLength(1000);

                entity.Property(e => e.Moto)
                      .HasMaxLength(200);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasIndex(e => e.UserId).IsUnique();

                entity.HasData(
                    new UserProfile(1, "John", "Doe","JohnDoe", "https://example.com/profiles/johndoe.jpg",
                        "Experienced tour guide with over 10 years of guiding tours in Europe.",
                        "Discover the world with passion.", 12345), //tour guide

                    new UserProfile(2, "Jane", "Smith","JaneSmith", "https://example.com/profiles/janesmith.jpg",
                        "Tourist looking for the best culinary experiences across the globe.",
                        "Eat, Travel, Enjoy.", 12346), //tourist

                    new UserProfile(3, "Alice", "Johnson","AliceJohnson" ,"https://example.com/profiles/alicejohnson.jpg",
                        "A passionate history buff who loves to show people hidden gems in ancient cities.",
                        "History lives through the stories we tell.", 12347), //tour guide

                    new UserProfile(4, "Bob", "Williams","BobWilli" ,"https://example.com/profiles/bobwilliams.jpg",
                        "Tourist looking to explore unique and off-the-beaten-path destinations.",
                        "Explore the unexplored.", 12348) //tourist
                );
            });
        }
    }
}
