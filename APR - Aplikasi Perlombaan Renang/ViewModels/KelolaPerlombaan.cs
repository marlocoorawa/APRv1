using APR___Aplikasi_Perlombaan_Renang.Models;
using APR___Aplikasi_Perlombaan_Renang.MVVM_Dependencies;
using System.Collections.Generic;
using System.Windows.Input;
using System;

namespace APR___Aplikasi_Perlombaan_Renang.ViewModels {
    class KelolaPerlombaan : ViewModelBase, IPage {

        #region Properties

        public string PageName { get { return "Kelola Perlombaan"; } }
        public List<Perlombaan> ListPerlombaan { get; set; }
        public Perlombaan SelectedPerlombaan { get; set; }
        public ICommand BuatPerlombaanPageOpen { get; set; }
        public ICommand EditPerlombaanPageOpen { get; set; }
        public ICommand KelolaAcaraPageOpen { get; set; }

        #endregion

        #region Private Properties

        private Application _ApplicationVM;

        #endregion

        #region Constructor

        public KelolaPerlombaan(Application applicationVM) {
            _ApplicationVM = applicationVM;
            PerlombaanDAO lombaDAO = new PerlombaanDAO();
            BuatPerlombaanPageOpen = new RelayCommand(o => BuatPerlombaanPageOpenMethod());
            EditPerlombaanPageOpen = new RelayCommand(EditPerlombaanPageOpenMethod);
            KelolaAcaraPageOpen = new RelayCommand(KelolaAcaraPageOpenMethod);
            ListPerlombaan = lombaDAO.GetAllLomba();
        }

        #endregion

        #region Command Methods

        private void BuatPerlombaanPageOpenMethod() {
            _ApplicationVM.CurrentPage = new BuatPerlombaan(_ApplicationVM);
        }
        
        private void EditPerlombaanPageOpenMethod(object obj) {
            Perlombaan perlombaanEdit = (Perlombaan)obj;
            _ApplicationVM.CurrentPage = new EditPerlombaan(_ApplicationVM, perlombaanEdit);
        }

        private void KelolaAcaraPageOpenMethod(object obj) {
            Perlombaan selectedPerlombaan = (Perlombaan)obj;
            _ApplicationVM.CurrentPage = new KelolaAcaraPerlombaan(_ApplicationVM, selectedPerlombaan);
        }


        #endregion
    }
}
