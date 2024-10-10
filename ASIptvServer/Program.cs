using ASIptvServer;
using ASIptvServer.Api;

Startup.Start();


var builder = WebApplication.CreateBuilder(args);

// Adicionar serviços ao contêiner, incluindo o Swagger
builder.Services.AddControllers();

// Registrando a configuração do Swagger que está na classe separada
builder.Services.AddSwaggerConfiguration();


var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

// Configurar o middleware do Swagger
app.UseSwaggerConfiguration();

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthentication();

app.UseAuthorization();
app.MapControllers();

app.Run();