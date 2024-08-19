using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GifoX.web.Utility
{
    public class SD
    {
        public static string? CouponAPIBase { get; set; }
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE,
        }
        public enum Services
        {
            Coupone,
            Product
        }
        public enum Operations
        {
            GetAll,
            GetByCode,
        }
    }
}