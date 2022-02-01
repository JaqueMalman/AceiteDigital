using AceiteDigital.Data.Context;
using AceiteDigital.Data.Repository;
using AceiteDigitalApp.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AceiteDigitalWebApp
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //adiciona o contexto para gerar migration
            builder.Services.AddDbContext<ApplicationDbContext>(opt =>
            {
                opt.UseSqlServer(
                                builder.Configuration.GetConnectionString("ApplicationDbContext"),
                                b => b.MigrationsAssembly("AceiteDigital.Data"));
            });

            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

            var appAssemblie = typeof(
                AceiteDigital.Application.Documentos.Commands.CriarDocumento.CriarDocumentoCommand).Assembly;

            builder.Services.AddMediatR(appAssemblie);

            builder.Services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );


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