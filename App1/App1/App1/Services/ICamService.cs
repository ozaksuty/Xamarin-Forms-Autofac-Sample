using System.Threading.Tasks;

namespace App1.Services
{
    public interface ICamService
    {
        bool CameraAvailable();
        bool PickPhotoSupported();
        Task<byte[]> TakePhotoAsync();
        Task<byte[]> PickPhotoAsync();
    }
}