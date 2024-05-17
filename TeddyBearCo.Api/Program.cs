using TeddyBearCo.Api.Database;
using TeddyBearCo.Api.Repositories;
using TeddyBearCo.Api.Services;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
	Args = args,
	ContentRootPath = Directory.GetCurrentDirectory()
});

var config = builder.Configuration;


// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddSingleton<IDbConnectionFactory>(_ =>
	new NpgsqlConnectionFactory(config.GetValue<string>("Database:ConnectionString")));
builder.Services.AddSingleton<DatabaseInitializer>();

builder.Services.AddSingleton<ITeddyBearRepository, TeddyBearRepository>();
builder.Services.AddSingleton<ITeddyBearService, TeddyBearService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();

	var databaseInitializer = app.Services.GetRequiredService<DatabaseInitializer>();
	await databaseInitializer.InitializeAsync();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
