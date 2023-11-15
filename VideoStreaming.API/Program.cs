using Microsoft.Extensions.FileProviders;
using VideoStreaming.Application.Interfaces.Services;
using VideoStreaming.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IVideoService, VideoService>();
builder.Services.AddScoped<IVideoManagerService, VideoManagerService>();
builder.Services.AddScoped<IVideoConverterService, VideoConverterService>();
builder.Services.AddSingleton<IFileProvider>(new PhysicalFileProvider(@$"D:\Videos"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
