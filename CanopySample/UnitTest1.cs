using System;
using canopy;
using _ = canopy.csharp.canopy;

namespace CanopySample
{
    public class Program
    {
        public static void Main()
        {
            new UnitTest1().Test1();
        }
    }

    public class UnitTest1
    {
        public void Test1()
        {
            configuration.elementTimeout = 3.0;
            configuration.compareTimeout = 3.0;
            configuration.pageTimeout = 3.0;
            configuration.reporter = new reporters.ConsoleReporter();
            var testpage = "https://localhost:5001";

            _.start(types.BrowserStartMode.Chrome);

            _.test("Apostrophes don't break anything", () =>
            {
                _.url(testpage);
                _.equality(_.title(), "SampleSpaSite");
            });

            _.test("Login Failed", () =>
            {
                _.url($"{testpage}/Identity/Account/Login");
                _.equality(_.title(), "Log in - SampleSpaSite");

                _.write("#Input_Email", "admin@mail.com");
                _.write("#Input_Password", "invalid");
                _.click("#login-submit");

                var element = _.elements(".validation-summary-errors li");
                _.equality(1, element.Length);
                _.equality("Invalid login attempt.", element[0].Text);

                _.equality(_.title(), "Log in - SampleSpaSite");
            });

            _.test("Login", () =>
            {
                _.url($"{testpage}/Identity/Account/Login");
                _.equality(_.title(), "Log in - SampleSpaSite");

                _.write("#Input_Email", "admin@mail.com");
                _.write("#Input_Password", "P@55w0rd");
                _.click("#login-submit");

                _.equality("SampleSpaSite", _.title());

                _.click("a.nav-link:contains('Fetch data')");

                _.waitForElement("table");
                _.eq("h1", "Weather forecast");
                _.count("table tbody tr", 5);
            });

            _.run();

            _.quit();
        }
    }
}
