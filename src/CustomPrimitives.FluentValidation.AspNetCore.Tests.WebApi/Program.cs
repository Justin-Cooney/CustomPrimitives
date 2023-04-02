using CustomPrimitives.FluentValidation.AspNetCore;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
	.AddControllers();

builder.Services
	.AddFluentValidationAutoValidation(x =>
	{
		x.ImplicitlyValidateChildProperties = true;
	})
	.AddFluentValidationClientsideAdapters()
	.AddPrimitivesWithValidation()
	.AddPrimitiveValidatorsFromAssemblyContaining<Program>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }