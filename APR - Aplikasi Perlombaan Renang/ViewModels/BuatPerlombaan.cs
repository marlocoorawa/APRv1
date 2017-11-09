using APR___Aplikasi_Perlombaan_Renang.Models;
using APR___Aplikasi_Perlombaan_Renang.MVVM_Dependencies;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace APR___Aplikasi_Perlombaan_Renang.ViewModels {
    class BuatPerlombaan : ViewModelBase, IPage{

        #region Properties

        public string PageName { get { return "Buat Perlombaan"; } }
        public Perlombaan PerlombaanInput { get; set; }
        public ICommand SubmitBuatPerlombaan { get; set; }
        public ICommand Cancel { get; set; }
        public ICommand TambahKelompok { get; set; }

        #endregion

        #region Private Properties

        private Application _ApplicationVM;

        #endregion

        #region Constructor

        public BuatPerlombaan(Application applicationVM) {
            _ApplicationVM = applicationVM;
            SubmitBuatPerlombaan = new RelayCommand(SubmitBuatPerlombaanMethod);
            Cancel = new RelayCommand(o => CancelMethod());
            TambahKelompok = new RelayCommand(o => TambahKelompokMethod());
            PerlombaanInput = new Perlombaan() { TanggalPerlombaan = DateTime.Today };
            PerlombaanInput.ListKelompok = new ObservableCollection<Kelompok>();
        }

        #endregion

        #region Command Methods

        private void SubmitBuatPerlombaanMethod(object obj) {
            Perlombaan perlombaanInput = (Perlombaan)obj;
            PerlombaanDAO perlombaanDAO = new PerlombaanDAO();
            perlombaanDAO.InsertLomba(perlombaanInput);
            _ApplicationVM.CurrentPage = new KelolaPerlombaan(_ApplicationVM);
        }
        
        private void CancelMethod() {
            _ApplicationVM.CurrentPage = new KelolaPerlombaan(_ApplicationVM);
        }

        private void TambahKelompokMethod() {
            PerlombaanInput.ListKelompok.Add(new Kelompok() { KodeKelompok = "Kode Kelompok", NamaKelompok = "Nama Kelompok" });
        }

        #endregion

    }
}
