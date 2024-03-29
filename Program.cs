using JMR.Models;
using JMR.helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes("Test_key_Now_Here")),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
builder.Services.AddMvc()
        .AddSessionStateTempDataProvider();
builder.Services.AddSession();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
var db = new BloggingContext();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseExceptionHandler("/Home/Error");

app.UseSession();
app.Use(async (context, next) =>    
{
    var token = context.Session.GetString("Token"); 
    if (!string.IsNullOrEmpty(token))  
    {
        context.Request.Headers.Add("Authorization", "Bearer " + token);
    }
    await next();
});

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Signup}/{id?}");

app.Run();

