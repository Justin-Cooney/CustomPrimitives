public class PersonId : GuidPrimitive<PersonId, PersonId.Validator>
{
	private PersonId(Guid value) : base(value) { }

	public class Validator : PrimitiveValidator<Guid>
	{
		public Validator()
		{
			RuleFor(x => x).NotNull().NotEmpty();
		}
	}
}