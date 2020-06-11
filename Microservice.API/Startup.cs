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

using MediatR;
using System.Reflection;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Microservice.Infrastructure.Data;
using Microservice.Infrastructure.Data.Repositories;
using Microservice.Infrastructure.Commands;
using Microservice.Infrastructure.Queries;

namespace Microservice
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
            services.AddDbContext<OrderDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                    sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure(maxRetryCount: 3, maxRetryDelay: TimeSpan.FromSeconds(30),
                            errorNumbersToAdd: null);
                    });
            });

            services.AddControllers();
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<UnitOfWork>();
            services.AddMediatR(typeof(CreateOrderHandler).Assembly);
            services.AddMediatR(typeof(UpdateOrderStatusHandler).Assembly);
            services.AddMediatR(typeof(UpdateOrderTotalHandler).Assembly);
            services.AddMediatR(typeof(GetOrderbyCustomerIdHandler).Assembly);
            services.AddMediatR(typeof(GetOrderbyOrderNumberHandler).Assembly);

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo { Title = "Order API", Version = "v1" });
                s.DescribeAllParametersInCamelCase();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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

            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Order API V1"); });
        }
    }
}
