
using CourseSelection.Data;
using CourseSelection.Interfaces;
using CourseSelection.Services;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System.Data;
using System.Reflection;


namespace CourseSelection
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
            builder.Services.AddSwaggerGen(opt =>
            {
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                opt.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
                opt.SchemaFilter<SwaggerSchemaFilter>();
            });

            //¸ê®Æ®wµù¥U
            builder.Services.AddDbContext<CourseSelectionContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("CourseSelectionDB")));
            //Dapper
            builder.Services.AddScoped<IDbConnection>(opt => new SqlConnection(builder.Configuration.GetConnectionString("CourseSelectionDB")));
            
            builder.Services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));
            builder.Services.AddScoped<IUserManagementService, UserManagementService>();
            builder.Services.AddScoped<ICourseService, CourseService>();
            builder.Services.AddScoped<ITeacherService, TeacherService>();

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
