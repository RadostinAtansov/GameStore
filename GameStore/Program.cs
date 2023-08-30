using GameStore.Data;
using GameStore.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using GameStore.Data.Services;
using GameStore.Data.Services.Interfaces;
using GameStore.Data.Models.Services;
using GameStore.Data.Models;
using Microsoft.Identity.Client;
//using GameStore.Models.UserModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<GameStoreDataDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<GameStoreDataDbContext>();

builder.Services.AddTransient<IGameService, GameService>();
builder.Services.AddTransient<IHomeService, HomeService>();
builder.Services.AddTransient<IAccountService, AccountService>();


builder.Services.Configure<AppSettings>(builder.Configuration.GetSection(nameof(AppSettings)));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.Run();