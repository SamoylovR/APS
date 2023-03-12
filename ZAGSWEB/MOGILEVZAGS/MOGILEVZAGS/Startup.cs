using Microsoft.EntityFrameworkCore;
using MOGILEVZAGS.DataAccess;
using MOGILEVZAGS.DataAccess.Services;

namespace MOGILEVZAGS
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        private const string AngularClientName = "MarketClient";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DBContext>(options =>
                        options.UseSqlServer(Configuration
                            .GetSection("ConnectionStrings")
                                .GetValue<string>("DefaultDbConnection")));

            services.AddTransient<IClientsService, ClientsService>();

            //services
            //    .AddControllers()
            //    .AddNewtonsoftJson(options =>
            //    {
            //        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            //        options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
            //    });

            //services
            //    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            //    .AddCookie();

            services.AddRazorPages();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });

            //app.UseAuthorization();
        }
    }
}
