using System;

namespace Shared.Shared.Core.Requests;

public class Request
{
    public string Url { get; set; } = string.Empty;
    public HttpContent? Data { get; set; }
}

