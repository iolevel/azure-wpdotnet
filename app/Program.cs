using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace PeachPied.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Directory.SetCurrentDirectory(Path.GetDirectoryName(typeof(Program).Assembly.Location));

            //
            var host = WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls("http://*:5004/")
                .Build();

            host.Run();
        }
    }

    class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddResponseCompression();
        }

        public void Configure(IApplicationBuilder app, IHostEnvironment env, IConfiguration configuration)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseWordPress();
            app.UseDefaultFiles();
        }
    }
}
