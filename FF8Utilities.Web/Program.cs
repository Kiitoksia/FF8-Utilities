using Blazored.LocalStorage;
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

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<SettingsService>();
builder.Services.AddSingleton<CardTrackerStateService>();
builder.Services.AddScoped<WebService>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazorBootstrap();




await builder.Build().RunAsync();

