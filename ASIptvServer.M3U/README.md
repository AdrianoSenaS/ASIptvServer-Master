    # ASIptvServer.M3U

###### ASIptvServer.M3U uma biblioteca C# que fornece funcionalidades para ler listas m3u .

## Funcionalidades
* Ler varios formatos de listas
* faz download da url e salva em arquivo m3u
* Separa no logo e url
* verifica se é uma série, filme ou programa de tv  



## Exemplo de Código

```
using ASIptvServer.M3U;

class Program
{
    static void Main(string[] args)
    {
        var url = "http://url";
        var m3u = M3UList.M3u(url);
        Console.WriteLine(m3u.Id);  // Saída: "01"
        Console.WriteLine(m3u.Name);  // Saída: "ex!"
        Console.WriteLine(m3u.Logo);  // Saída: "http://urlLogo"
        Console.WriteLine(m3u.Categories);  // Saída: "Movies | action"
        Console.WriteLine(m3u.Movies);  // Saída: "true"
        Console.WriteLine(m3u.Series);  // Saída: "false"
        Console.WriteLine(m3u.Tv);  // Saída: "false"
        
    }
}

```
