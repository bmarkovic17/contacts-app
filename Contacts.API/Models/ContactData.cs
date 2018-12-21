using System.ComponentModel.DataAnnotations;

namespace Contacts.API.Models
{
    public class ContactData
    {
        public int ContactDataId { get; set; }
        public int ContactId { get; set; }
        // PHONE/MAIL
        [Required]
        [MaxLength(10)]
        public string ContactDataType { get; set; }
        [Required]
        [MaxLength(1)]
        public string ContactDataStatus { get; set; }
        [Required]
        [MaxLength(50)]
        public string ContactDataValue { get; set; }
        public Contact Contact { get; set; }
    }
}