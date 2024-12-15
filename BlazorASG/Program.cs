//using BlazorASG;
//using BlazorASG.Application_Layer.Interfaces;
//using BlazorASG.Application_Layer.Repositories;
//using BlazorASG.Application_Layer.Use_Cases.Auth;
//using BlazorASG.Data;
//using CardShopping.Web.Token;
//using Microsoft.AspNetCore.Components;
//using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
//using Microsoft.AspNetCore.Components.Web;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;
//using MudBlazor;
//using MudBlazor.Services;
//using Blazorise.Captcha.ReCaptcha;
//using Blazorise;

//var builder = WebApplication.CreateBuilder(args);
//string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial catalog=MDB_Use;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
//builder.Services.AddRazorComponents()
//    .AddInteractiveServerComponents();

//builder.Services.AddDbContext<UseDbContext>(options =>
//{
//    options.UseSqlServer(connectionString);
//});
//// Add services to the container.  
//builder.Services.AddHttpClient("ApiClient", client =>
//{
//    client.BaseAddress = new Uri("http://asg.tryasp.net/");
//});
///////////////////////////////////////////


//builder.Services
//    .AddBlazorise(options =>
//    {
//        options.Immediate = true;
//    })
//    .AddBlazoriseGoogleReCaptcha(reCaptchaOptions =>
//    {
//        reCaptchaOptions.SiteKey = "dddddddgffee";
//        //Set any other ReCaptcha options here...
//    });


//////////////////////////////////////////
//builder.Services.AddSingleton<ILoggerService,ConsoleLoggerService>();
//builder.Services.AddScoped<IRAuth,RepostryAuth>();
//builder.Services.AddScoped<CreateLogin>();

////////////////////////////////////////////
//builder.Services.AddRazorPages();
//builder.Services.AddServerSideBlazor();
//builder.Services.AddSingleton<WeatherForecastService>();
//builder.Services.AddMudServices();
//builder.Services.AddScoped<ProtectedSessionStorage>();
//builder.Services.AddTransient<Auth>();
//builder.Services.AddDistributedMemoryCache();
//builder.Services.AddIdentity<IdentityUser, IdentityRole>()
//     .AddRoles<IdentityRole>()
//     .AddRoleManager<RoleManager<IdentityRole>>()
//     .AddSignInManager<SignInManager<IdentityUser>>()
//     .AddUserManager<UserManager<IdentityUser>>()
//    .AddEntityFrameworkStores<UseDbContext>();
//builder.Services.AddScoped<TokenService>();

//builder.Services.AddSession(options =>
//{
//    options.IdleTimeout = TimeSpan.FromMinutes(100);
//    options.Cookie.HttpOnly = true;
//    options.Cookie.IsEssential = true;
//});
//var app = builder.Build();
//builder.Services.AddSignalR();
//app.MapHub<ChatHub>("/chathub");

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

//app.UseHttpsRedirection();

//app.UseStaticFiles();

//app.UseRouting();
//app.UseSession();
//app.MapBlazorHub();
//app.MapFallbackToPage("/_Host");
//await ATTK.Load();
//app.Run();
using BlazorASG;
using BlazorASG.Application_Layer.Interfaces;
using BlazorASG.Application_Layer.Repositories;
using BlazorASG.Application_Layer.Use_Cases.Auth;
using BlazorASG.Data;
using CardShopping.Web.Token;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MudBlazor;
using MudBlazor.Services;
using Blazorise.Captcha.ReCaptcha;
using Blazorise;

var builder = WebApplication.CreateBuilder(args);

// ﬁ«⁄œ… «·»Ì«‰« 
string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MDB_Use;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
builder.Services.AddDbContext<UseDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

//  ”ÃÌ· SignalR
builder.Services.AddSignalR();

// ≈÷«›… Œœ„«  Blazor Ê Blazorise
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services
    .AddBlazorise(options =>
    {
        options.Immediate = true;
    })
    .AddBlazoriseGoogleReCaptcha(reCaptchaOptions =>
    {
        reCaptchaOptions.SiteKey = "dddddddgffee";
    });

// Œœ„«  «·„‘—Ê⁄
builder.Services.AddSingleton<ILoggerService, ConsoleLoggerService>();
builder.Services.AddScoped<IRAuth, RepostryAuth>();
builder.Services.AddScoped<CreateLogin>();
builder.Services.AddTransient<Auth>();
builder.Services.AddScoped<TokenService>();

// Œœ„«  MudBlazor
builder.Services.AddMudServices();

// Œœ„«  Blazor
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<ProtectedSessionStorage>();

// «·ÂÊÌ… (Identity)
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddRoles<IdentityRole>()
    .AddRoleManager<RoleManager<IdentityRole>>()
    .AddSignInManager<SignInManager<IdentityUser>>()
    .AddUserManager<UserManager<IdentityUser>>()
    .AddEntityFrameworkStores<UseDbContext>();

// «· Œ“Ì‰ «·„ƒﬁ  Ê«·Ã·”« 
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(100);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// »‰«¡ «· ÿ»Ìﬁ
var app = builder.Build();

// ≈⁄œ«œ SignalR
app.MapHub<ChatHub>("/chathub");

// ≈⁄œ«œ «·‹ Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

await ATTK.Load();

app.Run();
