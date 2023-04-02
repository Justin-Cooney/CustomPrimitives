using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;

namespace CustomPrimitives;

public abstract class StringPrimitive<TCustom> : ConvertiblePrimitive<TCustom, string>, IEnumerable<char>, IEnumerable, ICloneable
	where TCustom : StringPrimitive<TCustom>
{
	protected StringPrimitive(string value) : base(value) { }

	//
	// Summary:
	//     Gets the number of characters in the current System.String object.
	//
	// Returns:
	//     The number of characters in the current string.
	public int Length => Value.Length;

	//
	// Summary:
	//     Returns a reference to this instance of System.String.
	//
	// Returns:
	//     This instance of System.String.
	public object Clone() => Value.Clone();

	//
	// Summary:
	//     Retrieves an object that can iterate through the individual characters in this
	//     string.
	//
	// Returns:
	//     An enumerator object.
	IEnumerator IEnumerable.GetEnumerator() => Value.GetEnumerator();

	//
	// Summary:
	//     Retrieves an object that can iterate through the individual characters in this
	//     string.
	//
	// Returns:
	//     An enumerator object.
	IEnumerator<char> IEnumerable<char>.GetEnumerator() => Value.GetEnumerator();

	//
	// Summary:
	//     Returns a value indicating whether a specified character occurs within this string.
	//
	// Parameters:
	//   value:
	//     The character to seek.
	//
	// Returns:
	//     true if the value parameter occurs within this string; otherwise, false.
	public bool Contains(char value) => Value.Contains(value);

	//
	// Summary:
	//     Returns a value indicating whether a specified character occurs within this string,
	//     using the specified comparison rules.
	//
	// Parameters:
	//   value:
	//     The character to seek.
	//
	//   comparisonType:
	//     One of the enumeration values that specifies the rules to use in the comparison.
	//
	// Returns:
	//     true if the value parameter occurs within this string; otherwise, false.
	public bool Contains(char value, StringComparison comparisonType) => Value.Contains(value, comparisonType);

	//
	// Summary:
	//     Returns a value indicating whether a specified substring occurs within this string.
	//
	// Parameters:
	//   value:
	//     The string to seek.
	//
	// Returns:
	//     true if the value parameter occurs within this string, or if value is the empty
	//     string (""); otherwise, false.
	//
	// Exceptions:
	//   T:System.ArgumentNullException:
	//     value is null.
	public bool Contains(String value) => Value.Contains(value);

	//
	// Summary:
	//     Returns a value indicating whether a specified string occurs within this string,
	//     using the specified comparison rules.
	//
	// Parameters:
	//   value:
	//     The string to seek.
	//
	//   comparisonType:
	//     One of the enumeration values that specifies the rules to use in the comparison.
	//
	// Returns:
	//     true if the value parameter occurs within this string, or if value is the empty
	//     string (""); otherwise, false.
	public bool Contains(String value, StringComparison comparisonType) => Value.Contains(value, comparisonType);

	//
	// Summary:
	//     Copies a specified number of characters from a specified position in this instance
	//     to a specified position in an array of Unicode characters.
	//
	// Parameters:
	//   sourceIndex:
	//     The index of the first character in this instance to copy.
	//
	//   destination:
	//     An array of Unicode characters to which characters in this instance are copied.
	//
	//   destinationIndex:
	//     The index in destination at which the copy operation begins.
	//
	//   count:
	//     The number of characters in this instance to copy to destination.
	//
	// Exceptions:
	//   T:System.ArgumentNullException:
	//     destination is null.
	//
	//   T:System.ArgumentOutOfRangeException:
	//     sourceIndex, destinationIndex, or count is negative -or- sourceIndex does not
	//     identify a position in the current instance. -or- destinationIndex does not identify
	//     a valid index in the destination array. -or- count is greater than the length
	//     of the substring from sourceIndex to the end of this instance -or- count is greater
	//     than the length of the subarray from destinationIndex to the end of the destination
	//     array.
	public void CopyTo(int sourceIndex, char[] destination, int destinationIndex, int count) => Value.CopyTo(sourceIndex, destination, destinationIndex, count);

	//
	// Summary:
	//     Copies the contents of this string into the destination span.
	//
	// Parameters:
	//   destination:
	//     The span into which to copy this string's contents.
	//
	// Exceptions:
	//   T:System.ArgumentException:
	//     The destination span is shorter than the source string.
	public void CopyTo(Span<char> destination) => Value.CopyTo(destination);
	//
	// Summary:
	//     Determines whether the end of this string instance matches the specified character.
	//
	// Parameters:
	//   value:
	//     The character to compare to the character at the end of this instance.
	//
	// Returns:
	//     true if value matches the end of this instance; otherwise, false.
	public bool EndsWith(char value) => Value.EndsWith(value);
	//
	// Summary:
	//     Determines whether the end of this string instance matches the specified string.
	//
	// Parameters:
	//   value:
	//     The string to compare to the substring at the end of this instance.
	//
	// Returns:
	//     true if value matches the end of this instance; otherwise, false.
	//
	// Exceptions:
	//   T:System.ArgumentNullException:
	//     value is null.
	public bool EndsWith(String value) => Value.EndsWith(value);
	//
	// Summary:
	//     Determines whether the end of this string instance matches the specified string
	//     when compared using the specified culture.
	//
	// Parameters:
	//   value:
	//     The string to compare to the substring at the end of this instance.
	//
	//   ignoreCase:
	//     true to ignore case during the comparison; otherwise, false.
	//
	//   culture:
	//     Cultural information that determines how this instance and value are compared.
	//     If culture is null, the current culture is used.
	//
	// Returns:
	//     true if the value parameter matches the end of this string; otherwise, false.
	//
	// Exceptions:
	//   T:System.ArgumentNullException:
	//     value is null.
	public bool EndsWith(String value, bool ignoreCase, CultureInfo? culture) => Value.EndsWith(value, ignoreCase, culture);
	//
	// Summary:
	//     Determines whether the end of this string instance matches the specified string
	//     when compared using the specified comparison option.
	//
	// Parameters:
	//   value:
	//     The string to compare to the substring at the end of this instance.
	//
	//   comparisonType:
	//     One of the enumeration values that determines how this string and value are compared.
	//
	// Returns:
	//     true if the value parameter matches the end of this string; otherwise, false.
	//
	// Exceptions:
	//   T:System.ArgumentNullException:
	//     value is null.
	//
	//   T:System.ArgumentException:
	//     comparisonType is not a System.StringComparison value.
	public bool EndsWith(String value, StringComparison comparisonType) => Value.EndsWith(value, comparisonType);
	//
	// Summary:
	//     Returns an enumeration of System.Text.Rune from this string.
	//
	// Returns:
	//     A string rune enumerator.
	public StringRuneEnumerator EnumerateRunes() => Value.EnumerateRunes();
	//
	// Summary:
	//     Determines whether this string and a specified System.String object have the
	//     same value. A parameter specifies the culture, case, and sort rules used in the
	//     comparison.
	//
	// Parameters:
	//   value:
	//     The string to compare to this instance.
	//
	//   comparisonType:
	//     One of the enumeration values that specifies how the strings will be compared.
	//
	// Returns:
	//     true if the value of the value parameter is the same as this string; otherwise,
	//     false.
	//
	// Exceptions:
	//   T:System.ArgumentException:
	//     comparisonType is not a System.StringComparison value.
	public bool Equals([NotNullWhen(true)] String? value, StringComparison comparisonType) => Value.Equals(value, comparisonType);

	//
	// Summary:
	//     Retrieves an object that can iterate through the individual characters in this
	//     string.
	//
	// Returns:
	//     An enumerator object.
	public CharEnumerator GetEnumerator() => Value.GetEnumerator();
	//
	// Summary:
	//     Returns the hash code for this string using the specified rules.
	//
	// Parameters:
	//   comparisonType:
	//     One of the enumeration values that specifies the rules to use in the comparison.
	//
	// Returns:
	//     A 32-bit signed integer hash code.
	public int GetHashCode(StringComparison comparisonType) => Value.GetHashCode(comparisonType);

	//
	// Summary:
	//     Reports the zero-based index of the first occurrence of the specified string
	//     in the current System.String object. A parameter specifies the type of search
	//     to use for the specified string.
	//
	// Parameters:
	//   value:
	//     The string to seek.
	//
	//   comparisonType:
	//     One of the enumeration values that specifies the rules for the search.
	//
	// Returns:
	//     The index position of the value parameter if that string is found, or -1 if it
	//     is not. If value is System.String.Empty, the return value is 0.
	//
	// Exceptions:
	//   T:System.ArgumentNullException:
	//     value is null.
	//
	//   T:System.ArgumentException:
	//     comparisonType is not a valid System.StringComparison value.
	public int IndexOf(String value, StringComparison comparisonType) => Value.IndexOf(value, comparisonType);

	//
	// Summary:
	//     Reports the zero-based index of the first occurrence of the specified string
	//     in this instance. The search starts at a specified character position and examines
	//     a specified number of character positions.
	//
	// Parameters:
	//   value:
	//     The string to seek.
	//
	//   startIndex:
	//     The search starting position.
	//
	//   count:
	//     The number of character positions to examine.
	//
	// Returns:
	//     The zero-based index position of value from the start of the current instance
	//     if that string is found, or -1 if it is not. If value is System.String.Empty,
	//     the return value is startIndex.
	//
	// Exceptions:
	//   T:System.ArgumentNullException:
	//     value is null.
	//
	//   T:System.ArgumentOutOfRangeException:
	//     count or startIndex is negative. -or- startIndex is greater than the length of
	//     this string. -or- count is greater than the length of this string minus startIndex.
	public int IndexOf(String value, int startIndex, int count) => Value.IndexOf(value, startIndex, count);
	//
	// Summary:
	//     Reports the zero-based index of the first occurrence of the specified string
	//     in this instance. The search starts at a specified character position.
	//
	// Parameters:
	//   value:
	//     The string to seek.
	//
	//   startIndex:
	//     The search starting position.
	//
	// Returns:
	//     The zero-based index position of value from the start of the current instance
	//     if that string is found, or -1 if it is not. If value is System.String.Empty,
	//     the return value is startIndex.
	//
	// Exceptions:
	//   T:System.ArgumentNullException:
	//     value is null.
	//
	//   T:System.ArgumentOutOfRangeException:
	//     startIndex is less than 0 (zero) or greater than the length of this string.
	public int IndexOf(String value, int startIndex) => Value.IndexOf(value, startIndex);
	//
	// Summary:
	//     Reports the zero-based index of the first occurrence of the specified string
	//     in this instance.
	//
	// Parameters:
	//   value:
	//     The string to seek.
	//
	// Returns:
	//     The zero-based index position of value if that string is found, or -1 if it is
	//     not. If value is System.String.Empty, the return value is 0.
	//
	// Exceptions:
	//   T:System.ArgumentNullException:
	//     value is null.
	public int IndexOf(String value) => Value.IndexOf(value);
	//
	// Summary:
	//     Reports the zero-based index of the first occurrence of the specified Unicode
	//     character in this string. A parameter specifies the type of search to use for
	//     the specified character.
	//
	// Parameters:
	//   value:
	//     The character to seek.
	//
	//   comparisonType:
	//     An enumeration value that specifies the rules for the search.
	//
	// Returns:
	//     The zero-based index of value if that character is found, or -1 if it is not.
	//
	// Exceptions:
	//   T:System.ArgumentException:
	//     comparisonType is not a valid System.StringComparison value.
	public int IndexOf(char value, StringComparison comparisonType) => Value.IndexOf(value, comparisonType);
	//
	// Summary:
	//     Reports the zero-based index of the first occurrence of the specified character
	//     in this instance. The search starts at a specified character position and examines
	//     a specified number of character positions.
	//
	// Parameters:
	//   value:
	//     A Unicode character to seek.
	//
	//   startIndex:
	//     The search starting position.
	//
	//   count:
	//     The number of character positions to examine.
	//
	// Returns:
	//     The zero-based index position of value from the start of the string if that character
	//     is found, or -1 if it is not.
	//
	// Exceptions:
	//   T:System.ArgumentOutOfRangeException:
	//     count or startIndex is negative. -or- startIndex is greater than the length of
	//     this string. -or- count is greater than the length of this string minus startIndex.
	public int IndexOf(char value, int startIndex, int count) => Value.IndexOf(value, startIndex, count);
	//
	// Summary:
	//     Reports the zero-based index of the first occurrence of the specified Unicode
	//     character in this string. The search starts at a specified character position.
	//
	// Parameters:
	//   value:
	//     A Unicode character to seek.
	//
	//   startIndex:
	//     The search starting position.
	//
	// Returns:
	//     The zero-based index position of value from the start of the string if that character
	//     is found, or -1 if it is not.
	//
	// Exceptions:
	//   T:System.ArgumentOutOfRangeException:
	//     startIndex is less than 0 (zero) or greater than the length of the string.
	public int IndexOf(char value, int startIndex) => Value.IndexOf(value, startIndex);
	//
	// Summary:
	//     Reports the zero-based index of the first occurrence of the specified Unicode
	//     character in this string.
	//
	// Parameters:
	//   value:
	//     A Unicode character to seek.
	//
	// Returns:
	//     The zero-based index position of value if that character is found, or -1 if it
	//     is not.
	public int IndexOf(char value) => Value.IndexOf(value);
	//
	// Summary:
	//     Reports the zero-based index of the first occurrence of the specified string
	//     in the current System.String object. Parameters specify the starting search position
	//     in the current string, the number of characters in the current string to search,
	//     and the type of search to use for the specified string.
	//
	// Parameters:
	//   value:
	//     The string to seek.
	//
	//   startIndex:
	//     The search starting position.
	//
	//   count:
	//     The number of character positions to examine.
	//
	//   comparisonType:
	//     One of the enumeration values that specifies the rules for the search.
	//
	// Returns:
	//     The zero-based index position of the value parameter from the start of the current
	//     instance if that string is found, or -1 if it is not. If value is System.String.Empty,
	//     the return value is startIndex.
	//
	// Exceptions:
	//   T:System.ArgumentNullException:
	//     value is null.
	//
	//   T:System.ArgumentOutOfRangeException:
	//     count or startIndex is negative. -or- startIndex is greater than the length of
	//     this instance. -or- count is greater than the length of this string minus startIndex.
	//
	//   T:System.ArgumentException:
	//     comparisonType is not a valid System.StringComparison value.
	public int IndexOf(String value, int startIndex, int count, StringComparison comparisonType) => Value.IndexOf(value, startIndex, count, comparisonType);
	//
	// Summary:
	//     Reports the zero-based index of the first occurrence of the specified string
	//     in the current System.String object. Parameters specify the starting search position
	//     in the current string and the type of search to use for the specified string.
	//
	// Parameters:
	//   value:
	//     The string to seek.
	//
	//   startIndex:
	//     The search starting position.
	//
	//   comparisonType:
	//     One of the enumeration values that specifies the rules for the search.
	//
	// Returns:
	//     The zero-based index position of the value parameter from the start of the current
	//     instance if that string is found, or -1 if it is not. If value is System.String.Empty,
	//     the return value is startIndex.
	//
	// Exceptions:
	//   T:System.ArgumentNullException:
	//     value is null.
	//
	//   T:System.ArgumentOutOfRangeException:
	//     startIndex is less than 0 (zero) or greater than the length of this string.
	//
	//   T:System.ArgumentException:
	//     comparisonType is not a valid System.StringComparison value.
	public int IndexOf(String value, int startIndex, StringComparison comparisonType) => Value.IndexOf(value, startIndex, comparisonType);
	//
	// Summary:
	//     Reports the zero-based index of the first occurrence in this instance of any
	//     character in a specified array of Unicode characters. The search starts at a
	//     specified character position.
	//
	// Parameters:
	//   anyOf:
	//     A Unicode character array containing one or more characters to seek.
	//
	//   startIndex:
	//     The search starting position.
	//
	// Returns:
	//     The zero-based index position of the first occurrence in this instance where
	//     any character in anyOf was found; -1 if no character in anyOf was found.
	//
	// Exceptions:
	//   T:System.ArgumentNullException:
	//     anyOf is null.
	//
	//   T:System.ArgumentOutOfRangeException:
	//     startIndex is negative. -or- startIndex is greater than the number of characters
	//     in this instance.
	public int IndexOfAny(char[] anyOf, int startIndex) => Value.IndexOfAny(anyOf, startIndex);
	//
	// Summary:
	//     Reports the zero-based index of the first occurrence in this instance of any
	//     character in a specified array of Unicode characters. The search starts at a
	//     specified character position and examines a specified number of character positions.
	//
	// Parameters:
	//   anyOf:
	//     A Unicode character array containing one or more characters to seek.
	//
	//   startIndex:
	//     The search starting position.
	//
	//   count:
	//     The number of character positions to examine.
	//
	// Returns:
	//     The zero-based index position of the first occurrence in this instance where
	//     any character in anyOf was found; -1 if no character in anyOf was found.
	//
	// Exceptions:
	//   T:System.ArgumentNullException:
	//     anyOf is null.
	//
	//   T:System.ArgumentOutOfRangeException:
	//     count or startIndex is negative. -or- count + startIndex is greater than the
	//     number of characters in this instance.
	public int IndexOfAny(char[] anyOf, int startIndex, int count) => Value.IndexOfAny(anyOf, startIndex, count);
	//
	// Summary:
	//     Reports the zero-based index of the first occurrence in this instance of any
	//     character in a specified array of Unicode characters.
	//
	// Parameters:
	//   anyOf:
	//     A Unicode character array containing one or more characters to seek.
	//
	// Returns:
	//     The zero-based index position of the first occurrence in this instance where
	//     any character in anyOf was found; -1 if no character in anyOf was found.
	//
	// Exceptions:
	//   T:System.ArgumentNullException:
	//     anyOf is null.
	public int IndexOfAny(char[] anyOf) => Value.IndexOfAny(anyOf);
	//
	// Summary:
	//     Returns a new string in which a specified string is inserted at a specified index
	//     position in this instance.
	//
	// Parameters:
	//   startIndex:
	//     The zero-based index position of the insertion.
	//
	//   value:
	//     The string to insert.
	//
	// Returns:
	//     A new string that is equivalent to this instance, but with value inserted at
	//     position startIndex.
	//
	// Exceptions:
	//   T:System.ArgumentNullException:
	//     value is null.
	//
	//   T:System.ArgumentOutOfRangeException:
	//     startIndex is negative or greater than the length of this instance.
	public String Insert(int startIndex, String value) => Value.Insert(startIndex, value);
	//
	// Summary:
	//     Indicates whether this string is in Unicode normalization form C.
	//
	// Returns:
	//     true if this string is in normalization form C; otherwise, false.
	//
	// Exceptions:
	//   T:System.ArgumentException:
	//     The current instance contains invalid Unicode characters.
	public bool IsNormalized() => Value.IsNormalized();
	//
	// Summary:
	//     Indicates whether this string is in the specified Unicode normalization form.
	//
	// Parameters:
	//   normalizationForm:
	//     A Unicode normalization form.
	//
	// Returns:
	//     true if this string is in the normalization form specified by the normalizationForm
	//     parameter; otherwise, false.
	//
	// Exceptions:
	//   T:System.ArgumentException:
	//     The current instance contains invalid Unicode characters.
	public bool IsNormalized(NormalizationForm normalizationForm) => Value.IsNormalized(normalizationForm);
	//
	// Summary:
	//     Reports the zero-based index position of the last occurrence of the specified
	//     Unicode character in a substring within this instance. The search starts at a
	//     specified character position and proceeds backward toward the beginning of the
	//     string for a specified number of character positions.
	//
	// Parameters:
	//   value:
	//     The Unicode character to seek.
	//
	//   startIndex:
	//     The starting position of the search. The search proceeds from startIndex toward
	//     the beginning of this instance.
	//
	//   count:
	//     The number of character positions to examine.
	//
	// Returns:
	//     The zero-based index position of value if that character is found, or -1 if it
	//     is not found or if the current instance equals System.String.Empty.
	//
	// Exceptions:
	//   T:System.ArgumentOutOfRangeException:
	//     The current instance does not equal System.String.Empty, and startIndex is less
	//     than zero or greater than or equal to the length of this instance. -or- The current
	//     instance does not equal System.String.Empty, and startIndex - count + 1 is less
	//     than zero.
	public int LastIndexOf(char value, int startIndex, int count) => Value.LastIndexOf(value, startIndex, count);
	//
	// Summary:
	//     Reports the zero-based index position of the last occurrence of a specified string
	//     within this instance.
	//
	// Parameters:
	//   value:
	//     The string to seek.
	//
	// Returns:
	//     The zero-based starting index position of value if that string is found, or -1
	//     if it is not.
	//
	// Exceptions:
	//   T:System.ArgumentNullException:
	//     value is null.
	public int LastIndexOf(String value) => Value.LastIndexOf(value);
	//
	// Summary:
	//     Reports the zero-based index position of the last occurrence of a specified string
	//     within this instance. The search starts at a specified character position and
	//     proceeds backward toward the beginning of the string.
	//
	// Parameters:
	//   value:
	//     The string to seek.
	//
	//   startIndex:
	//     The search starting position. The search proceeds from startIndex toward the
	//     beginning of this instance.
	//
	// Returns:
	//     The zero-based starting index position of value if that string is found, or -1
	//     if it is not found or if the current instance equals System.String.Empty.
	//
	// Exceptions:
	//   T:System.ArgumentNullException:
	//     value is null.
	//
	//   T:System.ArgumentOutOfRangeException:
	//     The current instance does not equal System.String.Empty, and startIndex is less
	//     than zero or greater than the length of the current instance. -or- The current
	//     instance equals System.String.Empty, and startIndex is less than -1 or greater
	//     than zero.
	public int LastIndexOf(String value, int startIndex) => Value.LastIndexOf(value, startIndex);
	//
	// Summary:
	//     Reports the zero-based index position of the last occurrence of a specified string
	//     within this instance. The search starts at a specified character position and
	//     proceeds backward toward the beginning of the string for a specified number of
	//     character positions.
	//
	// Parameters:
	//   value:
	//     The string to seek.
	//
	//   startIndex:
	//     The search starting position. The search proceeds from startIndex toward the
	//     beginning of this instance.
	//
	//   count:
	//     The number of character positions to examine.
	//
	// Returns:
	//     The zero-based starting index position of value if that string is found, or -1
	//     if it is not found or if the current instance equals System.String.Empty.
	//
	// Exceptions:
	//   T:System.ArgumentNullException:
	//     value is null.
	//
	//   T:System.ArgumentOutOfRangeException:
	//     count is negative. -or- The current instance does not equal System.String.Empty,
	//     and startIndex is negative. -or- The current instance does not equal System.String.Empty,
	//     and startIndex is greater than the length of this instance. -or- The current
	//     instance does not equal System.String.Empty, and startIndex - count+ 1 specifies
	//     a position that is not within this instance. -or- The current instance equals
	//     System.String.Empty and start is less than -1 or greater than zero. -or- The
	//     current instance equals System.String.Empty and count is greater than 1.
	public int LastIndexOf(String value, int startIndex, int count) => Value.LastIndexOf(value, startIndex, count);
	//
	// Summary:
	//     Reports the zero-based index position of the last occurrence of a specified string
	//     within this instance. The search starts at a specified character position and
	//     proceeds backward toward the beginning of the string for the specified number
	//     of character positions. A parameter specifies the type of comparison to perform
	//     when searching for the specified string.
	//
	// Parameters:
	//   value:
	//     The string to seek.
	//
	//   startIndex:
	//     The search starting position. The search proceeds from startIndex toward the
	//     beginning of this instance.
	//
	//   count:
	//     The number of character positions to examine.
	//
	//   comparisonType:
	//     One of the enumeration values that specifies the rules for the search.
	//
	// Returns:
	//     The zero-based starting index position of the value parameter if that string
	//     is found, or -1 if it is not found or if the current instance equals System.String.Empty.
	//
	// Exceptions:
	//   T:System.ArgumentNullException:
	//     value is null.
	//
	//   T:System.ArgumentOutOfRangeException:
	//     count is negative. -or- The current instance does not equal System.String.Empty,
	//     and startIndex is negative. -or- The current instance does not equal System.String.Empty,
	//     and startIndex is greater than the length of this instance. -or- The current
	//     instance does not equal System.String.Empty, and startIndex + 1 - count specifies
	//     a position that is not within this instance. -or- The current instance equals
	//     System.String.Empty and start is less than -1 or greater than zero. -or- The
	//     current instance equals System.String.Empty and count is greater than 1.
	//
	//   T:System.ArgumentException:
	//     comparisonType is not a valid System.StringComparison value.
	public int LastIndexOf(String value, int startIndex, int count, StringComparison comparisonType) => Value.LastIndexOf(value, startIndex, count, comparisonType);
	//
	// Summary:
	//     Reports the zero-based index of the last occurrence of a specified string within
	//     the current System.String object. The search starts at a specified character
	//     position and proceeds backward toward the beginning of the string. A parameter
	//     specifies the type of comparison to perform when searching for the specified
	//     string.
	//
	// Parameters:
	//   value:
	//     The string to seek.
	//
	//   startIndex:
	//     The search starting position. The search proceeds from startIndex toward the
	//     beginning of this instance.
	//
	//   comparisonType:
	//     One of the enumeration values that specifies the rules for the search.
	//
	// Returns:
	//     The zero-based starting index position of the value parameter if that string
	//     is found, or -1 if it is not found or if the current instance equals System.String.Empty.
	//
	// Exceptions:
	//   T:System.ArgumentNullException:
	//     value is null.
	//
	//   T:System.ArgumentOutOfRangeException:
	//     The current instance does not equal System.String.Empty, and startIndex is less
	//     than zero or greater than the length of the current instance. -or- The current
	//     instance equals System.String.Empty, and startIndex is less than -1 or greater
	//     than zero.
	//
	//   T:System.ArgumentException:
	//     comparisonType is not a valid System.StringComparison value.
	public int LastIndexOf(String value, int startIndex, StringComparison comparisonType) => Value.LastIndexOf(value, startIndex, comparisonType);
	//
	// Summary:
	//     Reports the zero-based index of the last occurrence of a specified string within
	//     the current System.String object. A parameter specifies the type of search to
	//     use for the specified string.
	//
	// Parameters:
	//   value:
	//     The string to seek.
	//
	//   comparisonType:
	//     One of the enumeration values that specifies the rules for the search.
	//
	// Returns:
	//     The zero-based starting index position of the value parameter if that string
	//     is found, or -1 if it is not.
	//
	// Exceptions:
	//   T:System.ArgumentNullException:
	//     value is null.
	//
	//   T:System.ArgumentException:
	//     comparisonType is not a valid System.StringComparison value.
	public int LastIndexOf(String value, StringComparison comparisonType) => Value.LastIndexOf(value, comparisonType);
	//
	// Summary:
	//     Reports the zero-based index position of the last occurrence of a specified Unicode
	//     character within this instance. The search starts at a specified character position
	//     and proceeds backward toward the beginning of the string.
	//
	// Parameters:
	//   value:
	//     The Unicode character to seek.
	//
	//   startIndex:
	//     The starting position of the search. The search proceeds from startIndex toward
	//     the beginning of this instance.
	//
	// Returns:
	//     The zero-based index position of value if that character is found, or -1 if it
	//     is not found or if the current instance equals System.String.Empty.
	//
	// Exceptions:
	//   T:System.ArgumentOutOfRangeException:
	//     The current instance does not equal System.String.Empty, and startIndex is less
	//     than zero or greater than or equal to the length of this instance.
	public int LastIndexOf(char value, int startIndex) => Value.LastIndexOf(value, startIndex);
	//
	// Summary:
	//     Reports the zero-based index position of the last occurrence of a specified Unicode
	//     character within this instance.
	//
	// Parameters:
	//   value:
	//     The Unicode character to seek.
	//
	// Returns:
	//     The zero-based index position of value if that character is found, or -1 if it
	//     is not.
	public int LastIndexOf(char value) => Value.LastIndexOf(value);
	//
	// Summary:
	//     Reports the zero-based index position of the last occurrence in this instance
	//     of one or more characters specified in a Unicode array.
	//
	// Parameters:
	//   anyOf:
	//     A Unicode character array containing one or more characters to seek.
	//
	// Returns:
	//     The index position of the last occurrence in this instance where any character
	//     in anyOf was found; -1 if no character in anyOf was found.
	//
	// Exceptions:
	//   T:System.ArgumentNullException:
	//     anyOf is null.
	public int LastIndexOfAny(char[] anyOf) => Value.LastIndexOfAny(anyOf);
	//
	// Summary:
	//     Reports the zero-based index position of the last occurrence in this instance
	//     of one or more characters specified in a Unicode array. The search starts at
	//     a specified character position and proceeds backward toward the beginning of
	//     the string.
	//
	// Parameters:
	//   anyOf:
	//     A Unicode character array containing one or more characters to seek.
	//
	//   startIndex:
	//     The search starting position. The search proceeds from startIndex toward the
	//     beginning of this instance.
	//
	// Returns:
	//     The index position of the last occurrence in this instance where any character
	//     in anyOf was found; -1 if no character in anyOf was found or if the current instance
	//     equals System.String.Empty.
	//
	// Exceptions:
	//   T:System.ArgumentNullException:
	//     anyOf is null.
	//
	//   T:System.ArgumentOutOfRangeException:
	//     The current instance does not equal System.String.Empty, and startIndex specifies
	//     a position that is not within this instance.
	public int LastIndexOfAny(char[] anyOf, int startIndex) => Value.LastIndexOfAny(anyOf, startIndex);
	//
	// Summary:
	//     Reports the zero-based index position of the last occurrence in this instance
	//     of one or more characters specified in a Unicode array. The search starts at
	//     a specified character position and proceeds backward toward the beginning of
	//     the string for a specified number of character positions.
	//
	// Parameters:
	//   anyOf:
	//     A Unicode character array containing one or more characters to seek.
	//
	//   startIndex:
	//     The search starting position. The search proceeds from startIndex toward the
	//     beginning of this instance.
	//
	//   count:
	//     The number of character positions to examine.
	//
	// Returns:
	//     The index position of the last occurrence in this instance where any character
	//     in anyOf was found; -1 if no character in anyOf was found or if the current instance
	//     equals System.String.Empty.
	//
	// Exceptions:
	//   T:System.ArgumentNullException:
	//     anyOf is null.
	//
	//   T:System.ArgumentOutOfRangeException:
	//     The current instance does not equal System.String.Empty, and count or startIndex
	//     is negative. -or- The current instance does not equal System.String.Empty, and
	//     startIndex minus count + 1 is less than zero.
	public int LastIndexOfAny(char[] anyOf, int startIndex, int count) => Value.LastIndexOfAny(anyOf,startIndex,count);
	//
	// Summary:
	//     Returns a new string whose textual value is the same as this string, but whose
	//     binary representation is in Unicode normalization form C.
	//
	// Returns:
	//     A new, normalized string whose textual value is the same as this string, but
	//     whose binary representation is in normalization form C.
	//
	// Exceptions:
	//   T:System.ArgumentException:
	//     The current instance contains invalid Unicode characters.
	public String Normalize() => Value.Normalize();
	//
	// Summary:
	//     Returns a new string whose textual value is the same as this string, but whose
	//     binary representation is in the specified Unicode normalization form.
	//
	// Parameters:
	//   normalizationForm:
	//     A Unicode normalization form.
	//
	// Returns:
	//     A new string whose textual value is the same as this string, but whose binary
	//     representation is in the normalization form specified by the normalizationForm
	//     parameter.
	//
	// Exceptions:
	//   T:System.ArgumentException:
	//     The current instance contains invalid Unicode characters.
	public String Normalize(NormalizationForm normalizationForm) => Value.Normalize(normalizationForm);
	//
	// Summary:
	//     Returns a new string that right-aligns the characters in this instance by padding
	//     them on the left with a specified Unicode character, for a specified total length.
	//
	// Parameters:
	//   totalWidth:
	//     The number of characters in the resulting string, equal to the number of original
	//     characters plus any additional padding characters.
	//
	//   paddingChar:
	//     A Unicode padding character.
	//
	// Returns:
	//     A new string that is equivalent to this instance, but right-aligned and padded
	//     on the left with as many paddingChar characters as needed to create a length
	//     of totalWidth. However, if totalWidth is less than the length of this instance,
	//     the method returns a reference to the existing instance. If totalWidth is equal
	//     to the length of this instance, the method returns a new string that is identical
	//     to this instance.
	//
	// Exceptions:
	//   T:System.ArgumentOutOfRangeException:
	//     totalWidth is less than zero.
	public String PadLeft(int totalWidth, char paddingChar) => Value.PadLeft(totalWidth, paddingChar);
	//
	// Summary:
	//     Returns a new string that right-aligns the characters in this instance by padding
	//     them with spaces on the left, for a specified total length.
	//
	// Parameters:
	//   totalWidth:
	//     The number of characters in the resulting string, equal to the number of original
	//     characters plus any additional padding characters.
	//
	// Returns:
	//     A new string that is equivalent to this instance, but right-aligned and padded
	//     on the left with as many spaces as needed to create a length of totalWidth. However,
	//     if totalWidth is less than the length of this instance, the method returns a
	//     reference to the existing instance. If totalWidth is equal to the length of this
	//     instance, the method returns a new string that is identical to this instance.
	//
	// Exceptions:
	//   T:System.ArgumentOutOfRangeException:
	//     totalWidth is less than zero.
	public String PadLeft(int totalWidth) => Value.PadLeft(totalWidth);
	//
	// Summary:
	//     Returns a new string that left-aligns the characters in this string by padding
	//     them with spaces on the right, for a specified total length.
	//
	// Parameters:
	//   totalWidth:
	//     The number of characters in the resulting string, equal to the number of original
	//     characters plus any additional padding characters.
	//
	// Returns:
	//     A new string that is equivalent to this instance, but left-aligned and padded
	//     on the right with as many spaces as needed to create a length of totalWidth.
	//     However, if totalWidth is less than the length of this instance, the method returns
	//     a reference to the existing instance. If totalWidth is equal to the length of
	//     this instance, the method returns a new string that is identical to this instance.
	//
	// Exceptions:
	//   T:System.ArgumentOutOfRangeException:
	//     totalWidth is less than zero.
	public String PadRight(int totalWidth) => Value.PadRight(totalWidth);
	//
	// Summary:
	//     Returns a new string that left-aligns the characters in this string by padding
	//     them on the right with a specified Unicode character, for a specified total length.
	//
	// Parameters:
	//   totalWidth:
	//     The number of characters in the resulting string, equal to the number of original
	//     characters plus any additional padding characters.
	//
	//   paddingChar:
	//     A Unicode padding character.
	//
	// Returns:
	//     A new string that is equivalent to this instance, but left-aligned and padded
	//     on the right with as many paddingChar characters as needed to create a length
	//     of totalWidth. However, if totalWidth is less than the length of this instance,
	//     the method returns a reference to the existing instance. If totalWidth is equal
	//     to the length of this instance, the method returns a new string that is identical
	//     to this instance.
	//
	// Exceptions:
	//   T:System.ArgumentOutOfRangeException:
	//     totalWidth is less than zero.
	public String PadRight(int totalWidth, char paddingChar) => Value.PadRight(totalWidth, paddingChar);
	//
	// Summary:
	//     Returns a new string in which all the characters in the current instance, beginning
	//     at a specified position and continuing through the last position, have been deleted.
	//
	// Parameters:
	//   startIndex:
	//     The zero-based position to begin deleting characters.
	//
	// Returns:
	//     A new string that is equivalent to this string except for the removed characters.
	//
	// Exceptions:
	//   T:System.ArgumentOutOfRangeException:
	//     startIndex is less than zero. -or- startIndex specifies a position that is not
	//     within this string.
	public String Remove(int startIndex) => Value.Remove(startIndex);
	//
	// Summary:
	//     Returns a new string in which a specified number of characters in the current
	//     instance beginning at a specified position have been deleted.
	//
	// Parameters:
	//   startIndex:
	//     The zero-based position to begin deleting characters.
	//
	//   count:
	//     The number of characters to delete.
	//
	// Returns:
	//     A new string that is equivalent to this instance except for the removed characters.
	//
	// Exceptions:
	//   T:System.ArgumentOutOfRangeException:
	//     Either startIndex or count is less than zero. -or- startIndex plus count specify
	//     a position outside this instance.
	public String Remove(int startIndex, int count) => Value.Remove(startIndex, count);
	//
	// Summary:
	//     Returns a new string in which all occurrences of a specified Unicode character
	//     in this instance are replaced with another specified Unicode character.
	//
	// Parameters:
	//   oldChar:
	//     The Unicode character to be replaced.
	//
	//   newChar:
	//     The Unicode character to replace all occurrences of oldChar.
	//
	// Returns:
	//     A string that is equivalent to this instance except that all instances of oldChar
	//     are replaced with newChar. If oldChar is not found in the current instance, the
	//     method returns the current instance unchanged.
	public String Replace(char oldChar, char newChar) => Value.Replace(oldChar, newChar);
	//
	// Summary:
	//     Returns a new string in which all occurrences of a specified string in the current
	//     instance are replaced with another specified string.
	//
	// Parameters:
	//   oldValue:
	//     The string to be replaced.
	//
	//   newValue:
	//     The string to replace all occurrences of oldValue.
	//
	// Returns:
	//     A string that is equivalent to the current string except that all instances of
	//     oldValue are replaced with newValue. If oldValue is not found in the current
	//     instance, the method returns the current instance unchanged.
	//
	// Exceptions:
	//   T:System.ArgumentNullException:
	//     oldValue is null.
	//
	//   T:System.ArgumentException:
	//     oldValue is the empty string ("").
	public String Replace(String oldValue, String? newValue) => Value.Replace(oldValue, newValue);
	//
	// Summary:
	//     Returns a new string in which all occurrences of a specified string in the current
	//     instance are replaced with another specified string, using the provided culture
	//     and case sensitivity.
	//
	// Parameters:
	//   oldValue:
	//     The string to be replaced.
	//
	//   newValue:
	//     The string to replace all occurrences of oldValue.
	//
	//   ignoreCase:
	//     true to ignore casing when comparing; false otherwise.
	//
	//   culture:
	//     The culture to use when comparing. If culture is null, the current culture is
	//     used.
	//
	// Returns:
	//     A string that is equivalent to the current string except that all instances of
	//     oldValue are replaced with newValue. If oldValue is not found in the current
	//     instance, the method returns the current instance unchanged.
	//
	// Exceptions:
	//   T:System.ArgumentNullException:
	//     oldValue is null.
	//
	//   T:System.ArgumentException:
	//     oldValue is the empty string ("").
	public String Replace(String oldValue, String? newValue, bool ignoreCase, CultureInfo? culture) => Value.Replace(oldValue, newValue, ignoreCase, culture);
	//
	// Summary:
	//     Returns a new string in which all occurrences of a specified string in the current
	//     instance are replaced with another specified string, using the provided comparison
	//     type.
	//
	// Parameters:
	//   oldValue:
	//     The string to be replaced.
	//
	//   newValue:
	//     The string to replace all occurrences of oldValue.
	//
	//   comparisonType:
	//     One of the enumeration values that determines how oldValue is searched within
	//     this instance.
	//
	// Returns:
	//     A string that is equivalent to the current string except that all instances of
	//     oldValue are replaced with newValue. If oldValue is not found in the current
	//     instance, the method returns the current instance unchanged.
	//
	// Exceptions:
	//   T:System.ArgumentNullException:
	//     oldValue is null.
	//
	//   T:System.ArgumentException:
	//     oldValue is the empty string ("").
	public String Replace(String oldValue, String? newValue, StringComparison comparisonType) => Value.Replace(oldValue, newValue, comparisonType);
	//
	// Summary:
	//     Replaces all newline sequences in the current string with System.Environment.NewLine.
	//
	// Returns:
	//     A string whose contents match the current string, but with all newline sequences
	//     replaced with System.Environment.NewLine.
	public String ReplaceLineEndings() => Value.ReplaceLineEndings();
	//
	// Summary:
	//     Replaces all newline sequences in the current string with replacementText.
	//
	// Parameters:
	//   replacementText:
	//     The text to use as replacement.
	//
	// Returns:
	//     A string whose contents match the current string, but with all newline sequences
	//     replaced with replacementText.
	public String ReplaceLineEndings(String replacementText) => Value.ReplaceLineEndings(replacementText);
	//
	// Summary:
	//     Splits a string into a maximum number of substrings based on specified delimiting
	//     strings and, optionally, options.
	//
	// Parameters:
	//   separator:
	//     The strings that delimit the substrings in this string, an empty array that contains
	//     no delimiters, or null.
	//
	//   count:
	//     The maximum number of substrings to return.
	//
	//   options:
	//     A bitwise combination of the enumeration values that specifies whether to trim
	//     substrings and include empty substrings.
	//
	// Returns:
	//     An array whose elements contain the substrings in this string that are delimited
	//     by one or more strings in separator. For more information, see the Remarks section.
	//
	// Exceptions:
	//   T:System.ArgumentOutOfRangeException:
	//     count is negative.
	//
	//   T:System.ArgumentException:
	//     options is not one of the System.StringSplitOptions values.
	public String[] Split(String[]? separator, int count, StringSplitOptions options) => Value.Split(separator, count, options);
	//
	// Summary:
	//     Splits a string into a maximum number of substrings based on a specified delimiting
	//     string and, optionally, options.
	//
	// Parameters:
	//   separator:
	//     A string that delimits the substrings in this instance.
	//
	//   count:
	//     The maximum number of elements expected in the array.
	//
	//   options:
	//     A bitwise combination of the enumeration values that specifies whether to trim
	//     substrings and include empty substrings.
	//
	// Returns:
	//     An array that contains at most count substrings from this instance that are delimited
	//     by separator.
	public String[] Split(String? separator, int count, StringSplitOptions options = StringSplitOptions.None) => Value.Split(separator, count, options);
	//
	// Summary:
	//     Splits a string into substrings based on a specified delimiting string and, optionally,
	//     options.
	//
	// Parameters:
	//   separator:
	//     An array of strings that delimit the substrings in this string, an empty array
	//     that contains no delimiters, or null.
	//
	//   options:
	//     A bitwise combination of the enumeration values that specifies whether to trim
	//     substrings and include empty substrings.
	//
	// Returns:
	//     An array whose elements contain the substrings in this string that are delimited
	//     by one or more strings in separator. For more information, see the Remarks section.
	//
	// Exceptions:
	//   T:System.ArgumentException:
	//     options is not one of the System.StringSplitOptions values.
	public String[] Split(String[]? separator, StringSplitOptions options) => Value.Split(separator, options);
	//
	// Summary:
	//     Splits a string into substrings that are based on the provided string separator.
	//
	// Parameters:
	//   separator:
	//     A string that delimits the substrings in this string.
	//
	//   options:
	//     A bitwise combination of the enumeration values that specifies whether to trim
	//     substrings and include empty substrings.
	//
	// Returns:
	//     An array whose elements contain the substrings from this instance that are delimited
	//     by separator.
	public String[] Split(String? separator, StringSplitOptions options = StringSplitOptions.None) => Value.Split(separator, options);
	//
	// Summary:
	//     Splits a string into a maximum number of substrings based on specified delimiting
	//     characters and, optionally, options.
	//
	// Parameters:
	//   separator:
	//     An array of characters that delimit the substrings in this string, an empty array
	//     that contains no delimiters, or null.
	//
	//   count:
	//     The maximum number of substrings to return.
	//
	//   options:
	//     A bitwise combination of the enumeration values that specifies whether to trim
	//     substrings and include empty substrings.
	//
	// Returns:
	//     An array that contains the substrings in this string that are delimited by one
	//     or more characters in separator. For more information, see the Remarks section.
	//
	// Exceptions:
	//   T:System.ArgumentOutOfRangeException:
	//     count is negative.
	//
	//   T:System.ArgumentException:
	//     options is not one of the System.StringSplitOptions values.
	public String[] Split(char[]? separator, int count, StringSplitOptions options) => Value.Split(separator, count, options);
	//
	// Summary:
	//     Splits a string into substrings based on specified delimiting characters and
	//     options.
	//
	// Parameters:
	//   separator:
	//     An array of characters that delimit the substrings in this string, an empty array
	//     that contains no delimiters, or null.
	//
	//   options:
	//     A bitwise combination of the enumeration values that specifies whether to trim
	//     substrings and include empty substrings.
	//
	// Returns:
	//     An array whose elements contain the substrings in this string that are delimited
	//     by one or more characters in separator. For more information, see the Remarks
	//     section.
	//
	// Exceptions:
	//   T:System.ArgumentException:
	//     options is not one of the System.StringSplitOptions values.
	public String[] Split(char[]? separator, StringSplitOptions options) => Value.Split(separator, options);
	//
	// Summary:
	//     Splits a string into substrings based on a specified delimiting character and,
	//     optionally, options.
	//
	// Parameters:
	//   separator:
	//     A character that delimits the substrings in this string.
	//
	//   options:
	//     A bitwise combination of the enumeration values that specifies whether to trim
	//     substrings and include empty substrings.
	//
	// Returns:
	//     An array whose elements contain the substrings from this instance that are delimited
	//     by separator.
	public String[] Split(char separator, StringSplitOptions options = StringSplitOptions.None) => Value.Split(separator, options);
	//
	// Summary:
	//     Splits a string into a maximum number of substrings based on specified delimiting
	//     characters.
	//
	// Parameters:
	//   separator:
	//     An array of characters that delimit the substrings in this string, an empty array
	//     that contains no delimiters, or null.
	//
	//   count:
	//     The maximum number of substrings to return.
	//
	// Returns:
	//     An array whose elements contain the substrings in this instance that are delimited
	//     by one or more characters in separator. For more information, see the Remarks
	//     section.
	//
	// Exceptions:
	//   T:System.ArgumentOutOfRangeException:
	//     count is negative.
	public String[] Split(char[]? separator, int count) => Value.Split(separator, count);
	//
	// Summary:
	//     Splits a string into substrings based on specified delimiting characters.
	//
	// Parameters:
	//   separator:
	//     An array of delimiting characters, an empty array that contains no delimiters,
	//     or null.
	//
	// Returns:
	//     An array whose elements contain the substrings from this instance that are delimited
	//     by one or more characters in separator. For more information, see the Remarks
	//     section.
	public String[] Split(params char[]? separator) => Value.Split(separator);
	//
	// Summary:
	//     Splits a string into a maximum number of substrings based on a specified delimiting
	//     character and, optionally, options. Splits a string into a maximum number of
	//     substrings based on the provided character separator, optionally omitting empty
	//     substrings from the result.
	//
	// Parameters:
	//   separator:
	//     A character that delimits the substrings in this instance.
	//
	//   count:
	//     The maximum number of elements expected in the array.
	//
	//   options:
	//     A bitwise combination of the enumeration values that specifies whether to trim
	//     substrings and include empty substrings.
	//
	// Returns:
	//     An array that contains at most count substrings from this instance that are delimited
	//     by separator.
	public String[] Split(char separator, int count, StringSplitOptions options = StringSplitOptions.None) => Value.Split(separator, count, options);
	//
	// Summary:
	//     Determines whether this string instance starts with the specified character.
	//
	// Parameters:
	//   value:
	//     The character to compare.
	//
	// Returns:
	//     true if value matches the beginning of this string; otherwise, false.
	public bool StartsWith(char value) => Value.StartsWith(value);
	//
	// Summary:
	//     Determines whether the beginning of this string instance matches the specified
	//     string.
	//
	// Parameters:
	//   value:
	//     The string to compare.
	//
	// Returns:
	//     true if value matches the beginning of this string; otherwise, false.
	//
	// Exceptions:
	//   T:System.ArgumentNullException:
	//     value is null.
	public bool StartsWith(String value) => Value.StartsWith(value);
	//
	// Summary:
	//     Determines whether the beginning of this string instance matches the specified
	//     string when compared using the specified culture.
	//
	// Parameters:
	//   value:
	//     The string to compare.
	//
	//   ignoreCase:
	//     true to ignore case during the comparison; otherwise, false.
	//
	//   culture:
	//     Cultural information that determines how this string and value are compared.
	//     If culture is null, the current culture is used.
	//
	// Returns:
	//     true if the value parameter matches the beginning of this string; otherwise,
	//     false.
	//
	// Exceptions:
	//   T:System.ArgumentNullException:
	//     value is null.
	public bool StartsWith(String value, bool ignoreCase, CultureInfo? culture) => Value.StartsWith(value);
	//
	// Summary:
	//     Determines whether the beginning of this string instance matches the specified
	//     string when compared using the specified comparison option.
	//
	// Parameters:
	//   value:
	//     The string to compare.
	//
	//   comparisonType:
	//     One of the enumeration values that determines how this string and value are compared.
	//
	// Returns:
	//     true if this instance begins with value; otherwise, false.
	//
	// Exceptions:
	//   T:System.ArgumentNullException:
	//     value is null.
	//
	//   T:System.ArgumentException:
	//     comparisonType is not a System.StringComparison value.
	public bool StartsWith(String value, StringComparison comparisonType) => Value.StartsWith(value, comparisonType);
	//
	// Summary:
	//     Retrieves a substring from this instance. The substring starts at a specified
	//     character position and continues to the end of the string.
	//
	// Parameters:
	//   startIndex:
	//     The zero-based starting character position of a substring in this instance.
	//
	// Returns:
	//     A string that is equivalent to the substring that begins at startIndex in this
	//     instance, or System.String.Empty if startIndex is equal to the length of this
	//     instance.
	//
	// Exceptions:
	//   T:System.ArgumentOutOfRangeException:
	//     startIndex is less than zero or greater than the length of this instance.
	public String Substring(int startIndex) => Value.Substring(startIndex);
	//
	// Summary:
	//     Retrieves a substring from this instance. The substring starts at a specified
	//     character position and has a specified length.
	//
	// Parameters:
	//   startIndex:
	//     The zero-based starting character position of a substring in this instance.
	//
	//   length:
	//     The number of characters in the substring.
	//
	// Returns:
	//     A string that is equivalent to the substring of length length that begins at
	//     startIndex in this instance, or System.String.Empty if startIndex is equal to
	//     the length of this instance and length is zero.
	//
	// Exceptions:
	//   T:System.ArgumentOutOfRangeException:
	//     startIndex plus length indicates a position not within this instance. -or- startIndex
	//     or length is less than zero.
	public String Substring(int startIndex, int length) => Value.Substring(startIndex, length);
	//
	// Summary:
	//     Copies the characters in this instance to a Unicode character array.
	//
	// Returns:
	//     A Unicode character array whose elements are the individual characters of this
	//     instance. If this instance is an empty string, the returned array is empty and
	//     has a zero length.
	public char[] ToCharArray() => Value.ToCharArray();
	//
	// Summary:
	//     Copies the characters in a specified substring in this instance to a Unicode
	//     character array.
	//
	// Parameters:
	//   startIndex:
	//     The starting position of a substring in this instance.
	//
	//   length:
	//     The length of the substring in this instance.
	//
	// Returns:
	//     A Unicode character array whose elements are the length number of characters
	//     in this instance starting from character position startIndex.
	//
	// Exceptions:
	//   T:System.ArgumentOutOfRangeException:
	//     startIndex or length is less than zero. -or- startIndex plus length is greater
	//     than the length of this instance.
	public char[] ToCharArray(int startIndex, int length) => Value.ToCharArray(startIndex, length);
	//
	// Summary:
	//     Returns a copy of this string converted to lowercase.
	//
	// Returns:
	//     A string in lowercase.
	public String ToLower() => Value.ToLower();
	//
	// Summary:
	//     Returns a copy of this string converted to lowercase, using the casing rules
	//     of the specified culture.
	//
	// Parameters:
	//   culture:
	//     An object that supplies culture-specific casing rules. If culture is null, the
	//     current culture is used.
	//
	// Returns:
	//     The lowercase equivalent of the current string.
	public String ToLower(CultureInfo? culture) => Value.ToLower(culture);
	//
	// Summary:
	//     Returns a copy of this System.String object converted to lowercase using the
	//     casing rules of the invariant culture.
	//
	// Returns:
	//     The lowercase equivalent of the current string.
	public String ToLowerInvariant() => Value.ToLowerInvariant();
	//
	// Summary:
	//     Returns this instance of System.String; no actual conversion is performed.
	//
	// Parameters:
	//   provider:
	//     (Reserved) An object that supplies culture-specific formatting information.
	//
	// Returns:
	//     The current string.
	public String ToString(IFormatProvider? provider) => Value.ToString(provider);

	//
	// Summary:
	//     Returns a copy of this string converted to uppercase.
	//
	// Returns:
	//     The uppercase equivalent of the current string.
	public String ToUpper() => Value.ToUpper();
	//
	// Summary:
	//     Returns a copy of this string converted to uppercase, using the casing rules
	//     of the specified culture.
	//
	// Parameters:
	//   culture:
	//     An object that supplies culture-specific casing rules. If culture is null, the
	//     current culture is used.
	//
	// Returns:
	//     The uppercase equivalent of the current string.
	public String ToUpper(CultureInfo? culture) => Value.ToUpper(culture);
	//
	// Summary:
	//     Returns a copy of this System.String object converted to uppercase using the
	//     casing rules of the invariant culture.
	//
	// Returns:
	//     The uppercase equivalent of the current string.
	public String ToUpperInvariant() => Value.ToUpperInvariant();
	//
	// Summary:
	//     Removes all leading and trailing white-space characters from the current string.
	//
	// Returns:
	//     The string that remains after all white-space characters are removed from the
	//     start and end of the current string. If no characters can be trimmed from the
	//     current instance, the method returns the current instance unchanged.
	public String Trim() => Value.Trim();
	//
	// Summary:
	//     Removes all leading and trailing instances of a character from the current string.
	//
	// Parameters:
	//   trimChar:
	//     A Unicode character to remove.
	//
	// Returns:
	//     The string that remains after all instances of the trimChar character are removed
	//     from the start and end of the current string. If no characters can be trimmed
	//     from the current instance, the method returns the current instance unchanged.
	public String Trim(char trimChar) => Value.Trim(trimChar);
	//
	// Summary:
	//     Removes all leading and trailing occurrences of a set of characters specified
	//     in an array from the current string.
	//
	// Parameters:
	//   trimChars:
	//     An array of Unicode characters to remove, or null.
	//
	// Returns:
	//     The string that remains after all occurrences of the characters in the trimChars
	//     parameter are removed from the start and end of the current string. If trimChars
	//     is null or an empty array, white-space characters are removed instead. If no
	//     characters can be trimmed from the current instance, the method returns the current
	//     instance unchanged.
	public String Trim(params char[]? trimChars) => Value.Trim(trimChars);
	//
	// Summary:
	//     Removes all the trailing white-space characters from the current string.
	//
	// Returns:
	//     The string that remains after all white-space characters are removed from the
	//     end of the current string. If no characters can be trimmed from the current instance,
	//     the method returns the current instance unchanged.
	public String TrimEnd() => Value.TrimEnd();
	//
	// Summary:
	//     Removes all the trailing occurrences of a character from the current string.
	//
	// Parameters:
	//   trimChar:
	//     A Unicode character to remove.
	//
	// Returns:
	//     The string that remains after all occurrences of the trimChar character are removed
	//     from the end of the current string. If no characters can be trimmed from the
	//     current instance, the method returns the current instance unchanged.
	public String TrimEnd(char trimChar) => Value.TrimEnd(trimChar);
	//
	// Summary:
	//     Removes all the trailing occurrences of a set of characters specified in an array
	//     from the current string.
	//
	// Parameters:
	//   trimChars:
	//     An array of Unicode characters to remove, or null.
	//
	// Returns:
	//     The string that remains after all occurrences of the characters in the trimChars
	//     parameter are removed from the end of the current string. If trimChars is null
	//     or an empty array, Unicode white-space characters are removed instead. If no
	//     characters can be trimmed from the current instance, the method returns the current
	//     instance unchanged.
	public String TrimEnd(params char[]? trimChars) => Value.TrimEnd(trimChars);
	//
	// Summary:
	//     Removes all the leading white-space characters from the current string.
	//
	// Returns:
	//     The string that remains after all white-space characters are removed from the
	//     start of the current string. If no characters can be trimmed from the current
	//     instance, the method returns the current instance unchanged.
	public String TrimStart() => Value.TrimStart();
	//
	// Summary:
	//     Removes all the leading occurrences of a specified character from the current
	//     string.
	//
	// Parameters:
	//   trimChar:
	//     The Unicode character to remove.
	//
	// Returns:
	//     The string that remains after all occurrences of the trimChar character are removed
	//     from the start of the current string. If no characters can be trimmed from the
	//     current instance, the method returns the current instance unchanged.
	public String TrimStart(char trimChar) => Value.TrimStart(trimChar);
	//
	// Summary:
	//     Removes all the leading occurrences of a set of characters specified in an array
	//     from the current string.
	//
	// Parameters:
	//   trimChars:
	//     An array of Unicode characters to remove, or null.
	//
	// Returns:
	//     The string that remains after all occurrences of characters in the trimChars
	//     parameter are removed from the start of the current string. If trimChars is null
	//     or an empty array, white-space characters are removed instead. If no characters
	//     can be trimmed from the current instance, the method returns the current instance
	//     unchanged.
	public String TrimStart(params char[]? trimChars) => Value.TrimStart(trimChars);
	//
	// Summary:
	//     Copies the contents of this string into the destination span.
	//
	// Parameters:
	//   destination:
	//     The span into which to copy this string's contents.
	//
	// Returns:
	//     true if the data was copied; false if the destination was too short to fit the
	//     contents of the string.
	public bool TryCopyTo(Span<char> destination) => Value.TryCopyTo(destination);

	//
	// Summary:
	//     Defines an implicit conversion of a given string to a read-only span of characters.
	//
	// Parameters:
	//   value:
	//     A string to implicitly convert.
	//
	// Returns:
	//     A new read-only span of characters representing the string.
	public static implicit operator ReadOnlySpan<char>(StringPrimitive<TCustom> value) => value.Value;
}