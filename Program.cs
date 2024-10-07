using ConsoleAppDB;
using ConsoleAppDB.Contexts;
using ConsoleAppDB.Repositories;
using ConsoleAppDB.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
{

    services.AddDbContext<DataContext>(x => x.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\erik_\Desktop\Data_lagring\ConsoleAppDataBase\ConsoleAppDataBase\Data\database.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True"));

    services.AddScoped<AddressRepository>();
    services.AddScoped<CategoryRepository>();
    services.AddScoped<CustomerRepository>();
    services.AddScoped<ManufactureRepository>();
    services.AddScoped<ProductRepository>();

    services.AddScoped<AddressService>();
    services.AddScoped<CategoryService>();
    services.AddScoped<CustomerService>();
    services.AddScoped<ManufactureService>();
    services.AddScoped<ProductService>();

    services.AddSingleton<ConsoleMenu>();

}).Build();

var consoleMenu = builder.Services.GetRequiredService<ConsoleMenu>();
consoleMenu.ConsoleMenuChoice();