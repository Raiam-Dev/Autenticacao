using Aplicacao.Data;
using Microsoft.EntityFrameworkCore;
using Aplicacao.Entities.TarefaCommandHandler;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DbContextMemory>(config => {
    config.UseInMemoryDatabase(
        builder.Configuration
            .GetConnectionString("DataBaseMemoria")!);
});
builder.Services.AddMediatR(config => {
    config.RegisterServicesFromAssembly(
        typeof(TarefaCommandHandler).Assembly);
});
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
    options.JsonSerializerOptions.Converters.Add
        (
            new System.Text.Json.Serialization
                .JsonStringEnumConverter()
        );
    });
builder.Services.AddSwaggerGen(config =>
{
    config.EnableAnnotations();
});
builder.Services.AddCors(config =>
{
    config.AddPolicy("Acesso", config => {
        config.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("Acesso");
app.UseHttpsRedirection();
app.UseAuthentication();
app.MapControllers();

app.Run();