using System;

namespace Shared.Shared.Core.Responses;

public class Response<T>
{
    public string? Message { get; set; }
    public bool IsSuccess { get; set; }
    public T Content { get; set; } = default(T)!;

}
