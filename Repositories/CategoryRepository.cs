using ConsoleAppDB.Contexts;
using ConsoleAppDB.Entities;

namespace ConsoleAppDB.Repositories;

internal class CategoryRepository : Repo<CategoryEntity>
{
    public CategoryRepository(DataContext context) : base(context)
    {
    }
}
