using EFCore_Application.Contract.ProductCategory;
using EFCore_Application;
using EFCore.Domain.ProductCategoryAgg;
using EFCore_Infrasturactures.EfCore.Repository;
using EFCore_Infrasturactures.EfCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<IProductCategoryApplication, ProductCategoryApplication>();
builder.Services.AddScoped<IProductCategoryRepository,ProductCategoryRepository>();
builder.Services.AddDbContext<EfContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("EFCoreProject"));
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
