﻿using System;
using System.Collections.Generic;

namespace ProductService.Domain.Entities;

public partial class Company
{
    public long Id { get; set; }

    public string Description { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string CompanyPhoneNumber { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string Email { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
