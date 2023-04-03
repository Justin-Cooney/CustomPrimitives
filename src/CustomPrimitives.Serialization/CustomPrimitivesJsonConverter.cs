using System.Reflection;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace CustomPrimitives.Serialization;

public class CustomPrimitivesJsonConverter<TCustom, TPrimitive> : JsonConverter<TCustom>
	where TCustom : IPrimitive<TPrimitive>
{
	public CustomPrimitivesJsonConverter() { }

	public override TCustom? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		var valueConverter = (JsonConverter<TPrimitive>)options.GetConverter(typeof(TPrimitive));
		var value = valueConverter.Read(ref reader, typeToConvert, options);

		var primitive = (TCustom)Activator.CreateInstance(typeof(TCustom), BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new object[] { value }, null);
		Type type = primitive.GetType();
		PropertyInfo prop = type.BaseType.GetProperty("Value");
		prop.SetValue(primitive, value, null);

		return primitive;
	}

	public override void Write(Utf8JsonWriter writer, TCustom value, JsonSerializerOptions options)
	{
		((JsonConverter<TPrimitive>)options.GetConverter(typeof(TPrimitive))).Write(writer, value.Value, options);
	}
}
