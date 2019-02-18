using System.Collections.ObjectModel;
using CommonHelpers.Common;
using CustomPrototypes.NetStandard.Models;
using CustomPrototypes.NetStandard.Views;
using CustomPrototypes.NetStandard.Views.Calendar;
using CustomPrototypes.NetStandard.Views.Chat;
using CustomPrototypes.NetStandard.Views.DataGrid;

namespace CustomPrototypes.NetStandard.ViewModels
{
    public class RootMasterViewModel : ViewModelBase
    {
        public RootMasterViewModel()
        {
            MenuItems = new ObservableCollection<NavigationMenuItem>
            {
                new NavigationMenuItem { Title = "Dicom Service", TargetType = typeof(DicomDemoPage)},
                new NavigationMenuItem
                {
                    Title = "Calendar",
                    TargetType = null,
                    Children = new ObservableCollection<NavigationMenuItem>
                    {
                        new NavigationMenuItem { Title = "ControlTemplate Customization", TargetType = typeof(ChatCustomizationPage)}
                    }
                },
                new NavigationMenuItem { Title = "File IO", TargetType = typeof(FileTestsPage)},
                new NavigationMenuItem
                {
                    Title = "Calendar",
                    TargetType = null,
                    Children = new ObservableCollection<NavigationMenuItem>
                    {
                        new NavigationMenuItem { Title = "Custom Renderers", TargetType = typeof(CalendarRenderersPage)}
                    }
                },
                new NavigationMenuItem
                {
                    Title = "DataGrid",
                    TargetType = null,
                    Children = new ObservableCollection<NavigationMenuItem>
                    {
                        new NavigationMenuItem { Title = "DataGrid EditContext", TargetType = typeof(DataGridEditContextPage)},
                        new NavigationMenuItem { Title = "DataGrid Grouping", TargetType = typeof(DataGridGrouping)},
                    }
                },
                new NavigationMenuItem { Title = "Global Styles", TargetType = typeof(GlobalStylesPage)},
                new NavigationMenuItem { Title = "Badges Idea", TargetType = typeof(BadgesIdeaPage)},
                new NavigationMenuItem { Title = "About", TargetType = typeof(AboutPage) }
            };
        }

        public ObservableCollection<NavigationMenuItem> MenuItems { get; set; }
    }
}
