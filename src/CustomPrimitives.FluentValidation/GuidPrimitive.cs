using FluentValidation;
using FluentValidation.Results;
using Functional;

namespace CustomPrimitives.FluentValidation;

public abstract class GuidPrimitive<TCustom, TValidator> : GuidPrimitive<TCustom>, IValidationPrimitive<TCustom, TValidator, Guid>
	where TCustom : GuidPrimitive<TCustom>
	where TValidator : IValidator<TCustom>, new ()
{
	private static TValidator _validator => new TValidator();

	protected GuidPrimitive(Guid value) : base(value)
	{
	}

	public static ValidationResult Validate(TCustom value) => _validator.Validate(value);

	protected static Result<TCustom, ValidationResult> TryValidate(TCustom value) => IValidationPrimitive<TCustom, TValidator, Guid>.TryValidate(value);

	public static Result<TCustom, ValidationResult> Create(Guid value) => IValidationPrimitive<TCustom, TValidator, Guid>.Create(value);
}