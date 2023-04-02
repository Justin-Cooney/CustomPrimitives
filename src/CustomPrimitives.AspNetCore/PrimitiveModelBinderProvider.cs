using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CustomPrimitives.AspNetCore;

public class PrimitiveModelBinderProvider : IModelBinderProvider
{
	public IModelBinder GetBinder(ModelBinderProviderContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException(nameof(context));
		}

		if (context.Metadata.ModelType.GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IPrimitive<>)))
		{
			return new PrimitiveModelBinder();
		}

		return null;
	}
}