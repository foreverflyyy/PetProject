using DBRepository.Interfaces;
using DBRepository;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration; // ������ � ����� ������������
    }
    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();

        services.AddScoped<IRepositoryContextFactory, RepositoryContextFactory>();
        services.AddScoped<IBlogRepository>(provider => 
            new BlogRepository(Configuration.GetConnectionString("DefaultConnection"), provider.GetService<IRepositoryContextFactory>()));
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseWebpackDevMiddleware(); // �������� ��������� webpack
        }

        app.UseStaticFiles();
        app.UseMvc(routes =>
        {
            routes.MapRoute(
                name: "DefaultApi",
                template: "api/{controller}/{action}");
            // ��������� ����������� �������� (���� ��� �������������� �������� ������������� �������� ��������)
            routes.MapSpaFallbackRoute("spa-fallback", new { controller = "Home", action = "Index" }); 
        });
    }
}