using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using WebApi.Database.Models;

namespace WebApi.Database
{
    public class DatabaseConection : DbContext
    {
        public DatabaseConection([NotNull] DbContextOptions options) : base(options)
        {
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Phone> Phones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(builder => {
                builder.ToTable("persons");
                builder.HasKey(p => p.ID);
                builder.Property(p => p.Name).HasColumnName("name").HasColumnType("VARCHAR(60)");
                builder.Property(p => p.LastName).HasColumnName("last_name").HasColumnType("VARCHAR(60)");
                builder.Property(p => p.BirtDate).HasColumnName("birt_date").HasColumnType("DATETIME");
            });

            modelBuilder.Entity<Phone>(builder => {
                builder.ToTable("phones");
                builder.HasKey(p => p.ID);
                builder.Property(p => p.Number).HasColumnName("number").HasColumnType("VARCHAR(15)");
                builder.Property(p => p.PhoneType).HasColumnName("phone_type");
                builder.HasOne(p => p.Person).WithMany(p => p.Phones).HasForeignKey(p => p.PersonID).OnDelete(DeleteBehavior.Cascade);
            });
        }


    }
}
