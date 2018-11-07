using CommonHelpers.Common;

namespace CustomPrototypes.NetStandard.Models
{
    public class Data : BindableBase
    {
        private string _country;
        private string _capital;

        public string Country
        {
            get => _country;
            set => SetProperty(ref _country, value);
        }

        public string Capital
        {
            get => _capital;
            set => SetProperty(ref _capital, value);
        }
    }
}
