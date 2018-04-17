namespace CustomPrototypes.Portable.Models
{
    public class Data : ObservableObject
    {
        private string country;
        private string capital;

        public string Country
        {
            get => country;
            set => SetProperty(ref country, value);
        }

        public string Capital
        {
            get => capital;
            set => SetProperty(ref capital, value);
        }
    }
}
