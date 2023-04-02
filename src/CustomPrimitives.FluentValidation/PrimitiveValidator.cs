using FluentValidation;
using FluentValidation.Results;

namespace CustomPrimitives.FluentValidation;

public abstract class PrimitiveValidator<T> : AbstractValidator<T>, IValidator<IPrimitive<T>>
{ 
	bool IValidator.CanValidateInstancesOfType(Type type)
	{
		if (type == null) throw new ArgumentNullException(nameof(type));
		return type.IsAssignableTo(typeof(IPrimitive<T>)) || typeof(T).IsAssignableFrom(type);
	}

	public ValidationResult Validate(IPrimitive<T> instance)
	{
		var value = instance.Value;
		return base.Validate(value);
	}

	public Task<ValidationResult> ValidateAsync(IPrimitive<T> instance, CancellationToken cancellation = default)
	{
		var value = instance.Value;
		return base.ValidateAsync(value);
	}

	public ValidationResult Validate(IValidationContext context)
	{
		if (context.InstanceToValidate is IPrimitive<T> primitiveType)
		{
			var value = primitiveType.Value;
			return base.Validate(new ValidationContext<T>(value));
		}
		return base.Validate(context as ValidationContext<T>);
	}

	public Task<ValidationResult> ValidateAsync(IValidationContext context, CancellationToken cancellation = default)
	{
		if (context.InstanceToValidate is IPrimitive<T> primitiveType)
		{
			var value = primitiveType.Value;
			return base.ValidateAsync(new ValidationContext<T>(value));
		}
		return base.ValidateAsync(context as ValidationContext<T>);
	}
}