using Xamarin.Forms;

namespace CustomPrototypes.NetStandard.Views.Other
{
	public partial class FileTestsPage : ContentPage
	{
		public FileTestsPage ()
		{
			InitializeComponent ();
		}
        
	    protected override async void OnDisappearing()
	    {
	        await ViewModel.DeleteAllAsync();
	        base.OnDisappearing();
	    }
	}
}