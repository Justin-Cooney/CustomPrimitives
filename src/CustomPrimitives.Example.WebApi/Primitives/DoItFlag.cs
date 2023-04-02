public class DoItFlag : BoolPrimitive<DoItFlag, DoItFlag.Validator>
{
	private DoItFlag(bool value) : base(value) { }

	public class Validator : PrimitiveValidator<bool>
	{
		public Validator()
		{
			RuleFor(x => x).NotNull().NotEmpty().NotEqual(false);
		}
	}
}