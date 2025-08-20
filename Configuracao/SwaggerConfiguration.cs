using Microsoft.OpenApi.Models;

namespace RNovaTech.Configuracao
{
    public static class SwaggerConfiguration
    {
        public static WebApplicationBuilder SwaggerConfig(this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations();
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "RNovaTech API",
                    Version = "v1",
                    Description = "Desenvolvendo Teste"
                });
            });

            return builder;
        }
    }
}
