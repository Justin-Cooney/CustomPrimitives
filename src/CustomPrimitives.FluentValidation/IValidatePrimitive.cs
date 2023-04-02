using FluentValidation;
using FluentValidation.Results;

namespace CustomPrimitives.FluentValidation;

public interface IValidatePrimitive<PrimitiveType, TValidator>
	where TValidator : IValidator<PrimitiveType>, new()
{
	public static ValidationResult Validate(PrimitiveType value) => new TValidator().Validate(value);
}
