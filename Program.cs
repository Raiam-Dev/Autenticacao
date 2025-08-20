using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Builder.Extensions;
using RNovaTech.Configuracao;
using RNovaTech.Features._Shared;

var builder = WebApplication.CreateBuilder(args);

builder
    .DbContextConfig()
    .MediatorConfig()
    .ControllerConfig()
    .SwaggerConfig();

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IFirebaseTokenService, FirebaseTokenService>();

var optionsDesenvolvimento = new AppOptions
{
    Credential = GoogleCredential.FromFile(builder.Configuration["FIREBASE_CREDENTIAL_JSON_PRODUCAO"]),
    ProjectId = "autenticacao-29915"
};

FirebaseApp.Create(optionsDesenvolvimento);

var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(config =>
    {
        config.SwaggerEndpoint("/swagger/v1/swagger.json", "RNovaTech");
    });
}

app.UseCors("Acesso");
app.UseHttpsRedirection();
app.UseAuthentication();
app.MapControllers();

app.Run();