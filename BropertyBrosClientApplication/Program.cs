using Blazored.LocalStorage;
using BropertyBrosClientApplication.Components;

using BropertyBrosClientApplication.Components.Account;
using BropertyBrosClientApplication.Data;
using BropertyBrosClientApplication.Providers;
using BropertyBrosClientApplication.Services;
using BropertyBrosClientApplication.Services.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
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

            builder.Services.AddHttpClient("BropertyBrosApi2.0", client =>
            {
                client.BaseAddress = new Uri("https://localhost:7151/");
            });
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddScoped<ApiAuthStateProvider>();
            builder.Services.AddScoped<AuthenticationStateProvider>(s => s.GetRequiredService<ApiAuthStateProvider>());
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<RealtorService>();
            builder.Services.AddScoped<PropertyService>();
            builder.Services.AddScoped<CityService>();
            builder.Services.AddScoped<RealtorFirmService>();

            builder.Services.AddScoped<IClient>(provider =>
            {
                var httpClient = provider.GetRequiredService<HttpClient>();
                httpClient.BaseAddress = new Uri(builder.Configuration["ApiSettings:BaseUrl"]);
                return new Client(httpClient);
            });

            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();




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

            app.UseAuthorization();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();


            app.Run();
        }
    }
}