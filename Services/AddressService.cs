using ConsoleAppDB.Entities;
using ConsoleAppDB.Repositories;

namespace ConsoleAppDB.Services;

internal class AddressService
{
    private readonly AddressRepository _addressRepository;

    public AddressService(AddressRepository addressRepository)
    {
        _addressRepository = addressRepository;
    }

    public AddressEntity CreateAddress(string streetName, string city, string postalCode)
    {
        var adressEntity = _addressRepository.Get(x => x.StreetName == streetName && x.City == city && x.PostalCode == postalCode);
        adressEntity ??= _addressRepository.Create(new AddressEntity { StreetName = streetName, City = city, PostalCode = postalCode });

        return adressEntity;
    }

    public AddressEntity GetAddressByAddress(string streetName, string city, string postalCode)
    {
        var adressEntity = _addressRepository.Get(x => x.StreetName == streetName && x.City == city && x.PostalCode == postalCode);
        return adressEntity;
    }

    public AddressEntity GetAddressById(int id)
    {
        var addressEntity = _addressRepository.Get(x => x.Id == id);
        return addressEntity;
    }

    public IEnumerable<AddressEntity> GetAdresses()
    {
        var addresses = _addressRepository.GetAll();
        return addresses;
    }

    public AddressEntity UpdateAddress(AddressEntity addressEntity)
    {
        var updateAddressEntity = _addressRepository.Update(x => x.Id == addressEntity.Id, addressEntity);
        return updateAddressEntity;
    }

    public void DeleteAddress(int id)
    {
        _addressRepository.Delete(x => x.Id == id);
    }   
}
