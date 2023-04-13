var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();

// Позволяет обслуживать файлы
app.UseStaticFiles();
app.UseRouting();


app.MapControllers();

// Включает обслуживание документа по умолчанию для любого неизвестного запроса, получаемого сервером
app.MapFallbackToFile("index.html"); ;

app.Run();
