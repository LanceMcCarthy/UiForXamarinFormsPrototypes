using System.Diagnostics;
using System.IO;
using CustomPrototypes.iOS.DependencyServices;
using CustomPrototypes.NetStandard.DependencyServices;
using Dicom;
using Dicom.Imaging;

[assembly: Xamarin.Forms.Dependency(typeof(CustomDicomService))]
namespace CustomPrototypes.iOS.DependencyServices
{
    public class CustomDicomService : ICustomDicomService
    {
        public Stream GetImageStream(DicomFile file, int frame)
        {
            if (file != null)
            {
                Debug.WriteLine(file.GetType().ToString());

                var name = file.Dataset.Get<string>(DicomTag.PatientName);

                if (name != null)
                    Debug.WriteLine(name);

                var dicomImage = new DicomImage(file.Dataset);

                var image = dicomImage.RenderImage(frame);

                var imageBytes = image.AsUIImage().AsPNG().ToArray();

                var memStream = new MemoryStream(imageBytes);
                memStream.Position = 0;
                return memStream;
            }

            return null;
        }

        public byte[] GetImageBytes(DicomFile file, int frame)
        {
            if (file != null)
            {
                Debug.WriteLine(file.GetType().ToString());

                var name = file.Dataset.Get<string>(DicomTag.PatientName);

                if (name != null)
                    Debug.WriteLine(name);

                var dicomImage = new DicomImage(file.Dataset);

                var image = dicomImage.RenderImage(frame);

                return image.AsUIImage().AsPNG().ToArray();
                
            }

            return null;
        }
    }
}