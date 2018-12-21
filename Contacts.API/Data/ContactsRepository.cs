using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contacts.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Contacts.API.Data
{
  public class ContactsRepository : IContactsRepository
  {
    private readonly DataContext context;
    public ContactsRepository(DataContext context)
    {
        this.context = context;
    }
    public void Add<T>(T entity) where T : class
    {
        context.Add(entity);
    }

    public void Delete<T>(T entity) where T : class
    {
        context.Remove(entity);
    }

    public async Task<bool> SaveAll()
    {
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<IEnumerable<Contact>> GetContacts(string filter)
    {
        var contacts = context.Contacts
            .Include(c => c.Address)
            .Include(c => c.ContactData)
            .Include(c => c.ContactTags)
            .AsQueryable();

        contacts = from contact in contacts
                  where string.IsNullOrWhiteSpace(filter) ||
                        contact.Name.Contains(filter) ||
                        contact.Surname.Contains(filter) ||
                        (from contactTag in context.ContactTag
                        where contactTag.ContactId == contact.ContactId &&
                              contactTag.ContactTagName.Contains(filter)
                       select contactTag.ContactTagName).Count() > 0
                 select contact;

        return await contacts.ToListAsync();
    }

    public async Task<Contact> GetContact(int contactId)
    {
        var contact = await context.Contacts
            .Include(c => c.Address)
            .Include(c => c.ContactData)
            .Include(c => c.ContactTags)
            .SingleAsync(c => c.ContactId == contactId);

      return contact;
    }

    public async Task<ContactData> GetContactData(int contactDataId)
    {
        var contactData = await context.ContactData
            .SingleAsync(cd => cd.ContactDataId == contactDataId);

      return contactData;
    }
  }
}