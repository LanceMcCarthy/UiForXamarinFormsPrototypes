namespace CustomPrototypes.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new NetStandard.App());
        }
    }
}
