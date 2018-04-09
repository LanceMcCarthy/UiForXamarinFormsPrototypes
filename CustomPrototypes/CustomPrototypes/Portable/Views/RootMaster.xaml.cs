using CustomPrototypes.Portable.ViewModels;
using Telerik.XamarinForms.DataControls;
using Xamarin.Forms;

namespace CustomPrototypes.Portable.Views
{
    public partial class RootMaster : ContentPage
    {
        public RadListView ListView;

        public RootMaster()
        {
            InitializeComponent();

            BindingContext = new RootMasterViewModel();
            ListView = MenuItemsListView;
        }
    }
}