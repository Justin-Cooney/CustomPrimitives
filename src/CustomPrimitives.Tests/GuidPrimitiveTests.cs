namespace CustomPrimitives.Tests;

public class GuidPrimitiveTests
{
	private class TestPrimitiveA : GuidPrimitive<TestPrimitiveA>
	{
		private TestPrimitiveA() : base(Guid.Empty) { }

		public TestPrimitiveA(Guid value) : base(value) { }
	}

	private class TestPrimitiveB : GuidPrimitive<TestPrimitiveB>
	{
		public TestPrimitiveB() : base(Guid.Empty) { }

		public TestPrimitiveB(Guid value, int testProp) : base(value) { TestProp = testProp; }

		public int TestProp { get; }
	}

	private class TestPrimitiveC : GuidPrimitive<TestPrimitiveC>
	{
		public TestPrimitiveC(Guid value, int otherProp) : base(value) { OtherProp = otherProp; }

		public int OtherProp { get; }
	}

	private Guid _guid1 = Guid.Parse("d17b4c5e-6dd3-4842-aa87-70802eae1887");
	private Guid _guid2 = Guid.Parse("d17b4c5e-6dd3-4842-aa87-70802eae1886");

	//General Primitive
	[Fact]
	public void ToString_ReturnsPrimitiveToString()
	{
		new TestPrimitiveB(_guid1, 50).ToString().Should().Be(_guid1.ToString());
	}

	[Fact]
	public void GetHashCode_ReturnsCorrectHashCodes()
	{
		new TestPrimitiveA(_guid1).GetHashCode().Should().Be(_guid1.GetHashCode());
		new TestPrimitiveB(_guid1, 34).GetHashCode().Should().Be(_guid1.GetHashCode());
		new TestPrimitiveB(_guid1, 34).GetHashCode().Should().Be(new TestPrimitiveC(_guid1, 50).GetHashCode());
	}

	[Fact]
	public void CompareTo_CanCompareToPrimitiveAndOtherCustomPrimitives()
	{
		new TestPrimitiveB(_guid1, 34).CompareTo(_guid1).Should().Be(0);
		new TestPrimitiveB(_guid1, 34).CompareTo(_guid2).Should().Be(1);
		new TestPrimitiveB(_guid2, 34).CompareTo(_guid1).Should().Be(-1);
		new TestPrimitiveB(_guid1, 34).CompareTo(new TestPrimitiveB(_guid1, 50)).Should().Be(0);
		new TestPrimitiveB(_guid1, 34).CompareTo(new TestPrimitiveB(_guid2, 50)).Should().Be(1);
		new TestPrimitiveB(_guid2, 34).CompareTo(new TestPrimitiveB(_guid1, 50)).Should().Be(-1);
		new TestPrimitiveB(_guid1, 34).CompareTo(new TestPrimitiveC(_guid1, 50)).Should().Be(0);
		new TestPrimitiveB(_guid1, 34).CompareTo(new TestPrimitiveC(_guid2, 50)).Should().Be(1);
		new TestPrimitiveB(_guid2, 34).CompareTo(new TestPrimitiveC(_guid1, 50)).Should().Be(-1);
	}

	[Fact]
	public void CompareToObject_CanCompareToPrimitivesAndOtherCustomPrimitivesObjects()
	{
		new TestPrimitiveB(_guid1, 34).CompareTo((object)_guid1).Should().Be(0);
		new TestPrimitiveB(_guid1, 34).CompareTo((object)_guid2).Should().Be(1);
		new TestPrimitiveB(_guid2, 34).CompareTo((object)_guid1).Should().Be(-1);
		new TestPrimitiveB(_guid1, 34).CompareTo((object)new TestPrimitiveB(_guid1, 50)).Should().Be(0);
		new TestPrimitiveB(_guid1, 34).CompareTo((object)new TestPrimitiveB(_guid2, 50)).Should().Be(1);
		new TestPrimitiveB(_guid2, 34).CompareTo((object)new TestPrimitiveB(_guid1, 50)).Should().Be(-1);
		new TestPrimitiveB(_guid1, 34).CompareTo((object)new TestPrimitiveC(_guid1, 50)).Should().Be(0);
		new TestPrimitiveB(_guid1, 34).CompareTo((object)new TestPrimitiveC(_guid2, 50)).Should().Be(1);
		new TestPrimitiveB(_guid2, 34).CompareTo((object)new TestPrimitiveC(_guid1, 50)).Should().Be(-1);
	}

	[Fact]
	public void EqualsCustomPrimitive_EqualityIsCorrect()
	{
		new TestPrimitiveB(_guid1, 34).Equals(new TestPrimitiveB(_guid1, 50)).Should().BeTrue();
		new TestPrimitiveB(_guid1, 34).Equals(new TestPrimitiveB(_guid2, 50)).Should().BeFalse();
	}

	[Fact]
	public void EqualsPrimitive_EqaulityIsCorrect()
	{
		new TestPrimitiveB(_guid1, 34).Equals(_guid1).Should().BeTrue();
		new TestPrimitiveB(_guid1, 34).Equals(_guid2).Should().BeFalse();

		new TestPrimitiveB(_guid1, 34).Equals(new TestPrimitiveC(_guid1, 50)).Should().BeTrue();
		new TestPrimitiveB(_guid1, 34).Equals(new TestPrimitiveC(_guid2, 50)).Should().BeFalse();
	}

	[Fact]
	public void EqualsObject_EqaulityIsCorrect()
	{
		new TestPrimitiveB(_guid1, 34).Equals((object) new TestPrimitiveB(_guid1, 50)).Should().BeTrue();
		new TestPrimitiveB(_guid1, 34).Equals((object) new TestPrimitiveB(_guid2, 50)).Should().BeFalse();

		new TestPrimitiveB(_guid1, 34).Equals((object)_guid1).Should().BeTrue();
		new TestPrimitiveB(_guid1, 34).Equals((object)_guid2).Should().BeFalse();

		new TestPrimitiveB(_guid1, 34).Equals((object) new TestPrimitiveC(_guid1, 50)).Should().BeTrue();
		new TestPrimitiveB(_guid1, 34).Equals((object) new TestPrimitiveC(_guid2, 50)).Should().BeFalse();
	}

	[Fact]
	public void ImplicitCasting_CanCastToPrimitive()
	{
		Guid test = new TestPrimitiveA(_guid1);
		test.Should().Be(_guid1);
	}

	[Fact]
	public void EqualsOperator()
	{
		(new TestPrimitiveB(_guid1, 34) == _guid1).Should().BeTrue();
		(new TestPrimitiveB(_guid1, 34) == _guid2).Should().BeFalse();

		(new TestPrimitiveB(_guid1, 34) == new TestPrimitiveC(_guid1, 34)).Should().BeTrue();
		(new TestPrimitiveB(_guid1, 34) == new TestPrimitiveC(_guid2, 34)).Should().BeFalse();
	}

	[Fact]
	public void NotEqualsOperator()
	{
		(new TestPrimitiveB(_guid1, 34) != _guid1).Should().BeFalse();
		(new TestPrimitiveB(_guid1, 34) != _guid2).Should().BeTrue();

		(new TestPrimitiveB(_guid1, 34) != new TestPrimitiveC(_guid1, 34)).Should().BeFalse();
		(new TestPrimitiveB(_guid1, 34) != new TestPrimitiveC(_guid2, 34)).Should().BeTrue();

		(new TestPrimitiveB(_guid1, 34) != new TestPrimitiveB(_guid1, 34)).Should().BeFalse();
		(new TestPrimitiveB(_guid1, 34) != new TestPrimitiveB(_guid2, 34)).Should().BeTrue();
	}

	// Guid Specific
}