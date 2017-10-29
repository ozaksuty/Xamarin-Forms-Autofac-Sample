using App1.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace App1.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private byte[] _file1;
        public byte[] File1
        {
            get
            {
                return _file1;
            }
            set
            {
                _file1 = value;
                OnPropertyChanged();
            }
        }
        private readonly ICamService camService;

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(propertyName));
        }

        public MainPageViewModel(ICamService _camService)
        {
            camService = _camService;
        }

        public ICommand AddPictureCommand => new Command(async () =>
        await AddNewPicture());

        public async Task AddNewPicture()
        {
            byte[] file = null;

            //if (camService.PickPhotoSupported())
            //    file = await camService.PickPhotoAsync();

            if (camService.CameraAvailable())
                file = await camService.TakePhotoAsync();

            if (file == null)
                return;
            File1 = file;
        }
    }
}