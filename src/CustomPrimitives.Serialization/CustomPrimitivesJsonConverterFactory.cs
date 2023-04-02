using System.Reflection;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace CustomPrimitives.Serialization;

public class CustomPrimitivesJsonConverterFactory : JsonConverterFactory
{
	public override bool CanConvert(Type typeToConvert)
		=> typeToConvert.GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IPrimitive<>));

	public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
	{
		var interfaceType = typeToConvert.GetInterfaces().First(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IPrimitive<>));
		var primitiveType = interfaceType.GetGenericArguments().First();

		JsonConverter converter = (JsonConverter)Activator.CreateInstance(
				typeof(CustomPrimitivesJsonConverter<,>).MakeGenericType(
					new Type[] { typeToConvert, primitiveType }),
				BindingFlags.Instance | BindingFlags.Public,
				binder: null,
				args: new object[] { },
				culture: null)!;

		return converter;
	}
}
