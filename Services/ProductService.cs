using ConsoleAppDB.Entities;
using ConsoleAppDB.Repositories;

namespace ConsoleAppDB.Services;

internal class ProductService
{
    private readonly ProductRepository _productRepository;
    private readonly CategoryService _categoryService;
    private readonly ManufactureService _manufacturerService;

    public ProductService(ProductRepository productRepository, CategoryService categoryService, ManufactureService manufacturerService)
    {
        _productRepository = productRepository;
        _categoryService = categoryService;
        _manufacturerService = manufacturerService;
    }

    public ProductEntity CreateProduct(string title, decimal price, string categoryName, string manufactureName)
    {
        var categoryEntity = _categoryService.CreateCategory(categoryName);
        var manufactureEntity = _manufacturerService.CreateManufacture(manufactureName);

        var productEntity = new ProductEntity
        {
            Title = title,
            Price = price,
            CategoryId = categoryEntity.Id,
            ManufactureId = manufactureEntity.Id,
        };

        productEntity = _productRepository.Create(productEntity);
        return productEntity;
    }

    public ProductEntity GetProductByTitle(string title)
    {
        var productEntity = _productRepository.Get(x => x.Title == title);
        return productEntity;
    }

    public ProductEntity GetProductById(int id)
    {
        var productEntity = _productRepository.Get(x => x.Id == id);
        return productEntity;
    }

    public IEnumerable<ProductEntity> GetProducts()
    {
        var products = _productRepository.GetAll();
        return products;
    }

    public ProductEntity UpdateProduct(ProductEntity ProductEntity)
    {
        var updatedProductEntity = _productRepository.Update(x => x.Id == ProductEntity.Id, ProductEntity);
        return updatedProductEntity;
    }

    public void DeleteProduct(int id)
    {
        _productRepository.Delete(x => x.Id == id);
    }
}
