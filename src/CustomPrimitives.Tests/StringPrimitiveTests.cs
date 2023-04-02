using System.Text.Json;

namespace CustomPrimitives.Tests;

public class StringPrimitiveTests
{
	private class TestPrimitiveA : StringPrimitive<TestPrimitiveA>
	{
		public TestPrimitiveA(string value) : base(value) { }
	}

	private class TestPrimitiveB : StringPrimitive<TestPrimitiveB>
	{
		public TestPrimitiveB(string value, int testProp) : base(value) { TestProp = testProp; }

		public int TestProp { get; }
	}

	private class TestPrimitiveC : StringPrimitive<TestPrimitiveC>
	{
		public TestPrimitiveC(string value, int otherProp) : base(value) { OtherProp = otherProp; }

		public int OtherProp { get; }
	}

	//General Primitive
	[Fact]
	public void ToString_ReturnsPrimitiveToString()
	{
		new TestPrimitiveB("Test", 50).ToString().Should().Be("Test");
	}

	[Fact]
	public void GetHashCode_ReturnsCorrectHashCodes()
	{
		new TestPrimitiveA("Test").GetHashCode().Should().Be("Test".GetHashCode());
		new TestPrimitiveB("Test", 34).GetHashCode().Should().Be("Test".GetHashCode());
		new TestPrimitiveB("Test", 34).GetHashCode().Should().Be(new TestPrimitiveC("Test", 50).GetHashCode());
	}

	[Fact]
	public void CompareTo_CanCompareToPrimitiveAndOtherCustomPrimitives()
	{
		new TestPrimitiveB("TestA", 34).CompareTo("TestB").Should().Be(-1);
		new TestPrimitiveB("TestB", 34).CompareTo("TestB").Should().Be(0);
		new TestPrimitiveB("TestC", 34).CompareTo("TestB").Should().Be(1);
		new TestPrimitiveB("TestA", 34).CompareTo(new TestPrimitiveB("TestB", 50)).Should().Be(-1);
		new TestPrimitiveB("TestB", 34).CompareTo(new TestPrimitiveB("TestB", 50)).Should().Be(0);
		new TestPrimitiveB("TestC", 34).CompareTo(new TestPrimitiveB("TestB", 50)).Should().Be(1);
		new TestPrimitiveB("TestA", 34).CompareTo(new TestPrimitiveC("TestB", 50)).Should().Be(-1);
		new TestPrimitiveB("TestB", 34).CompareTo(new TestPrimitiveC("TestB", 50)).Should().Be(0);
		new TestPrimitiveB("TestC", 34).CompareTo(new TestPrimitiveC("TestB", 50)).Should().Be(1);
	}

	[Fact]
	public void CompareToObject_CanCompareToPrimitivesAndOtherCustomPrimitivesObjects()
	{
		new TestPrimitiveB("TestA", 34).CompareTo((object) "TestB").Should().Be(-1);
		new TestPrimitiveB("TestB", 34).CompareTo((object)"TestB").Should().Be(0);
		new TestPrimitiveB("TestC", 34).CompareTo((object)"TestB").Should().Be(1);
		new TestPrimitiveB("TestA", 34).CompareTo((object)new TestPrimitiveB("TestB", 50)).Should().Be(-1);
		new TestPrimitiveB("TestB", 34).CompareTo((object)new TestPrimitiveB("TestB", 50)).Should().Be(0);
		new TestPrimitiveB("TestC", 34).CompareTo((object)new TestPrimitiveB("TestB", 50)).Should().Be(1);
		new TestPrimitiveB("TestA", 34).CompareTo((object)new TestPrimitiveC("TestB", 50)).Should().Be(-1);
		new TestPrimitiveB("TestB", 34).CompareTo((object)new TestPrimitiveC("TestB", 50)).Should().Be(0);
		new TestPrimitiveB("TestC", 34).CompareTo((object)new TestPrimitiveC("TestB", 50)).Should().Be(1);
	}

	[Fact]
	public void EqualsCustomPrimitive_EqualityIsCorrect()
	{
		new TestPrimitiveB("Test", 34).Equals(new TestPrimitiveB("Test", 50)).Should().BeTrue();
		new TestPrimitiveB("Test", 34).Equals(new TestPrimitiveB("NotTest", 50)).Should().BeFalse();
	}

	[Fact]
	public void EqualsPrimitive_EqaulityIsCorrect()
	{
		new TestPrimitiveB("Test", 34).Equals("Test").Should().BeTrue();
		new TestPrimitiveB("Test", 34).Equals("NotTest").Should().BeFalse();

		new TestPrimitiveB("Test", 34).Equals(new TestPrimitiveC("Test", 50)).Should().BeTrue();
		new TestPrimitiveB("Test", 34).Equals(new TestPrimitiveC("NotTest", 50)).Should().BeFalse();
	}

	[Fact]
	public void EqualsObject_EqaulityIsCorrect()
	{
		new TestPrimitiveB("Test", 34).Equals((object) new TestPrimitiveB("Test", 50)).Should().BeTrue();
		new TestPrimitiveB("Test", 34).Equals((object) new TestPrimitiveB("NotTest", 50)).Should().BeFalse();

		new TestPrimitiveB("Test", 34).Equals((object)"Test").Should().BeTrue();
		new TestPrimitiveB("Test", 34).Equals((object)"NotTest").Should().BeFalse();

		new TestPrimitiveB("Test", 34).Equals((object) new TestPrimitiveC("Test", 50)).Should().BeTrue();
		new TestPrimitiveB("Test", 34).Equals((object) new TestPrimitiveC("NotTest", 50)).Should().BeFalse();
	}

	[Fact]
	public void ImplicitCasting_CanCastToPrimitive()
	{
		string test = new TestPrimitiveA("Test");
		test.Should().Be("Test");
	}

	[Fact]
	public void EqualsOperator()
	{
		(new TestPrimitiveB("Test", 34) == "Test").Should().BeTrue();
		(new TestPrimitiveB("Test", 34) == "NotTest").Should().BeFalse();

		(new TestPrimitiveB("Test", 34) == new TestPrimitiveC("Test", 34)).Should().BeTrue();
		(new TestPrimitiveB("Test", 34) == new TestPrimitiveC("NotTest", 34)).Should().BeFalse();
	}

	[Fact]
	public void NotEqualsOperator()
	{
		(new TestPrimitiveB("Test", 34) != "Test").Should().BeFalse();
		(new TestPrimitiveB("Test", 34) != "NotTest").Should().BeTrue();

		(new TestPrimitiveB("Test", 34) != new TestPrimitiveC("Test", 34)).Should().BeFalse();
		(new TestPrimitiveB("Test", 34) != new TestPrimitiveC("NotTest", 34)).Should().BeTrue();

		(new TestPrimitiveB("Test", 34) != new TestPrimitiveB("Test", 34)).Should().BeFalse();
		(new TestPrimitiveB("Test", 34) != new TestPrimitiveB("NotTest", 34)).Should().BeTrue();
	}

	// Convertible Specific
	[Fact]
	public void GetTypeCode_ReturnsPrimitiveType()
	{
		new TestPrimitiveA("Test").GetTypeCode().Should().Be(TypeCode.String);
	}

	[Fact]
	public void Convertible_AllConversionsWork()
	{
		Convert.ToBoolean(new TestPrimitiveB("True", 30) as object).Should().Be(true);
		Convert.ToBoolean(new TestPrimitiveB("False", 30) as object).Should().Be(false);
		Convert.ToByte(new TestPrimitiveB("8", 30) as object).Should().Be(8);
		Convert.ToChar(new TestPrimitiveB("T", 30) as object).Should().Be('T');
		Convert.ToDateTime(new TestPrimitiveB("1995-03-14", 30) as object).Should().Be(new DateTime(1995, 3, 14));
		Convert.ToDecimal(new TestPrimitiveB("13.5", 30) as object).Should().Be(13.5m);
		Convert.ToDouble(new TestPrimitiveB("13.5", 30) as object).Should().Be(13.5);
		Convert.ToInt16(new TestPrimitiveB("13", 30) as object).Should().Be(13);
		Convert.ToInt32(new TestPrimitiveB("13", 30) as object).Should().Be(13);
		Convert.ToInt64(new TestPrimitiveB("13", 30) as object).Should().Be(13);
		Convert.ToSByte(new TestPrimitiveB("8", 30) as object).Should().Be(8);
		Convert.ToSingle(new TestPrimitiveB("13.5", 30) as object).Should().Be(13.5f);
		Convert.ToString(new TestPrimitiveB("Test", 30) as object).Should().Be("Test");
		Convert.ToUInt16(new TestPrimitiveB("13", 30) as object).Should().Be(13);
		Convert.ToUInt32(new TestPrimitiveB("13", 30) as object).Should().Be(13);
		Convert.ToUInt64(new TestPrimitiveB("13", 30) as object).Should().Be(13);
		Convert.ChangeType(new TestPrimitiveB("13", 30) as object, typeof(int)).Should().Be(13);
	}

	// String Specific
	[Fact]
	public void Length_ReturnsStringLength()
	{
		new TestPrimitiveA("Test").Length.Should().Be(4);
	}

	[Fact]
	public void Clone_ReturnsCloneOfString()
	{
		var obj = new TestPrimitiveA("Test").Clone();
		obj.GetType().Should().Be(typeof(string));
		obj.ToString().Should().Be("Test");
	}

	[Fact]
	public void Contains_ReturnsCorrectBoolean()
	{
		new TestPrimitiveA("Test").Contains('e').Should().BeTrue();
		new TestPrimitiveA("Test").Contains('E').Should().BeFalse();
		new TestPrimitiveA("Test").Contains('E', StringComparison.OrdinalIgnoreCase).Should().BeTrue();
		new TestPrimitiveA("Test").Contains('a', StringComparison.OrdinalIgnoreCase).Should().BeFalse();
		new TestPrimitiveA("Test").Contains("es").Should().BeTrue();
		new TestPrimitiveA("Test").Contains("ES").Should().BeFalse();
		new TestPrimitiveA("Test").Contains("ES", StringComparison.OrdinalIgnoreCase).Should().BeTrue();
		new TestPrimitiveA("Test").Contains("as", StringComparison.OrdinalIgnoreCase).Should().BeFalse();
	}

}