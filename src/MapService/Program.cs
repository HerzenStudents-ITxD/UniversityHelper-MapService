
using HerzenHelper.Core.EFSupport.Helpers;
using HerzenHelper.Core.Extensions;
using HerzenHelper.MapService.Data.Provider.MsSql.Ef;
using Microsoft.EntityFrameworkCore;
using SixLabors.ImageSharp;

namespace MapService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // START DANGER ZZZZZZZZZZZZZZZZZZZZONE
            //builder.Services.AddHttpContextAccessor();

            //string dbConnStr = "Server=127.0.0.1,20340;User=sa;Password=Map_1234;Database=MapDB;";
            //builder.Services.AddDbContext<MapServiceDbContext>(options =>
            //{
            //    options.UseSqlServer(dbConnStr);
            //});

            //builder.Services.AddBusinessObjects();

            var app = builder.Build();
            // END DANGER ZZZZZZZZZZZZZZZZZZZZONE

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
