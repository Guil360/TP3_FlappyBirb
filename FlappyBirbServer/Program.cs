﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FlappyBirbServer.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<FlappyBirbServerContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("FlappyBirbServerContext") ?? throw new InvalidOperationException("Connection string 'FlappyBirbServerContext' not found."));
    options.UseLazyLoadingProxies();
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
