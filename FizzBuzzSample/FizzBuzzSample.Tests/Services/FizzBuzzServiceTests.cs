using FizzBuzzSample.Services.Contracts;
using FizzBuzzSample.Services.Impl;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzSample.Tests.Services
{
    [TestFixture]
    internal class FizzBuzzServiceTests
    {
        IFizzBuzzService TestSubject;

        [SetUp]
        public void Setup()
        {
            TestSubject = new FizzBuzzService();
        }

        [Test]
        [TestCaseSource(nameof(GetProcessTestData))]
        public void TestProcess(string commaSeparatedValues, Dictionary<string, List<string>> results)
        {
            var output = TestSubject.Process(commaSeparatedValues);
            
            Assert.That(output, Is.EquivalentTo(results));           

        }

        public static IEnumerable<TestCaseData> GetProcessTestData()
        {
            yield return new TestCaseData(null, new Dictionary<string, List<string>> { { "<empty>", new List<string> { "Invalid Item" } } });
            yield return new TestCaseData(" ", new Dictionary<string, List<string>> { { "<empty>", new List<string> { "Invalid Item" } } });
            yield return new TestCaseData(" A ", new Dictionary<string, List<string>> { { " A ", new List<string> { "Invalid Item" } } });
            yield return new TestCaseData("1, 1,1 ", new Dictionary<string, List<string>> { { "1", new List<string> { "Divided 1 by 3", "Divided 1 by 5" }}, { " 1", new List<string> { "Divided 1 by 3", "Divided 1 by 5" } }, { "1 ", new List<string> { "Divided 1 by 3", "Divided 1 by 5" } } });            
            yield return new TestCaseData("3, 3,3 ", new Dictionary<string, List<string>> { { "3", new List<string> { "Fizz" } }, { " 3", new List<string> { "Fizz" } }, { "3 ", new List<string> { "Fizz"} } });
            yield return new TestCaseData("5, 5,5 ", new Dictionary<string, List<string>> { { "5", new List<string> { "Buzz" } }, { " 5", new List<string> { "Buzz" } }, { "5 ", new List<string> { "Buzz" } } });
            yield return new TestCaseData(", ", new Dictionary<string, List<string>> { { "<empty>", new List<string> { "Invalid Item" } } });            
            yield return new TestCaseData("15, 15,15 ", new Dictionary<string, List<string>> { { "15", new List<string> { "FizzBuzz" } }, { " 15", new List<string> { "FizzBuzz" } }, { "15 ", new List<string> { "FizzBuzz" } } });
            yield return new TestCaseData("A, A,A , A ", new Dictionary<string, List<string>> { { "A", new List<string> { "Invalid Item"} }, { " A", new List<string> { "Invalid Item" } }, { "A ", new List<string> { "Invalid Item" } }, { " A ", new List<string> { "Invalid Item" } } });
        }
    }
}
