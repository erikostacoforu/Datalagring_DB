using System.ComponentModel.DataAnnotations;

namespace ConsoleAppDB.Entities;

public class ManufactureEntity
{
    [Key]
    public int Id { get; set; }

    public string ManufactureName { get; set; } = null!;
}
