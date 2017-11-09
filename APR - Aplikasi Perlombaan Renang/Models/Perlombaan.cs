using System;
using System.Collections.ObjectModel;

namespace APR___Aplikasi_Perlombaan_Renang.Models {
    class Perlombaan {
        public string IdPerlombaan { get; set; }
        public string NamaPerlombaan { get; set; }
        public DateTime TanggalPerlombaan { get; set; }
        public ObservableCollection<Kelompok> ListKelompok { get; set; }

        public Perlombaan() {
            ListKelompok = new ObservableCollection<Kelompok>();
        }
    }
}
