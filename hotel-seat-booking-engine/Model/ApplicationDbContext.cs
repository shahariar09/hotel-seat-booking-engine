using Microsoft.EntityFrameworkCore;
using System;

using Microsoft.EntityFrameworkCore;
using hotel_seat_booking_engine.Model;

namespace QueryModelMapper.Model
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Layout> Layout { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

        

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Layout>()
                .HasKey(l => l.Id);
            modelBuilder.Entity<OrderDetails>()
                .HasKey(l => l.Id);


            // Other entity configurations

            base.OnModelCreating(modelBuilder);

  
       
        }


    }
}

