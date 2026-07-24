using SlothSec.BlazorUI.Components;
using SlothSec.BlazorUI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpClient("SlothSecAPI", client =>
{
    client.BaseAddress = new Uri("https://localhost:5248");
});

builder.Services.AddHttpClient<AbuseApiClient>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5241/");
});

builder.Services.AddScoped(sp =>
    sp.GetRequiredService<IHttpClientFactory>().CreateClient("SlothSecAPI"));

builder.Services.AddScoped<CvssApiService>();
builder.Services.AddScoped<OwaspApiService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
