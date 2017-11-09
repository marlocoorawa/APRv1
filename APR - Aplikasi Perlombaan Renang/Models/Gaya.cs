namespace APR___Aplikasi_Perlombaan_Renang.Models {
    class Gaya {
        public int IdGaya { get; set; }
        public string NamaGaya { get; set; }

        public Gaya() { }
        public Gaya(Gaya gaya) {
            IdGaya = gaya.IdGaya;
            NamaGaya = gaya.NamaGaya;
        }


        //By default WPF compares SelectedItem to each item in the ItemsSource by reference, 
        //meaning that unless the SelectedItem points to the same item in memory as the ItemsSource item,
        //it will decide that the item doesn’t exist in the ItemsSource and so no item gets selected.
        public override bool Equals(object obj) {
            if (obj == null || !(obj is Gaya))
                return false;

            return ((Gaya)obj).IdGaya == this.IdGaya;
        }
    }
}
