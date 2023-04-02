using System.Reflection;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace CustomPrimitives.Serialization;

public class CustomPrimitivesJsonConverter<PrimitiveType, T> : JsonConverter<PrimitiveType>
	where PrimitiveType : IPrimitive<T>
{
	public CustomPrimitivesJsonConverter() { }

	public override PrimitiveType? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		var valueConverter = (JsonConverter<T>)options.GetConverter(typeof(T));
		var value = valueConverter.Read(ref reader, typeToConvert, options);

		var primitive = (PrimitiveType)Activator.CreateInstance(typeof(PrimitiveType), BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new object[] { value }, null);
		Type type = primitive.GetType();
		PropertyInfo prop = type.BaseType.GetProperty("Value");
		prop.SetValue(primitive, value, null);

		return primitive;
	}

	public override void Write(Utf8JsonWriter writer, PrimitiveType value, JsonSerializerOptions options)
	{
		((JsonConverter<T>)options.GetConverter(typeof(T))).Write(writer, value.Value, options);
	}
}
