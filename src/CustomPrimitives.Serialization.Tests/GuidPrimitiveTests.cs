using FluentAssertions;
using System.Text.Json;

namespace CustomPrimitives.Serialization.Tests;

public class GuidPrimitiveTests
{
	private Guid _guid = Guid.Parse("d17b4c5e-6dd3-4842-aa87-70802eae1887");

	private class TestPrimitive : GuidPrimitive<TestPrimitive>
	{
		private TestPrimitive(Guid value) : base(value)
		{
		}

		public TestPrimitive(Guid value, int testProp) : base(value) { TestProp = testProp; }

		public int TestProp { get; }
	}

	private record TestModel(TestPrimitive TestProperty) { }

	JsonSerializerOptions GetJsonOptions()
	{
		var options = new JsonSerializerOptions();
		options.Converters.Add(new CustomPrimitivesJsonConverterFactory());
		return options;
	}

	[Fact]
	public void Serialization_ConvertsToString()
	{
		JsonSerializer.Serialize(new TestPrimitive(_guid, 50), GetJsonOptions()).Should().Be("\"d17b4c5e-6dd3-4842-aa87-70802eae1887\"");
	}

	[Fact]
	public void Deserialization_ConvertsFromString()
	{
		var options = new JsonSerializerOptions();
		options.Converters.Add(new CustomPrimitivesJsonConverterFactory());
		JsonSerializer.Deserialize<TestPrimitive>(_guid, GetJsonOptions()).Value.Should().Be(new TestPrimitive(_guid, default));
	}

	[Fact]
	public void ModelSerialization_ConvertsToString()
	{
		JsonSerializer.Serialize(new TestModel(new TestPrimitive(_guid, 50)), GetJsonOptions())
			.Should().Be("{\"TestProperty\":\"d17b4c5e-6dd3-4842-aa87-70802eae1887\"}");
	}

	[Fact]
	public void ModelDeserialization_ConvertsFromString()
	{
		JsonSerializer.Deserialize<TestModel>("{\"TestProperty\":\"d17b4c5e-6dd3-4842-aa87-70802eae1887\"}", GetJsonOptions())
			.Should().Be(new TestModel(new TestPrimitive(_guid, default)));
	}
}