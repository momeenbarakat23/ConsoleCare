using Console_Care.orderforcust;
using Console_Care.Models;
using Microsoft.EntityFrameworkCore;
using Console_Care.identity;
using Microsoft.AspNetCore.Identity;
using Console_Care.Securty;
using Console_Care.DeleteAllData;
using Console_Care.CustomerDataBase;
using Console_Care.Iinvoice;
using System.Configuration;



var builder = WebApplication.CreateBuilder(args);
var mycon = builder.Configuration.GetConnectionString("mycon");
builder.Services.AddDbContext<Appdbcontext>(x => x.UseSqlServer(mycon));
builder.Services.AddScoped<Iorder, Order>();
builder.Services.AddScoped<IAuth, Auth>();
builder.Services.AddScoped<IDelete, Delete>();
builder.Services.AddScoped<ICustomerDataBase, CustomerDB>();
builder.Services.AddScoped<Iinvoice, Invoices>();





builder.Services.AddIdentity<Appuser,IdentityRole>(op=>
{
    op.User.RequireUniqueEmail = true;
    op.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
}).AddEntityFrameworkStores<Appdbcontext>()
.AddDefaultTokenProviders();
// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
