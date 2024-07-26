using ETicaretAPI.Application.Abstractions;
using ETicaretAPI.Persistence.Concrates;
using Microsoft.EntityFrameworkCore;
using ETicaretAPI.Persistence.Contexts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceServices(this IServiceCollection services)
        {
            services.AddDbContext<ETicaretAPIDbContext>(options=>options.UseNpgsql(Configuration.ConnectionString));
        }
    }
}
