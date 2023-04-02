using FluentAssertions;
using System.Text.Json;

namespace CustomPrimitives.Serialization.Tests;

public class IntPrimitiveTests
{
	private class TestPrimitive : IntPrimitive<TestPrimitive>
	{
		private TestPrimitive(int value) : base(value)
		{
		}

		public TestPrimitive(int value, int testProp) : base(value) { TestProp = testProp; }

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
		JsonSerializer.Serialize(new TestPrimitive(9, 50), GetJsonOptions()).Should().Be("9");
	}

	[Fact]
	public void Deserialization_ConvertsFromString()
	{
		(JsonSerializer.Deserialize<TestPrimitive>("9", GetJsonOptions()) as object).Should().Be(new TestPrimitive(9, default));
	}


	[Fact]
	public void ModelSerialization_ConvertsToString()
	{
		JsonSerializer.Serialize(new TestModel(new TestPrimitive(9, 50)), GetJsonOptions())
			.Should().Be("{\"TestProperty\":9}");
	}

	[Fact]
	public void ModelDeserialization_ConvertsFromString()
	{
		JsonSerializer.Deserialize<TestModel>("{\"TestProperty\":9}", GetJsonOptions())
			.Should().Be(new TestModel(new TestPrimitive(9, default)));
	}
}