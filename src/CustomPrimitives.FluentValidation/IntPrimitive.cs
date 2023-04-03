using FluentValidation;
using FluentValidation.Results;
using Functional;

namespace CustomPrimitives.FluentValidation;

public abstract class IntPrimitive<TCustom, TValidator> : IntPrimitive<TCustom>, IValidationPrimitive<TCustom, TValidator, int>
	where TCustom : IntPrimitive<TCustom>
	where TValidator : IValidator<TCustom>, new ()
{
	private static TValidator _validator => new TValidator();

	protected IntPrimitive(int value) : base(value)
	{
	}

	public static ValidationResult Validate(TCustom value) => _validator.Validate(value);

	protected static Result<TCustom, ValidationResult> TryValidate(TCustom value) => IValidationPrimitive<TCustom, TValidator, int>.TryValidate(value);

	public static Result<TCustom, ValidationResult> Create(int value) => IValidationPrimitive<TCustom, TValidator, int>.Create(value);
}