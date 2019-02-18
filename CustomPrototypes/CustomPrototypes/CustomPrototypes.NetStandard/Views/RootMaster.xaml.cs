using CustomPrototypes.NetStandard.ViewModels;
using Telerik.XamarinForms.DataControls;
using Xamarin.Forms;

namespace CustomPrototypes.NetStandard.Views
{
    public partial class RootMaster : ContentPage
    {
        public RadTreeView TreeView;

        public RootMaster()
        {
            InitializeComponent();

            BindingContext = new RootMasterViewModel();
            TreeView = MenuItemsTreeView;
        }
    }
}