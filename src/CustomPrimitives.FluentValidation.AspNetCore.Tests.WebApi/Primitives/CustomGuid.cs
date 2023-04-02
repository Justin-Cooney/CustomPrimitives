using FluentValidation;

namespace CustomPrimitives.FluentValidation.AspNetCore.Tests.WebApi.Primitives;

public class CustomGuid : GuidPrimitive<CustomGuid, CustomGuid.Validator>
{
	private CustomGuid(Guid value) : base(value)
	{
	}

	public class Validator : PrimitiveValidator<Guid>
	{
		public Validator() => RuleFor(x => x).NotEmpty().NotNull();
	}
}
