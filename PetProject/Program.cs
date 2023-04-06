using PetProject.Controllers;
using PetProject.Configuration;

// изменяем папку для хранения статических файлов
var builder = WebApplication.CreateBuilder(new WebApplicationOptions {WebRootPath = "static"}); 

builder.Services.AddTransient<TimeService>();
//builder.Services.AddSingleton<StartService>();
//builder.Services.AddSingleton<IReadText>(serv => serv.GetRequiredService<StartService>());
//builder.Services.AddSingleton<IGenerateText>(serv => serv.GetRequiredService<StartService>());
 
var app = builder.Build();

// поддержка страниц html по умолчанию, добавляем поддержку статических файлов
app.UseFileServer();

// Конечные точки, обработка по заданной ссылке и указанным парметрам (: - ограничение маршрута, ** - все что идёт после записывается в переменную, 
// alpha - строка должна состоять из одного и более алфавитных символов.)
app.Map(
    "/users/{name:alpha:minlength(2)}/{age:int:range(1, 110)}",
    (string name, int age) => $"User Age: {age} \nUser Name:{name??"Ser gey"}"
);
app.Map(
    "/phonebook/{phone:regex(^7-\\d{{3}}-\\d{{3}}-\\d{{4}}$)}/",
    (string phone) => CallByTelephone(new TimeService(), phone)
);

//app.Map("/", () => "Index Page");
app.Run(async (context) => await context.Response.WriteAsync("Hello Boss"));

//app.UseMiddleware<ReadMiddleware>();
//app.UseMiddleware<GenerateMiddleware>();

// добавляет компонент middleware, который позволяет передать обработку запроса далее следующим в конвейере компонентам.
app.Use(async (context, next) => 
{
    await next.Invoke();

    if(context.Response.StatusCode == 404)
        await context.Response.WriteAsync("Resource Not Found!");
});

app.Run();

string CallByTelephone(TimeService timeService, string phone)
{
    return $"Phone: {phone} at time: {timeService.Time}";
}

public class TimeService
{
    public string Time  =>  DateTime.Now.ToLongTimeString();
}