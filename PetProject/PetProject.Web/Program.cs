using PetProject.Orchestrators.Implementations;
using PetProject.Orchestrators.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// добавляем сервисы CORS
builder.Services.AddCors(); 

builder.Services.AddScoped<IUserOrchestrator, UserOrchestrator>();

var app = builder.Build();

// настраиваем CORS
// указываем, что приложение может обрабатывать запросы с только одним адресом и любыми заголовками и  методами запросов
app.UseCors(builder => builder.WithOrigins("https://localhost:44477")
                            .AllowAnyHeader()
                            .AllowAnyMethod());


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
   app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseRouting();

app.MapControllers();

app.MapFallbackToFile("index.html"); ;

app.Run();
