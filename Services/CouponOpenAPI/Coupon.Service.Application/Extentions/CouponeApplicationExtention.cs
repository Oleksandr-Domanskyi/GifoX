using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coupons.Service.Application.CQRS.Query.CouponeGetAll;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Coupons.Service.Application.Extentions
{
    public static class CouponeApplicationExtention
    {
        public static void AddCouponeApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CouponeGetAllQueryHandler).Assembly));
        }
    }
}