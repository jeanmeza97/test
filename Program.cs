using GoogleMapsComponents;
using MudBlazor.Services;
using Localizate.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddBlazorGoogleMaps("AIzaSyC__QUJ3Od9sG-59kW86EQwc9JN5W7pbCo");

    
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddMudServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();