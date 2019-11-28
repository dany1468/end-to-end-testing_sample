using Atata;

namespace AtataSample
{
    using _ = HomePage;

    [Url("/")]
    [VerifyTitle("SampleSpaSite")]
    public class HomePage : Page<_>
    {
        [FindByContent("Fetch data")]
        public LinkDelegate<FetchDataPage, _> FetchData { get; private set; }
    }
}
