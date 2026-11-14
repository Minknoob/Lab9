using CsvHelper;
using System.Collections.Generic;
using System.IO;
using Xunit;
using BankAccountApp;

namespace BankAccountTests
{
    [CsvRecord]
    public partial class TestData
    {
        public string CustomerName { get; set; } = string.Empty;
        public decimal InitialBalance { get; set; }
        public decimal DebitAmount { get; set; }
        public string ExpectedBalance { get; set; } = string.Empty;
    }

    public class BankAccountCsvTests
    {
        public static IEnumerable<object[]> GetTestData()
        {
            using (var reader = new StreamReader("BankAccountTestData.csv"))
            using (var csv = CsvReader.Create(reader))
            {
                foreach (var record in csv.GetRecords<TestData>())
                {
                    yield return new object[] { record.CustomerName, record.InitialBalance, record.DebitAmount, record.ExpectedBalance };
                }
            }
        }

        [Theory]
        [MemberData(nameof(GetTestData))]
        public void Debit_CsvData_UpdatesBalance(string customerName, decimal initialBalance, decimal debitAmount, string expectedBalance)
        {
            var account = new BankAccount(customerName, initialBalance);

            if (expectedBalance == "Insufficient funds")
            {
                Xunit.Assert.Throws<InvalidOperationException>(() => account.Debit(debitAmount));
            }
            else
            {
                account.Debit(debitAmount);
                Xunit.Assert.Equal(decimal.Parse(expectedBalance), account.Balance);
            }
        }
    }
}