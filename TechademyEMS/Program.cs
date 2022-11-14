global using Serilog;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TechademyEMS.DatabaseContext;
using TechademyEMS.Models.Authorization;
using TechademyEMS.Repository.Implementation;
using TechademyEMS.Repository.Interface;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EMSDbContext>(Options => Options.UseSqlServer(builder.Configuration.GetConnectionString("DbConn")));
//builder.Services.AddDbContext<AuthenticationContext>(Options => Options.UseSqlServer(builder.Configuration.GetConnectionString("DbConn")));
builder.Services.AddCors(Options => Options.AddPolicy(name: "EMSOrigins", policy =>
{
    policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
}));
// Injecting Dependencies
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IDesignationRepository,DesignationRepository>();
builder.Services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
builder.Services.AddScoped<IPaymentRulesRepository, PaymentRulesRepository>();
builder.Services.AddScoped<IWorkingHoursRepository, WorkingHoursRepository>();
//Adding Identity
builder.Services.AddIdentity<Register, IdentityRole>(options =>
{
    options.User.RequireUniqueEmail = false;
    
}).AddEntityFrameworkStores<EMSDbContext>().AddDefaultUI();
//JWT Authentication Service
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
//Initialising Logger
var logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).Enrich.FromLogContext().CreateLogger();
    //.WriteTo.File("E:\\CA\\TechademyEMS\\logs\\ApiLog.log", rollingInterval: RollingInterval.Day).CreateLogger();
builder.Logging.AddSerilog(logger);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("EMSOrigins");
app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();
