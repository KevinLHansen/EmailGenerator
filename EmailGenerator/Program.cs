using EmailGenerator.Services;

namespace EmailGenerator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            ConfigureServices(builder.Services);

            var app = builder.Build();

            ConfigureApp(app);

            app.Run();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddRazorPages();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddHttpClient();

            services.AddTransient<RandomWordProvider>();
        }

        private static void ConfigureApp(WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
        }
    }
}