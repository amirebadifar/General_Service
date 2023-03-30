using CoreLayer.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

#region SqlServer

builder.Services.AddDbContext<DataLayer.DB_Context>(o =>
    o.UseSqlServer(builder.Configuration.GetValue<string>("SQL:Connection")));

#endregion

#region Identity

builder.Services.AddAuthentication(o =>
    {
        o.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        o.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        o.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    })
    .AddCookie(o =>
    {
        o.LoginPath = "/admin/login";
        o.LogoutPath = "/admin/logout";
        o.ExpireTimeSpan = TimeSpan.FromDays(builder.Configuration.GetValue<int>("CountDateIdentity"));
    });

#endregion

#region IOC

builder.Services.AddScoped<DataLayer.DB_Context, DataLayer.DB_Context>();

builder.Services.AddTransient<IAboutService, AboutService>();
builder.Services.AddTransient<IServiceService, ServiceService>();
builder.Services.AddTransient<IWorkSampleService, WorkSampleService>();
builder.Services.AddTransient<IQuestionService, QuestionService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IContactService, ContactService>();
builder.Services.AddTransient<IAdminService, AdminService>();
builder.Services.AddTransient<IOtherService, OtherService>();

#endregion

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error");
    app.UseHsts();
}

app.Use(async (context, next) =>
    {
        await next();
        if (context.Response.StatusCode == 404)
        {
            context.Response.Redirect("/404");
            return;
        }
    });

if (!builder.Configuration.GetValue<bool>("Activity"))
{
    app.Use(async (context, next) =>
    {
        await next();
        context.Response.Redirect("/error");
        return;
    });
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "MyArea",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();