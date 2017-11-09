using APR___Aplikasi_Perlombaan_Renang.Models;
using APR___Aplikasi_Perlombaan_Renang.MVVM_Dependencies;
using System.Collections.Generic;
using System.Windows.Input;
using System;
using System.Windows;

namespace APR___Aplikasi_Perlombaan_Renang.ViewModels {
    class KelolaAcaraPerlombaan : ViewModelBase, IPage{

        #region Properties

        public string PageName { get { return "Kelola Acara Perlombaan"; } }
        public Perlombaan SelectedPerlombaan { get; set; }
        public Kelompok SelectedKelompok { get; set; }
        public List<Gaya> ListGaya { get; set; }
        public ICommand TambahAcara { get; set; }
        public ICommand SubmitAcara { get; set; }
        public ICommand KelolaPerlombaanPageOpen { get; set; }

        //helper
        public List<KeyValuePair<JenisAcara, string>> JenisAcaraHelper { get; set; }

        #endregion

        #region Private Properties

        private Application _ApplicationVM;

        #endregion

        #region Constructor

        public KelolaAcaraPerlombaan(Application applicationVM, Perlombaan selectedPerlombaan) {
            _ApplicationVM = applicationVM;
            SelectedPerlombaan = selectedPerlombaan;
            SelectedKelompok = SelectedPerlombaan.ListKelompok[0];
            GayaDAO gayaDAO = new GayaDAO();
            ListGaya = gayaDAO.GetAllGaya();
            TambahAcara = new RelayCommand(o => TambahAcaraMethod());
            SubmitAcara = new RelayCommand(o => SubmitAcaraMethod());
            KelolaPerlombaanPageOpen = new RelayCommand(o => KelolaPerlombaanPageOpenMethod());

            //helper generate
            JenisAcaraHelper = new List<KeyValuePair<JenisAcara, string>>();
            JenisAcaraHelper.Add(new KeyValuePair<JenisAcara, string>(JenisAcara.Putra, "Putra"));
            JenisAcaraHelper.Add(new KeyValuePair<JenisAcara, string>(JenisAcara.Putri, "Putri"));
            JenisAcaraHelper.Add(new KeyValuePair<JenisAcara, string>(JenisAcara.Campur, "Campuran"));
            //end helper generate
        }

        #endregion

        #region Command Methods

        private void TambahAcaraMethod() {
            SelectedKelompok.ListAcara.Add(new Acara());
        }

        private void SubmitAcaraMethod() {
            AcaraDAO acaraDAO = new AcaraDAO();
            acaraDAO.SubmitAcara(SelectedPerlombaan);
            MessageBox.Show("Acara Berhasil Di Input Ke Database!");
            _ApplicationVM.CurrentPage = new KelolaPerlombaan(_ApplicationVM);
        }

        private void KelolaPerlombaanPageOpenMethod() {
            _ApplicationVM.CurrentPage = new KelolaPerlombaan(_ApplicationVM);
        }

        #endregion

    }
}
