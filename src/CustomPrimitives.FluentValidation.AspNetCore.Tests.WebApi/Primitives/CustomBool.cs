using FluentValidation;

namespace CustomPrimitives.FluentValidation.AspNetCore.Tests.WebApi.Primitives;

public class CustomBool : BoolPrimitive<CustomBool, CustomBool.Validator>
{
	private CustomBool(bool value) : base(value)
	{
	}

	public class Validator : PrimitiveValidator<bool>
	{
		public Validator() => RuleFor(x => x).NotEmpty().NotNull().Equal(true);
	}
}
