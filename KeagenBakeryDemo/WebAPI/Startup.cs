using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI
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
            services.AddControllers();

            //Register swagger generator, defining 1 or more swagger documents
            services.AddSwaggerGen();

            //database context
            services.AddDbContext<EmployeeContext>(opt =>
            opt.UseSqlServer(Configuration.GetConnectionString("EmployeeContext")));
            //user table context
            services.AddDbContext<UserContext>(opt =>
            opt.UseSqlServer(Configuration.GetConnectionString("UserContext")));

            //products database context
            services.AddDbContext<ProductContext>(opt =>
           opt.UseSqlServer(Configuration.GetConnectionString("ProductContext")));

            //Order Details
            services.AddDbContext<OrderDetailsContext>(opt =>
          opt.UseSqlServer(Configuration.GetConnectionString("OrderDetailsContext")));

            //Customers context
            services.AddDbContext<CustomersContext>(opt =>
            opt.UseSqlServer(Configuration.GetConnectionString("CustomersContext")));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
