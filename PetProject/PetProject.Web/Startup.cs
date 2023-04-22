//using Client.Application.Services.Converters;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PetProject.Web.Configuration;

namespace PetProject.Web
{
    public class Startup
    {
        private readonly ILogger<Startup> mLogger;
        private JsonSerializerSettings mJsonSerializerSettings;

        public Startup(ILogger<Startup> logger, IConfiguration configuration)
        {
            Configuration = configuration;
            mLogger = logger;
        }

        /// <summary>
        /// Настройки WebHost
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Вызывается средой выполнения. Использовать для добавление сервисов в контейнер
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.RegistrationUserMsSqlServices(Configuration);

            services.AddOrchestrators(Configuration);;
            services.AddControllers();
            services.AddCors();
            services.AddDataLayer();
            services.AddAuthorization(Configuration);

            // добавление сервиса компрессии
            //services.AddResponseCompression(options => options.EnableForHttps = true);
            // - следующая строка: быстрее и эффективнее на больших данных. Но испольуется компрессия на всем проекте,
            // поэтому используем по умолчанию - быструю компрессию

            //services.AddCacheService();

            // добавление кэширования
            //services.AddMemoryCache();

            services.AddAntiforgery(options =>
            {
                options.HeaderName = "X-XSRF-TOKEN";
                options.Cookie.SameSite = SameSiteMode.None;
                options.Cookie.SecurePolicy = CookieSecurePolicy.None;
                options.Cookie.HttpOnly = true;
            });

            // In production, the Angular files will be served from this directory
            /*services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist/app";
            });*/
        }

        /// <summary>
        /// Вызывается средой выполнения. Использовать для конфигурации HTTP запросов
        /// </summary>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IAntiforgery antiforgery, IConfiguration configuration, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseCors(builder => builder.WithOrigins("https://localhost:44477")
                            .AllowAnyHeader()
                            .AllowAnyMethod());
            }
            else
                app.UseExceptionHandler("/Error");

            app.UseCookiePolicy(
                new CookiePolicyOptions()
                {
                    MinimumSameSitePolicy = SameSiteMode.None,
                    Secure = CookieSecurePolicy.None
                }
            );

            app.UseStaticFiles();
            
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });

            // подключение компрессии
            //app.UseResponseCompression();

            //app.UseSpaStaticFiles();
            /*app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                    spa.UseProxyToSpaDevelopmentServer("https://localhost:44477");
            });*/
        }
    }
}
