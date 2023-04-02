namespace CustomPrimitives.AspNetCore.Tests.WebApi.Primitives;

public class CustomString : StringPrimitive<CustomString>
{
	private CustomString(string value) : base(value)
	{
	}
}
