using Microsoft.EntityFrameworkCore;
using BuberBreakfast.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace BuberBreakfast.Context
{
    public class YourDbContext : DbContext
    {
        public DbSet<Breakfast> Breakfasts { get; set; }

        public YourDbContext(DbContextOptions<YourDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Check if the table already exists in the database
            if (!modelBuilder.Model.GetEntityTypes().Any(t => t.ClrType == typeof(Breakfast)))
            {
                modelBuilder.Entity<Breakfast>(entity =>
                {
                    entity.HasKey(b => b.Id);
                    entity.Property(b => b.Name)
                        .IsRequired()
                        .HasMaxLength(Breakfast.MaxNameLength);

                    entity.Property(b => b.Description)
                        .IsRequired()
                        .HasMaxLength(Breakfast.MaxDescriptionLength);

                    entity.Property(b => b.StartDateTime)
                        .IsRequired();

                    entity.Property(b => b.EndDateTime)
                        .IsRequired();

                    entity.Property(b => b.LastModifiedDateTime)
                        .IsRequired();

                    // No need for ValueComparison here

                    // Alternatively, you can handle the conversion manually in your application logic
                    // entity.Property(b => b.Savory)
                    //     .HasConversion(
                    //         v => string.Join(',', v),
                    //         v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
                    //     );

                    // entity.Property(b => b.Sweet)
                    //     .HasConversion(
                    //         v => string.Join(',', v),
                    //         v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
                    //     );
                });
            }

            // Seed data if needed
            var projectRoot = Directory.GetCurrentDirectory();
            var jsonFilePath = Path.Combine(projectRoot, "jsonfiles", "Breakfasts.json");
            var data = File.ReadAllText(jsonFilePath);
            var breakfasts = JsonSerializer.Deserialize<List<Breakfast>>(data);

            modelBuilder.Entity<Breakfast>().HasData(breakfasts);
        }
    }
}
