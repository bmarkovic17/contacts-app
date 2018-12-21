using System.Collections.Generic;
using System.Threading.Tasks;
using Contacts.API.Models;

namespace Contacts.API.Data
{
    public interface IContactsRepository
    {
         void Add<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         Task<bool> SaveAll();
         Task<IEnumerable<Contact>> GetContacts(string filter);
         Task<Contact> GetContact(int contactId);
         Task<ContactData> GetContactData(int contactDataId);
    }
}