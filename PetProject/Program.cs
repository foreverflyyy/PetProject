using PetProject.Controllers;
using PetProject.Configuration;
using PetProject.FileLogger;
using PetProject.Sessions;

// изменяем папку для хранения статических файлов
//var builder = WebApplication.CreateBuilder(new WebApplicationOptions {WebRootPath = "static"}); 
var builder = WebApplication.CreateBuilder(); 

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

// устанавливаем файл для логгирования
builder.Logging.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "logger.txt"));

//builder.Services.AddTransient<TimeService>();
//builder.Services.AddSingleton<StartService>();
//builder.Services.AddSingleton<IReadText>(serv => serv.GetRequiredService<StartService>());
//builder.Services.AddSingleton<IGenerateText>(serv => serv.GetRequiredService<StartService>());

builder.Configuration.AddJsonFile("settings.json");
builder.Services.Configure<Person>(builder.Configuration);

var app = builder.Build();

app.UseSession();

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

// Два вида реализации логгов
app.Map("/hello", (ILogger<Program> logger) => {
    logger.LogInformation("Wow, its logs!");
    return "hello";
});

app.Map("/hi", (ILoggerFactory loggerFactory) => {
    ILogger logger = loggerFactory.CreateLogger("DefaultFile");
    logger.LogInformation("Wow, its logs!");
    return "hello";
});

app.Run(async (context) =>
{
    // Если у нас уже в сессии(в словаре сессии) имеется запись с нужным ключом, то выводим её, если нет, то записываем
    if (context.Session.Keys.Contains("person"))
    {
        Person? person = context.Session.Get<Person>("person");
        await context.Response.WriteAsync($"Hello {person?.Name}, your age: {person?.Age}!");
    }
    else
    {
        Person person = new Person { Name = "Tom", Age = 22 };
        context.Session.Set<Person>("person", person);
        await context.Response.WriteAsync("Hello World! I created new sessions data");
    }
});

// добавляет компонент middleware, который позволяет передать обработку запроса далее следующим в конвейере компонентам.
/*app.Use(async (context, next) => 
{
    await next.Invoke();

    if(context.Response.StatusCode == 404)
        await context.Response.WriteAsync("Resource Not Found!");
});*/

app.Run();