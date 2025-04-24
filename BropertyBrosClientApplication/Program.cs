using Blazored.LocalStorage;
using BropertyBrosClientApplication.Components;
using BropertyBrosClientApplication.Data;
using BropertyBrosClientApplication.Services;
using BropertyBrosClientApplication.Services.Authentication;
using BropertyBrosClientApplication.Services.Base2;
using BropertyBrosClientApplication.Services.Providers;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BropertyBrosClientApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            builder.Services.AddCascadingAuthenticationState();

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddScoped<ApiAuthenticationStateProvider>();
            builder.Services.AddScoped<AuthenticationStateProvider>(s => 
                s.GetRequiredService<ApiAuthenticationStateProvider>());
            builder.Services.AddAuthenticationCore();

            builder.Services.AddHttpClient("BropertyBrosApi2.0", client =>
            {
                client.BaseAddress = new Uri("https://localhost:7151/");
            });
            builder.Services.AddScoped<CategoryService>();
            builder.Services.AddScoped<RealtorService>();
            builder.Services.AddScoped<PropertyService>();
            builder.Services.AddScoped<CityService>();
            builder.Services.AddScoped<RealtorFirmService>();
            builder.Services.AddScoped<IClient, Client>();
            builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();


            app.Run();
        }
    }
}
