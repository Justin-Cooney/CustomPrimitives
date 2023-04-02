namespace CustomPrimitives.Tests;

public class BoolPrimitiveTests
{
	private class TestPrimitiveA : BoolPrimitive<TestPrimitiveA>
	{
		private TestPrimitiveA() : base(true) { }

		public TestPrimitiveA(bool value) : base(value) { }
	}

	private class TestPrimitiveB : BoolPrimitive<TestPrimitiveB>
	{
		public TestPrimitiveB() : base(true) { }

		public TestPrimitiveB(bool value, int testProp) : base(value) { TestProp = testProp; }

		public int TestProp { get; }
	}

	private class TestPrimitiveC : BoolPrimitive<TestPrimitiveC>
	{
		public TestPrimitiveC(bool value, int otherProp) : base(value) { OtherProp = otherProp; }

		public int OtherProp { get; }
	}

	//General Primitive
	[Fact]
	public void ToString_ReturnsPrimitiveToString()
	{
		new TestPrimitiveB(true, 50).ToString().Should().Be("True");
		new TestPrimitiveB(false, 50).ToString().Should().Be("False");
	}

	[Fact]
	public void GetHashCode_ReturnsCorrectHashCodes()
	{
		new TestPrimitiveA(true).GetHashCode().Should().Be(true.GetHashCode());
		new TestPrimitiveA(false).GetHashCode().Should().Be(false.GetHashCode());
		new TestPrimitiveB(true, 34).GetHashCode().Should().Be(true.GetHashCode());
		new TestPrimitiveB(false, 34).GetHashCode().Should().Be(false.GetHashCode());
		new TestPrimitiveB(true, 34).GetHashCode().Should().Be(new TestPrimitiveC(true, 50).GetHashCode());
		new TestPrimitiveB(false, 34).GetHashCode().Should().Be(new TestPrimitiveC(false, 50).GetHashCode());
	}

	[Fact]
	public void CompareTo_CanCompareToPrimitiveAndOtherCustomPrimitives()
	{
		new TestPrimitiveB(true, 34).CompareTo(true).Should().Be(0);
		new TestPrimitiveB(true, 34).CompareTo(false).Should().Be(1);
		new TestPrimitiveB(false, 34).CompareTo(false).Should().Be(0);
		new TestPrimitiveB(false, 34).CompareTo(true).Should().Be(-1);
		new TestPrimitiveB(true, 34).CompareTo(new TestPrimitiveB(true, 50)).Should().Be(0);
		new TestPrimitiveB(true, 34).CompareTo(new TestPrimitiveB(false, 50)).Should().Be(1);
		new TestPrimitiveB(false, 34).CompareTo(new TestPrimitiveB(false, 50)).Should().Be(0);
		new TestPrimitiveB(false, 34).CompareTo(new TestPrimitiveB(true, 50)).Should().Be(-1);
		new TestPrimitiveB(true, 34).CompareTo(new TestPrimitiveC(true, 50)).Should().Be(0);
		new TestPrimitiveB(true, 34).CompareTo(new TestPrimitiveC(false, 50)).Should().Be(1);
		new TestPrimitiveB(false, 34).CompareTo(new TestPrimitiveC(false, 50)).Should().Be(0);
		new TestPrimitiveB(false, 34).CompareTo(new TestPrimitiveC(true, 50)).Should().Be(-1);
	}

	[Fact]
	public void CompareToObject_CanCompareToPrimitivesAndOtherCustomPrimitivesObjects()
	{
		new TestPrimitiveB(true, 34).CompareTo((object)true).Should().Be(0);
		new TestPrimitiveB(true, 34).CompareTo((object)false).Should().Be(1);
		new TestPrimitiveB(false, 34).CompareTo((object)false).Should().Be(0);
		new TestPrimitiveB(false, 34).CompareTo((object)true).Should().Be(-1);
		new TestPrimitiveB(true, 34).CompareTo((object)new TestPrimitiveB(true, 50)).Should().Be(0);
		new TestPrimitiveB(true, 34).CompareTo((object)new TestPrimitiveB(false, 50)).Should().Be(1);
		new TestPrimitiveB(false, 34).CompareTo((object)new TestPrimitiveB(false, 50)).Should().Be(0);
		new TestPrimitiveB(false, 34).CompareTo((object)new TestPrimitiveB(true, 50)).Should().Be(-1);
		new TestPrimitiveB(true, 34).CompareTo((object)new TestPrimitiveC(true, 50)).Should().Be(0);
		new TestPrimitiveB(true, 34).CompareTo((object)new TestPrimitiveC(false, 50)).Should().Be(1);
		new TestPrimitiveB(false, 34).CompareTo((object)new TestPrimitiveC(false, 50)).Should().Be(0);
		new TestPrimitiveB(false, 34).CompareTo((object)new TestPrimitiveC(true, 50)).Should().Be(-1);
	}

	[Fact]
	public void EqualsCustomPrimitive_EqualityIsCorrect()
	{
		new TestPrimitiveB(true, 34).Equals(new TestPrimitiveB(true, 50)).Should().BeTrue();
		new TestPrimitiveB(true, 34).Equals(new TestPrimitiveB(false, 50)).Should().BeFalse();
		new TestPrimitiveB(false, 34).Equals(new TestPrimitiveB(true, 50)).Should().BeFalse();
		new TestPrimitiveB(false, 34).Equals(new TestPrimitiveB(false, 50)).Should().BeTrue();
	}

	[Fact]
	public void EqualsPrimitive_EqaulityIsCorrect()
	{
		new TestPrimitiveB(true, 34).Equals(true).Should().BeTrue();
		new TestPrimitiveB(true, 34).Equals(false).Should().BeFalse();
		new TestPrimitiveB(false, 34).Equals(true).Should().BeFalse();
		new TestPrimitiveB(false, 34).Equals(false).Should().BeTrue();

		new TestPrimitiveB(true, 34).Equals(new TestPrimitiveC(true, 50)).Should().BeTrue();
		new TestPrimitiveB(true, 34).Equals(new TestPrimitiveC(false, 50)).Should().BeFalse();
		new TestPrimitiveB(false, 34).Equals(new TestPrimitiveC(true, 50)).Should().BeFalse();
		new TestPrimitiveB(false, 34).Equals(new TestPrimitiveC(false, 50)).Should().BeTrue();
	}

	[Fact]
	public void EqualsObject_EqaulityIsCorrect()
	{
		new TestPrimitiveB(true, 34).Equals((object) new TestPrimitiveB(true, 50)).Should().BeTrue();
		new TestPrimitiveB(true, 34).Equals((object) new TestPrimitiveB(false, 50)).Should().BeFalse();
		new TestPrimitiveB(false, 34).Equals((object) new TestPrimitiveB(true, 50)).Should().BeFalse();
		new TestPrimitiveB(false, 34).Equals((object) new TestPrimitiveB(false, 50)).Should().BeTrue();

		new TestPrimitiveB(true, 34).Equals((object) true).Should().BeTrue();
		new TestPrimitiveB(true, 34).Equals((object) false).Should().BeFalse();
		new TestPrimitiveB(false, 34).Equals((object) true).Should().BeFalse();
		new TestPrimitiveB(false, 34).Equals((object) false).Should().BeTrue();

		new TestPrimitiveB(true, 34).Equals((object) new TestPrimitiveC(true, 50)).Should().BeTrue();
		new TestPrimitiveB(true, 34).Equals((object) new TestPrimitiveC(false, 50)).Should().BeFalse();
		new TestPrimitiveB(false, 34).Equals((object) new TestPrimitiveC(true, 50)).Should().BeFalse();
		new TestPrimitiveB(false, 34).Equals((object) new TestPrimitiveC(false, 50)).Should().BeTrue();
	}

	[Fact]
	public void ImplicitCasting_CanCastToPrimitive()
	{
		bool test = new TestPrimitiveA(true);
		test.Should().BeTrue();

		bool test2 = new TestPrimitiveA(false);
		test2.Should().BeFalse();
	}

	[Fact]
	public void EqualsOperator()
	{
		(new TestPrimitiveB(true, 34) == true).Should().BeTrue();
		(new TestPrimitiveB(true, 34) == false).Should().BeFalse();
		(new TestPrimitiveB(false, 34) == true).Should().BeFalse();
		(new TestPrimitiveB(false, 34) == false).Should().BeTrue();

		(new TestPrimitiveB(true, 34) == new TestPrimitiveC(true, 34)).Should().BeTrue();
		(new TestPrimitiveB(true, 34) == new TestPrimitiveC(false, 34)).Should().BeFalse();
		(new TestPrimitiveB(false, 34) == new TestPrimitiveC(true, 34)).Should().BeFalse();
		(new TestPrimitiveB(false, 34) == new TestPrimitiveC(false, 34)).Should().BeTrue();
	}

	[Fact]
	public void NotEqualsOperator()
	{
		(new TestPrimitiveB(true, 34) != true).Should().BeFalse();
		(new TestPrimitiveB(true, 34) != false).Should().BeTrue();
		(new TestPrimitiveB(false, 34) != true).Should().BeTrue();
		(new TestPrimitiveB(false, 34) != false).Should().BeFalse();

		(new TestPrimitiveB(true, 34) != new TestPrimitiveC(true, 34)).Should().BeFalse();
		(new TestPrimitiveB(true, 34) != new TestPrimitiveC(false, 34)).Should().BeTrue();
		(new TestPrimitiveB(false, 34) != new TestPrimitiveC(true, 34)).Should().BeTrue();
		(new TestPrimitiveB(false, 34) != new TestPrimitiveC(false, 34)).Should().BeFalse();

		(new TestPrimitiveB(true, 34) != new TestPrimitiveB(true, 34)).Should().BeFalse();
		(new TestPrimitiveB(true, 34) != new TestPrimitiveB(false, 34)).Should().BeTrue();
		(new TestPrimitiveB(false, 34) != new TestPrimitiveB(true, 34)).Should().BeTrue();
		(new TestPrimitiveB(false, 34) != new TestPrimitiveB(false, 34)).Should().BeFalse();
	}

	// Convertible Specific
	[Fact]
	public void GetTypeCode_ReturnsPrimitiveType()
	{
		new TestPrimitiveA(true).GetTypeCode().Should().Be(TypeCode.Boolean);
		new TestPrimitiveA(false).GetTypeCode().Should().Be(TypeCode.Boolean);
	}

	[Fact]
	public void Convertible_AllConversionsWork()
	{
		Convert.ToBoolean(new TestPrimitiveB(true, 30) as object).Should().Be(true);
		Convert.ToBoolean(new TestPrimitiveB(false, 30) as object).Should().Be(false);
		Convert.ToByte(new TestPrimitiveB(true, 30) as object).Should().Be(1);
		Convert.ToByte(new TestPrimitiveB(false, 30) as object).Should().Be(0);
		new Action(() => Convert.ToChar(new TestPrimitiveB(true, 30) as object)).Should().Throw<Exception>();
		new Action(() => Convert.ToDateTime(new TestPrimitiveB(true, 30) as object)).Should().Throw<Exception>();
		Convert.ToDecimal(new TestPrimitiveB(true, 30) as object).Should().Be(1);
		Convert.ToDecimal(new TestPrimitiveB(false, 30) as object).Should().Be(0);
		Convert.ToDouble(new TestPrimitiveB(true, 30) as object).Should().Be(1);
		Convert.ToDouble(new TestPrimitiveB(false, 30) as object).Should().Be(0);
		Convert.ToInt16(new TestPrimitiveB(true, 30) as object).Should().Be(1);
		Convert.ToInt16(new TestPrimitiveB(false, 30) as object).Should().Be(0);
		Convert.ToInt32(new TestPrimitiveB(true, 30) as object).Should().Be(1);
		Convert.ToInt32(new TestPrimitiveB(false, 30) as object).Should().Be(0);
		Convert.ToInt64(new TestPrimitiveB(true, 30) as object).Should().Be(1);
		Convert.ToInt64(new TestPrimitiveB(false, 30) as object).Should().Be(0);
		Convert.ToSByte(new TestPrimitiveB(true, 30) as object).Should().Be(1);
		Convert.ToSByte(new TestPrimitiveB(false, 30) as object).Should().Be(0);
		Convert.ToSingle(new TestPrimitiveB(true, 30) as object).Should().Be(1);
		Convert.ToSingle(new TestPrimitiveB(false, 30) as object).Should().Be(0);
		Convert.ToString(new TestPrimitiveB(true, 30) as object).Should().Be("True");
		Convert.ToString(new TestPrimitiveB(false, 30) as object).Should().Be("False");
		Convert.ToUInt16(new TestPrimitiveB(true, 30) as object).Should().Be(1);
		Convert.ToUInt16(new TestPrimitiveB(false, 30) as object).Should().Be(0);
		Convert.ToUInt32(new TestPrimitiveB(true, 30) as object).Should().Be(1);
		Convert.ToUInt32(new TestPrimitiveB(false, 30) as object).Should().Be(0);
		Convert.ToUInt64(new TestPrimitiveB(true, 30) as object).Should().Be(1);
		Convert.ToUInt64(new TestPrimitiveB(false, 30) as object).Should().Be(0);
		Convert.ChangeType(new TestPrimitiveB(true, 30) as object, typeof(int)).Should().Be(1);
		Convert.ChangeType(new TestPrimitiveB(false, 30) as object, typeof(int)).Should().Be(0);
	}

	// Boolean Specific
	[Fact]
	public void TryFormat_IsCorrect()
	{
		var str = "TestString";
		Span<char> span = stackalloc char[str.Length]; // or `new char[str.Length]`
		str.AsSpan().CopyTo(span);
		var result = new TestPrimitiveB(true, 50).TryFormat(span, out var chars);
		result.Should().BeTrue();
		chars.Should().Be(4);
		span.ToString().Should().Be("TrueString");
	}
}