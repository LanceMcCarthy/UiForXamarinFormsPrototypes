using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Xaml.Media.Imaging;
using CustomPrototypes.NetStandard.DependencyServices;
using CustomPrototypes.UWP.DependencyServices;
using Dicom;
using Dicom.Imaging;

[assembly: Xamarin.Forms.Dependency(typeof(CustomDicomService))]
namespace CustomPrototypes.UWP.DependencyServices
{
    public class CustomDicomService : ICustomDicomService
    {
        public Stream GetImageStream(DicomFile file, int frame = 0)
        {
            if (file != null)
            {
                Debug.WriteLine(file.GetType().ToString());

                var name = file.Dataset.Get<string>(DicomTag.PatientName);

                if (name != null)
                    Debug.WriteLine(name);

                var dicomImage = new DicomImage(file.Dataset);

                var image = dicomImage.RenderImage(frame);



                return image.AsWriteableBitmap().PixelBuffer.AsStream();
            }

            return null;
        }

        public byte[] GetImageBytes(DicomFile file, int frame = 0)
        {
            if (file != null)
            {
                Debug.WriteLine(file.GetType().ToString());

                var name = file.Dataset.Get<string>(DicomTag.PatientName);

                if (name != null)
                    Debug.WriteLine(name);

                var dicomImage = new DicomImage(file.Dataset);

                var image = dicomImage.RenderImage(frame);
                
                return image.AsWriteableBitmap().PixelBuffer.ToArray();
            }

            return null;
        }
    }
}
