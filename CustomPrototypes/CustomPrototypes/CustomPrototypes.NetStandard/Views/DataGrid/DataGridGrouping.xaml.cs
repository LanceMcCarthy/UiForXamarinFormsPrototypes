using System;
using System.Linq;
using Telerik.XamarinForms.DataGrid;
using Telerik.XamarinForms.Primitives;
using Xamarin.Forms;

namespace CustomPrototypes.NetStandard.Views.DataGrid
{
    public partial class DataGridGrouping : ContentPage
	{
		public DataGridGrouping()
		{
			InitializeComponent();
        }

        private void GroupHeaderCheckbox_OnIsCheckedChanged(object sender, Telerik.XamarinForms.Primitives.CheckBox.IsCheckedChangedEventArgs e)
        {
            if(sender is RadCheckBox cb && cb.BindingContext is GroupHeaderContext context)
            {
                foreach (var item in context.Group.ChildItems)
                {
                    if (e.NewValue == true)
                    {
                        context.Grid.SelectItem(item);
                    }
                    else
                    {
                        context.Grid.DeselectItem(item);
                    }
                }
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            DataGrid.DeselectAll();

            // Get the DataView.
            var dataView = DataGrid.GetDataView();

            // Get all the groups in the DataView.
            var groups = dataView.GetGroups();

            // Get the group you want to make the selections in.
            var firstGroup = groups.FirstOrDefault();
            
            // Select all the rows in that group.
            foreach (var item in firstGroup.ChildItems)
            {
                DataGrid.SelectItem(item);
            }
        }
    }
}