using FluentValidation;
using FluentValidation.Results;
using Functional;

namespace CustomPrimitives.FluentValidation;

public abstract class StringPrimitive<TCustom, TValidator> : StringPrimitive<TCustom>, IValidationPrimitive<TCustom, TValidator, string>
	where TCustom : StringPrimitive<TCustom>
	where TValidator : IValidator<TCustom>, new ()
{
	private static TValidator _validator => new TValidator();

	protected StringPrimitive(string value) : base(value)
	{
	}

	public static ValidationResult Validate(TCustom value) => _validator.Validate(value);

	protected static Result<TCustom, ValidationResult> TryValidate(TCustom value) => IValidationPrimitive<TCustom, TValidator, string>.TryValidate(value);

	public static Result<TCustom, ValidationResult> Create(string value) => IValidationPrimitive<TCustom, TValidator, string>.Create(value);
}
