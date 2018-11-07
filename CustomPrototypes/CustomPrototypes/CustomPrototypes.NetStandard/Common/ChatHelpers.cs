using CommonHelpers.Common;

namespace CustomPrototypes.NetStandard.Common
{
    public class ChatHelpers : BindableBase
    {
        #region Singleton Members

        private static ChatHelpers _instance;
        public static ChatHelpers Instance => _instance ?? (_instance = new ChatHelpers());

        #endregion

        private string _remainingCharacters;
        public string RemainingCharacters
        {
            get => _remainingCharacters;
            set => SetProperty(ref _remainingCharacters, value);
        }
    }
}
