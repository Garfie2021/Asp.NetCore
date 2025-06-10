using Microsoft.AspNetCore.Localization.Routing;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
  var supportedCultures = new[] { "ja", "en" };
  options.SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);
});

builder.Services.AddMvc()
  .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
  .AddDataAnnotationsLocalization();

// Add services to the container.
builder.Services.AddControllersWithViews()
  .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
  .AddDataAnnotationsLocalization();

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
  var supportedCultures = new[]
  {
    new System.Globalization.CultureInfo("en"),
    new System.Globalization.CultureInfo("ja")
  };

  options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("ja");
  options.SupportedCultures = supportedCultures;
  options.SupportedUICultures = supportedCultures;
  options.RequestCultureProviders = new[] {
    new RouteDataRequestCultureProvider { Options = options }
  };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseRequestLocalization(
    app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value
);

app.UseAuthorization();

app.MapControllerRoute(
  name: "default",
  pattern: "{culture=ja}/{controller=Home}/{action=Index}/{id?}");

app.Run();
