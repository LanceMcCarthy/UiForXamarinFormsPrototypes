using Xamarin.Forms;

namespace CustomPrototypes.NetStandard.Models
{
    public class DownloadedImage : ObservableObject
    {
        private long id;
        private string filePath;
        private string fileName;
        private ImageSource source;

        public long Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }

        public string FilePath
        {
            get => filePath;
            set => SetProperty(ref filePath, value);
        }

        public string FileName
        {
            get => fileName;
            set => SetProperty(ref fileName, value);
        }

        public ImageSource Source
        {
            get => source;
            set => SetProperty(ref source, value);
        }
    }
}