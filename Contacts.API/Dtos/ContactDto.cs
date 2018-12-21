using System;
using System.Collections.Generic;
using Contacts.API.Models;

namespace Contacts.API.Dtos
{
    public class ContactDto
    {
        public int ContactId { get; set; }
        public int AddressId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public AddressDto Address { get; set; }
        public List<ContactDataDto> ContactData { get; set; }
        public List<ContactTagDto> ContactTags { get; set; }
    }
}