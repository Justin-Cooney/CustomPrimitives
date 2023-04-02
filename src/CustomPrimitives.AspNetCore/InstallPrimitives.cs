using CustomPrimitives.AspNetCore;
using CustomPrimitives.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;

namespace CustomPrimitives.FluentValidation.AspNetCore;

public static class InstallPrimitives
{
	public static IServiceCollection AddPrimitives(this IServiceCollection services)
	{
		services.Configure<MvcOptions>(options => options.ModelBinderProviders.Insert(0, new PrimitiveModelBinderProvider()));
		services.Configure<JsonOptions>(options => options.JsonSerializerOptions.Converters.Add(new CustomPrimitivesJsonConverterFactory()));
		services.Configure<JsonSerializerOptions>(options => options.Converters.Add(new CustomPrimitivesJsonConverterFactory()));
		return services;
	}
}