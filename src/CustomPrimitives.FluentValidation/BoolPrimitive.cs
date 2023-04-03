using FluentValidation;
using FluentValidation.Results;
using Functional;

namespace CustomPrimitives.FluentValidation;

public abstract class BoolPrimitive<TCustom, TValidator> : BoolPrimitive<TCustom>, IValidationPrimitive<TCustom, TValidator, bool>
	where TCustom : BoolPrimitive<TCustom>
	where TValidator : IValidator<TCustom>, new ()
{
	private static TValidator _validator => new TValidator();

	protected BoolPrimitive(bool value) : base(value)
	{
	}

	public static ValidationResult Validate(TCustom value) => _validator.Validate(value);

	protected static Result<TCustom, ValidationResult> TryValidate(TCustom value) => IValidationPrimitive<TCustom, TValidator, bool>.TryValidate(value);

	public static Result<TCustom, ValidationResult> Create(bool value) => IValidationPrimitive<TCustom, TValidator, bool>.Create(value);
}
