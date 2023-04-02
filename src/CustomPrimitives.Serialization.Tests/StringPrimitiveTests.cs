using FluentAssertions;
using System.Text.Json;

namespace CustomPrimitives.Serialization.Tests;

public class StringPrimitiveTests
{
	private class TestPrimitive : StringPrimitive<TestPrimitive>
	{
		private TestPrimitive(string value) : base(value)
		{
		}

		public TestPrimitive(string value, int testProp) : base(value) { TestProp = testProp; }

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
		JsonSerializer.Serialize(new TestPrimitive("This is a Test", 50), GetJsonOptions()).Should().Be("\"This is a Test\"");
	}

	[Fact]
	public void Deserialization_ConvertsFromString()
	{
		(JsonSerializer.Deserialize<TestPrimitive>("\"This is a Test\"", GetJsonOptions()) as object).Should().Be(new TestPrimitive("This is a Test", default));
	}


	[Fact]
	public void ModelSerialization_ConvertsToString()
	{
		JsonSerializer.Serialize(new TestModel(new TestPrimitive("This is a Test", 50)), GetJsonOptions())
			.Should().Be("{\"TestProperty\":\"This is a Test\"}");
	}

	[Fact]
	public void ModelDeserialization_ConvertsFromString()
	{
		JsonSerializer.Deserialize<TestModel>("{\"TestProperty\":\"This is a Test\"}", GetJsonOptions())
			.Should().Be(new TestModel(new TestPrimitive("This is a Test", default)));
	}
}