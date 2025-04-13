using System.Net.Http;
using Autofac;
using Autofac.Features.ResolveAnything;
using DevExpress.Mvvm.POCO;
using DevExpress.Utils.MVVM;
using DevExpress.Utils.MVVM.Services;
using DevExpressApp.Service;
using DevExpressApp.ViewModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DevExpressApp
{
    internal static class Program
    {
        static IContainer container;

        [STAThread]
        static void Main()
        {
            // Create a configuration builder to read appsettings.json
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());

            builder.Register<IConfiguration>(c =>
            {
                return new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
            }).SingleInstance();

            builder.Register(c =>
            {
                var config = c.Resolve<IConfiguration>();
                var baseUrl = config["ServerSettings:BaseUrl"] ?? "http://127.0.0.1:8080";
                return new HttpClient()
                {

                    BaseAddress = new Uri(baseUrl),
                    Timeout = new TimeSpan(0, 0, 10)
                };
            }).As<HttpClient>().SingleInstance();

            builder.Register<IPostService>(c =>
            {
                var client = c.Resolve<HttpClient>();
                return new PostService(client);
            }).SingleInstance();

            builder.Register<IUserService>(c =>
            {
                var client = c.Resolve<HttpClient>();
                return new UserService(client);
            });

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