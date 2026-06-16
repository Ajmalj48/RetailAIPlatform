//using RetailAI.Dashboard;
//using RetailAI.Dashboard.Services;

//var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddRazorComponents()
//    .AddInteractiveServerComponents();

//builder.Services.AddScoped(sp =>
//{
//    return new HttpClient();
//});

//builder.Services.AddScoped<DashboardService>();

//var app = builder.Build();

//app.UseStaticFiles();

//app.UseAntiforgery();

//app.MapRazorComponents<App>()
//    .AddInteractiveServerRenderMode();

//app.Run();

using RetailAI.Dashboard.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddServerSideBlazor();

builder.Services.AddScoped<DashboardService>();

builder.Services.AddScoped(sp =>
{
    return new HttpClient();
});

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();

app.MapFallbackToPage("/_Host");

app.Run();