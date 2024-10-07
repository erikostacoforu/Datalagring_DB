﻿using System.ComponentModel.DataAnnotations;

namespace ConsoleAppDB.Entities;

public class ProductEntity
{
    [Key]
    public int Id { get; set; } 

    public string Title { get; set; } = null!;

    public decimal Price { get; set; }

    public int CategoryId { get; set; }

    public  CategoryEntity Category { get; set; } = null!;

    public int ManufactureId { get; set; }

    public ManufactureEntity Manufacture { get; set; } = null!;
}
