using ConsoleAppDB.Entities;
using ConsoleAppDB.Repositories;

namespace ConsoleAppDB.Services;

internal class CustomerService
{
    private readonly CustomerRepository _customerRepository;
    private readonly AddressService _addressService;

    public CustomerService(CustomerRepository customerRepository, AddressService addressService)
    {
        _customerRepository = customerRepository;
        _addressService = addressService;
    }

    public CustomerEntity CreateCustomer(string firstName, string lastName, string email, string streetName, string city, string postalCode)
    {
        var addressEntity = _addressService.CreateAddress(streetName, city, postalCode);

        var CustomerEntity = new CustomerEntity
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            AddressId = addressEntity.Id
        };

        CustomerEntity = _customerRepository.Create(CustomerEntity);

        return CustomerEntity;

    }

    public CustomerEntity GetCustomerByEmail(string email)
    {
        var customerEntity = _customerRepository.Get(x => x.Email == email);
        return customerEntity;
    }

    public CustomerEntity GetCustomerById(int id)
    {
        var customerEntity = _customerRepository.Get(x => x.Id == id);
        return customerEntity;
    }

    public IEnumerable<CustomerEntity> GetCustomers()
    {
        var customers = _customerRepository.GetAll();
        return customers;
    }

    public CustomerEntity UpdateCustomer(CustomerEntity CustomerEntity)
    {
        var updatedCustomerEntity = _customerRepository.Update(x => x.Id == CustomerEntity.Id, CustomerEntity);
        return updatedCustomerEntity;
    }

    public void DeleteCustomer(int id)
    {
        _customerRepository.Delete(x => x.Id == id);
    }

}
