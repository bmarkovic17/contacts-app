using System.Threading.Tasks;
using Contacts.API.Models;

namespace Contacts.API.Data
{
    public interface IAddressRepository
    {
         Task<Address> GetAddress(int addressId);
    }
}