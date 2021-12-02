using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantAPI.Entities;
using RestaurantAPI.Services;
using RestaurantAPI.Middleware;
using RestaurantAPI.Authorization;
using RestaurantAPI.Models;
using RestaurantAPI.Models.Validators;
using Microsoft.AspNetCore.Identity;
using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace RestaurantAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) 
        {
            var authenticationSettings = new AuthenticationSettings();

            Configuration.GetSection("Authentication").Bind(authenticationSettings); // po��czenie sekcji Authentication z appsettings.json z obiektem AuthenticationSettings


            services.AddSingleton(authenticationSettings);
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = "Bearer";
                option.DefaultScheme = "Bearer";
                option.DefaultChallengeScheme = "Bearer";
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;   // ma zapisa� po stronie serwera
                cfg.TokenValidationParameters = new TokenValidationParameters   // parametry walidacji tego tokenu
                {
                    ValidIssuer = authenticationSettings.JwtIssuer,     // wydawca tokenu
                    ValidAudience = authenticationSettings.JwtIssuer,   // dopuszczone podmioty do u�ywania autentykacji tego tokenu
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey)), // prywatny klucz zale�ny od JwtKey
                };
            });

            services.AddAuthorization(option =>
            {
                option.AddPolicy("HasNationality", builder => builder.RequireClaim("Nationality", "German", "Polish"));
            });

            services.AddAuthorization(option =>
            {
                option.AddPolicy("AtLeast20", builder => builder.AddRequirements(new MinimumAgeRequirement(20)));
            });

            services.AddAuthorization(option =>
            {
                option.AddPolicy("AtLeast2Restaurants", builder => builder.AddRequirements(new MinimumRestaurantsRequirement(2)));
            });

            
            services.AddScoped<IAuthorizationHandler, MinimumAgeRequirementHandler>();
            services.AddScoped<IAuthorizationHandler, ResourceOperationRequirementHandler>();
            services.AddScoped<IAuthorizationHandler, MinimumRestaurantsRequirementHandler>();
            services.AddControllers().AddFluentValidation();    // �eby fluentValidation zadzia�a�o trzeba je doda� do kontrolera
            services.AddAutoMapper(this.GetType().Assembly);    // dodanie automappera do serwis�w
            services.AddScoped<IRestaurantService, RestaurantService>();    // rejestracja interfejsu
            services.AddScoped<IDishService, DishService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
            services.AddScoped<IValidator<RegisterUserDto>, RegisterUserDtoValidation>();   // rejestracja interfejsu IValidator z FluentValidation dla rzutowania rejestracji
            services.AddScoped<IValidator<RestaurantQuery>, RestaurantQueryValidation>();
            services.AddScoped<ErrorHandlingMiddleware>();  // rejestracja w serwisach ErrorHandlingMiddleware
            services.AddScoped<RequestTimeMiddleware>();    // rejestracja w serwisach RequestTimeMiddleware
            services.AddScoped<IUserContextService, UserContextService>();
            services.AddHttpContextAccessor();  // zezwala na wstrzykni�cie IHttpContextAccessor
            services.AddSwaggerGen();   // dodanie Swaggera do serwis�w
            services.AddCors(options =>
            {
                options.AddPolicy("FrontEndClient", builder => builder.AllowAnyMethod()
                .AllowAnyHeader()
                .WithOrigins(Configuration["AllowedOrigins"])); // dzieki allowed origins nie trzeba hardcode'owa� strony
                //.AllowAnyOrigin());
            });


            services.AddDbContext<RestaurantDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("RestaurantDbConnection")));   // dodanie kontekstu bazy danych (HttpContext)
            services.AddScoped<RestaurantSeeder>(); // dodaje przyk�adowe warto�ci (seeduje) do bazy danych

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, RestaurantSeeder seeder)
        {
            app.UseResponseCaching();
            app.UseStaticFiles(); // na pocz�tku, �eby od pocz�tku wiedzie� czy istnieje plik, o kt�ry mo�e zapyta� u�ytkownik
            // pami�ta� zeby pliki pod inn� �cie�k� ni� API czyli nie po /api w zapytaniu http
            app.UseCors("FrontEndClient"); // dla innej polityki, wystarczy poda� odpowiedni� dla niej nazw�
            seeder.Seed();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMiddleware<ErrorHandlingMiddleware>();   // musi by� przed UseHttpRedirection()
            app.UseMiddleware<RequestTimeMiddleware>();
            app.UseAuthentication();
            app.UseHttpsRedirection();

            app.UseSwagger(); // !!
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Restaurant API");
            });

            app.UseRouting(); // mi�dzy tym

            app.UseAuthorization(); 

            app.UseEndpoints(endpoints => // a tym uzywamy autoryzacji
            {
                endpoints.MapControllers();
            });
        }
    }
}
