namespace CustomPrimitives.AspNetCore.Tests.WebApi.Primitives;

public class CustomInt : IntPrimitive<CustomInt>
{
	private CustomInt(int value) : base(value)
	{
	}
}
