using APR___Aplikasi_Perlombaan_Renang.Models;
using APR___Aplikasi_Perlombaan_Renang.MVVM_Dependencies;
using System.Collections.Generic;
using System.Windows.Input;
using System;

namespace APR___Aplikasi_Perlombaan_Renang.ViewModels {
    class KelolaGayaRenang : ViewModelBase, IPage {

        #region Properties

        public string PageName { get { return "Kelola Gaya Renang"; } }
        public List<Gaya> ListGaya { get; set; }
        public Gaya GayaInput { get; set; }
        public ICommand TambahGayaRenang { get; set; }
        public ICommand HapusGayaRenang { get; set; }

        #endregion

        #region Constructor

        public KelolaGayaRenang() {
            GayaDAO gayaDAO = new GayaDAO();
            GayaInput = new Gaya();
            ListGaya = gayaDAO.GetAllGaya();
            TambahGayaRenang = new RelayCommand(TambahGayaRenangMethod);
            HapusGayaRenang = new RelayCommand(HapusGayaRenangMethod);
        }

        #endregion

        #region Command Methods

        private void TambahGayaRenangMethod(object obj) {
            Gaya gayaInput = (Gaya)obj;
            GayaDAO gayaDAO = new GayaDAO();
            gayaDAO.InsertGaya(gayaInput);
            ListGaya = gayaDAO.GetAllGaya();
        }
        
        private void HapusGayaRenangMethod(object obj) {
            Gaya gayaHapus = (Gaya)obj;
            GayaDAO gayaDAO = new GayaDAO();
            gayaDAO.HapusGaya(gayaHapus);
            ListGaya = gayaDAO.GetAllGaya();
        }

        #endregion
    }
}
