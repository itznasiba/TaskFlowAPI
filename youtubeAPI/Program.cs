using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using TaskAPI.Business.Services;
using TaskAPI.DataAccess.Repository;
using TaskAPI.Business.Profiles;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI; // Add this using directive
using Swashbuckle.AspNetCore.Swagger;   // Add this using directive
using Swashbuckle.AspNetCore.SwaggerGen;
using TaskAPI.Middleware; // Add this using directive

namespace TaskAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            builder.Services.AddDbContext<TaskDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IUserService, UserService>();

            // Add Swagger services
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "YoutubeAPI", Version = "v1" });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();
            app.UseMiddleware<ExceptionMiddleware>();

            app.UseAuthorization();

            app.MapControllers();

            // Use Swagger middleware
            app.UseSwagger(); // <-- This requires Swashbuckle.AspNetCore NuGet package
            app.UseSwaggerUI(c =>
            {
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "YoutubeAPI v1");
                }
            });

            app.Run();
        }
    }
}
