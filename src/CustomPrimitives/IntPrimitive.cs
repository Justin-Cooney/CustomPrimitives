namespace CustomPrimitives;

public abstract class IntPrimitive<TCustom> : ConvertiblePrimitive<TCustom, int>, ISpanFormattable, IFormattable
	where TCustom : IntPrimitive<TCustom>
{
	protected IntPrimitive(int value) : base(value) { }

	//
	// Summary:
	//     Converts the numeric value of this instance to its equivalent string representation
	//     using the specified culture-specific format information.
	//
	// Parameters:
	//   provider:
	//     An object that supplies culture-specific formatting information.
	//
	// Returns:
	//     The string representation of the value of this instance as specified by provider.
	public string ToString(IFormatProvider? provider) => Value.ToString(provider);

	//
	// Summary:
	//     Converts the numeric value of this instance to its equivalent string representation,
	//     using the specified format.
	//
	// Parameters:
	//   format:
	//     A standard or custom numeric format string.
	//
	// Returns:
	//     The string representation of the value of this instance as specified by format.
	//
	// Exceptions:
	//   T:System.FormatException:
	//     format is invalid or not supported.
	public string ToString(string? format) => Value.ToString(format);
	//
	// Summary:
	//     Converts the numeric value of this instance to its equivalent string representation
	//     using the specified format and culture-specific format information.
	//
	// Parameters:
	//   format:
	//     A standard or custom numeric format string.
	//
	//   provider:
	//     An object that supplies culture-specific formatting information.
	//
	// Returns:
	//     The string representation of the value of this instance as specified by format
	//     and provider.
	//
	// Exceptions:
	//   T:System.FormatException:
	//     format is invalid or not supported.
	public string ToString(string? format, IFormatProvider? provider) => Value.ToString(format, provider);
	//
	// Summary:
	//     Tries to format the value of the current integer number instance into the provided
	//     span of characters.
	//
	// Parameters:
	//   destination:
	//     When this method returns, this instance's value formatted as a span of characters.
	//
	//   charsWritten:
	//     When this method returns, the number of characters that were written in destination.
	//
	//   format:
	//     A span containing the characters that represent a standard or custom format string
	//     that defines the acceptable format for destination.
	//
	//   provider:
	//     An optional object that supplies culture-specific formatting information for
	//     destination.
	//
	// Returns:
	//     true if the formatting was successful; otherwise, false.
	public bool TryFormat(Span<char> destination, out Int32 charsWritten, ReadOnlySpan<char> format = default, IFormatProvider? provider = null) => Value.TryFormat(destination, out charsWritten, format, provider);


}