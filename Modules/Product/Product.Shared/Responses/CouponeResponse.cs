using System;

namespace Product.Shared.Responses;

public class CouponeResponse<T>
{
    public bool Success { get; set; }
    public T? Data { get; set; }
    public string? Message { get; set; }
}
