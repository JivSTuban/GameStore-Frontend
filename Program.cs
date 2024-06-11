using GameStore.Frontend.Clients;
using GameStore.Frontend.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();
var gameStoreUrl = builder.Configuration["GameStoreUrl"] ??
    throw new Exception("GameStoreApiUrl is not set."); 

builder.Services.AddHttpClient<GamesClient>(
    client => client.BaseAddress = new Uri(gameStoreUrl));

builder.Services.AddHttpClient<GenresClient>(
    client => client.BaseAddress = new Uri(gameStoreUrl));

builder.Services.AddHttpClient<UsersClient>(
    client => client.BaseAddress = new Uri(gameStoreUrl));


builder.Services.AddAuthorizationCore();



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
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
           Path.Combine(Directory.GetCurrentDirectory(), "Temp", "Storage", "games")),
    RequestPath = "/Temp/Storage/games"
});
app.UseAntiforgery();

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();
