using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contacts.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Contacts.API.Data
{
  public class ContactDataRepository : IContactDataRepository
  {
    private readonly DataContext context;

    public ContactDataRepository(DataContext context)
    {
      this.context = context;
    }

    public async Task<IEnumerable<ContactData>> GetContactDataForContact(int contactId)
    {
        var contactDataList = from contactData in context.ContactData.AsQueryable()
                             where contactData.ContactId == contactId
                            select contactData;

        return await contactDataList.ToListAsync();
    }
  }
}