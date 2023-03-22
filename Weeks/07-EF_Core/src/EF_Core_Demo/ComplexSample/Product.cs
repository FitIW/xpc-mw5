using System;
using System.Collections.Generic;

namespace ComplexSample;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Code { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int CategoryId { get; set; }

    public int BrandId { get; set; }

    public int Price { get; set; }

    public int Stock { get; set; }

    public int Weight { get; set; }

    public string ImageKey { get; set; } = null!;

    public DateTime Created { get; set; }

    public DateTime Updated { get; set; }

    public virtual Brand Brand { get; set; } = null!;

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Rating> Ratings { get; } = new List<Rating>();
}
