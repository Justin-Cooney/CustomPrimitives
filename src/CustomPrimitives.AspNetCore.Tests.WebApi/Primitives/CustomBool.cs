namespace CustomPrimitives.AspNetCore.Tests.WebApi.Primitives;

public class CustomBool : BoolPrimitive<CustomBool>
{
	private CustomBool(bool value) : base(value)
	{
	}
}
