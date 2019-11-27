using System;
using Atata;
using NUnit.Framework;
namespace AtataSample
{
    [TestFixture]
    public class SignInTests
    {
        [SetUp]
        public void SetUp()
        {
            AtataContext.Configure().
                UseChrome().
                UseBaseUrl("https://localhost:5001/").
                UseNUnitTestName().
                AddNUnitTestContextLogging().
                AddScreenshotFileSaving().
                LogNUnitError().
                TakeScreenshotOnNUnitError().
                Build();
        }

        [TearDown]
        public void TearDown()
        {
            AtataContext.Current?.CleanUp();
        }

        [Test]
        public void SignIn()
        {
            Go.To<LogInPage>().
                Email.Set("admin@mail.com").
                Password.Set("abc123").
                LogIn.Click()
                .UnorderedList.Items.Count.Should.Equal(1)
                .UnorderedList.Items[0].Content.Should.Equal("Invalid login attempt.");
        }

        [Test]
        public void SignInAndGoHome()
        {
            Go.To<LogInPage>()
                .Email.Set("admin@mail.com")
                .Password.Set("P@55w0rd")
                .LogIn()
                .FetchData()
                .WeatherTable.Rows.Count.Should.Equal(5);
        }
    }
}
