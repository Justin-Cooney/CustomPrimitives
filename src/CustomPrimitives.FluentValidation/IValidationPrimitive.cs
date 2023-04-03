using FluentValidation;
using FluentValidation.Results;
using Functional;
using System.Reflection;

namespace CustomPrimitives.FluentValidation;

public interface IValidationPrimitive<TCustom, TValidator, TPrimitive> : IValidatePrimitive<TCustom, TValidator>
	where TCustom : IPrimitive<TPrimitive>
	where TValidator : IValidator<TCustom>, new()
{
	protected static Result<TCustom, ValidationResult> TryValidate(TCustom value)
	{
		var validationResult = Validate(value);
		return Result.Create(validationResult.IsValid, value, validationResult);
	}

	public static Result<TCustom, ValidationResult> Create(TPrimitive value)
	{
		var obj = (TCustom)Activator.CreateInstance(typeof(TCustom), BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new object[] { value }, null);
		return TryValidate(obj);
	}
}