using System.Collections.Generic;
using System.Threading.Tasks;
using Contacts.API.Models;

namespace Contacts.API.Data
{
    public interface IContactDataRepository
    {
        Task<IEnumerable<ContactData>> GetContactDataForContact(int contactId);
    }
}