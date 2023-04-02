using CustomPrimitives.FluentValidation.AspNetCore;
using CustomPrimitives.Serialization;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Http.Json;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
	.AddControllers();

builder.Services
	.AddFluentValidationAutoValidation(x =>
	{
		x.ImplicitlyValidateChildProperties = true;
	})
	.AddFluentValidationClientsideAdapters();

builder.Services
	.AddPrimitivesWithValidation()
	.AddPrimitiveValidatorsFromAssemblyContaining<Program>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
