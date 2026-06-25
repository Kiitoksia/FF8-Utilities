using Blazored.LocalStorage;
using FF8Utilities.Common.Cards;
using FF8Utilities.Web;
using FF8Utilities.Web.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<SettingsService>();
builder.Services.AddScoped<CardTrackerStateService>();
builder.Services.AddScoped<WebService>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazorBootstrap();


var app = builder.Build();
var settings = app.Services.GetRequiredService<SettingsService>();
await settings.Initialise();

using (HttpClient http = new HttpClient())
{
    http.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
    string resourceUrl = builder.HostEnvironment.BaseAddress + "res";

    await BaseZellCardTrackerModel.InitializeLateQuistisAsync(http, resourceUrl);
    await WebHelper.LoadFishPatterns(http, resourceUrl);
}


await app.RunAsync();

