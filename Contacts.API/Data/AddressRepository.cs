using System.Threading.Tasks;
using Contacts.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Contacts.API.Data
{
  public class AddressRepository : IAddressRepository
  {
    private readonly DataContext context;

    public AddressRepository(DataContext context)
    {
      this.context = context;
    }
    public async Task<Address> GetAddress(int addressId)
    {
      var address = await context.Address
          .SingleAsync(a => a.AddressId == addressId);

      return address;
    }
  }
}