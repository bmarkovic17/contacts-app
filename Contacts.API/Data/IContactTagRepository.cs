using System.Threading.Tasks;
using Contacts.API.Models;

namespace Contacts.API.Data
{
    public interface IContactTagRepository
    {
         Task<ContactTag> GetContactTag(int contactTagId);
    }
}