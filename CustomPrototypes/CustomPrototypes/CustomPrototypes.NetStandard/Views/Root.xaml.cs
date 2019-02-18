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
            MasterPage.TreeView.ItemTapped += TreeView_ItemTapped;
        }

        private void TreeView_ItemTapped(object sender, Telerik.XamarinForms.DataControls.TreeView.TreeViewItemEventArgs e)
        {
            if (!(e.Item is NavigationMenuItem item))
                return;

            if(item.TargetType == null)
                return;

            var page = (Page)Activator.CreateInstance(item.TargetType);

            page.Title = item.Title;

            Detail = new NavigationPage(page);

            // Hide the master page, except on UWP-desktop
            if (Device.RuntimePlatform == Device.UWP && Device.Idiom == TargetIdiom.Desktop)
            {
                return;
            }

            IsPresented = false;
        }
    }
}