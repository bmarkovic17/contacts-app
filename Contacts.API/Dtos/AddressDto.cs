namespace Contacts.API.Dtos
{
    public class AddressDto
    {
        public string Street { get; set; }
        public string AddressNumber { get; set; }
        public string Postcode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}