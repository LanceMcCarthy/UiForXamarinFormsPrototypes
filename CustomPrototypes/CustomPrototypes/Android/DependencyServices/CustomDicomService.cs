using System.IO;
using Android.Graphics;
using CustomPrototypes.Android.DependencyServices;
using CustomPrototypes.NetStandard.DependencyServices;
using Dicom;
using Dicom.Imaging;

[assembly: Xamarin.Forms.Dependency(typeof(CustomDicomService))]
namespace CustomPrototypes.Android.DependencyServices
{
    public class CustomDicomService : ICustomDicomService
    {
        public Stream GetImageStream(DicomFile file, int frame = 0)
        {
            if (file != null)
            {
                System.Diagnostics.Debug.WriteLine(file.GetType().ToString());

                var name = file.Dataset.Get<string>(DicomTag.PatientName);

                if (name != null)
                    System.Diagnostics.Debug.WriteLine(name);

                var dicomImage = new DicomImage(file.Dataset);
                var image = dicomImage.RenderImage(frame);
                var bitmap = image.AsBitmap();

                var stream = new MemoryStream();
                bitmap.Compress(Bitmap.CompressFormat.Png, 0, stream);

                stream.Position = 0;
                return stream;
            }

            return null;
        }

        public byte[] GetImageBytes(DicomFile file, int frame)
        {
            if (file != null)
            {
                System.Diagnostics.Debug.WriteLine(file.GetType().ToString());

                var name = file.Dataset.Get<string>(DicomTag.PatientName);

                if (name != null)
                    System.Diagnostics.Debug.WriteLine(name);

                var dicomImage = new DicomImage(file.Dataset);
                var image = dicomImage.RenderImage(frame);
                var bitmap = image.AsBitmap();
                
                var stream = new MemoryStream();
                bitmap.Compress(Bitmap.CompressFormat.Png, 0, stream);

                stream.Position = 0;
                return stream.ToArray();
            }

            return null;
        }
    }
}