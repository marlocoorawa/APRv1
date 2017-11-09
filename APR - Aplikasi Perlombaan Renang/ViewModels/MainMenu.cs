using APR___Aplikasi_Perlombaan_Renang.MVVM_Dependencies;
using System.Windows.Input;

namespace APR___Aplikasi_Perlombaan_Renang.ViewModels {
    class MainMenu : ViewModelBase, IPage {


        #region Properties

        public string PageName { get { return "Main Menu"; } }
        public ICommand KelolaPerlombaanButton { get; set; }

        #endregion

        #region Private Properties

        private Application _ApplicationVM;

        #endregion

        #region Constructor

        public MainMenu(Application applicationVM) {
            _ApplicationVM = applicationVM;
            KelolaPerlombaanButton = new RelayCommand(o => KelolaPerlombaanMethod());
        }

        #endregion

        #region Command Methods

        private void KelolaPerlombaanMethod() {
            _ApplicationVM.CurrentPage = new KelolaPerlombaan(_ApplicationVM);
        }

        #endregion
    }
}
