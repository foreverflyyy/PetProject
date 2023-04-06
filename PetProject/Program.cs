using PetProject.Controllers;
using PetProject.Configuration;
using PetProject.FileLogger;

// изменяем папку для хранения статических файлов
//var builder = WebApplication.CreateBuilder(new WebApplicationOptions {WebRootPath = "static"}); 
var builder = WebApplication.CreateBuilder(); 

// устанавливаем файл для логгирования
builder.Logging.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "logger.txt"));

//builder.Services.AddTransient<TimeService>();
//builder.Services.AddSingleton<StartService>();
//builder.Services.AddSingleton<IReadText>(serv => serv.GetRequiredService<StartService>());
//builder.Services.AddSingleton<IGenerateText>(serv => serv.GetRequiredService<StartService>());

builder.Configuration.AddJsonFile("settings.json");
builder.Services.Configure<Person>(builder.Configuration);

var app = builder.Build();

// поддержка страниц html по умолчанию, добавляем поддержку статических файлов
//app.UseFileServer();

// Конечные точки, обработка по заданной ссылке и указанным парметрам (: - ограничение маршрута, ** - все что идёт после записывается в переменную, 
// alpha - строка должна состоять из одного и более алфавитных символов.)
/*app.Map(
    "/users/{name:alpha:minlength(2)}/{age:int:range(1, 110)}",
    (string name, int age) => $"User Age: {age} \nUser Name:{name??"Ser gey"}"
);
app.Map(
    "/phonebook/{phone:regex(^7-\\d{{3}}-\\d{{3}}-\\d{{4}}$)}/",
    (string phone) => $"Phone: {phone}."
);*/

//app.UseMiddleware<PersonMiddleware>();

app.Map("/hello", (ILogger<Program> logger) => {
    logger.LogInformation("Wow, its logs!");
    return "hello";
});

app.Map("/hi", (ILoggerFactory loggerFactory) => {
    ILogger logger = loggerFactory.CreateLogger("DefaultFile");
    logger.LogInformation("Wow, its logs!");
    return "hello";
});

// добавляет компонент middleware, который позволяет передать обработку запроса далее следующим в конвейере компонентам.
/*app.Use(async (context, next) => 
{
    await next.Invoke();

    if(context.Response.StatusCode == 404)
        await context.Response.WriteAsync("Resource Not Found!");
});*/

app.Run();