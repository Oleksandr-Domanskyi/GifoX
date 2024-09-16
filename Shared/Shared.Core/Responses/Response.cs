using System;

namespace Product.Shared.Responses;

public class Response<T>
{
    public string? Message { get; set; }
    public bool IsSuccess { get; set; }
    public T Content { get; set; } = default(T)!;

}
