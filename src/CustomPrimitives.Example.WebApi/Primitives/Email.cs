public class Email : StringPrimitive<Email, Email.Validator>
{
	private Email(string value) : base(value) { }

	public class Validator : PrimitiveValidator<string>
	{
		public Validator()
		{
			RuleFor(x => x).NotNull().NotEmpty().EmailAddress();
		}
	}
}
