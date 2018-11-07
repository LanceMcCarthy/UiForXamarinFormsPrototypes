using System.Collections.ObjectModel;
using CommonHelpers.Common;
using CustomPrototypes.NetStandard.Models;
using CustomPrototypes.NetStandard.Views;

namespace CustomPrototypes.NetStandard.ViewModels
{
    public class RootMasterViewModel : ViewModelBase
    {
        public RootMasterViewModel()
        {
            MenuItems = new ObservableCollection<RootMenuItem>
            {
                new RootMenuItem { Title = "Dicom Service", TargetType = typeof(DicomDemoPage)},
                new RootMenuItem { Title = "Chat Customization", TargetType = typeof(ChatCustomizationPage)},
                new RootMenuItem { Title = "File IO", TargetType = typeof(FileTestsPage)},
                new RootMenuItem { Title = "Calendar Renderers", TargetType = typeof(CalendarRenderersPage)},
                new RootMenuItem { Title = "DataGrid EditContext", TargetType = typeof(DataGridEditContextPage)},
                new RootMenuItem { Title = "Global Styles", TargetType = typeof(GlobalStylesPage)},
                new RootMenuItem { Title = "Badges Idea", TargetType = typeof(BadgesIdeaPage)},
                new RootMenuItem { Title = "About", TargetType = typeof(AboutPage) }
            };
        }

        public ObservableCollection<RootMenuItem> MenuItems { get; set; }
    }
}
