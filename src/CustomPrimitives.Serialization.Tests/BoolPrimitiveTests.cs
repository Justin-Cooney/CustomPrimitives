using FluentAssertions;
using System.Text.Json;

namespace CustomPrimitives.Serialization.Tests;

public class BoolPrimitiveTests
{
	private class TestPrimitive : BoolPrimitive<TestPrimitive>
	{
		private TestPrimitive(bool value) : base(value)
		{
		}

		public TestPrimitive(bool value, int testProp) : base(value) { TestProp = testProp; }

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
		JsonSerializer.Serialize(new TestPrimitive(true, 50), GetJsonOptions()).Should().Be("true");
		JsonSerializer.Serialize(new TestPrimitive(false, 50), GetJsonOptions()).Should().Be("false");
	}

	[Fact]
	public void Deserialization_ConvertsFromString()
	{
		var options = new JsonSerializerOptions();
		options.Converters.Add(new CustomPrimitivesJsonConverterFactory());
		JsonSerializer.Deserialize<TestPrimitive>("true", GetJsonOptions()).Value.Should().Be(new TestPrimitive(true, default));
		JsonSerializer.Deserialize<TestPrimitive>("false", GetJsonOptions()).Value.Should().Be(new TestPrimitive(false, default));
	}

	[Fact]
	public void ModelSerialization_ConvertsToString()
	{
		JsonSerializer.Serialize(new TestModel(new TestPrimitive(true, 50)), GetJsonOptions())
			.Should().Be("{\"TestProperty\":true}");
		JsonSerializer.Serialize(new TestModel(new TestPrimitive(false, 50)), GetJsonOptions())
			.Should().Be("{\"TestProperty\":false}");
	}

	[Fact]
	public void ModelDeserialization_ConvertsFromString()
	{
		JsonSerializer.Deserialize<TestModel>("{\"TestProperty\":true}", GetJsonOptions())
			.Should().Be(new TestModel(new TestPrimitive(true, default)));
		JsonSerializer.Deserialize<TestModel>("{\"TestProperty\":false}", GetJsonOptions())
			.Should().Be(new TestModel(new TestPrimitive(false, default)));
	}
}