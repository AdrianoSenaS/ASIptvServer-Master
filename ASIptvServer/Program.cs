using ASIptvServer.Api.Interfaces;
using ASIptvServer.Data.Data;
using ASIptvServer.Data.Database;
using ASIptvServer.IO;
using ASIptvServer.System.Configuration;
using ASIptvServer.Configuration.Api;
using ASIptvServer.Api.Services.M3u;
using ASIptvServer.Api.Services.Movies;
using ASIptvServer.TMDB;
using ASIptvServer;
using ASIptvServer.Api.Services.IO;
using ASIptvServer.Api.Services.Tv;

var builder = WebApplication.CreateBuilder(args);
// Registrando a configuração do Swagger que está na classe separada
builder.Services.AddSwaggerConfiguration();
// Adicionar serviços ao contêiner, incluindo o Swagger
builder.Services.AddControllers();
builder.Services.AddScoped<IVerification, VerificationOs>();
builder.Services.AddScoped<IOsPath, OsPath>();
builder.Services.AddScoped<IDatabase, DbData>();
builder.Services.AddScoped<IDbPath, DbPath>();
builder.Services.AddScoped<IMovieService, DbMovies>();
builder.Services.AddScoped<ISeriesService, DbSeries>();
builder.Services.AddScoped<ITvService, DbTV>();
builder.Services.AddScoped<IM3uService, M3uService>();
builder.Services.AddScoped<ImoviesSevices, MoviesServices>();
builder.Services.AddScoped<ITMDBMovie, GetMovies>();
builder.Services.AddScoped<IUploadService, UploadService>();
builder.Services.AddScoped<ITvServices, TvServices>();



var app = builder.Build();
var scope = app.Services.CreateScope();
var path = scope.ServiceProvider.GetService<IOsPath>();
path.CreatePath();
var data = scope.ServiceProvider.GetService<IDatabase>();
data.CreateDatabase();



IVerification verification = scope.ServiceProvider.GetService<IVerification>();


var loggerFactory = LoggerFactory.Create(builder =>
{
    builder.AddConsole();
    builder.AddProvider(new FileLoggerProvider(verification.Verification().PathTemp + "App.log"));
});
ILogger logger = loggerFactory.CreateLogger<Program>();
logger.LogInformation("Iniciando aplicação...");


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
else
{
    // Servir os arquivos estáticos do build do Vite em produção
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