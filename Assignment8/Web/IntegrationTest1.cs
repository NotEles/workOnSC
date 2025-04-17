using control;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OrderApp;
namespace Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Configuration.AddJsonFile("appsettings.json");
            var connectionString = builder.Configuration.GetConnectionString("todoDatabase");

            // Add services to the container.
            
            
            //把DbContext加入到容器
            builder.Services.AddDbContext<OrderContext>(opt => opt.UseMySQL(connectionString));
            builder.Services.AddScoped<OrderService>();
            builder.Services.AddControllers();
            var app = builder.Build();

            // Configure the HTTP request pipeline.

            
            app.MapControllers();
            app.Run();
        }
    }
}
