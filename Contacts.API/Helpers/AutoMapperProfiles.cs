using AutoMapper;
using Contacts.API.Dtos;
using Contacts.API.Models;

namespace Contacts.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Contact, ContactDto>();
            CreateMap<Address, AddressDto>();
            CreateMap<ContactData, ContactDataDto>();
            CreateMap<ContactTag, ContactTagDto>();
        }
    }
}