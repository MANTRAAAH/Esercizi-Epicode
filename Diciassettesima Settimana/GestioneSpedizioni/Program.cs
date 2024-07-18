using GestioneSpedizioni.Models;
using GestioneSpedizioni.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Leggi la connection string dal file di configurazione
var configuration = builder.Configuration;
string connectionString = configuration.GetConnectionString("DefaultConnection");

// Aggiungi un logging per verificare la stringa di connessione
Console.WriteLine($"Connection String: {connectionString}");

// Registra DatabaseManager nel container DI
builder.Services.AddScoped<DatabaseManager>(serviceProvider =>
{
    var logger = serviceProvider.GetRequiredService<ILogger<DatabaseManager>>();
    return new DatabaseManager(connectionString, logger);
});
// Inside ConfigureServices method in Startup.cs
builder.Services.AddScoped<ISpedizioneService, SpedizioneService>();


// Configura l'autenticazione con cookie
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Auth/Login";
        options.LogoutPath = "/Auth/Logout";
        options.AccessDeniedPath = "/Account/AccessDenied";
    });
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireUserRole", policy => policy.RequireRole("User"));
    options.AddPolicy("RequireEmployeeRole", policy => policy.RequireRole("Dipendente"));
});

// Aggiungi altri servizi necessari
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Abilita l'autenticazione e l'autorizzazione
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
