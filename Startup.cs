using Assignment_Backend.IService;
using Assignment_Backend.Models;
using Assignment_Backend.Repositories.IRepositories;
using Assignment_Backend.Repositories.RepositoryImplmentation;
using Assignment_Backend.ServiceImpl;
using Assignment_Backend.SignalR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_Backend
{
    public class Startup
    {
        readonly string AllowedOrigin = "allowedOrigin";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(option =>
            {
                option.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials().WithOrigins("http://localhost:4200")
                    );
            });

            services.AddSignalR();
            services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Assignment_Backend", Version = "v1" });
            });
           services.AddDbContext<MyDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DevConnection")));
           services.AddTransient<IMessageService, MessageService>();
           services.AddTransient<IUserService, UserService>();
           services.AddTransient<IMessageRepository, MessageRepositoryImpl>();
           services.AddTransient<IUserRepoistary, UserRepositoryImpl>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Assignment_Backend v1"));
            }

            app.UseHttpsRedirection();

            app.UseCors("CorsPolicy");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<NotifyHub>("/notify");
            });
        }
    }
}
