using DackorInventoryManagementSystem.Areas.Identity;
using DackorInventoryManagementSystem.Data;
using IMS.Plugins.EFCore;
using IMS.UseCases;
using IMS.UseCases.Activities;
using IMS.UseCases.Interfaces;
using IMS.UseCases.Inventories;
using IMS.UseCases.PluginInterfaces;
using IMS.UseCases.Products;
using IMS.UseCases.Reports;
using IMS.UseCases.Validations;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
builder.Services.AddSingleton<WeatherForecastService>();

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mgo+DSMBaFt/QHRqVVhkVFpHaV5HQmFJfFBmRGNTflZ6cFxWESFaRnZdQV1hSH1SdkRrXH9ceXNR;Mgo+DSMBPh8sVXJ0S0J+XE9AflRBQmJMYVF2R2BJfl56dV1MZFVBNQtUQF1hSn5Rd0ZiWX5WdXRWR2FZ;ORg4AjUWIQA/Gnt2VVhkQlFacldJXnxIe0x0RWFab19wflROalhYVAciSV9jS31TdERgWH9feHFVRWJZVA==;MTEyMDg5MUAzMjMwMmUzNDJlMzBGTlhUQXRpTGs2SUFrVXRCSi9LVlB3bEEzdWFiN1lSYmhaY2o5Q1VKZHdrPQ==;MTEyMDg5MkAzMjMwMmUzNDJlMzBCeU9IMWVUWXBpbWxYSmVhczh3a1N5aWpwMG1KSTlGdUIwakRneWdsbS9RPQ==;NRAiBiAaIQQuGjN/V0Z+WE9EaFtKVmBWf1ZpR2NbfE5xdF9HaFZVTWYuP1ZhSXxQdkdiWn5ecXxQRmNUUkQ=;MTEyMDg5NEAzMjMwMmUzNDJlMzBBa0V5WTIvaWN4N0dkUmNicjVqN09sU0d2RE00RUlBOVJoRVVtWGc0Wjc4PQ==;MTEyMDg5NUAzMjMwMmUzNDJlMzBTWFNWbzNOYUVyREtaQ2RrbXlCazY2NVZKYU8wbEx1a1JjSHJITkdvbFVrPQ==;Mgo+DSMBMAY9C3t2VVhkQlFacldJXnxIe0x0RWFab19wflROalhYVAciSV9jS31TdERgWH9feHFVQmRdVA==;MTEyMDg5N0AzMjMwMmUzNDJlMzBlV3kvOFZMdm1BNUdYZVc1NGV3Zjd1RENIWis3WUMxUVcyakx4aTVSRHBFPQ==;MTEyMDg5OEAzMjMwMmUzNDJlMzBBR2ZRSTUyVXhmWnB2QVBFV3N0Z3g3cDVmYmpROXBQWWlGMFgvSWR2cUpJPQ==;MTEyMDg5OUAzMjMwMmUzNDJlMzBBa0V5WTIvaWN4N0dkUmNicjVqN09sU0d2RE00RUlBOVJoRVVtWGc0Wjc4PQ==");

builder.Services.AddDbContext<IMSContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("InventoryManagement"));
});
//DI repositories
builder.Services.AddTransient<IInventoryRepository, InventoryRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IInventoryTransactionRepository, InventoryTransactionRepository>();
builder.Services.AddTransient<IProductTransactionRepository, ProductTransactionRepository>();

//DI use cases
builder.Services.AddTransient<IViewInventoriesByNameUseCase, ViewInventoriesByNameUseCase>();
builder.Services.AddTransient<IAddInventoryUseCase, AddInventoryUseCase>();
builder.Services.AddTransient<IEditInventoryUseCase, EditInventoryUseCase>();
builder.Services.AddTransient<IViewInventoryByIdUseCase, ViewInventoryByIdUseCase>();

builder.Services.AddTransient<IViewProductsByNameUseCase, ViewProductsByNameUseCase>();
builder.Services.AddTransient<IAddProductUseCase, AddProductUseCase>();
builder.Services.AddTransient<IViewProductByIdUseCase, ViewProductByIdUseCase>();
builder.Services.AddTransient<IEditProductUseCase, EditProductUseCase>();
builder.Services.AddTransient<IDeleteProductUseCase, DeleteProductUseCase>();
builder.Services.AddTransient<IPurchaseInventoryUseCase, PurchaseInventoryUseCase>();
builder.Services.AddTransient<IValidateEnoughInventoryForProductionUseCase, ValidateEnoughInventoryForProductionUseCase>();
builder.Services.AddTransient<IProduceProductUseCase, ProduceProductUseCase>();
builder.Services.AddTransient<ISellProductUseCase, SellProductUseCase>();
builder.Services.AddTransient<ISearchInventoryTransactionsUseCase, SearchInventoryTransactionsUseCase>();
builder.Services.AddTransient<ISearchProductTransactionUseCase, SearchProductTransactionUseCase>();

builder.Services.AddSyncfusionBlazor();

var app = builder.Build();

var scope = app.Services.CreateScope();
var imsContext = scope.ServiceProvider.GetRequiredService<IMSContext>();
//imsContext.Database.EnsureDeleted();
//imsContext.Database.EnsureCreated();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
