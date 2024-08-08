using Carter;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using RentAndInvoice.Core.Application;
using RentAndInvoice.Core.Infraestructure;
using RentAndInvoice.Core.WebAPI.Extensions;
using RentAndInvoice.Core.WebAPI.OptionsSetup;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthorization();


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddInfraestructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddCarter();



builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));



builder.Services.ConfigureOptions<JwtOptionsSetup>();
builder.Services.ConfigureOptions<JwtBearerOptionsSetup>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer();

builder.Services.AddCors(opt =>
{
    opt.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseCors();

app.UseAuthorization();

app.MapCarter();

app.Run();