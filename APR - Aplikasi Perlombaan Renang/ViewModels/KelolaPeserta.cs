using System;
using APR___Aplikasi_Perlombaan_Renang.MVVM_Dependencies;
using Excel = Microsoft.Office.Interop.Excel;
using System.Collections.Generic;
using APR___Aplikasi_Perlombaan_Renang.Models;

namespace APR___Aplikasi_Perlombaan_Renang.ViewModels {
    class KelolaPeserta : ViewModelBase, IPage{

        #region Properties
        
        public string PageName { get { return "Kelola Peserta"; } }

        #endregion

        List<Acara> test = new List<Acara>();
        List<Acara> test2 = new List<Acara>();

        #region Constructor

        public KelolaPeserta() {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlBook;
            Excel.Sheets xlSheet;

            test.AddRange(test2);

            xlBook = xlApp.Workbooks.Open("Mentah.xlsx");
            xlApp.Visible = true;

        }

        #endregion

        #region Command Methods

        #endregion

    }
}
