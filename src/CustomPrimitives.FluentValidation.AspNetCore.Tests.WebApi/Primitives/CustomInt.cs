using FluentValidation;

namespace CustomPrimitives.FluentValidation.AspNetCore.Tests.WebApi.Primitives;

public class CustomInt : IntPrimitive<CustomInt, CustomInt.Validator>
{
	private CustomInt(int value) : base(value)
	{
	}

	public class Validator : PrimitiveValidator<int>
	{
		public Validator() => RuleFor(x => x).NotEmpty().NotNull().GreaterThan(4);
	}
}
