using CsvHelper;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;
using Allure.Net.Commons;
using Allure.Xunit.Attributes;
namespace LoginAutomation
{
    [AllureSuite("Login Tests")]
    [AllureFeature("Login")]
    public class LoginTests
    {
        public static IEnumerable<object[]> GetTestData()
        {
            using var reader = CsvReader.FromFile("LoginTestData.csv");

            int userIndex = reader.GetFieldIndex("username");
            int passIndex = reader.GetFieldIndex("password");

            while (reader.Read())
            {
                yield return new object[]
                {
                    reader.GetString(userIndex),
                    reader.GetString(passIndex)
                };
            }
        }
        [Theory]
        [MemberData(nameof(GetTestData))]
        [AllureSubSuite("Valid credentials")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureStory("User logs in with CSV data")]
        [AllureTag("selenium", "csv")]
        public void Login_WithValidCredentials_ShouldSucceed(string username, string password)
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                // Open the login page
                driver.Navigate().GoToUrl("file:///D:/524H0168_Lab9/LoginPage/login.html");

                // Fill in the form
                driver.FindElement(By.Id("username")).SendKeys(username);
                driver.FindElement(By.Id("password")).SendKeys(password);

                // Click the login button
                driver.FindElement(By.Id("loginButton")).Click();

                // Wait a moment so the result can be seen
                Thread.Sleep(2000);

                // Assertion: the page must show the success message
                string message = driver.FindElement(By.Id("message")).Text;
                Assert.Equal("Login successful", message);
            }
        }
    }
}