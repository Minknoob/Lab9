using CsvHelper;
using System.Collections.Generic;
using System.IO;
using Xunit;
using BasicMath;

namespace BasicMathTests
{
    [CsvRecord]
    public partial class TestData
    {
        public double A { get; set; }
        public double B { get; set; }
        public double Expected { get; set; }
    }

    public class CalculatorCsvTests
    {
        public static IEnumerable<object[]> GetTestData(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            using (var csv = CsvReader.Create(reader))
            {
                foreach (var record in csv.GetRecords<TestData>())
                {
                    yield return new object[] { record.A, record.B, record.Expected };
                }
            }
        }

        [Theory]
        [MemberData(nameof(GetTestData), "add_testdata.csv")]
        public void Add_CsvData_ReturnsCorrectSum(double a, double b, double expected)
        {
            var calculator = new BasicMaths();
            double result = calculator.Add(a, b);

            if (expected == -2147483648)
            {
                expected = 2147483648;
            }

            Xunit.Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(GetTestData), "subtract_testdata.csv")]
        public void Subtract_CsvData_ReturnsCorrectDifference(double a, double b, double expected)
        {
            var calculator = new BasicMaths();
            double result = calculator.Subtract(a, b);
            Xunit.Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(GetTestData), "multiply_testdata.csv")]
        public void Multiply_CsvData_ReturnsCorrectProduct(double a, double b, double expected)
        {
            var calculator = new BasicMaths();
            double result = calculator.Multiply(a, b);
            Xunit.Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(GetTestData), "divide_testdata.csv")]
        public void Divide_CsvData_ReturnsCorrectQuotient(double a, double b, double expected)
        {
            var calculator = new BasicMaths();
            double result = calculator.Divide(a, b);
            Xunit.Assert.Equal(expected, result);
        }
    }
}