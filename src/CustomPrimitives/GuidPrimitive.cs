namespace CustomPrimitives;

public abstract class GuidPrimitive<TCustom> : Primitive<TCustom, Guid>, IFormattable
	where TCustom : GuidPrimitive<TCustom>
{
	protected GuidPrimitive(Guid value) : base(value) { }
	//
	// Summary:
	//     Returns a 16-element byte array that contains the value of this instance.
	//
	// Returns:
	//     A 16-element byte array.
	public byte[] ToByteArray() => Value.ToByteArray();

	//
	// Summary:
	//     Returns a string representation of the value of this instance in registry format.
	//
	// Returns:
	//     The value of this System.Guid, formatted by using the "D" format specifier as
	//     follows: xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx where the value of the GUID is
	//     represented as a series of lowercase hexadecimal digits in groups of 8, 4, 4,
	//     4, and 12 digits and separated by hyphens. An example of a return value is "382c74c3-721d-4f34-80e5-57657b6cbc27".
	//     To convert the hexadecimal digits from a through f to uppercase, call the System.String.ToUpper
	//     method on the returned string.
	public override string ToString() => Value.ToString();

	//
	// Summary:
	//     Returns a string representation of the value of this System.Guid instance, according
	//     to the provided format specifier.
	//
	// Parameters:
	//   format:
	//     A single format specifier that indicates how to format the value of this System.Guid.
	//     The format parameter can be "N", "D", "B", "P", or "X". If format is null or
	//     an empty string (""), "D" is used.
	//
	// Returns:
	//     The value of this System.Guid, represented as a series of lowercase hexadecimal
	//     digits in the specified format.
	//
	// Exceptions:
	//   T:System.FormatException:
	//     The value of format is not null, an empty string (""), "N", "D", "B", "P", or
	//     "X".
	public string ToString(string? format) => Value.ToString(format);

	//
	// Summary:
	//     Returns a string representation of the value of this instance of the System.Guid
	//     class, according to the provided format specifier and culture-specific format
	//     information.
	//
	// Parameters:
	//   format:
	//     A single format specifier that indicates how to format the value of this System.Guid.
	//     The format parameter can be "N", "D", "B", "P", or "X". If format is null or
	//     an empty string (""), "D" is used.
	//
	//   provider:
	//     (Reserved) An object that supplies culture-specific formatting information.
	//
	// Returns:
	//     The value of this System.Guid, represented as a series of lowercase hexadecimal
	//     digits in the specified format.
	//
	// Exceptions:
	//   T:System.FormatException:
	//     The value of format is not null, an empty string (""), "N", "D", "B", "P", or
	//     "X".
	public string ToString(string? format, IFormatProvider? provider) => Value.ToString(format, provider);

	//
	// Summary:
	//     Tries to format the current GUID instance into the provided character span.
	//
	// Parameters:
	//   destination:
	//     When this method returns, the GUID as a span of characters.
	//
	//   charsWritten:
	//     When this method returns, the number of characters written into the span.
	//
	//   format:
	//     A read-only span containing the character representing one of the following specifiers
	//     that indicates the exact format to use when interpreting input: "N", "D", "B",
	//     "P", or "X".
	//
	// Returns:
	//     true if the formatting operation was successful; false otherwise.
	public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default) => Value.TryFormat(destination, out charsWritten, format);

	//
	// Summary:
	//     Tries to write the current GUID instance into a span of bytes.
	//
	// Parameters:
	//   destination:
	//     When this method returns, the GUID as a span of bytes.
	//
	// Returns:
	//     true if the GUID is successfully written to the specified span; false otherwise.
	public bool TryWriteBytes(Span<byte> destination) => Value.TryWriteBytes(destination);
}