using CoreLayer.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

#region SqlServer

builder.Services.AddDbContext<DataLayer.DB_Context>(o =>
    o.UseSqlServer("Data Source =.;Initial Catalog=DB_General_Service;Integrated Security=true;TrustServerCertificate=True"));

#endregion

//#region Identity

//builder.Services.AddAuthentication(o =>
//    {
//        o.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//        o.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//        o.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//    })
//    .AddCookie(o =>
//    {
//        o.LoginPath = "/login";
//        o.LogoutPath = "/logout";
//        o.ExpireTimeSpan = TimeSpan.FromDays(30);
//    });

//#endregion

#region IOC

builder.Services.AddScoped<DataLayer.DB_Context, DataLayer.DB_Context>();

builder.Services.AddTransient<IAboutService, AboutService>();
builder.Services.AddTransient<IServiceService, ServiceService>();
builder.Services.AddTransient<IWorkSampleService, WorkSampleService>();
builder.Services.AddTransient<IQuestionService, QuestionService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IContactService, ContactService>();
builder.Services.AddTransient<IOtherService, OtherService>();

#endregion

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error");
    app.UseHsts();
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