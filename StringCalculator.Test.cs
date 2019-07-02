using System;
using Xunit;

namespace StringCalculator.Test
{
    public class StringCalculatorTests
    {
        StringCalculator stringCalculator = new StringCalculator();
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Empty_Or_Null_String_Should_Return_Zero(string value) => Assert.Equal(0, stringCalculator.Add(value));
        [Theory]
        [InlineData(".")]
        [InlineData("12,31z")]
        [InlineData("zdd%a")]
        [InlineData("7y")]
        [InlineData("7,7,null")]
        [InlineData("7,7,null,")]
        public void Anything_Else_Except_A_Number_Should_Throw_Exception(string value) => Assert.Throws<FormatException>(() => stringCalculator.Add(value));
        [Fact]
        public void Single_Number_Should_Return_Value() => Assert.Equal(5, stringCalculator.Add("5"));
        [Fact]
        public void Two_Numbers_Should_Return_Sum() => Assert.Equal(3.5, stringCalculator.Add("1,2.5"));
        [Fact]
        public void Ten_Numbers_Should_Return_Sum() => Assert.Equal(10, stringCalculator.Add("1,1,1,1,1,1,1,1,1,1"));
        [Fact]
        public void Negative_Number_Should_Throw_Exception() => Assert.Throws<ArgumentException>(() => stringCalculator.Add("-3,-5,4,3,-1"));
        [Fact]
        public void Missing_Number_In_The_Last_Position() => Assert.Throws<InvalidOperationException>(() => stringCalculator.Add("1,2,"));

    }
}
