
using API_Personnes2.Models;
using API_Personnes2.Models.Services;
using Microsoft.EntityFrameworkCore;

namespace API_Personnes2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Ajout
            builder.Services.AddDbContext<PersonnesDbContext>(options => options.UseMySQL(builder.Configuration.GetConnectionString("Default")));
            builder.Services.AddTransient<PersonnesServices>();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


            //Fin AJout


            // Add services to the container.

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