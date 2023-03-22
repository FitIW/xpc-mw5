using System;
using System.Collections.Generic;

namespace ComplexSample;

public partial class Country
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Brand> Brands { get; } = new List<Brand>();
}
