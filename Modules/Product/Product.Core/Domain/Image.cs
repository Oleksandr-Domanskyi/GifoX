using System;

namespace Product.Service.Core.Domain;

public class Image
{
    private Guid _Id;
    private string _Url = default!;
    private Guid _ProductId;


    public Guid Id { get => _Id; set => _Id = value; }
    public string Url { get => _Url; set => _Url = value; }
    public Guid ProductId { get => _ProductId; set => _ProductId = value; }
}
