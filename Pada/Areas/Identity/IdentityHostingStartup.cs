using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pada.Areas.Identity.Data;
using Pada.Data;

[assembly: HostingStartup(typeof(Pada.Areas.Identity.IdentityHostingStartup))]
namespace Pada.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<Pada_AuthenContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("Pada_AuthenContextConnection")));

                services.AddDefaultIdentity<PadaUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<Pada_AuthenContext>()
                            .AddDefaultTokenProviders();

            });
        }
    }
}