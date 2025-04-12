using System.Net.Http;
using Autofac;
using Autofac.Features.ResolveAnything;
using DevExpress.Mvvm.POCO;
using DevExpress.Utils.MVVM;
using DevExpress.Utils.MVVM.Services;
using DevExpressApp.Service;
using DevExpressApp.ViewModel;
using Microsoft.Extensions.DependencyInjection;

namespace DevExpressApp
{
    internal static class Program
    {
        static IContainer container = null;

        [STAThread]
        static void Main()
        {
            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://jsonplaceholder.typicode.com"),
                Timeout = new TimeSpan(0, 0, 10)
            };
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());
            builder.RegisterInstance<IPostService>(new PostService(httpClient));
            builder.RegisterInstance<IUserService>(new UserService(httpClient));
            container = builder.Build();

            MVVMContextCompositionRoot.ViewModelCreate += (s, e) =>
            {
                e.ViewModel = container.Resolve(e.RuntimeViewModelType);
            };

            Application.EnableVisualStyles();
            ApplicationConfiguration.Initialize();
            Application.Run(new MainView());
        }
    }
}