using Atata;

namespace AtataSample
{
    using _ = HomePage;

    [Url("/")]
    [VerifyTitle("SampleSpaSite")]
    [VerifyH1("Hello, world!")]
    public class HomePage : Page<_>
    {
        [FindByContent("Fetch data")]
        public LinkDelegate<FetchDataPage, _> FetchData { get; private set; }
    }
}
