using WaterLevels.Data;
using Microsoft.EntityFrameworkCore;
using WaterLevels.Logic;
using WaterLevels.Repo;
using WaterLevels.Database;
namespace WaterLevels
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddScoped<IWaterLevelsLogic, WaterlLevelsLogic>();
            builder.Services.AddScoped<IWaterLevelRepo, WaterLevelRepo>();
            builder.Services.AddDbContext<WaterLevelContext>(options =>
            {
            options.UseSqlServer(builder.Configuration.GetConnectionString("@\"Data Source=(localDB)\\MSSQLLocalDB;Initial Catalog=Waters;Integrated Security=True;MultipleActiveResultSets=true\""));
                options.UseLazyLoadingProxies();
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            var app=builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
