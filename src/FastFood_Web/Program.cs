using FastFood_Web.Api.Configurations.LayerConfigurations;
using FastFood_Web.Service.Interfaces;
using FastFood_Web.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDataAccess(builder.Configuration);
builder.Services.AddHttpContextAccessor();

builder.ConfigurAuth();
builder.Services.AddService();

builder.Services.AddScoped<IAccountService, AccountService>();


builder.Services.AddMemoryCache();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
