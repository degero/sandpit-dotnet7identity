using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using aspcoreidentity.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("aspcoreidentityIdentityDbContextConnection") ?? throw new InvalidOperationException("Connection string 'aspcoreidentityIdentityDbContextConnection' not found.");

builder.Services.AddDbContext<aspcoreidentityIdentityDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<aspcoreidentityIdentityDbContext>();

// Add services to the container.
builder.Services.AddRazorPages();
var config = builder.Configuration;
builder.Services.AddAuthentication().AddMicrosoftAccount(microsoftOptions =>
   {
       microsoftOptions.ClientId = config["Authentication:Microsoft:ClientId"];
       microsoftOptions.ClientSecret = config["Authentication:Microsoft:ClientSecret"];
   });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
