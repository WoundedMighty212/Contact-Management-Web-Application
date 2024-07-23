//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Contact_Management_Web_Application.Models;

    public class ContactContext : DbContext
    {
        public ContactContext (DbContextOptions<ContactContext> options)
            : base(options)
        {
        }
    public DbSet<Contact_Management_Web_Application.Models.Contact> Contact { get; set; } = default!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Contact>().ToTable("Contact");
            // Seed data
            modelBuilder.Entity<Contact>().HasData(
                new Contact { ContactId = 1, Name = "Sample Contact 1", Email = "SampleContact1@gmail.com", PhoneNumber = "074 324 4354", },
                new Contact { ContactId = 2, Name = "Sample Contact 2", Email = "SampleContact2@gmail.com", PhoneNumber = "075 675 2345", },
                new Contact { ContactId = 3, Name = "Sample Contact 3", Email = "SampleContact3@gmail.com", PhoneNumber = "084 323 6756", }
            );
        }
    }
