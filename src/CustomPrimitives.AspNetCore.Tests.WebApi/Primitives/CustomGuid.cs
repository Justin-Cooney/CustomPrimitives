namespace CustomPrimitives.AspNetCore.Tests.WebApi.Primitives;

public class CustomGuid : GuidPrimitive<CustomGuid>
{
	private CustomGuid(Guid value) : base(value)
	{
	}
}
