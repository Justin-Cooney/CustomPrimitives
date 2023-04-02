using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Linq.Expressions;
using System.Reflection;
using Functional;

namespace CustomPrimitives.FluentValidation.AspNetCore;

public static class InstallPrimitiveValidators
{
	public static IServiceCollection AddPrimitivesWithValidation(this IServiceCollection services)
		=> services
			.AddPrimitives()
			.AddPrimitivesFluentValidationOptions();

	public static IServiceCollection AddPrimitivesFluentValidationOptions(this IServiceCollection services)
	{
		ValidatorOptions.Global.MessageFormatterFactory = () => new PrimitivesMessageFormatter();

		var defaultDisplayNameResolver = ValidatorOptions.Global.DisplayNameResolver.Clone() as Func<Type, MemberInfo, LambdaExpression, string>;

		ValidatorOptions.Global.DisplayNameResolver = (type, memberInfo, expression) =>
					   PrimitivesFluentValidationResolvers.DefaultDisplayNameResolver(defaultDisplayNameResolver, type, memberInfo, expression);

		var defaultPropertyResolver = ValidatorOptions.Global.PropertyNameResolver.Clone() as Func<Type, MemberInfo, LambdaExpression, string>;

		ValidatorOptions.Global.PropertyNameResolver = (type, memberInfo, expression) =>
					   PrimitivesFluentValidationResolvers.DefaultPropertyNameResolver(defaultPropertyResolver, type, memberInfo, expression);

		return services;
	}

	public static IServiceCollection AddPrimitiveValidatorsFromAssemblyContaining<T>(this IServiceCollection services, ServiceLifetime lifetime = ServiceLifetime.Scoped, Func<AssemblyScanner.AssemblyScanResult, bool> filter = null, bool includeInternalTypes = false)
		=> services.AddPrimitiveValidatorsFromAssembly(typeof(T).Assembly, lifetime, filter, includeInternalTypes);

	public static IServiceCollection AddPrimitiveValidatorsFromAssembly(this IServiceCollection services, Assembly assembly, ServiceLifetime lifetime = ServiceLifetime.Scoped, Func<AssemblyScanner.AssemblyScanResult, bool> filter = null, bool includeInternalTypes = false)
	{
		FindValidatorsInAssembly(new[] { assembly }, includeInternalTypes).Apply(tuple =>
			services.Add(new ServiceDescriptor(tuple.ivalidator, tuple.implementation, lifetime)));
		return services;
	}

	public static IEnumerable<(Type ivalidator, Type implementation)> FindValidatorsInAssembly(IEnumerable<Assembly> assemblies, bool includeInternalTypes = false)
	{
		var types = assemblies.SelectMany(x => includeInternalTypes ? x.GetTypes() : x.GetExportedTypes()).Distinct();
		var openGenericType = typeof(IValidatePrimitive<,>);

		return types
			.Where(type => type.GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == openGenericType))
			.Select(type => type.GetInterfaces().First(x => x.IsGenericType && x.GetGenericTypeDefinition() == openGenericType))
			.Select(type => (ivalidator: typeof(IValidator<>).MakeGenericType(type.GetGenericArguments()[0]), implementation: type.GetGenericArguments()[1]));
	}
}