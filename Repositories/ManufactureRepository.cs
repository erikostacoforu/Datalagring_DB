using ConsoleAppDB.Contexts;
using ConsoleAppDB.Entities;

namespace ConsoleAppDB.Repositories;

internal class ManufactureRepository : Repo<ManufactureEntity>
{
    public ManufactureRepository(DataContext context) : base(context)
    {
    }
}
