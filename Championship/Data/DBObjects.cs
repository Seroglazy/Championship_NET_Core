using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Championship.Data
{
    public class DBObjects
    {
        public static void Initial(IApplicationBuilder app)
        {
            AppDBContent content = app.ApplicationServices.GetRequiredService<AppDBContent>();
        }
    }
}
