using System;
using System.Collections.Generic;

namespace ComplexSample;

public partial class Brand
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string ImageKey { get; set; } = null!;

    public int CountryId { get; set; }

    public virtual Country Country { get; set; } = null!;

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
