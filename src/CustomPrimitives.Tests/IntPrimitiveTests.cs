namespace CustomPrimitives.Tests;

public class IntPrimitiveTests
{
	private class TestPrimitiveA : IntPrimitive<TestPrimitiveA>
	{
		private TestPrimitiveA() : base(0) { }

		public TestPrimitiveA(int value) : base(value) { }
	}

	private class TestPrimitiveB : IntPrimitive<TestPrimitiveB>
	{
		public TestPrimitiveB() : base(0) { }

		public TestPrimitiveB(int value, int testProp) : base(value) { TestProp = testProp; }

		public int TestProp { get; }
	}

	private class TestPrimitiveC : IntPrimitive<TestPrimitiveC>
	{
		public TestPrimitiveC(int value, int otherProp) : base(value) { OtherProp = otherProp; }

		public int OtherProp { get; }
	}

	//General Primitive
	[Fact]
	public void ToString_ReturnsPrimitiveToString()
	{
		new TestPrimitiveB(9, 50).ToString().Should().Be(9.ToString());
	}

	[Fact]
	public void GetHashCode_ReturnsCorrectHashCodes()
	{
		new TestPrimitiveA(9).GetHashCode().Should().Be(9.GetHashCode());
		new TestPrimitiveB(9, 34).GetHashCode().Should().Be(9.GetHashCode());
		new TestPrimitiveB(9, 34).GetHashCode().Should().Be(new TestPrimitiveC(9, 50).GetHashCode());
	}

	[Fact]
	public void CompareTo_CanCompareToPrimitiveAndOtherCustomPrimitives()
	{
		new TestPrimitiveB(9, 34).CompareTo(9).Should().Be(0);
		new TestPrimitiveB(9, 34).CompareTo(8).Should().Be(1);
		new TestPrimitiveB(9, 34).CompareTo(10).Should().Be(-1);
		new TestPrimitiveB(9, 34).CompareTo(new TestPrimitiveB(9, 50)).Should().Be(0);
		new TestPrimitiveB(9, 34).CompareTo(new TestPrimitiveB(8, 50)).Should().Be(1);
		new TestPrimitiveB(9, 34).CompareTo(new TestPrimitiveB(10, 50)).Should().Be(-1);
		new TestPrimitiveB(9, 34).CompareTo(new TestPrimitiveC(9, 50)).Should().Be(0);
		new TestPrimitiveB(9, 34).CompareTo(new TestPrimitiveC(8, 50)).Should().Be(1);
		new TestPrimitiveB(9, 34).CompareTo(new TestPrimitiveC(10, 50)).Should().Be(-1);
	}

	[Fact]
	public void CompareToObject_CanCompareToPrimitivesAndOtherCustomPrimitivesObjects()
	{
		new TestPrimitiveB(9, 34).CompareTo((object)9).Should().Be(0);
		new TestPrimitiveB(9, 34).CompareTo((object)8).Should().Be(1);
		new TestPrimitiveB(9, 34).CompareTo((object)10).Should().Be(-1);
		new TestPrimitiveB(9, 34).CompareTo((object)new TestPrimitiveB(9, 50)).Should().Be(0);
		new TestPrimitiveB(9, 34).CompareTo((object)new TestPrimitiveB(8, 50)).Should().Be(1);
		new TestPrimitiveB(9, 34).CompareTo((object)new TestPrimitiveB(10, 50)).Should().Be(-1);
		new TestPrimitiveB(9, 34).CompareTo((object)new TestPrimitiveC(9, 50)).Should().Be(0);
		new TestPrimitiveB(9, 34).CompareTo((object)new TestPrimitiveC(8, 50)).Should().Be(1);
		new TestPrimitiveB(9, 34).CompareTo((object)new TestPrimitiveC(10, 50)).Should().Be(-1);
	}

	[Fact]
	public void EqualsCustomPrimitive_EqualityIsCorrect()
	{
		new TestPrimitiveB(9, 34).Equals(new TestPrimitiveB(9, 50)).Should().BeTrue();
		new TestPrimitiveB(9, 34).Equals(new TestPrimitiveB(8, 50)).Should().BeFalse();
	}

	[Fact]
	public void EqualsPrimitive_EqaulityIsCorrect()
	{
		new TestPrimitiveB(9, 34).Equals(9).Should().BeTrue();
		new TestPrimitiveB(9, 34).Equals(8).Should().BeFalse();

		new TestPrimitiveB(9, 34).Equals(new TestPrimitiveC(9, 50)).Should().BeTrue();
		new TestPrimitiveB(9, 34).Equals(new TestPrimitiveC(8, 50)).Should().BeFalse();
	}

	[Fact]
	public void EqualsObject_EqaulityIsCorrect()
	{
		new TestPrimitiveB(9, 34).Equals((object) new TestPrimitiveB(9, 50)).Should().BeTrue();
		new TestPrimitiveB(9, 34).Equals((object) new TestPrimitiveB(8, 50)).Should().BeFalse();

		new TestPrimitiveB(9, 34).Equals((object)9).Should().BeTrue();
		new TestPrimitiveB(9, 34).Equals((object)8).Should().BeFalse();

		new TestPrimitiveB(9, 34).Equals((object) new TestPrimitiveC(9, 50)).Should().BeTrue();
		new TestPrimitiveB(9, 34).Equals((object) new TestPrimitiveC(8, 50)).Should().BeFalse();
	}

	[Fact]
	public void ImplicitCasting_CanCastToPrimitive()
	{
		int test = new TestPrimitiveA(9);
		test.Should().Be(9);
	}

	[Fact]
	public void EqualsOperator()
	{
		(new TestPrimitiveB(9, 34) == 9).Should().BeTrue();
		(new TestPrimitiveB(9, 34) == 8).Should().BeFalse();

		(new TestPrimitiveB(9, 34) == new TestPrimitiveC(9, 34)).Should().BeTrue();
		(new TestPrimitiveB(9, 34) == new TestPrimitiveC(8, 34)).Should().BeFalse();
	}

	[Fact]
	public void NotEqualsOperator()
	{
		(new TestPrimitiveB(9, 34) != 9).Should().BeFalse();
		(new TestPrimitiveB(9, 34) != 8).Should().BeTrue();

		(new TestPrimitiveB(9, 34) != new TestPrimitiveC(9, 34)).Should().BeFalse();
		(new TestPrimitiveB(9, 34) != new TestPrimitiveC(8, 34)).Should().BeTrue();

		(new TestPrimitiveB(9, 34) != new TestPrimitiveB(9, 34)).Should().BeFalse();
		(new TestPrimitiveB(9, 34) != new TestPrimitiveB(8, 34)).Should().BeTrue();
	}

	// Guid Specific
}