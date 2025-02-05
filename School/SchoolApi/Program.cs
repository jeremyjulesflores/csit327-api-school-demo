using SchoolApi.Context;
using SchoolApi.Repositories;
using SchoolApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Trasient -> create new instance of DapperContext everytime.
builder.Services.AddTransient<DapperContext>();
builder.Services.AddScoped<ISchoolRepository, SchoolRepository>();
builder.Services.AddScoped<ISchoolService, SchoolService>();

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
