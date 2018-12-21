using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Contacts.API.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        [Required]
        [MaxLength(200)]
        public string Street { get; set; }
        [Required]
        [MaxLength(10)]
        public string AddressNumber { get; set; }
        [Required]
        [MaxLength(10)]
        public string Postcode { get; set; }
        [Required]
        [MaxLength(50)]
        public string City { get; set; }
        [Required]
        [MaxLength(50)]
        public string Country { get; set; }
        public List<Contact> Contacts { get; set; }
    }
}