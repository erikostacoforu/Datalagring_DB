using ConsoleAppDB.Entities;
using ConsoleAppDB.Repositories;

namespace ConsoleAppDB.Services;

internal class ManufactureService
{
    private readonly ManufactureRepository _manufactureRepository;

    public ManufactureService(ManufactureRepository manufactureRepository)
    {
        _manufactureRepository = manufactureRepository;
    }

    public ManufactureEntity CreateManufacture(string manufactureName)
    {
        var manufactureEntity =  _manufactureRepository.Get(x => x.ManufactureName == manufactureName);
        manufactureEntity ??= _manufactureRepository.Create( new ManufactureEntity { ManufactureName = manufactureName });

        return manufactureEntity;
    }


    public ManufactureEntity GetManufactureByManufactureName(string manufactureName)
    {
        var manufactureEntity = _manufactureRepository.Get(x => x.ManufactureName == manufactureName);
        return manufactureEntity;
    }

    public ManufactureEntity GetManufactureById(int id)
    {
        var manufactureEntity = _manufactureRepository.Get(x => x.Id == id);
        return manufactureEntity;
    }

    public IEnumerable<ManufactureEntity> GetManufacturers()
    {
        var manufacturers = _manufactureRepository.GetAll();
        return manufacturers;
    }

    public ManufactureEntity UpdateManufacturer(ManufactureEntity manufactureEntity)
    {
        var updateManufactureEntity = _manufactureRepository.Update(x => x.Id == manufactureEntity.Id, manufactureEntity);
        return updateManufactureEntity;
    }

    public void DeleteManufacture(int id)
    {
        _manufactureRepository.Delete(x => x.Id == id);
    }
}
