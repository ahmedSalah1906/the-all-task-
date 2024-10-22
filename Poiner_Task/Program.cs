using Microsoft.EntityFrameworkCore;
using Poiner_Task.Models;
using Poiner_Task.Repository.Employees;
using Poiner_Task.Repository.Propertys;
using Poiner_Task.Service;
using Poiner_Task.Service.Propertys;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<PoinerTaskContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("cs")));
builder.Services.AddScoped<IEmployeeservice, EmployeeService>();
builder.Services.AddScoped<IEmployeeRepository, EmpRepository>();
builder.Services.AddScoped<IPropertyService, PropertyService>();
builder.Services.AddScoped<IPropertyRepository, PropertyRepository>();

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
app.UseDeveloperExceptionPage();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
