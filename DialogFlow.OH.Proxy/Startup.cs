using System;
using System.Net.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Openhab.Clinet;

namespace DialogFlow.OH.Proxy
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
            // injecting IHttpClientFactory and a named HttpClient
            services.AddHttpClient<IOpenhabClient, OpenhabClient>();
            services.AddScoped<IOpenhabClient, OpenhabClient>(p =>
            {
                // create a named/configured HttpClient
                var httpClient = p.GetRequiredService<IHttpClientFactory>()
                    .CreateClient(nameof(IOpenhabClient));

                // get the base Uri from service disco (service name could come from configuration again...)
                // or read the Uri from configuration if you want to hard code it...
                var baseUri = new Uri("http://192.168.1.17:8080/rest");

                return new OpenhabClient(baseUri, httpClient);
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
