using System.Collections.ObjectModel;
using CustomPrototypes.NetStandard.Models;

namespace CustomPrototypes.NetStandard.ViewModels
{
    public class BadgesIdeaViewModel : ViewModelBase
    {
        public BadgesIdeaViewModel()
        {
            for (int i = 0; i < 10; i++)
            {
                MyItems.Add(new BadgedItem
                {
                    Title = $"Item {i}",
                    BadgeCount = i
                });
            }
        }

        public ObservableCollection<BadgedItem> MyItems { get; set; } = new ObservableCollection<BadgedItem>();
    }
}
