using FluentAssertions;
using FluentValidation;

namespace CustomPrimitives.FluentValidation.Tests;

public class StringPrimitive
{
	public class TestPrimitive : StringPrimitive<TestPrimitive, TestPrimitive.Validator>
	{
		private TestPrimitive(string value) : base(value) { }

		public class Validator : PrimitiveValidator<string>
		{
			public Validator()
			{
				RuleFor(x => x)
				.NotNull()
				.MinimumLength(5);
			}
		}
	}

	[Fact]
	public void Create_InvalidValuesFail()
	{
		var failure = TestPrimitive.Create("abcd").Should().BeFaulted().AndFailureValue;
		failure.Errors.First().ErrorMessage.Should().Contain("must be at least 5 characters. You entered 4 characters.");
	}

	[Fact]
	public void Create_ValidValuesSucceed()
	{
		var success = TestPrimitive.Create("abcde").Should().BeSuccessful().AndSuccessValue;
		success.Value.Should().Be("abcde");
	}
}