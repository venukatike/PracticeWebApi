using HBP.api.Application_ClassLibrary.Interfaces;
using HBP.api.Application_ClassLibrary.Services;
using HBP.api.Custom_Middlewares;
using HBP.api.Data;
using HBP.api.Domain_ClassLibrary.Interfaces;
using HBP.api.Infrastucture_ClassLibrary.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPatient, PatientRepo>();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IAppUserEntity,AppUserRepo>();
builder.Services.AddScoped<IAppUserService,AppUserService>();
builder.Services.AddScoped<BillingDbContext>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseMiddleware<EasMiddleware>();

app.UseMiddleware<ExceptionMiddleware>();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
