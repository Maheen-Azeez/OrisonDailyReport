using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using OrisonDailyReport.Client;
using OrisonDailyReport.Client.Logics.Concrete.BoldReport;
using OrisonDailyReport.Client.Logics.Concrete.General;
using OrisonDailyReport.Client.Logics.Concrete.Registers;
using OrisonDailyReport.Client.Logics.Contract.BoldReport;
using OrisonDailyReport.Client.Logics.Contract.General;
using OrisonDailyReport.Client.Logics.Contract.Registers;
using OrisonDailyReport.Client.Services;
using OrisonDailyReport.Client.Shared;
using Syncfusion.Blazor;
using System.Globalization;

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NHaF1cWmhIfEx1RHxQdld5ZFRHallYTnNWUj0eQnxTdEZiW35bcHdWT2FdWERzVw==");
var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//For Arabic Language
builder.Services.AddLocalization();
builder.Services.AddSingleton(typeof(ISyncfusionStringLocalizer), typeof(SyncfusionLocalizer));
var host = builder.Build();

var jsInterop = host.Services.GetRequiredService<IJSRuntime>();
var result = await jsInterop.InvokeAsync<string>("cultureInfo.get");
CultureInfo culture;
if (result != null)
{
    culture = new CultureInfo(result);
}
else
{
    culture = new CultureInfo("en-US");
    await jsInterop.InvokeVoidAsync("cultureInfo.set", "en-US");
}
CultureInfo.DefaultThreadCurrentCulture = culture;
CultureInfo.DefaultThreadCurrentUICulture = culture;
//For Arabic Language

//Package Services
builder.Services.AddSyncfusionBlazor();
builder.Services.AddBlazoredSessionStorage();
//Package Services

//Custom Services
builder.Services.AddScoped<ToastService>();
builder.Services.AddScoped<GeneralServices>();
builder.Services.AddScoped<MailService>();
builder.Services.AddScoped<CacheVersionService>();
builder.Services.AddScoped<GlobalService>();
builder.Services.AddScoped<IBoldReportManager,BoldReportManager>();
builder.Services.AddScoped<IUserLoginManager,UserLoginManager>();
builder.Services.AddScoped<ICompanyManager,CompanyManager>();
builder.Services.AddScoped<IAccountsMain,AccountsMainManager>();
//Custom Services

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
await builder.Build().RunAsync();
