using Xamarin.Forms;

namespace CustomPrototypes.Portable.Models
{
    public class BadgedItem : ObservableObject
    {
        private string title;
        private bool hasBadges;
        private int badgeCount;

        public BadgedItem()
        {
            ResetBadgeCountCommand = new Command(() => { BadgeCount = 0; });
        }

        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        public bool HasBadges
        {
            get => hasBadges;
            set => SetProperty(ref hasBadges, value);
        }

        public int BadgeCount
        {
            get => badgeCount;
            set
            {
                SetProperty(ref badgeCount, value);

                HasBadges = value > 0;
            }
        }

        public Command ResetBadgeCountCommand { get; set; }
    }
}