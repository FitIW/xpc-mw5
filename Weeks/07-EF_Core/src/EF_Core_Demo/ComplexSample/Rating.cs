using System;
using System.Collections.Generic;

namespace ComplexSample;

public partial class Rating
{
    public int Id { get; set; }

    public string RatingText { get; set; } = null!;

    public int RatingNumber { get; set; }

    public int ProductId { get; set; }

    public virtual Product Product { get; set; } = null!;
}
