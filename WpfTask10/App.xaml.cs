using System.Collections.Generic;
using System.Windows;
using WpfTask10.Models;
using WpfTask10.Services;
using WpfTask10.Util;

namespace WpfTask10
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            DependencyInjector injector = DependencyInjector.instance;
            injector.Register<IDataAccessor<List<UserModel>>, XmlDataAccessor>();
            injector.Register<IRepository<UserModel>, UserRepository>();
        }
    }
}
