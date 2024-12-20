using ClassLibraryModels.Services;
using ClassLibraryServer.Connections;
using ClassLibraryServer.Interfaces;
using ClassLibraryServer.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Services ----------------------------------------------------------
builder.Services.AddDbContext<EntityDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("RutaSQL"));
});
builder.Services.AddSingleton<ImageProcess>();
builder.Services.AddSingleton<ITokenGenerator,TokenGenerator>();
builder.Services.AddTransient<IAuthService,AuthEmailService>();
// -------------------------------------------------------------------

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Cors --------------------------------------------------------------
app.UseCors(options =>
{
    options.AllowAnyHeader();
    options.AllowAnyMethod();
    options.AllowCredentials();
    options.SetIsOriginAllowed(origin => true);
});
// -------------------------------------------------------------------

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
