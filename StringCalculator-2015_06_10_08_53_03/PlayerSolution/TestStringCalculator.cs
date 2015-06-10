using System;
using Engine;
using Katarai.StringCalculator.Interfaces;
using NUnit.Framework;

namespace PlayerStringKata
{
    public class TestStringCalculator : ITestPack<IStringCalculator>
    {
        public Func<IStringCalculator> CreateSUT { get; set; }

		[SetUp]
        public void SetupTest()
        {
            CreateSUT = () => new StringCalculator();
        }
		
		private IStringCalculator CreateCalculator()
		{
			return CreateSUT();
		}
		
        /// <summary>
        /// This is a sample test that shows how the StringCalculator 
        /// should be created in future tests. 
        /// </summary>
        [Test]
        public void Constructor()
        {
            //---------------Arrange-------------------
            
            //---------------Act----------------------
            var calculator = CreateCalculator();
            //---------------Assert-----------------------
            Assert.IsNotNull(calculator);
        }

        [Test]
        public void Add_GivenInput_EmptyString_ShouldReturn_0()
        {
            const int expected = 0;

            var actual = CreateCalculator().Add("");

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_GivenInput_NumericString_ShouldReturn_IntegarValue()
        {
            const int expected = 1;

            var actual = CreateCalculator().Add("1");

            Assert.AreEqual(expected,actual);
        }

        [Test]
        public void Add_GivenInput_NumericStringOf2NumbersSeperatedByCommas_ShouldReturn_SumOfValues()
        {
            const int expected = 3;

            var actual = CreateCalculator().Add("1,2");

            Assert.AreEqual(expected,actual);
        }

        [Test]
        public void Add_GivenInput_NumericStringOf3NumbersSeperatedByCommas_ShouldReturn_SumOfValues()
        {
            const int expected = 6;

            var actual = CreateCalculator().Add("1,2,3");

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_GivenInput_NumericStringOf2NumbersSeperatedByNewLine_ShouldReturn_SumOfValues()
        {
            const int expected = 3;

            var actual = CreateCalculator().Add("1\n2");

            Assert.AreEqual(expected,actual);
        }

        [Test]
        public void Add_GivenInput_NumericStringOf3NumbersSeperatedByNewLine_ShouldReturn_SumOfValues()
        {
            const int expected = 10;

            var actual = CreateCalculator().Add("5\n4\n1");

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_GivenInput_NumericStringOf3NumbersSeperatedByNewLineAndCommas_ShouldReturn_SumOfValues()
        {
            const int expected = 11;

            var actual = CreateCalculator().Add("5\n5,1");

            Assert.AreEqual(expected,actual);
        }
      
    }
}
