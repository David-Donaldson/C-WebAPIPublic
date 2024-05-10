using Microsoft.EntityFrameworkCore;
using PortfolioNoIdentityAPI.Data;
using PortfolioNoIdentityAPI.Interfaces;
using PortfolioNoIdentityAPI.Repositories;
using PortfolioNoIdentityAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<ITroubleshootingService, TroubleshootingServiceRepository>();
builder.Services.AddScoped<ITroubleshootingServiceType, TroubleshootingServiceTypeRepository>();
builder.Services.AddScoped<IPortfolioContactForm, PortfolioContactRespoitory>();
builder.Services.AddScoped<IPortairLogistixContactForm, PortairLogixtixContactRepository>();
builder.Services.AddScoped<ITroubleshootingCustomerIssue, TroubleshootingCustomerIssueRepository>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IGoogleCaptchaService, GoogleCaptchaService>();
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
});

builder.Services.AddHttpClient();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
