using CommonHelpers.Common;
using Xamarin.Forms;

namespace CustomPrototypes.NetStandard.Models
{
    public class DownloadedImage : BindableBase
    {
        private long _id;
        private string _filePath;
        private string _fileName;
        private ImageSource _source;

        public long Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        public string FilePath
        {
            get => _filePath;
            set => SetProperty(ref _filePath, value);
        }

        public string FileName
        {
            get => _fileName;
            set => SetProperty(ref _fileName, value);
        }

        public ImageSource Source
        {
            get => _source;
            set => SetProperty(ref _source, value);
        }
    }
}