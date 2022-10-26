using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Webdev_project_1.Data;
using Webdev_project_1.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<UFO_context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UFO_context") ?? throw new InvalidOperationException("Connection string 'UFO_context' not found.")));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<UFO_context>();
    //context.Database.EnsureDeleted();
    context.Database.EnsureCreated();
    SeedData.Initialize(services);
    // DbInitializer.Initialize(context);
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
