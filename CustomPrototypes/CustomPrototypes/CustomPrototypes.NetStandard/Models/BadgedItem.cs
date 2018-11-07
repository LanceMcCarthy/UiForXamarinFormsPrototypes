using CommonHelpers.Common;
using Xamarin.Forms;

namespace CustomPrototypes.NetStandard.Models
{
    public class BadgedItem : BindableBase
    {
        private string _title;
        private bool _hasBadges;
        private int _badgeCount;

        public BadgedItem()
        {
            ResetBadgeCountCommand = new Command(() => { BadgeCount = 0; });
        }

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public bool HasBadges
        {
            get => _hasBadges;
            set => SetProperty(ref _hasBadges, value);
        }

        public int BadgeCount
        {
            get => _badgeCount;
            set
            {
                SetProperty(ref _badgeCount, value);

                HasBadges = value > 0;
            }
        }

        public Command ResetBadgeCountCommand { get; set; }
    }
}