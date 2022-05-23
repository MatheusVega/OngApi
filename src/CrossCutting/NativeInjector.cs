using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using AM.Amil.PeNaAreia.CrossCutting.Middleware;
using AM.Amil.PeNaAreia.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using Microsoft.Extensions.FileProviders;
using System.IO;
using AutoMapper;
using NLog;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System;
using System.Security.Claims;
using System.Linq;
using System.Threading.Tasks;
using Amazon.S3;
using AM.Amil.PeNaAreia.CrossCutting.Swagger;
using System.Text.Json.Serialization;
using AM.Amil.PeNaAreia.CrossCutting.InjetorEscopo;
using AM.Amil.PeNaAreia.Data.Mapping;

namespace AM.Amil.PeNaAreia.CrossCutting
{
    public class NativeInjector
    {
        public static IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PhmContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("Default"), sqlServerOptions => sqlServerOptions.CommandTimeout(60));
                options.EnableDetailedErrors(true);
                options.EnableSensitiveDataLogging(true);
            });

            var mapperConfig = new MapperConfiguration( mc => 
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            RepositoriesScopeInjector.Add(services);
            ServicesScopeInjector.Add(services, Configuration);

            services.AddSingleton<ILogger>(LogManager.GetCurrentClassLogger());

            services.AddCors(o => o.AddPolicy("Policy", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));

           // JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
           // services.AddAuthentication(options =>
           //{
           //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
           //    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
           //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
           //})
           // .AddJwtBearer(cfg =>
           // {
           //     cfg.RequireHttpsMetadata = false;
           //     cfg.SaveToken = true;
           //     cfg.TokenValidationParameters = new TokenValidationParameters
           //     {
           //         ValidIssuer = Configuration["JwtIssuer"],
           //         ValidAudience = Configuration["JwtIssuer"],
           //         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtKey"])),
           //         ClockSkew = TimeSpan.Zero // remove delay of token when expire
           //     };
           //     cfg.Events = new JwtBearerEvents
           //     {
           //         OnTokenValidated = context =>
           //         {
           //             // Add the access_token as a claim, as we may actually need it
           //             var accessToken = context.SecurityToken as JwtSecurityToken;
           //             if (accessToken != null)
           //             {
           //                 ClaimsIdentity identity = context.Principal.Identity as ClaimsIdentity;
           //                 if (identity != null)
           //                 {
           //                     var perfisDeAcesso = accessToken.Claims.Where(c => c.Type == ClaimTypes.Role).Select(x => x.Value).Distinct().ToList();
           //                     perfisDeAcesso.ForEach(x => identity.AddClaim(new Claim(ClaimTypes.Role, x)));

           //                     identity.AddClaim(new Claim("id", accessToken.Claims.Where(c => c.Type == "id").First().Value));
           //                     identity.AddClaim(new Claim("cpf", accessToken.Claims.Where(c => c.Type == "cpf").First().Value));
           //                 }
           //             }

           //             return Task.CompletedTask;
           //         }
           //     };
           // });

            services.AddControllers()
                .AddJsonOptions(options =>
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

            services.AddSwaggerGen();
            services.ConfigureOptions<OpcoesSwagger>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware(typeof(ExceptionHandleMiddleware));

            var usCulture = new CultureInfo("pt-BR");
            var supportedCultures = new[] { usCulture };


            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(usCulture),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });

            app.UseCors("Policy");

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "")),
                RequestPath = "",
            });
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("./v1/swagger.json", "PHM Sistemas");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
