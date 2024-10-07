using ConsoleAppDB.Contexts;
using ConsoleAppDB.Entities;

namespace ConsoleAppDB.Repositories;

internal class AddressRepository : Repo<AddressEntity>
{
    public AddressRepository(DataContext context) : base(context)
    {
    }
}
