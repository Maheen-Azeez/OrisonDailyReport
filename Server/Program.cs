using Microsoft.AspNetCore.ResponseCompression;
using OrisonDailyReport.Server.Logics.Concrete.BoldReport;
using OrisonDailyReport.Server.Logics.Concrete.General;
using OrisonDailyReport.Server.Logics.Concrete.Main;
using OrisonDailyReport.Server.Logics.Contract.BoldReport;
using OrisonDailyReport.Server.Logics.Contract.General;
using OrisonDailyReport.Server.Logics.Contract.Main;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IUserLoginManager, UserLoginManager>();
builder.Services.AddScoped<ICompanyManager, CompanyManager>();
builder.Services.AddScoped<IDapperManager, DapperManager>();
builder.Services.AddScoped<IDBOperationManager, DBOperationManager>();
builder.Services.AddScoped<IBoldReportManager, BoldReportManager>();
builder.Services.AddScoped<IAccountsMain, AccountsMain>();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
