using System;

namespace Product.Service.Core.Domain;

public class Image
{
    public Guid Id { get; set;}
    public string Url { get; set;} = default!;

    public string ProductId { get; set; } = default!;
}
