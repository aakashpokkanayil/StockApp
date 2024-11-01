using StockApp.Interfaces;
using StockApp.Service;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();// for using HTTP CLient request.
builder.Services.AddScoped<IMyservice, MyService>();
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();
app.Run();
