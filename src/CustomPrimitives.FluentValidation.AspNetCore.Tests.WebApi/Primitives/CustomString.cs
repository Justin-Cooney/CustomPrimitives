using FluentValidation;

namespace CustomPrimitives.FluentValidation.AspNetCore.Tests.WebApi.Primitives;

public class CustomString : StringPrimitive<CustomString, CustomString.Validator>
{
	private CustomString(string value) : base(value)
	{
	}

	public class Validator : PrimitiveValidator<string>
	{
		public Validator() => RuleFor(x => x).NotEmpty().NotNull().MinimumLength(5);
	}
}
