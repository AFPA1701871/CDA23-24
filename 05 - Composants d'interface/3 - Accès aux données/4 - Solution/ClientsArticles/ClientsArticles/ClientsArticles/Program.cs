
using ClientsArticles.Models;
using ClientsArticles.Models.Services;
using Microsoft.EntityFrameworkCore;

namespace ClientsArticles
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // scaffold-DbContext -Connection name=default -Provider MySql.EntityFrameworkCore -OutputDir Models/Data -Context ClientsArticlesDbContext -ContextDir Models


            // Add services to the container.
            builder.Services.AddDbContext<ClientsArticlesDbContext>(options => options.UseMySQL(builder.Configuration.GetConnectionString("Default")));
            builder.Services.AddTransient<CategoriesServices>();
            builder.Services.AddTransient<ArticlesServices>();
            builder.Services.AddTransient<CommandesServices>();
            builder.Services.AddTransient<ClientsServices>();
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