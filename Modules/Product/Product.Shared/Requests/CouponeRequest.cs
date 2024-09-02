using System;

namespace Product.Shared.Requests;

public class CouponeRequest
{
    public string Url { get; set; } = string.Empty;
    public HttpContent? Data { get; set; }
}

