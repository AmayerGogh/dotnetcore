using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore
{
    public class DataDbContxt:DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Person>()
                .ToTable("Persons");

            modelBuilder.Entity<Book>()
                 .ToTable("Books")
                 .HasOne(e=>e.Author).WithMany().HasForeignKey(e=>e.AuthorId).IsRequired();
            modelBuilder.Entity<Author>()
                .ToTable("Authors");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySql("Server=192.168.0.108;database=EFcore;uid=root;pwd=0620");
        }
    }
}
