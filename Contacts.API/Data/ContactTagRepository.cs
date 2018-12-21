using System.Threading.Tasks;
using Contacts.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Contacts.API.Data
{
  public class ContactTagRepository : IContactTagRepository
  {
    private readonly DataContext context;

    public ContactTagRepository(DataContext context)
    {
      this.context = context;
    }
    public async Task<ContactTag> GetContactTag(int contactTagId)
    {
      var contactTag = await context.ContactTag
          .SingleAsync(ct => ct.ContactTagId == contactTagId);

      return contactTag;
    }
  }
}