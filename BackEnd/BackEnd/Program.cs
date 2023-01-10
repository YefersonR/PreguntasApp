using BackEnd.Domain.IRepository;
using BackEnd.Domain.IServices;
using BackEnd.Infrastructure.Context;
using BackEnd.Infrastructure.Repositories;
using BackEnd.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options=>
                                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConectionAngular"));
});
builder.Services.AddScoped<IUsuarioRepository,UsuarioRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<ILoginRepository, LoginRepository>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<ICuestionarioRepository, CuestionarioRepository>();
builder.Services.AddScoped<ICuestionarioService, CuestionarioService>();
builder.Services.AddScoped<IRespuestaCuestionarioService, RespuestaCuestionarioService>();
builder.Services.AddScoped<IRespuestaCuestionarioRepository, RespuestaCuestionarioRepository>();

builder.Services.AddCors(option => option.AddPolicy("AllowMyApp", builder=> builder
                                                                            .AllowAnyOrigin()
                                                                            .AllowAnyHeader()
                                                                            .AllowAnyMethod()
                                                                            ));
builder.Services.AddAuthentication()
    .AddJwtBearer(option =>
    option.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidAudience = builder.Configuration["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:SecretKey"])),
        ClockSkew = TimeSpan.Zero
    });

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors("AllowMyApp");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
