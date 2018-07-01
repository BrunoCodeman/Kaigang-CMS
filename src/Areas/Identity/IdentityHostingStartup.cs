using System;
using kaigang.Areas.Identity.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(kaigang.Areas.Identity.IdentityHostingStartup))]
namespace kaigang.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ApplicationContext>(options =>
                        options.UseMySql("Server=172.17.0.2;database=kaigang;uid=root;pwd=root;")
                    // options.UseSqlServer(
                    //     context.Configuration.GetConnectionString("ApplicationContextConnection"))
                        );

                services.AddDefaultIdentity<KaigangUser>()
                    .AddEntityFrameworkStores<ApplicationContext>();
            });
        }
    }
}