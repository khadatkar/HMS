using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        public DbSet<Hospital> hospitals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Hospital>().HasData(
                new Hospital { 
                    HospitalId=1,
                    Name="Spandan",
                    Mobile=9881943266,
                    Email="abc@gmail.com",
                    City="Nagpur",
                    Description="Heart Specialist",
                    Photo="2.jpg"
                },
                new Hospital {
                    HospitalId = 2,
                    Name = "Wockheart",
                    Mobile = 9021910763,
                    Email = "Wockheart@gmail.com",
                    City = "Delhi",
                    Description = "Brain Specialist",
                    Photo = "2.jpg"
                }
                );
        }
    }
}
