using FluentValidation.Internal;

namespace CustomPrimitives.FluentValidation.AspNetCore;

public class PrimitivesMessageFormatter : MessageFormatter
{

	public override string BuildMessage(string messageTemplate)
	{
		var message = base.BuildMessage(messageTemplate).Replace("'PRIMITIVEPROPERTYNAME'", "this value");
		if (message.StartsWith("this value"))
			message = $"This value{message.Substring(10)}";
		return message;
	}
}