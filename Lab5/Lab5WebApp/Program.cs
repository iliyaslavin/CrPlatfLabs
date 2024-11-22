using Duende.IdentityServer.Models;
using Duende.IdentityServer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure IdentityServer
builder.Services.AddIdentityServer(options =>
{
    options.EmitStaticAudienceClaim = true;
})
.AddInMemoryClients(new List<Client>
{
    new Client
    {
        ClientId = "webapp",
        ClientSecrets = { new Secret("webapp-secret".Sha256()) },
        AllowedGrantTypes = GrantTypes.Code,
        RedirectUris = { "https://localhost:7214/signin-oidc" },
        PostLogoutRedirectUris = { "https://localhost:7214/signout-callback-oidc" },
        AllowedScopes = { "openid", "profile", "email", "api1" },
        RequirePkce = true,
        RequireConsent = false
    }
})
.AddInMemoryIdentityResources(new List<IdentityResource>
{
    new IdentityResources.OpenId(),
    new IdentityResources.Profile(),
    new IdentityResources.Email()
})
.AddInMemoryApiScopes(new List<ApiScope>
{
    new ApiScope("api1", "My API")
})
.AddDeveloperSigningCredential();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = "Cookies";
    options.DefaultChallengeScheme = "oidc";
})
.AddCookie("Cookies")
.AddOpenIdConnect("oidc", options =>
{
    options.Authority = "https://localhost:7214";
    options.ClientId = "webapp";
    options.ClientSecret = "webapp-secret";
    options.ResponseType = "code";
    options.Scope.Add("profile");
    options.Scope.Add("email");
    options.SaveTokens = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseIdentityServer();
app.UseAuthentication(); 
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "account",
    pattern: "{controller=Account}/{action=Register}/{id?}");
app.MapControllerRoute(
    name: "profile",
    pattern: "Profile",
    defaults: new { controller = "Account", action = "Profile" }
);



app.Run();
