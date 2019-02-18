using System.Collections.ObjectModel;
using CommonHelpers.Common;
using CustomPrototypes.NetStandard.Models;
using CustomPrototypes.NetStandard.Views.AutoCompleteView;
using CustomPrototypes.NetStandard.Views.Button;
using CustomPrototypes.NetStandard.Views.Calendar;
using CustomPrototypes.NetStandard.Views.Chat;
using CustomPrototypes.NetStandard.Views.DataGrid;
using CustomPrototypes.NetStandard.Views.Other;

namespace CustomPrototypes.NetStandard.ViewModels
{
    public class RootMasterViewModel : ViewModelBase
    {
        public RootMasterViewModel()
        {
            MenuItems = new ObservableCollection<NavigationMenuItem>
            {
                new NavigationMenuItem
                {
                    Title = "AutoCompleteView",
                    TargetType = null,
                    Children = new ObservableCollection<NavigationMenuItem>
                    {
                        new NavigationMenuItem { Title = "MVVM", TargetType = typeof(AutoCompleteMvvm)}
                    }
                },
                new NavigationMenuItem
                {
                    Title = "Button",
                    TargetType = null,
                    Children = new ObservableCollection<NavigationMenuItem>
                    {
                        new NavigationMenuItem { Title = "Badges", TargetType = typeof(BadgesIdeaPage)}
                    }
                },
                new NavigationMenuItem
                {
                    Title = "Calendar",
                    TargetType = null,
                    Children = new ObservableCollection<NavigationMenuItem>
                    {
                        new NavigationMenuItem { Title = "ControlTemplate Customization", TargetType = typeof(ChatCustomizationPage)}
                    }
                },
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
                        new NavigationMenuItem { Title = "Edit Context", TargetType = typeof(DataGridEditContextPage)},
                        new NavigationMenuItem { Title = "Grouping", TargetType = typeof(DataGridGrouping)},
                    }
                },
                new NavigationMenuItem
                {
                    Title = "Other",
                    TargetType = null,
                    Children = new ObservableCollection<NavigationMenuItem>
                    {
                        new NavigationMenuItem { Title = "Dicom Service", TargetType = typeof(DicomDemoPage)},
                        new NavigationMenuItem { Title = "File IO", TargetType = typeof(FileTestsPage)},
                        new NavigationMenuItem { Title = "Global Styles", TargetType = typeof(GlobalStylesPage)}
                    }
                },
                
                new NavigationMenuItem { Title = "About", TargetType = typeof(AboutPage)}
            };
        }

        public ObservableCollection<NavigationMenuItem> MenuItems { get; set; }
    }
}
