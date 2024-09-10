using BlurHash.Context;
using BlurHash.Providers;
using Microsoft.Extensions.Azure;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAzureClients(clientBuilder =>
{
    clientBuilder.AddBlobServiceClient(builder.Configuration["Azurite:blob"]!, preferMsi: true);
    clientBuilder.AddQueueServiceClient(builder.Configuration["Azurite:queue"]!, preferMsi: true);
});
builder.Services.AddScoped<AzureBlobService>();
builder.Services.AddScoped<ImageService>();
builder.Services.AddScoped<ApplicationDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(builder => builder.AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();
