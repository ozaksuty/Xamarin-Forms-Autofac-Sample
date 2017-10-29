using App1.Helper;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Threading.Tasks;

namespace App1.Services
{
    public class CamService : ICamService
    {
        public bool CameraAvailable()
        {
            if (!CrossMedia.Current.IsCameraAvailable || 
                !CrossMedia.Current.IsTakePhotoSupported)
                return false;
            return true;
        }

        public async Task<byte[]> PickPhotoAsync()
        {
            try
            {
                var init = await CrossMedia.Current.Initialize();
                var file = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions
                {
                    PhotoSize = PhotoSize.Medium,
                    CompressionQuality = 50,
                });
                if (file == null)
                    return null;
                var stream = file.GetStream();
                var image = ImageHelper.ReadFully(stream);
                return image;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool PickPhotoSupported()
        {
            if (!CrossMedia.Current.IsPickPhotoSupported)
                return false;
            return true;
        }

        public async Task<byte[]> TakePhotoAsync()
        {
            try
            {
                var init = await CrossMedia.Current.Initialize();
                var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                {
                    PhotoSize = PhotoSize.Medium,
                    CompressionQuality = 50,
                    Name = Guid.NewGuid().ToString() + ".jpg"
                });
                if (file == null)
                    return null;
                var stream = file.GetStream();
                var image = ImageHelper.ReadFully(stream);
                file.Dispose();
                return image;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}