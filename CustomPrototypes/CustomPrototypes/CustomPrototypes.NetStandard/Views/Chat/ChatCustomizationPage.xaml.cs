using CustomPrototypes.NetStandard.Common;
using Xamarin.Forms;

namespace CustomPrototypes.NetStandard.Views.Chat
{
    public partial class ChatCustomizationPage : ContentPage
	{
        public ChatCustomizationPage()
		{
			InitializeComponent();
	    }

	    private void RadEntry_OnTextChanged(object sender, TextChangedEventArgs e)
	    {
	        if (!string.IsNullOrEmpty(e?.NewTextValue))
	        {
	            ChatHelpers.Instance.RemainingCharacters = $"{e.NewTextValue.Length}/240";
	        }
	    }
    }
}