using System.ComponentModel;

namespace APR___Aplikasi_Perlombaan_Renang.MVVM_Dependencies {
    class ViewModelBase : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
    }
}
