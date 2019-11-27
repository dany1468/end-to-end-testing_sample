using Atata;

namespace AtataSample
{
    using _ = FetchDataPage;

    [Url("/")]
    [VerifyTitle("SampleSpaSite")]
    [VerifyH1("Weather forecast")]
    public class FetchDataPage : Page<_>
    {
        [FindByClass("table")]
        public Table<_> WeatherTable { get; private set; }

    }
}
