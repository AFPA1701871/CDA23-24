
using Microsoft.EntityFrameworkCore;
using Tables_1_vers_plusieurs.Models;
using Tables_1_vers_plusieurs.Models.Services;

namespace Tables_1_vers_plusieurs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<VoitureContext>(options => options.UseMySQL(builder.Configuration.GetConnectionString("Default")));
            builder.Services.AddTransient<MarqueService>();
            builder.Services.AddTransient<ModeleService>();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddControllers().AddNewtonsoftJson(); // pour faire fonctionner le patch

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

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