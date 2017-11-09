using APR___Aplikasi_Perlombaan_Renang.Models;
using APR___Aplikasi_Perlombaan_Renang.MVVM_Dependencies;
using System.Windows;
using System.Windows.Input;

namespace APR___Aplikasi_Perlombaan_Renang.ViewModels {
    class EditPerlombaan : ViewModelBase, IPage{

        #region Properties

        public string PageName { get { return "Edit Perlombaan"; } }
        public Perlombaan PerlombaanEdit { get; set; }
        public ICommand SubmitEditPerlombaan { get; set; }
        public ICommand HapusPerlombaan { get; set; }
        public ICommand Cancel { get; set; }

        #endregion

        #region Private Properties

        private Application _ApplicationVM;

        #endregion

        #region Constructor

        public EditPerlombaan(Application applicationVM, Perlombaan perlombaanEdit ) {
            _ApplicationVM = applicationVM;
            PerlombaanEdit = perlombaanEdit;
            PerlombaanDAO perlombaanDAO = new PerlombaanDAO();
            PerlombaanEdit.ListKelompok = perlombaanDAO.GetKelompok(PerlombaanEdit);
            SubmitEditPerlombaan = new RelayCommand(SubmitEditPerlombaanMethod);
            HapusPerlombaan = new RelayCommand(HapusPerlombaanMethod);
            Cancel = new RelayCommand(o => CancelMethod());
        }

        #endregion

        #region Command Method

        private void SubmitEditPerlombaanMethod(object obj) {
            Perlombaan perlombaanEdit = (Perlombaan)obj;
            PerlombaanDAO perlombaanDAO = new PerlombaanDAO();
            perlombaanDAO.UpdatePerlombaan(perlombaanEdit);
            _ApplicationVM.CurrentPage = new KelolaPerlombaan(_ApplicationVM);
        }
        
        private void HapusPerlombaanMethod(object obj) {

            if (MessageBox.Show("Apakah Anda Yakin Ingin Menghapus Data Perlombaan Ini?", "PERINGATAN!", MessageBoxButton.YesNo) == MessageBoxResult.Yes) {
                Perlombaan perlombaanHapus = (Perlombaan)obj;
                PerlombaanDAO perlombaanDAO = new PerlombaanDAO();
                perlombaanDAO.HapusPerlombaan(perlombaanHapus);
                _ApplicationVM.CurrentPage = new KelolaPerlombaan(_ApplicationVM);
            }
            
        }

        private void CancelMethod() {
            _ApplicationVM.CurrentPage = new KelolaPerlombaan(_ApplicationVM);
        }

        #endregion

    }
}
