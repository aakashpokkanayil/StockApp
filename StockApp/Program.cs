using StockApp.Interfaces;
using StockApp.mapping;
using StockApp.Options;
using StockApp.Service;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();// for using HTTP CLient request.
builder.Services.AddScoped<IFinnHubService, FinnHubService>();
builder.Services.Configure<FinnHubOptions>(builder.Configuration.GetSection("FinnHub"));
builder.Services.AddAutoMapper(typeof(MappingProfile)); 

var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();
app.Run();
