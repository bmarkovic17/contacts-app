using System.ComponentModel.DataAnnotations;

namespace Contacts.API.Models
{
    public class ContactTag
    {
        public int ContactTagId { get; set; }
        public int ContactId { get; set; }
        [Required]
        public string ContactTagName { get; set; }
        public Contact Contact { get; set; }
    }
}