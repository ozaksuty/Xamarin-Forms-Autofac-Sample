using App1.Services;
using App1.ViewModels;
using Autofac;
using Xamarin.Forms;

namespace App1
{
    public partial class App : Application
    {
        public static IContainer _container;
        public App()
        {
            InitializeComponent();

            var builder = new ContainerBuilder();

            builder.RegisterType<MainPageViewModel>();

            builder.RegisterType<CamService>().As<ICamService>();
            _container = builder.Build();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
