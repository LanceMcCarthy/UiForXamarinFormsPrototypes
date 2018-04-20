using System;
using CustomPrototypes.NetStandard.Models;
using Xamarin.Forms;

namespace CustomPrototypes.NetStandard.Views
{
    public partial class Root : MasterDetailPage
    {
        public Root()
        {
            InitializeComponent();
            MasterPage.ListView.ItemTapped += ListView_ItemTapped;
        }

        private void ListView_ItemTapped(object sender, Telerik.XamarinForms.DataControls.ListView.ItemTapEventArgs e)
        {
            if (!(e.Item is RootMenuItem item)) 
                return;

            var page = (Page)Activator.CreateInstance(item.TargetType);

            page.Title = item.Title;

            Detail = new NavigationPage(page);

            // Hide the pane on app launch if we're not running on desktop
            if (Device.RuntimePlatform != "UWP")
                IsPresented = false;
        }
    }
}