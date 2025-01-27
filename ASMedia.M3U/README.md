# ASMedia.M3U

# ASMedia.M3U uma biblioteca C# que fornece funcionalidades para ler listas m3u .

# Funcionalidades
* Ler varios formatos de listas
* faz download da url e salva em arquivo m3u
* Separa no logo e url
* verifica se é uma série, filme ou programa de tv  



# Exemplo de Código com arquivos m3u

```
using ASMedia.M3U;

class Program
{
    static void Main(string[] args)
    {
        var pathM3u = @"C:\list.m3u";
        M3UPath m3UPath = new M3UPath(pathM3u);
        var dt = M3UList.M3uPath(m3UPath);
        foreach (var item in dt)
        {
            Console.WriteLine(item.Id);  // Saída: "01"
            Console.WriteLine(item.Name);  // Saída: "ex!"
            Console.WriteLine(item.Logo);  // Saída: "http://urlLogo"
            Console.WriteLine(item.Categories);  // Saída: "Movies | action"
            Console.WriteLine(item.Movies);  // Saída: "true"
            Console.WriteLine(item.Series);  // Saída: "false"
            Console.WriteLine(item.Tv);  // Saída: "false"
            Console.WriteLine(item.Radio);  // Saída: "false"
        }  
    }
}

```
# Exemplo de Código com url m3u

```
using ASMedia.M3U;

class Program
{
    static void Main(string[] args)
    {
        var urlM3u = @"http://url.m3u";
        M3Uurl m3uUrl = new M3Uurl(urlM3u);
        var dt = M3UList.M3Uurl(m3uUrl);
        foreach (var item in dt.Result)
        {
            Console.WriteLine(item.Id);  // Saída: "01"
            Console.WriteLine(item.Name);  // Saída: "ex!"
            Console.WriteLine(item.Logo);  // Saída: "http://urlLogo"
            Console.WriteLine(item.Categories);  // Saída: "Movies | action"
            Console.WriteLine(item.Movies);  // Saída: "true"
            Console.WriteLine(item.Series);  // Saída: "false"
            Console.WriteLine(item.Tv);  // Saída: "false"
            Console.WriteLine(item.Radio);  // Saída: "false"
        }
        
    }
}

```


