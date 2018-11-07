using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using CommonHelpers.Common;
using CustomPrototypes.NetStandard.DependencyServices;
using Dicom;
using Xamarin.Forms;

namespace CustomPrototypes.NetStandard.ViewModels
{
    public class DicomDemoViewModel : ViewModelBase
    {
        private readonly HttpClient _client;
        private ImageSource _xrayImageSource;

        public DicomDemoViewModel()
        {
            _client = new HttpClient();

            LoadImageCommand = new Command(() =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    IsBusy = true;
                    XrayImageSource = await LoadImageAsync();
                    IsBusy = false;
                });
            });
        }

        public ImageSource XrayImageSource
        {
            get => _xrayImageSource;
            set => SetProperty(ref _xrayImageSource, value);
        }
        
        public Command LoadImageCommand { get; set; }

        private async Task<ImageSource> LoadImageAsync()
        {
            Debug.WriteLine("Downloading image...");
            using (var response = await _client.GetAsync("https://www.dropbox.com/s/ublhzi54a9hcv20/CR0000001.dcm?dl=1"))
            {
                Debug.WriteLine("Reading downloaded content...");
                using (var streamToReadFrom = await response.Content.ReadAsStreamAsync())
                {
                    Debug.WriteLine("Opening Dicom file...");
                    var file = await DicomFile.OpenAsync(streamToReadFrom);

                    Debug.WriteLine("Getting image from file using Dependency Service...");
                    var imageStream = DependencyService.Get<ICustomDicomService>().GetImageStream(file, 0);

                    if (imageStream.Position != 0) imageStream.Position = 0;
                    Debug.WriteLine($"ImageStream - Length: {imageStream.Length}, Position: {imageStream.Position}");

                    Debug.WriteLine("Creating ImageSource...");
                    var imgSource = ImageSource.FromStream(() => imageStream);

                    Debug.WriteLine("Done!");
                    return imgSource;

                    // Alternative
                    //var bytes = DependencyService.Get<ICustomDicomService>().GetImageBytes(file, 0);
                    //var stream = new MemoryStream(bytes);
                    //return ImageSource.FromStream(() => stream);
                }
            }
        }
    }
}