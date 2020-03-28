using Prism;
using Prism.Ioc;
using CoronaHelp.ViewModels;
using CoronaHelp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CoronaHelp.Views.Navigation;
using CoronaHelp.ViewModels.Navigation;
using CoronaHelp.Views.Dashboard;
using CoronaHelp.ViewModels.Dashboard;
using CoronaHelp.ViewModels.India;
using CoronaHelp.ViewModels.Info;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace CoronaHelp
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("PrismTabbedPage1");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<FAQPage, FAQViewModel>();
            containerRegistry.RegisterForNavigation<HealthCarePage, HealthCareViewModel>();
            containerRegistry.RegisterForNavigation<DocumentsListPage, DocumentsViewModel>();

            containerRegistry.RegisterForNavigation<PrismTabbedPage1, PrismTabbedPage1ViewModel>();
            containerRegistry.RegisterForNavigation<India, IndiaViewModel>();
            containerRegistry.RegisterForNavigation<Info, InfoViewModel>();
        }
    }
}
