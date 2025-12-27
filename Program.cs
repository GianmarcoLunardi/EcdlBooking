using EcdlBooking.AutoMapper;
using EcdlBooking.Data;
using EcdlBooking.Models;
using EcdlBooking.Services.Interfaces;
using EcdlBooking.Services.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using EcdlBooking.Configurazione;
using Microsoft.Extensions.DependencyInjection;
using EcdlBooking.Services.IService;
using EcdlBooking.Services.Service;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();


// Manca la definizione  dell usermanager

// inserimento del servizio di automapper

builder.Services.AddAutoMapper(typeof(ExamProfile), 
                               typeof(UserProfile),
                               typeof(SchoolProfile));
/*
builder.Services.AddAutoMapper(typeof(UserProfile));
builder.Services.AddAutoMapper(typeof(SchoolProfile));
builder.Services.AddAutoMapper(typeof(ExamProfile));
*/

builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.Password.RequiredLength = 8;
    options.Password.RequireDigit = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;

    options.SignIn.RequireConfirmedAccount = false;
})


  // Aggiunge il supporto ai ruoli
    .AddRoles<IdentityRole>()
    .AddRoleManager<RoleManager<IdentityRole>>()
            
   // Inserimento del gestore dei ruoli

    .AddUserManager<UserManager<ApplicationUser>>()
    .AddSignInManager<SignInManager<ApplicationUser>>()

    // Utilizzo del gestore base dati
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();


// inserimento dei servizi
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUteneteService, UteneteService>();

var app = builder.Build();
// chiamata del seeding statico / dinamico
await Configurazione.SeedAsync(app.Services);




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{Area=User}/{controller=Studenti}/{action=Index}/{id?}");
app.MapRazorPages(); 
app.Run();
