﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
namespace ASIptvServer.Api
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "AS Iptv Api",
                    Version = "v1",
                    Description = "Api para gerenciar filmes, séries e tv ao vivo",
                    Contact = new OpenApiContact
                    {
                        Name = "Adriano Sena silva",
                        Email = "adryanosenasilva@gmail.com",
                    }
                });

                // Outras configurações, como segurança, esquemas de autenticação, etc.
            });
        }
        public static void UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            // Configuração do middleware do Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "AS Iptv Api v1");
                c.RoutePrefix = "swagger";  // Para acessar o Swagger diretamente na raiz da aplicação
            });
        }
    }
}
