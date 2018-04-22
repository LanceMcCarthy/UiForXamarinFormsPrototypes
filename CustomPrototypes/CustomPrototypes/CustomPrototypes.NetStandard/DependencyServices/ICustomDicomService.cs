using System.IO;
using Dicom;

namespace CustomPrototypes.NetStandard.DependencyServices
{
    public interface ICustomDicomService
    {
        Stream GetImageStream(DicomFile file, int frame);
        byte[] GetImageBytes(DicomFile file, int frame);
    }
}
