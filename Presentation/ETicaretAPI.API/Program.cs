﻿using ETicaretAPI.Application.Validators.Products;
using ETicaretAPI.Infrastructure.Filter;
using ETicaretAPI.Persistence;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(o=>o.Filters.Add<ValidationFilter>()).AddFluentValidation(c => c.RegisterValidatorsFromAssemblyContaining<CreateProductValidator>())
    .ConfigureApiBehaviorOptions(o => o.SuppressModelStateInvalidFilter = true);

builder.Services.AddPersistenceServices();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options=>options.AddDefaultPolicy(policy=>policy.WithOrigins("http://localhost:4200", "https://localhost:4200")
.AllowAnyHeader().AllowAnyMethod()
));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

