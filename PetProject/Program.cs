using PetProject.Controllers;
using PetProject.Configuration;

var builder = WebApplication.CreateBuilder();

builder.Services.AddScoped<IStartClass, StartClass>();
builder.Services.AddScoped<StartService>();
 
var app = builder.Build();
 
app.UseMiddleware<StartMiddleware>();

app.Run();
