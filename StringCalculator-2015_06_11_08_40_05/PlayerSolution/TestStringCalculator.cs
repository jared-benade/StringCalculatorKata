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
        public void Add_Given_EmptyString_ShouldReturn_0()
        {
            //---------------Set up test pack-------------------
            const int expected = 0;
            const string input = "";
            var stringCalculator = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var actual = stringCalculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected,actual);
        }

        [Test]
        public void Add_Given_NumericStringWith1Number_ShouldReturn_IntegarValue()
        {
            //---------------Set up test pack-------------------
            const int expected = 1;
            const string input = "1";
            var stringCalculator = CreateCalculator();
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var actual = stringCalculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected,actual);
        }

        [Test]
        public void Add_Given_NumericStringOf2NumbersSeperatedByCommas_ShouldReturn_SumOfNumbers()
        {
            //---------------Set up test pack-------------------
            var expected = 2;
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var actual = CreateCalculator().Add("1,1");
            //---------------Test Result -----------------------
            Assert.AreEqual(expected,actual);
        } 
        
        [Test]
        public void Add_Given_NumericStringOf3NumbersSeperatedByCommas_ShouldReturn_SumOfNumbers()
        {
            //---------------Set up test pack-------------------
            var expected = 4;
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var actual = CreateCalculator().Add("1,1,2");
            //---------------Test Result -----------------------
            Assert.AreEqual(expected,actual);
        }

        [Test]
        public void Add_Given_NumericStringOf3NumbersSeperatedByCommasAndNewLine_ShouldReturn_SumOfNumbers()
        {
            //---------------Set up test pack-------------------
            var expected = 4;
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var actual = CreateCalculator().Add("1,1\n2");
            //---------------Test Result -----------------------
            Assert.AreEqual(expected,actual);
        }

        [Test]
        public void Add_Given_NumericStringOf2NumbersWithCustomDelimiter_ShouldReturn_SumOfNumbers()
        {
            //---------------Set up test pack-------------------
            const string input = "//;\n1;1";
            const int expected = 2;
            var stringCalculator = CreateCalculator();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            var actual = stringCalculator.Add(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected,actual);
        }

        [Test]
        public void Add_Given_NumericStringWithNegativeNumbers_ShouldReturn_NegativesNotAllowedException()
        {
            //---------------Set up test pack-------------------
            var expected = -1;
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var actual = Assert.Throws<NegativesNotAllowedException>(() => CreateCalculator().Add("-1"));
            //---------------Test Result -----------------------

            Assert.That(actual, Is.Not.Null);
        }

        [Test]
        public void Add_Given_NumericStringWithNegativeNumbers_ShouldReturn_NegativesNotAllowedExceptionAndTheNegativeNumbers()
        {
            //---------------Set up test pack-------------------
            int[] expected = new int[1]{-1};
            //---------------Assert Precondition----------------

            //---------------Execute Test ----------------------
            var actual = Assert.Throws<NegativesNotAllowedException>(() => CreateCalculator().Add("-1"));
            //---------------Test Result -----------------------
            //Assert.AreEqual(expected,actual);

            Assert.AreEqual(actual.NegativeNumbers, expected);
        }

    }
}
