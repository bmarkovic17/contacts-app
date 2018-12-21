using System;
using Contacts.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Contacts.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Address> Address { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactData> ContactData { get; set; }
        public DbSet<ContactTag> ContactTag { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .HasIndex(a => a.AddressId)
                .HasName("AddressIdIDX")
                .IsUnique();

            modelBuilder.Entity<Address>()
                .HasData(
                    new Address { AddressId = 1, Street = "Linda Ave.",         AddressNumber = "8106", Postcode = "12302", City = "Schenectady",     Country = "New York, US" },
                    new Address { AddressId = 2, Street = "N. Roehampton Ave.", AddressNumber = "7201", Postcode = "18042", City = "Easton",          Country = "Pennsylvania, US" },
                    new Address { AddressId = 3, Street = "Erlenweg",           AddressNumber = "57",   Postcode = "3027",  City = "Bern",            Country = "Switzerland" },
                    new Address { AddressId = 4, Street = "Pooh Bear Lane",     AddressNumber = "110",  Postcode = "29607", City = "Greenville",      Country = "South Carolina, US" },
                    new Address { AddressId = 5, Street = "Golden Ridge Road",  AddressNumber = "3357", Postcode = "12303", City = "Schenectady",     Country = "New York, US" },
                    new Address { AddressId = 6, Street = "Tuna Street",        AddressNumber = "2948", Postcode = "48075", City = "Southfield",      Country = "Michigan, US" },
                    new Address { AddressId = 7, Street = "Pointe Lane",        AddressNumber = "4597", Postcode = "33308", City = "Fort Lauderdale", Country = "Florida, US" },
                    new Address { AddressId = 8, Street = "Eva Pearl Street",   AddressNumber = "2382", Postcode = "70814", City = "Baton Rouge",     Country = "Louisiana, US" }
                );

            modelBuilder.Entity<Contact>()
                .HasOne(c => c.Address)
                .WithMany(a => a.Contacts)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Contact>()
                .HasIndex(c => c.ContactId)
                .HasName("ContactIdIDX")
                .IsUnique();

            modelBuilder.Entity<Contact>()
                .HasIndex(c => c.AddressId)
                .HasName("AddressIdIDX");

            modelBuilder.Entity<Contact>()
                .HasIndex(c => c.Name)
                .HasName("ContactNameIDX");

            modelBuilder.Entity<Contact>()
                .HasIndex(c => c.Surname)
                .HasName("ContactSurnameIDX");

            modelBuilder.Entity<Contact>()
                .HasData(
                    new Contact { ContactId = 1, Name = "Keanu",  Surname = "Reeves",   DateOfBirth = new DateTime(1964, 9, 2),   AddressId = 1 },
                    new Contact { ContactId = 2, Name = "Elon",   Surname = "Musk",     DateOfBirth = new DateTime(1971, 6, 28),  AddressId = 2 },
                    new Contact { ContactId = 3, Name = "Roger",  Surname = "Federer",  DateOfBirth = new DateTime(1981, 8, 8),   AddressId = 3 },
                    new Contact { ContactId = 4, Name = "Mark",   Surname = "Wahlberg", DateOfBirth = new DateTime(1971, 6, 5),   AddressId = 4 },
                    new Contact { ContactId = 5, Name = null,     Surname = "Superman", DateOfBirth = null,                       AddressId = 5 },
                    new Contact { ContactId = 6, Name = "Venus",  Surname = "Williams", DateOfBirth = new DateTime(1980, 6, 17),  AddressId = 6 },
                    new Contact { ContactId = 7, Name = "Serena", Surname = "Williams", DateOfBirth = new DateTime(1981, 9, 26),  AddressId = 7 },
                    new Contact { ContactId = 8, Name = "Bill",   Surname = "Gates",    DateOfBirth = new DateTime(1955, 10, 28), AddressId = 7 }
                );

            modelBuilder.Entity<ContactData>()
                .HasAlternateKey(cd => new { cd.ContactId, cd.ContactDataType, cd.ContactDataValue });

            modelBuilder.Entity<ContactData>()
                .HasIndex(cd => cd.ContactDataId)
                .HasName("ContactDataIdIDX")
                .IsUnique();

            modelBuilder.Entity<ContactData>()
                .HasIndex(cd => cd.ContactId)
                .HasName("ContactIdIDX");

            modelBuilder.Entity<ContactData>()
                .HasData(
                    new ContactData { ContactDataId = 1,  ContactId = 1, ContactDataType = "PHONE", ContactDataStatus = "Y", ContactDataValue = "090/0000-000" },
                    new ContactData { ContactDataId = 2,  ContactId = 1, ContactDataType = "PHONE", ContactDataStatus = "Y", ContactDataValue = "090/0000-001" },
                    new ContactData { ContactDataId = 3,  ContactId = 1, ContactDataType = "MAIL",  ContactDataStatus = "Y", ContactDataValue = "keanu.reeves@mail.com" },
                    new ContactData { ContactDataId = 4,  ContactId = 2, ContactDataType = "PHONE", ContactDataStatus = "Y", ContactDataValue = "090/0000-100" },
                    new ContactData { ContactDataId = 5,  ContactId = 2, ContactDataType = "MAIL",  ContactDataStatus = "Y", ContactDataValue = "elon.musk@mail.com" },
                    new ContactData { ContactDataId = 6,  ContactId = 2, ContactDataType = "MAIL",  ContactDataStatus = "Y", ContactDataValue = "elon.musk@anothermail.com" },
                    new ContactData { ContactDataId = 7,  ContactId = 3, ContactDataType = "PHONE", ContactDataStatus = "Y", ContactDataValue = "090/0000-200" },
                    new ContactData { ContactDataId = 8,  ContactId = 4, ContactDataType = "MAIL",  ContactDataStatus = "Y", ContactDataValue = "mark.wahlberg@mail.com" },
                    new ContactData { ContactDataId = 9,  ContactId = 5, ContactDataType = "MAIL",  ContactDataStatus = "Y", ContactDataValue = "superman@mail.com" },
                    new ContactData { ContactDataId = 10, ContactId = 5, ContactDataType = "PHONE", ContactDataStatus = "Y", ContactDataValue = "090/0000-002" },
                    new ContactData { ContactDataId = 11, ContactId = 6, ContactDataType = "PHONE", ContactDataStatus = "Y", ContactDataValue = "090/0000-333" },
                    new ContactData { ContactDataId = 12, ContactId = 6, ContactDataType = "MAIL",  ContactDataStatus = "Y", ContactDataValue = "venus.williams@anothermail.com" },
                    new ContactData { ContactDataId = 13, ContactId = 7, ContactDataType = "MAIL",  ContactDataStatus = "Y", ContactDataValue = "serena.williams@anothermail.com" },
                    new ContactData { ContactDataId = 14, ContactId = 8, ContactDataType = "PHONE", ContactDataStatus = "Y", ContactDataValue = "090/1000-100" },
                    new ContactData { ContactDataId = 15, ContactId = 8, ContactDataType = "MAIL",  ContactDataStatus = "Y", ContactDataValue = "bill.gates@mail.com" }
                );

            modelBuilder.Entity<ContactTag>()
                .HasAlternateKey(ct => new { ct.ContactId, ct.ContactTagName });

            modelBuilder.Entity<ContactTag>()
                .HasIndex(ct => ct.ContactTagId)
                .HasName("ContactTagIdIDX")
                .IsUnique();

            modelBuilder.Entity<ContactTag>()
                .HasIndex(ct => ct.ContactId)
                .HasName("ContactIdIDX");

            modelBuilder.Entity<ContactTag>()
                .HasIndex(ct => ct.ContactTagName)
                .HasName("ContactTagNameIDX");

            modelBuilder.Entity<ContactTag>()
                .HasData(
                    new ContactTag { ContactTagId = 1, ContactId = 1, ContactTagName = "friend" },
                    new ContactTag { ContactTagId = 2, ContactId = 2, ContactTagName = "roleModel" },
                    new ContactTag { ContactTagId = 3, ContactId = 2, ContactTagName = "colleague" },
                    new ContactTag { ContactTagId = 4, ContactId = 3, ContactTagName = "family" },
                    new ContactTag { ContactTagId = 5, ContactId = 4, ContactTagName = "friend" },
                    new ContactTag { ContactTagId = 6, ContactId = 5, ContactTagName = "friend" },
                    new ContactTag { ContactTagId = 7, ContactId = 8, ContactTagName = "friend" },
                    new ContactTag { ContactTagId = 8, ContactId = 8, ContactTagName = "business" }
                );
        }
    }
}