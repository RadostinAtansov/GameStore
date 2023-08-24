using GameStore.Data;
using GameStore.Config;
using GameStore.Data.Services;
using Microsoft.EntityFrameworkCore;
using GameStore.Data.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using GameStore.Models.UserModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<GameStoreDataDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<GameStoreDataDbContext>();

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<GameStoreDataDbContext>();

//builder.Services.AddDefaultIdentity<UserViewModel>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<GameStoreDataDbContext>();

//builder.Services.AddIdentity<IdentityUser, IdentityRole>()
//    .AddEntityFrameworkStores<GameStoreDataDbContext>()
//    .AddDefaultTokenProviders();
//builder.Services.AddDefaultIdentity<IdentityUser>().AddRoles<IdentityRole>();

builder.Services.AddTransient<IGameService, GameService>();
builder.Services.AddTransient<IHomeService, HomeService>();

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