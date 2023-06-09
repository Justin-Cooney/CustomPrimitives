﻿namespace CustomPrimitives;

public abstract class ConvertiblePrimitive<TCustom, TPrimitive> : Primitive<TCustom, TPrimitive>, IConvertible
	where TCustom : ConvertiblePrimitive<TCustom, TPrimitive>
	where TPrimitive : IConvertible, IComparable, IComparable<TPrimitive>, IEquatable<TPrimitive>
{
	protected ConvertiblePrimitive(TPrimitive value) : base(value) { }

	public TypeCode GetTypeCode() => Value.GetTypeCode();

	public bool ToBoolean(IFormatProvider? provider) => Value.ToBoolean(provider);

	public byte ToByte(IFormatProvider? provider) => Value.ToByte(provider);

	public char ToChar(IFormatProvider? provider) => Value.ToChar(provider);

	public DateTime ToDateTime(IFormatProvider? provider) => Value.ToDateTime(provider);

	public decimal ToDecimal(IFormatProvider? provider) => Value.ToDecimal(provider);

	public double ToDouble(IFormatProvider? provider) => Value.ToDouble(provider);

	public short ToInt16(IFormatProvider? provider) => Value.ToInt16(provider);

	public int ToInt32(IFormatProvider? provider) => Value.ToInt32(provider);

	public long ToInt64(IFormatProvider? provider) => Value.ToInt64(provider);

	public sbyte ToSByte(IFormatProvider? provider) => Value.ToSByte(provider);

	public float ToSingle(IFormatProvider? provider) => Value.ToSingle(provider);

	public string ToString(IFormatProvider? provider) => Value.ToString(provider);

	public object ToType(Type conversionType, IFormatProvider? provider) => Value.ToType(conversionType, provider);

	public ushort ToUInt16(IFormatProvider? provider) => Value.ToUInt16(provider);

	public uint ToUInt32(IFormatProvider? provider) => Value.ToUInt32(provider);

	public ulong ToUInt64(IFormatProvider? provider) => Value.ToUInt64(provider);
}