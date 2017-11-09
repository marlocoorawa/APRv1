using APR___Aplikasi_Perlombaan_Renang.MVVM_Dependencies;
using System;
using System.Windows.Input;

namespace APR___Aplikasi_Perlombaan_Renang.ViewModels {
    class Application : ViewModelBase {

        #region Properties

        public IPage CurrentPage { get; set; }
        public ICommand KelolaPerlombaanOpenPage { get; set; }
        public ICommand KelolaPesertaOpenPage { get; set; }
        public ICommand KelolaHasilPerlombaanOpenPage { get; set; }
        public ICommand KelolaGayaRenangOpenPage { get; set; }

        #endregion

        #region Constructor

        public Application() {
            CurrentPage = new KelolaPerlombaan(this);
            KelolaPerlombaanOpenPage = new RelayCommand(o => KelolaPerlombaanOpenPageMethod());
            KelolaPesertaOpenPage = new RelayCommand(o => KelolaPesertaOpenPageMethod());
            KelolaHasilPerlombaanOpenPage = new RelayCommand(o => KelolaHasilPerlombaanOpenPageMethod());
            KelolaGayaRenangOpenPage = new RelayCommand(o => KelolaGayaRenangOpenPageMethod());
        }

        #endregion

        #region Command Methods

        private void KelolaPerlombaanOpenPageMethod() {
            CurrentPage = new KelolaPerlombaan(this);
        }

        private void KelolaPesertaOpenPageMethod() {
            CurrentPage = new KelolaPeserta();
        }

        private void KelolaHasilPerlombaanOpenPageMethod() {
            //throw new NotImplementedException();
        }

        private void KelolaGayaRenangOpenPageMethod() {
            CurrentPage = new KelolaGayaRenang();
        }

        #endregion
    }
}
