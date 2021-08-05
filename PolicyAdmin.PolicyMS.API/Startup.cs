using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PolicyAdmin.PolicyMS.API.DataSeeding;
using PolicyAdmin.PolicyMS.API.DBContext;
using PolicyAdmin.PolicyMS.API.Interface;
using PolicyAdmin.PolicyMS.API.Repository;
using PolicyAdmin.PolicyMS.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolicyAdmin.PolicyMS.API
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

            if (Configuration.GetValue<bool>("InMemoryDatabase"))
            {
                services.AddDbContext<PolicyContext>(options => options.UseInMemoryDatabase("PolicyAdmin_Policy"));

            }
            else
            {
                services.AddDbContext<PolicyContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Database")));
            }



            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Secret"]))
                    };
                });
            services.AddCors(c => c.AddPolicy("POD_1_Policy", builder =>
            {
                builder.AllowAnyOrigin();
                builder.AllowAnyMethod();
                builder.AllowAnyHeader();
            }));


            services.AddTransient<IDBService, DBService>();
            services.AddTransient<IQuotesService, QuotesService>();
            services.AddTransient<IConsumerService, ConsumerService>();
            services.AddTransient<IPolicyRepository, PolicyRepository>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PolicyAdmin.PolicyMS.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PolicyAdmin.PolicyMS.API v1"));
            }
            if (Configuration.GetValue<bool>("inmemorydatabase"))
            {
                var scopeeee = app.ApplicationServices.CreateScope();
                var context = scopeeee.ServiceProvider.GetRequiredService<PolicyContext>();
                DataGeneratorPolicyMaster.Initialize(context);

            }
            app.UseRouting();
            app.UseCors("POD_1_Policy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
