﻿using System;
using eCommerce.Web.Areas.Identity.Data;
using eCommerce.Web.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(eCommerce.Web.Areas.Identity.IdentityHostingStartup))]
namespace eCommerce.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<IdentityDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("IdentityDbContextConnection")));

                services.AddDefaultIdentity<eCommerceWebUser>()
                .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<IdentityDbContext>();
            });
        }
    }
}