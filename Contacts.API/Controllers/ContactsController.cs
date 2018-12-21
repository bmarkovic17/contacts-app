// using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Contacts.API.Data;
using Contacts.API.Dtos;
using Contacts.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Contacts.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ContactsController : ControllerBase
  {
    private readonly IAddressRepository addressRepository;
    private readonly IContactsRepository contactsRepository;
    private readonly IContactDataRepository contactDataRepository;
    private readonly IContactTagRepository contactTagRepository;
    private readonly IMapper mapper;
    public ContactsController(
      IAddressRepository addressRepository,
      IContactsRepository contactsRepository,
      IContactDataRepository contactDataRepository,
      IContactTagRepository contactTagRepository,
      IMapper mapper)
    {
      this.mapper = mapper;
      this.addressRepository = addressRepository;
      this.contactsRepository = contactsRepository;
      this.contactDataRepository = contactDataRepository;
      this.contactTagRepository = contactTagRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetContacts(string filter)
    {
      var contacts = await contactsRepository.GetContacts(filter);

      var contactsToReturn = mapper.Map<IEnumerable<ContactDto>>(contacts);

      return Ok(contactsToReturn);
    }

    [HttpGet("{contactId}")]
    public async Task<IActionResult> GetContact(int contactId)
    {
      var contact = await contactsRepository.GetContact(contactId);

      var contactToReturn = mapper.Map<ContactDto>(contact);

      return Ok(contactToReturn);
    }


    [HttpPost("contact/new")]
    public async Task<IActionResult> AddContact(ContactDtoForAdd contactNew)
    {

      var contact = new Contact();

      contact.Name = contactNew.Name;
      contact.Surname = contactNew.Surname;
      contact.DateOfBirth = contactNew.DateOfBirth;

      contact.Address = new Address();
      contact.Address.Street = contactNew.Address.Street;
      contact.Address.AddressNumber = contactNew.Address.AddressNumber;
      contact.Address.Postcode = contactNew.Address.Postcode;
      contact.Address.City = contactNew.Address.City;
      contact.Address.Country = contactNew.Address.Country;

      contact.ContactData = new List<ContactData>();

      foreach(ContactDataDto contactData in contactNew.ContactData)
      {
        ContactData contactDataNew = new ContactData();

        contactDataNew.ContactDataStatus = "Y";
        contactDataNew.ContactDataType = contactData.ContactDataType;
        contactDataNew.ContactDataValue = contactData.ContactDataValue;

        contact.ContactData.Add(contactDataNew);
      }

      contactsRepository.Add(contact);

      if (await contactsRepository.SaveAll())
        return NoContent();

      return BadRequest("Error occured during adding of a contact!");
    }

    [HttpPut("{contactId}")]
    public async Task<IActionResult> UpdateContact(int contactId, ContactDto update)
    {
      var contact = await contactsRepository.GetContact(update.ContactId);

      contact.Name = update.Name;
      contact.Surname = update.Surname;
      contact.DateOfBirth = update.DateOfBirth;

      var address = await addressRepository.GetAddress(update.AddressId);

      address.Street = update.Address.Street;
      address.AddressNumber = update.Address.AddressNumber;
      address.Postcode = update.Address.Postcode;
      address.City = update.Address.City;
      address.Country = update.Address.Country;

      var contactData = await contactDataRepository.GetContactDataForContact(contact.ContactId);

      foreach (ContactData contactDataElement in contactData)
      {
        contactDataElement.ContactDataStatus = "N";

        foreach (ContactDataDto updateElement in update.ContactData)
        {
          if (contactDataElement.ContactDataType == updateElement.ContactDataType &&
          contactDataElement.ContactDataValue == updateElement.ContactDataValue)
          {
            contactDataElement.ContactDataStatus = "Y";
            update.ContactData.Remove(updateElement);
            break;
          }
        }
      }

      foreach (ContactDataDto updateElement in update.ContactData)
      {
        ContactData contactDataItem = new ContactData();

        contactDataItem.ContactId = contact.ContactId;
        contactDataItem.ContactDataType = updateElement.ContactDataType;
        contactDataItem.ContactDataStatus = "Y";
        contactDataItem.ContactDataValue = updateElement.ContactDataValue;

        contactsRepository.Add(contactDataItem);
      }

      if (await contactsRepository.SaveAll())
        return NoContent();

      return BadRequest("Error occured during contact update!");
    }

    [HttpDelete("{contactId}")]
    public async Task<IActionResult> DeleteContact(int contactId)
    {
      var contact = await contactsRepository.GetContact(contactId);

      contactsRepository.Delete(contact);

      if (await contactsRepository.SaveAll())
        return NoContent();

      return BadRequest("Error occured during contact deletion!");
    }


    [HttpDelete("contactData/{contactDataId}")]
    public async Task<IActionResult> DeleteContactData(int contactDataId)
    {
      var contactData = await contactsRepository.GetContactData(contactDataId);

      contactsRepository.Delete(contactData);

      if (await contactsRepository.SaveAll())
        return NoContent();

      return BadRequest("Error occured during contact data deletion!");
    }

    [HttpPost("contactTag/new")]
    public async Task<IActionResult> AddContactTag(ContactTag contactTagNew)
    {
      var contactTag = new ContactTag();

      contactTag.ContactId = contactTagNew.ContactId;
      contactTag.ContactTagName = contactTagNew.ContactTagName;

      contactsRepository.Add(contactTag);

      if (await contactsRepository.SaveAll())
        return NoContent();

      return BadRequest("Error occured during adding a contact tag!");
    }

    [HttpDelete("contactTag/{contactTagId}")]
    public async Task<IActionResult> DeleteContactTag(int contactTagId)
    {
      var contactTag = await contactTagRepository.GetContactTag(contactTagId);

      contactsRepository.Delete(contactTag);

      if (await contactsRepository.SaveAll())
        return NoContent();

      return BadRequest("Error occured during contact tag deletion!");
    }
  }
}