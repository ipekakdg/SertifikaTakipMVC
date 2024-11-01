using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Contracts;
using Services;
using Services.Contracts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages()
                .AddRazorRuntimeCompilation();      //Deðiþiklikleri anlýk olarak görmek için

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options=>
{
    options.Cookie.Name = ".MySessionCookie";
    options.IdleTimeout = TimeSpan.FromMinutes(30);   //Session ayarlarý
}
    );



builder.Services.AddDbContext<RepositoryContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("sqlconnection"),       //bir baðlantý dizesi verme ve sql server servisinin eklenmesi 
    b => b.MigrationsAssembly("SertifikaKontrol"));        //migration yaparken hedef projeyi belirtme
});

builder.Services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();  //Session iþlemleri

builder.Services.AddScoped<IRepositoryManager,RepositoryManager>(); //AddScoped dependency injection için kullanýmý
builder.Services.AddScoped<IApplicationRepository,ApplicationRepository>();
builder.Services.AddScoped<ICertificateRepository,CertificateRepository>();
builder.Services.AddScoped<INotificationRepository,NotificationRepository>();
builder.Services.AddScoped<IEmployeeRepository,EmployeeRepository>();

builder.Services.AddScoped<IServiceManager,ServiceManager>();
builder.Services.AddScoped<IApplicationService,ApplicationManager>();
builder.Services.AddScoped<ICertificateService,CertificateManager>();
builder.Services.AddScoped<INotificationService,NotificationManager>();
builder.Services.AddScoped<IEmployeeService,EmployeeManager>();


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

app.UseAuthorization();
app.UseSession();   //Session kullanmak için


app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        name: "Admin",
        areaName: "Admin",
        pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}");
    endpoints.MapControllerRoute("default","{controller=Login}/{action=Login}/{id?}");

});

app.Run();
