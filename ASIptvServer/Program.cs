using ASIptvServer.Api;
using ASIptvServer.Data;

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
/*var i = await M3UDownload.DownloadM3U("http://hclient.pro:80/get.php?username=ic8lvmt8&password=sguanhvo&type=m3u_plus&output=ts");

string caminho = "C:\\Dados\\listaAd.m3u"; // Caminho do arquivo

// Adiciona o conteúdo ao arquivo
File.AppendAllText(caminho, i);

Console.WriteLine("Texto adicionado ao arquivo com sucesso.");

foreach (var item in M3UList.M3u())
{
    if (item.Tv)
    {
        Console.WriteLine("tv: " + Renamber.SetNaming(item.Name).Name);
    }
    if (item.Films)
    {
        Console.WriteLine("Filme: " + Renamber.SetNaming(item.Name).Name);
    }
    if (item.Serie)
    {
        Console.WriteLine("Serie: " + Renamber.SetNaming(item.Name).Name);
    }
}*/
DbData.CreateDatabase();
app.MapControllers();

app.Run();