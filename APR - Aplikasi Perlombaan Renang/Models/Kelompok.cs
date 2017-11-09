using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace APR___Aplikasi_Perlombaan_Renang.Models {
    class Kelompok {

        public string KodeKelompok { get; set; }
        public string NamaKelompok { get; set; }
        public ObservableCollection<Acara> ListAcara { get; set; }

        public Kelompok() {
            ListAcara = new ObservableCollection<Acara>();
        }

    }
}
