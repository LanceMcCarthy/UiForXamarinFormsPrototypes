using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CustomPrototypes.NetStandard.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ChatCustomizationPage : ContentPage
	{
		public ChatCustomizationPage ()
		{
			InitializeComponent ();
		}
	}
}