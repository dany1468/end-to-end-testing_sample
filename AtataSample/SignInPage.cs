using Atata;

namespace AtataSample
{
    using _ = LogInPage;

    [Url("Identity/Account/Login")]
    [VerifyTitle("Log in - SampleSpaSite")]
    [VerifyH1("Log in")]
    public class LogInPage : Page<_>
    {
        [FindByLabel] public EmailInput<_> Email { get; private set; }

        [FindByLabel] public PasswordInput<_> Password { get; private set; }

        [Term("Log in")]
        public ButtonDelegate<HomePage, _> LogIn { get; private set; }

        [FindByClass("validation-summary-errors")]
        public UnorderedList<ListItem<_>, _> UnorderedList { get; private set; }
    }
}
