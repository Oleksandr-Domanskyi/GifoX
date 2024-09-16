using System;

namespace Product.Shared.Requests;

public class Request
{
    public string Url { get; set; } = string.Empty;
    public HttpContent? Data { get; set; }
}

