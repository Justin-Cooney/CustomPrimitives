using FluentValidation;
using FluentValidation.Results;
using Functional;
using System.Reflection;

namespace CustomPrimitives.FluentValidation;

public abstract class StringPrimitive<PrimitiveType, TValidator> : StringPrimitive<PrimitiveType>, IValidatePrimitive<PrimitiveType, TValidator>
	where PrimitiveType : StringPrimitive<PrimitiveType>
	where TValidator : IValidator<PrimitiveType>, new ()
{
	private static TValidator _validator => new TValidator();

	protected StringPrimitive(string value) : base(value)
	{
	}

	protected static Result<PrimitiveType, ValidationResult> CreateWithValidation(PrimitiveType value)
	{
		var validationResult = Validate(value);
		return Result.Create(validationResult.IsValid, value, validationResult);
	}

	public static ValidationResult Validate(PrimitiveType value) => _validator.Validate(value);

	public static Result<PrimitiveType, ValidationResult> Create(string value)
	{
		var obj = (PrimitiveType) Activator.CreateInstance(typeof(PrimitiveType), BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new object[] { value }, null);
		return CreateWithValidation(obj);
	}
}
