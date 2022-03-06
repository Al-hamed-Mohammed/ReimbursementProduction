using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManager2.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Azure;
using Azure.Storage.Queues;
using Azure.Storage.Blobs;
using Azure.Core.Extensions;
using Newtonsoft.Json.Serialization;

namespace EmployeeManager2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(60);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTY5MDA1QDMxMzkyZTM0MmUzMEhzUUN6cWpQYUdSZ0ZmWGdGRms2REFuV0YwdmJCT3RlZWUrZVZwQ3VTVms9;NTY5MDA2QDMxMzkyZTM0MmUzMGdseUNzY25yeHB0dGxoRWcwM3hYWnE4Z3V4NTh1QllOSUF4RlVFTHZtU2c9;NTY5MDA3QDMxMzkyZTM0MmUzME1odE1uM2UyTE0wdEs3M2NqY2pTUHBHcGkvUTBvRHZYMU8walprNUJwdlk9;NTY5MDA4QDMxMzkyZTM0MmUzMGg3QVpsMlRybGxRMDUxeExuanZjVGJvS3pXQVhKQytheTIyT2pUcHgzQnc9;NTY5MDA5QDMxMzkyZTM0MmUzMFRNRHNuNmp4bHA0UmFvcWo4ZllSUFY5Slp5NGNUM1hINnF6NDg2cWhjSDg9;NTY5MDEwQDMxMzkyZTM0MmUzMGxaZHlKUVQ1T0l2WlZQSy9vU3Vlb29VV25VSzRyQjRHMDgyUFVDTUx6TjQ9;NTY5MDExQDMxMzkyZTM0MmUzMERZNmtQZllrallPcEM3VFJvbFpoRy82MkJva0NPYi8yOWk4Um9kRnlON0E9;NTY5MDEyQDMxMzkyZTM0MmUzMERDWkZjNFVBUDB5d0cwVEFIb0ZQTWppY2Vld3p5RjU4WngrMXBSbWp4SFU9;NTY5MDEzQDMxMzkyZTM0MmUzMFNYT1VXdk96V2tNLzMzU3pSYUk3ekFBN25nVUpyd1JnZ09ydk9OVFYxZ289;NTY5MDE0QDMxMzkyZTM0MmUzMG1IdmlmMWdzZjdSVUMrMy9XM2FuQzhOVWVHdUZ0clV4VjUyWEU5d3cxYjQ9;NTY5MDE1QDMxMzkyZTM0MmUzME5qSWdUeXlqTTZ6aDdSd2Q4Z0JacStJK09kZnYwRWptTW1wVGpvdTdvMVE9");

            services.AddMvc().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });

            services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("EmployeeDBConnection")));
            services.AddControllersWithViews().AddXmlSerializerFormatters();
            services.AddScoped<IEmployeeRepository, SQLEmployeeRepository>();
            services.AddScoped<IAccountantRepo, AccountantRepo>();
            services.AddScoped<IInsertErrorLog, InsertErrorLog>();
            services.AddRazorPages();
            services.AddAzureClients(builder =>
            {
                builder.AddBlobServiceClient(Configuration["ConnectionStrings:reimbursmentstorage:blob"], preferMsi: true);
                builder.AddQueueServiceClient(Configuration["ConnectionStrings:reimbursmentstorage:queue"], preferMsi: true);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            
            app.UseRouting();
            app.UseSession();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
    internal static class StartupExtensions
    {
        public static IAzureClientBuilder<BlobServiceClient, BlobClientOptions> AddBlobServiceClient(this AzureClientFactoryBuilder builder, string serviceUriOrConnectionString, bool preferMsi)
        {
            if (preferMsi && Uri.TryCreate(serviceUriOrConnectionString, UriKind.Absolute, out Uri serviceUri))
            {
                return builder.AddBlobServiceClient(serviceUri);
            }
            else
            {
                return builder.AddBlobServiceClient(serviceUriOrConnectionString);
            }
        }
        public static IAzureClientBuilder<QueueServiceClient, QueueClientOptions> AddQueueServiceClient(this AzureClientFactoryBuilder builder, string serviceUriOrConnectionString, bool preferMsi)
        {
            if (preferMsi && Uri.TryCreate(serviceUriOrConnectionString, UriKind.Absolute, out Uri serviceUri))
            {
                return builder.AddQueueServiceClient(serviceUri);
            }
            else
            {
                return builder.AddQueueServiceClient(serviceUriOrConnectionString);
            }
        }
    }
}
