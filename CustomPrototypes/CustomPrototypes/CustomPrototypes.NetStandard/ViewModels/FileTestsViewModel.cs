using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CustomPrototypes.NetStandard.Common;
using CustomPrototypes.NetStandard.Models;
using Xamarin.Forms;

namespace CustomPrototypes.NetStandard.ViewModels
{
    public class FileTestsViewModel : ViewModelBase
    {
        private readonly HttpClient client;
        private ObservableCollection<DownloadedImage> images;

        public FileTestsViewModel()
        {
            client = new HttpClient();
            DownloadNextImageCommand = new Command(async () => { await DownloadAndSaveImage(); });
            DeleteAllImagesCommand = new Command(async () => { await DeleteAllAsync();});
        }

        public ObservableCollection<DownloadedImage> Images
        {
            get => images ?? (images = new ObservableCollection<DownloadedImage>());
            set => SetProperty(ref images, value);
        }

        public Command DownloadNextImageCommand { get; set; }

        public Command DeleteAllImagesCommand { get; set; }


        private async Task DownloadAndSaveImage()
        {
            try
            {
                IsBusy = true;

                using (var response = await client.GetStreamAsync("https://picsum.photos/180/320/"))
                {
                    var image = new DownloadedImage();
                    image.Id = DateTime.Now.Ticks;
                    image.FileName = $"image_{image.Id}.jpg";
                    image.FilePath = await response.SaveToLocalFolderAsync(image.FileName);
                    image.Source = new FileImageSource {File = image.FilePath};

                    Images.Add(image);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"DownloadAndSaveImage Exception: {ex}");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task DeleteAllAsync()
        {
            var itemsToRemove = new List<DownloadedImage>();
            
            foreach (var image in Images)
            {
                var deleteSuccessful = await image.FilePath.DeleteFileAtPathAsync();
                
                if(deleteSuccessful)
                    itemsToRemove.Add(image);
            }

            foreach (var itemToRemove in itemsToRemove)
            {
                Images.Remove(itemToRemove);
            }
        }
    }
}
