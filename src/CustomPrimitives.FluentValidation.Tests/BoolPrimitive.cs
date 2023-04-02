using FluentAssertions;
using FluentValidation;

namespace CustomPrimitives.FluentValidation.Tests;

public class BoolPrimitive
{
	public class TestPrimitive : BoolPrimitive<TestPrimitive, TestPrimitive.Validator>
	{
		private TestPrimitive(bool value) : base(value) { }

		public class Validator : PrimitiveValidator<bool>
		{
			public Validator()
			{
				RuleFor(x => x)
				.NotNull()
				.Equal(true);
			}
		}
	}

	[Fact]
	public void Create_InvalidValuesFail()
	{
		var failure = TestPrimitive.Create(false).Should().BeFaulted().AndFailureValue;
		failure.Errors.First().ErrorMessage.Should().Contain("must be equal to 'True'");
	}

	[Fact]
	public void Create_ValidValuesSucceed()
	{
		var success = TestPrimitive.Create(true).Should().BeSuccessful().AndSuccessValue;
		success.Value.Should().Be(true);
	}
}