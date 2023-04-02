using FluentValidation;
using System.Linq.Expressions;
using System.Reflection;

namespace CustomPrimitives.FluentValidation.AspNetCore;

public static class PrimitivesFluentValidationResolvers
{
	private const string PRIMITIVEPROPERTYNAME = "PRIMITIVEPROPERTYNAME";

	public static string DefaultDisplayNameResolver(Func<Type, MemberInfo, LambdaExpression, string> defaultResolver, Type type, MemberInfo memberInfo, LambdaExpression expression)
	{
		var defaultName = defaultResolver.Invoke(type, memberInfo, expression);
		return string.IsNullOrEmpty(defaultName) ? PRIMITIVEPROPERTYNAME : defaultName;
	}

	public static string DefaultPropertyNameResolver(Func<Type, MemberInfo, LambdaExpression, string> defaultResolver, Type type, MemberInfo memberInfo, LambdaExpression expression)
	{
		var defaultName = defaultResolver.Invoke(type, memberInfo, expression);
		var displayName = ValidatorOptions.Global.DisplayNameResolver.Invoke(type, memberInfo, expression);
		return defaultName == null && displayName == PRIMITIVEPROPERTYNAME ? "" : defaultName;
	}
}