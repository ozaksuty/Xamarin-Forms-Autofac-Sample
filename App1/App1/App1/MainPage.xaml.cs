using App1.Services;
using App1.ViewModels;
using Autofac;
using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        private MainPageViewModel vm;
        public MainPage()
        {
            InitializeComponent();
            vm = App._container.Resolve<MainPageViewModel>();
            this.BindingContext = vm;

           
        }
    }
}