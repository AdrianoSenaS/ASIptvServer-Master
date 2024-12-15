using ASIptvServer;
using ASIptvServer.Api;
using ASIptvServer.Api.Interfaces;
using ASIptvServer.Api.Models;
using ASIptvServer.Data.Data;
using ASIptvServer.Data.Database;

Startup.Start();


var builder = WebApplication.CreateBuilder(args);

// Adicionar servi�os ao cont�iner, incluindo o Swagger
builder.Services.AddControllers();

// Registrando a configura��o do Swagger que est� na classe separada
builder.Services.AddSwaggerConfiguration();
builder.Services.AddScoped<IDatabase, DbData>();
builder.Services.AddScoped<IMovieService, DbMovies>();
builder.Services.AddScoped<ISeriesService, DbSeries>();
builder.Services.AddScoped<ITvService, DbTV>();
builder.Services.AddScoped<IM3uService, M3uService>();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
   
}
else
{
    // Servir os arquivos est�ticos do build do Vite em produ��o
    app.UseDefaultFiles();
    app.UseStaticFiles();
}


// Configurar o middleware do Swagger
app.UseSwaggerConfiguration();

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthentication();

app.UseAuthorization();
app.MapControllers();

app.Run("https://*");