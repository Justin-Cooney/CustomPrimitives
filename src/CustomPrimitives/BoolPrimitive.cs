namespace CustomPrimitives;

public abstract class BoolPrimitive<TCustom> : ConvertiblePrimitive<TCustom, bool>
	where TCustom : BoolPrimitive<TCustom>
{
	protected BoolPrimitive(bool value) : base(value) { }

	public bool TryFormat(Span<char> destination, out int charsWritten) => Value.TryFormat(destination, out charsWritten);
}