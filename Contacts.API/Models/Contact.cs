using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Contacts.API.Models
{
    public class Contact
    {
        public int ContactId { get; set; }
        public int AddressId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(200)]
        public string Surname { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Address Address { get; set; }
        public List<ContactData> ContactData { get; set; }
        public List<ContactTag> ContactTags { get; set; }
    }
}