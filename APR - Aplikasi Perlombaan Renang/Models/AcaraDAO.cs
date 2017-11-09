using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace APR___Aplikasi_Perlombaan_Renang.Models {
    class AcaraDAO {
        private MySqlConnection connection;

        public AcaraDAO() {
            connection = new MySqlConnection("server=127.0.0.1;uid=root;database=perlombaan_renang;Convert Zero Datetime=True");
        }

        public void SubmitAcara(Perlombaan perlombaanInput) {
            try {
                connection.Open();
                string query = string.Format("delete from `acara` where id_perlombaan = {0}", perlombaanInput.IdPerlombaan);
                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
                int i = 0;
                foreach (Kelompok kelompok in perlombaanInput.ListKelompok) {
                    foreach(Acara acara in kelompok.ListAcara) {
                        query = string.Format("insert into `acara`(id_perlombaan, id_acara, id_gaya, kode_kelompok, jarak, jenis_acara, no_acara) values('{0}', {1}, {2}, '{3}', {4}, {5}, {6})",
                                                     perlombaanInput.IdPerlombaan, i, acara.Gaya.IdGaya, kelompok.KodeKelompok, acara.Jarak, (byte)acara.JenisAcara, i);
                        Console.WriteLine(query);
                        command = new MySqlCommand(query, connection);
                        command.ExecuteNonQuery();
                        i++;
                    }
                }
                connection.Close();
            } catch (Exception e) {
                MessageBox.Show("Error Submitting Acara!\nDetail :" + e.Message);
            }
        }

    }
}
