# ASMedia.Naming

# ASMedia.Naming uma biblioteca C# que fornece funcionalidades para renomear strings no formato "ex - 2019 (2019) S001 E003", resultando em strings formatadas como "ex ano 2019 ". A biblioteca captura o ano de uma string, remove parênteses e traços, e organiza o texto de maneira clara.

# Funcionalidades
* Remove parênteses ao redor do ano.
* Verifica se é uma série de tv
* Remove traços " - " das strings
* Organiza o ano extraído da string e posiciona ao final.   
* Mantém a estrutura do texto original ao reorganizar o conteúdo.

# Como funciona

1. A biblioteca utiliza expressões regulares para:
2. Identificar o ano na string (um número entre parênteses).
3. Remover parênteses e traços desnecessários.
4. Reorganizar a string de forma mais legível, com o ano sendo posicionado ao final.



# Exemplo de Código

```
using ASMedia.Naming.Renamber;
using ASMedia.Naming;

class Program
{
    static void Main(string[] args)
    {
        string nameString = "ex - 2019 (2019) S00 E03";
        NamingPath namingPath = new NamingPath(nameString);
        var renamedString = Renamber.SetNaming(namingPath);
        Console.WriteLine(renamedString.Name);  // Saída: "ex"
        Console.WriteLine(renamedString.Year);  // Saída: "2019"
        Console.WriteLine(renamedString.IsSerie);  // Saída: "true"
        
    }
}

```


