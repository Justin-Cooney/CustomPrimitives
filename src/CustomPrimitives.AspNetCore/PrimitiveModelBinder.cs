using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Primitives;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace CustomPrimitives.AspNetCore;

public class PrimitiveModelBinder : IModelBinder
{
	public async Task BindModelAsync(ModelBindingContext bindingContext)
	{
		if (bindingContext == null)
		{
			throw new ArgumentNullException(nameof(bindingContext));
		}

		var value =
			bindingContext.BindingSource == BindingSource.Body
				? await GetValueFromBody(bindingContext)
			: bindingContext.BindingSource == BindingSource.Header
				? GetValueFromHeader(bindingContext)
			: GetValueFromProvider(bindingContext);

		if (value == null) return;

		var primitiveType = bindingContext.ModelType;
		var primitiveInterface = primitiveType.GetInterfaces().First(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IPrimitive<>));
		var type = primitiveInterface.GetGenericArguments().First();

		var convertedValue = TypeDescriptor.GetConverter(type).ConvertFromInvariantString(value);
		var primitive = Activator.CreateInstance(primitiveType, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new object[] { convertedValue }, null);

		bindingContext.Result = ModelBindingResult.Success(primitive);

		return;
	}

	private async Task<string?> GetValueFromBody(ModelBindingContext bindingContext)
	{
		using (var reader = new StreamReader(bindingContext.HttpContext.Request.Body, Encoding.UTF8))
			return await reader.ReadToEndAsync();
	}

	private string? GetValueFromHeader(ModelBindingContext bindingContext)
	{
		if(bindingContext.HttpContext.Request.Headers.TryGetValue(bindingContext.FieldName, out StringValues values))
			return values.First();
		return null;
	}

	private string? GetValueFromProvider(ModelBindingContext bindingContext)
	{
		var modelName = bindingContext.OriginalModelName;
		var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);

		if (valueProviderResult == ValueProviderResult.None)
		{
			return null;
		}

		bindingContext.ModelState.SetModelValue(modelName, valueProviderResult);

		return valueProviderResult.FirstValue;
	}
}
