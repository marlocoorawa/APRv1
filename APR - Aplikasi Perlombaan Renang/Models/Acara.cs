namespace APR___Aplikasi_Perlombaan_Renang.Models {
    class Acara {
        public int IdAcara { get; set; }
        public Gaya Gaya { get; set; }
        public int Jarak { get; set; }
        public JenisAcara JenisAcara { get; set; }
        public byte NoAcara { get; set; }
    }

    enum JenisAcara {
        Putra, Putri, Campur
    }
}
