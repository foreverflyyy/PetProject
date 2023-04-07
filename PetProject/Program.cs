var builder = WebApplication.CreateBuilder(args);

// добавляем поддержку контроллеров и представлений
builder.Services.AddControllersWithViews();

// добавляем сервис ITimeService
builder.Services.AddTransient<ITimeService, SimpleTimeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
   app.UseExceptionHandler("/Home/Error");
   app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// сопоставление маршрутов с контроллерами, использование только маршрутизацию на основе атрибутов
app.MapControllers();

app.Run();


public interface ITimeService
{
   string Time { get; }
}
public class SimpleTimeService : ITimeService
{
   public string Time => DateTime.Now.ToString("hh:mm:ss");
}
