using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace APR___Aplikasi_Perlombaan_Renang.Models {
    class PerlombaanDAO {

        private MySqlConnection connection;

        public PerlombaanDAO() {
            connection = new MySqlConnection("server=127.0.0.1;uid=root;database=perlombaan_renang;Convert Zero Datetime=True");
        }

        /// <summary>
        /// Mengambil semua lomba dan kelompoknya dari database, probably acaranya juga later
        /// </summary>
        public List<Perlombaan> GetAllLomba() {

            List<Perlombaan> listPerlombaan = new List<Perlombaan>();

            try {
                string query = "select * from `perlombaan`";
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) {
                    listPerlombaan.Add(new Perlombaan() { IdPerlombaan = reader.GetString("id_perlombaan"), NamaPerlombaan = reader.GetString("nama_perlombaan"), TanggalPerlombaan = reader.GetDateTime("tanggal_perlombaan") });
                }
                reader.Close();
                connection.Close();
            } catch (Exception e) {
                MessageBox.Show("Error Retreiving Data Perlombaan!\nDetail :" + e.Message);
            }

            foreach (Perlombaan perlombaan in listPerlombaan) {
                perlombaan.ListKelompok = GetKelompok(perlombaan);
            }

            return listPerlombaan;

        }

        public void InsertLomba(Perlombaan perlombaanInput) {
            
            try {
                connection.Open();

                string query = "SELECT count(tanggal_perlombaan) AS jumlah FROM `perlombaan` WHERE tanggal_perlombaan = '" + perlombaanInput.TanggalPerlombaan.ToString("yyyy-MM-dd") + "'";
                MySqlCommand command = new MySqlCommand(query, connection);

                //making key for lomba
                string kodePerlombaan = perlombaanInput.TanggalPerlombaan.ToString("ddMMyyyy");
                Int64 keyLastPieceInt = (Int64)command.ExecuteScalar() + 1;
                string keyLastPiece = keyLastPieceInt.ToString("D2");
                kodePerlombaan = kodePerlombaan + keyLastPiece;
                //end making key


                query = string.Format("insert into `perlombaan`(id_perlombaan, nama_perlombaan, tanggal_perlombaan) values('{0}','{1}','{2}')",kodePerlombaan,perlombaanInput.NamaPerlombaan,perlombaanInput.TanggalPerlombaan.ToString("yyyy-MM-dd"));
                command.CommandText = query;
                command.ExecuteNonQuery();

                if (perlombaanInput.ListKelompok.Count > 0) {
                    foreach (Kelompok kelompok in perlombaanInput.ListKelompok) {
                        query = string.Format("insert into `kelompok`(id_perlombaan, kode_kelompok, nama_kelompok) values('{0}','{1}','{2}')", kodePerlombaan, kelompok.KodeKelompok, kelompok.NamaKelompok);
                        command.CommandText = query;
                        command.ExecuteNonQuery();
                    }
                }

                connection.Close();

            } catch (Exception e) {
                MessageBox.Show("Error Inserting Perlombaan!\nKeterangan :" + e.Message);
            }

        }

        public void UpdatePerlombaan(Perlombaan perlombaanEdit) {

            try {
                connection.Open();
                string query = string.Format("update `perlombaan` set nama_perlombaan='{0}', tanggal_perlombaan='{1}' where id_perlombaan = '{2}'", perlombaanEdit.NamaPerlombaan, perlombaanEdit.TanggalPerlombaan.ToString("yyyy-MM-dd"), perlombaanEdit.IdPerlombaan);
                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
                connection.Close();
            } catch (Exception e) {
                MessageBox.Show("Error Inserting Perlombaan!\nKeterangan :" + e.Message);
            }

        }

        public void HapusPerlombaan(Perlombaan perlombaanHapus) {

            try {
                connection.Open();
                string query = string.Format("delete from `perlombaan` where id_perlombaan = '{0}'", perlombaanHapus.IdPerlombaan);
                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
                connection.Close();
            } catch (Exception e) {
                MessageBox.Show("Error Inserting Perlombaan!\nKeterangan :" + e.Message);
            }

        }

        public ObservableCollection<Kelompok> GetKelompok(Perlombaan perlombaan) {

            ObservableCollection<Kelompok> listKelompok = new ObservableCollection<Kelompok>();

            try {
                connection.Open();
                string query = string.Format("select * from `kelompok` where id_perlombaan = '{0}'", perlombaan.IdPerlombaan);
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) {
                    listKelompok.Add(new Kelompok() { KodeKelompok = reader.GetString("kode_kelompok"), NamaKelompok = reader.GetString("nama_kelompok") });
                }
                connection.Close();
            } catch (Exception e) {
                MessageBox.Show("Error Retreiving Data Kelompok!\nDetail :" + e.Message);
            }

            foreach(Kelompok kelompok in listKelompok) {
                kelompok.ListAcara = GetAcara(perlombaan.IdPerlombaan, kelompok);
            }

            return listKelompok;

        }

        public ObservableCollection<Acara> GetAcara(string idPerlombaan, Kelompok kelompok) {

            GayaDAO gayaDAO = new GayaDAO();
            List<Gaya> listGaya = gayaDAO.GetAllGaya();

            ObservableCollection<Acara> listAcara = new ObservableCollection<Acara>();

            try {
                connection.Open();
                string query = string.Format("select * from `acara` where id_perlombaan = '{0}' and kode_kelompok = '{1}'", idPerlombaan, kelompok.KodeKelompok);
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) {
                    listAcara.Add(new Acara() {
                        IdAcara = reader.GetInt32("id_acara"),
                        Jarak = reader.GetInt32("jarak"),
                        JenisAcara = (JenisAcara)reader.GetByte("jenis_acara"),
                        NoAcara = reader.GetByte("no_acara"),
                        Gaya = new Gaya(listGaya.Find(item => item.IdGaya == reader.GetInt32("id_gaya")))
                    });
                }
                kelompok.ListAcara = listAcara;
                reader.Close();
                connection.Close();
            } catch (Exception e) {
                MessageBox.Show("Error Retreiving Acara!\nDetail :" + e.Message);
            }

            return listAcara;
        }

    }
}
