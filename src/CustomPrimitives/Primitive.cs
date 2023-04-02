namespace CustomPrimitives;

public interface IPrimitive<T>
{
	T Value { get; }
}

public abstract class Primitive<TCustom, TPrimitive> : IEquatable<TPrimitive>, IComparable, IComparable<TPrimitive>, IPrimitive<TPrimitive>
	where TCustom : Primitive<TCustom, TPrimitive>
	where TPrimitive : IComparable, IComparable<TPrimitive>, IEquatable<TPrimitive>
{
	public TPrimitive Value { get; internal set; }

	protected Primitive(TPrimitive value)
	{
		Value = value;
	}

	public override string? ToString() => Value.ToString();
	public override int GetHashCode() => Value.GetHashCode();
	public int CompareTo(TPrimitive? other) => Value.CompareTo(other);
	public int CompareTo(object? other)
	{
		if (other is TCustom primitiveObj) return Value.CompareTo(primitiveObj.Value);
		if (other is IComparable<TPrimitive> comparable) return -comparable.CompareTo(Value);
		if (other is TPrimitive primitive) return Value.CompareTo(primitive);
		return Value.CompareTo(other);
	}
	public bool Equals(TCustom? other) => other != null ? Value.Equals(other.Value) : Value == null;
	public bool Equals(TPrimitive? other) => Value.Equals(other);
	public override bool Equals(object? other)
	{
		if (other is TCustom primitiveObj) return Value.Equals(primitiveObj.Value);
		if (other is IEquatable<TPrimitive> equatable) return equatable.Equals(Value);
		if (other is TPrimitive primitive) return Value.Equals(primitive);
		return Value.Equals(other);
	}

	public static implicit operator TPrimitive(Primitive<TCustom, TPrimitive> value) => value.Value;
	public static bool operator ==(Primitive<TCustom, TPrimitive> a, TPrimitive b) => a.Value.Equals(b);
	public static bool operator !=(Primitive<TCustom, TPrimitive> a, TPrimitive b) => !a.Value.Equals(b);
}
