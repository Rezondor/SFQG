using BFQG;
using BFQG.Interfaces;
using BFQG.Models;
using BFQG.Repositories.Base;
using BFQG.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
const string PolicyName = "CorsPolicy";

builder.Services.AddCors(options => options.AddPolicy(PolicyName,
    builder =>
    {
        builder.WithOrigins("http://localhost:3000");
    })
);

builder.Services.AddDbContext<DbforqgsContext>(opt => 
        opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options => { 
    options.LoginPath = new PathString("/Account/login");
    options.Cookie.Name = "Auth";
    options.AccessDeniedPath = new PathString("/Account/login");
});


Scopeds.Add(builder.Services);

builder.Services.AddSingleton<IRoomsService, RoomsService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseCors(PolicyName);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
