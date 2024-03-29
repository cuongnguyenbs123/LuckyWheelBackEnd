using LuckyWheel.Core;
using LuckyWheel.Core.Interfaces;
using LuckyWheel.Core.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<DBConfig>(builder.Configuration);
builder.Services.AddSingleton<IDBConfig, DBConfigServices>();
builder.Services.AddTransient<IPrizeServices, PrizeServices>();
builder.Services.AddCors();/// <summary>
/// ///
/// </summary>

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(builder => builder.AllowAnyOrigin()
     .AllowAnyMethod()
     .AllowAnyHeader()
     );

app.UseAuthorization();

app.MapControllers();

app.Run();
