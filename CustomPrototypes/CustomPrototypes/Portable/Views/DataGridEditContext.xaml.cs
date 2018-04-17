using System.Collections.Generic;
using CustomPrototypes.Portable.Models;
using Telerik.XamarinForms.DataGrid;
using Telerik.XamarinForms.DataGrid.Commands;
using Xamarin.Forms;

namespace CustomPrototypes.Portable.Views
{
    public partial class DataGridEditContext : ContentPage
    {
        private readonly List<Data> items;

        public DataGridEditContext()
        {
            InitializeComponent();

            this.items = new List<Data>
            {
                new Data { Country = "India", Capital = "New Delhi"},
                new Data { Country = "South Africa", Capital = "Cape Town"},
                new Data { Country = "Nigeria", Capital = "Abuja" },
                new Data { Country = "Singapore", Capital = "Singapore" }
            };

            this.DataGrid.ItemsSource = items;
        }

        private void Button_Clicked(object sender, System.EventArgs e)
        {
            DataGridCellInfo cellInfo = new DataGridCellInfo(items[0], this.DataGrid.Columns[0]);
            var editContext = new EditContext(cellInfo, ActionTrigger.Programmatic, null);
            this.DataGrid.CommandService.ExecuteDefaultCommand(DataGridCommandId.BeginEdit, editContext);
        }
    }
}