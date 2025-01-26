var builder = WebApplication.CreateBuilder(args);
// Adicionar serviços ao contêiner, incluindo o Swagger
builder.Services.AddControllers();

var app = builder.Build();
var scope = app.Services.CreateScope();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // Servir os arquivos estáticos do build do Vite em produção
    app.UseDefaultFiles();
    app.UseStaticFiles();
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();