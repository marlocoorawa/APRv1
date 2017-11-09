using System.Windows;

namespace APR___Aplikasi_Perlombaan_Renang {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {
        protected override void OnStartup(StartupEventArgs e) {
            base.OnStartup(e);
            MainWindow app = new MainWindow();
            app.DataContext = new ViewModels.Application();
            app.Show();
        }
    }
}
