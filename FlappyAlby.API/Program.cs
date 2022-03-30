using FlappyAlby.API.Abstract;
using FlappyAlby.API.Options;
using FlappyAlby.API.Readers;
using FlappyAlby.API.Repositories;
using FlappyAlby.API.Writers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddOptions<ConnectionStringOptions>()
    .Bind(builder.Configuration.GetSection("ConnectionStrings"))
    .ValidateDataAnnotations();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

builder.Services.AddSingleton<IRankingRepository, RankingRepository>();
builder.Services.AddSingleton<IReader, SqlReader>();
builder.Services.AddSingleton<IWriter, SqlWriter>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(b => b.AllowAnyMethod().AllowAnyOrigin().AllowAnyMethod());

app.UseHttpsRedirection();

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();