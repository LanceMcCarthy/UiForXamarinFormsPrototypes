using CustomPrototypes.Portable.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly:XamlCompilation(XamlCompilationOptions.Compile)]
namespace CustomPrototypes.Portable
{
    public partial class App : Application
    {
        internal static MasterDetailPage RootPage { get; set; }

        public App()
        {
            InitializeComponent();

            RootPage = new Root();
            MainPage = RootPage;
        }

        protected override void OnStart()
        {
            
        }

        protected override void OnSleep()
        {
            
        }

        protected override void OnResume()
        {
            
        }
    }
}