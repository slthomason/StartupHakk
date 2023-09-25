using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.FeatureFilters;
using WebApplication11.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddFeatureManagement();
builder.Services.AddFeatureManagement().AddFeatureFilter<PercentageFilter>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapGet("articles/{id}", async (
    Guid id,
    IGetArticle query,
    IFeatureManager featureManager) =>
{
    var article = query.Execute(id);

    if (await featureManager.IsEnabledAsync(FeatureFlagsBase.ClipArticleContent))
    {
        article.Content = article.Content.Substring(0, 50);
    }

    return Results.Ok(article);
});
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
