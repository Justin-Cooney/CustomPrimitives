using CustomPrimitives.FluentValidation;
using FluentValidation;

public class SocialInsuranceNumber : StringPrimitive<SocialInsuranceNumber, SocialInsuranceNumber.Validator>
{
	private SocialInsuranceNumber(string value) : base(value) { }

	public class Validator : PrimitiveValidator<string>
	{
		public Validator()
		{
			RuleFor(x => x).NotNull().NotEmpty().MinimumLength(10);
		}
	}
}