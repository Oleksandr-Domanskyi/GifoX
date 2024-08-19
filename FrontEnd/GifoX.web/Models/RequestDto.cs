using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static GifoX.web.Utility.SD;

namespace GifoX.web.Models
{
    public class RequestDto
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string? Url { get; set; }
        public object? Data { get; set; }
        public string? AccessToken { get; set; }
    }
}