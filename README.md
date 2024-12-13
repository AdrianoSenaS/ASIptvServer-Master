# ASIptvServer
<p align="center">
<img src="https://github-production-user-asset-6210df.s3.amazonaws.com/61697830/395658951-90de0f84-d689-450f-8b42-3b565a6ebce5.png?X-Amz-Algorithm=AWS4-HMAC-SHA256&X-Amz-Credential=AKIAVCODYLSA53PQK4ZA%2F20241213%2Fus-east-1%2Fs3%2Faws4_request&X-Amz-Date=20241213T181814Z&X-Amz-Expires=300&X-Amz-Signature=fe9702376e944cd015b28570e8056042d0c2fa7f64e38e725fdacf67bdc539de&X-Amz-SignedHeaders=host" alt="ASIptvServer Logo" />
</p>

ASIptvServer é um media server IPTV escrito em C# que fornece uma solução robusta para gerenciamento de conteúdo como filmes, séries e TV ao vivo, além de gerenciar usuários, revendedores e métodos de pagamento. Este projeto é ideal para quem deseja uma plataforma completa de IPTV com suporte à leitura de arquivos e URLs no formato M3U.

## Principais Recursos

- **Suporte a arquivos e URLs M3U**: Permite a importação e o gerenciamento de canais, filmes e séries.
- **Gerenciamento de usuários**: Controle de acesso e perfis de usuários.
- **Gerenciamento de revendedores**: Administre seus revendedores com facilidade.
- **Integração de métodos de pagamento**: Automatize cobranças e gerencie pagamentos.
- **Compatível com multiplataforma**: Disponível para Linux e Windows.

## Requisitos

- **.NET 8 SDK**: Certifique-se de ter o .NET 8 instalado no seu sistema.

## Instalação

### Linux
1. Clone o repositório:
   ```bash
   git clone https://github.com/AdrianoSenaS/ASIptvServer-Master.git
   cd ASIptvServer-Master
   ```

2. Execute o script de instalação:
   ```bash
   chmod +x install.sh
   ./install.sh
   ```

3. Inicie o servidor:
   ```bash
   dotnet run --project ASIptvServer
   ```

### Windows
1. Baixe o projeto e abra-o no Visual Studio.
2. Certifique-se de que o .NET 8 SDK está instalado.
3. Compile e inicie o projeto pressionando `F5` ou utilizando a opção "Iniciar Depuração" no Visual Studio.

## Como Usar
1. Acesse a API através do endpoint principal para gerenciar os recursos.
2. Use a interface da API para configurar os seguintes itens:
   - Importação de arquivos/URLs M3U
   - Gerenciamento de usuários e revendedores
   - Configuração de métodos de pagamento

## Contribuição
Contribuições são bem-vindas! Sinta-se à vontade para enviar *pull requests* ou relatar problemas na página do repositório.

## Licença
Este projeto está licenciado sob a [MIT License](LICENSE).

