using CityApi.Info.Controllers;
using CityApi.Info.Models;
using FluentValidation;
using Microsoft.AspNetCore.StaticFiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>

 options.ReturnHttpNotAcceptable = true
).AddXmlDataContractSerializerFormatters();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<FileExtensionContentTypeProvider>();
builder.Services.AddScoped<IValidator<PointOfInterestCreationDto>, CustomValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints((endpoints) =>
{
    endpoints.MapControllers();
});

//app.MapControllers();

//commented as we want output from our controller actions
//app.Run(async (context) =>
//{
//    await context.Response.WriteAsync("Hello World");
//});

app.Run();
