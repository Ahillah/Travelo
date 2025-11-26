
using DomainLayer.Models.IdentityModule;
using DomainLayer.Models.Users;
using DomainLayer.RepositoryInterface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Persistence;
using Persistence.RepositoryImplementation;
using ServiceAbstraction;
using ServiceImplementation;
using ServiceImplementation.IdentityService;
using System.Text;
using AutoMapper;

namespace Travelo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddDbContext<TraveloIdentityDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection"));



            });
            builder.Services.AddDbContext<TraveloIdentityDbContext>(options =>
            {
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("IdentityConnection"),
                    b => b.MigrationsAssembly("Persistence")
                );
            });
            builder.Services.AddAuthentication(
                cobfig =>
                {
                    cobfig.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    cobfig.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

                }
                ).AddJwtBearer(
                options =>
                {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = builder.Configuration.GetSection("JwtOptions")["Issuer"],
                    ValidateAudience= true,
                    ValidAudience= builder.Configuration.GetSection("JwtOptions")["Audience"],
                    ValidateLifetime= true,
                    IssuerSigningKey=new SymmetricSecurityKey((Encoding.UTF8.GetBytes(builder.Configuration.GetSection("JwtOptions")["SecretKey"])))

                };


                }
                );
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
              .AddEntityFrameworkStores<TraveloIdentityDbContext>()
              .AddDefaultTokenProviders();
            builder.Services.AddScoped<ITouristAuthService, TouristAuthService>();
           
            builder.Services.AddScoped<IHotelAuthService, HotelAuthService>();
            builder.Services.AddScoped<ITripRepository, TripRepository>();
            builder.Services.AddScoped<ITripService, TripService>();
            builder.Services.AddScoped<ILocationRepository, LocationRepository>();
            builder.Services.AddScoped<IPaymentService, PaymentService>();
            builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
            builder.Services.AddAutoMapper(typeof(ServiceImplementation.MappingProfiles.TripProfile).Assembly);
            builder.Services.AddAutoMapper(typeof(ServiceImplementation.MappingProfiles.PaymentProfile).Assembly);


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
