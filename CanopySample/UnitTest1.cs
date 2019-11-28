using System;
using Xunit;
using canopy;
using _ = canopy.csharp.canopy;

namespace CanopySample
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var testpage = "http://lefthandedgoat.github.io/canopy/testpages/";

            _.start(types.BrowserStartMode.Chrome);

            _.test("Apostrophes don't break anything", () =>
            {
                _.url(testpage);
                _.count("I've got an apostrophe", 1);
            });

            _.run();

            _.quit();
        }
    }
}
