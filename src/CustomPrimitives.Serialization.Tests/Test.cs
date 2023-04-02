using FluentAssertions;
using System.Text.Json;

namespace CustomPrimitives.Serialization.Tests;

public class Test : BoolPrimitive<Test>
{
	private Test(bool value) : base(value)
	{
	}

	public Test(bool value, int tes) : base(value)
	{
	}
}