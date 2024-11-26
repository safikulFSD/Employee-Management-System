using EFCoreWithAsp.netCore.Models;
using EFCoreWithAsp.netCore.Repositories;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("EmpMngtConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));


//Register Department service
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
//Register Employee service
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

var app = builder.Build();




// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
