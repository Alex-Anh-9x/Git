using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pada.Data;

[assembly: HostingStartup(typeof(Pada.Areas.Identity.IdentityHostingStartup))]
namespace Pada.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<Pada_AuthenticationContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("Pada_AuthenticationContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<Pada_AuthenticationContext>();
            });
        }
    }
}