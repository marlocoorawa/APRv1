using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows;

namespace APR___Aplikasi_Perlombaan_Renang.Models {
    class GayaDAO {

        private MySqlConnection connection;

        public GayaDAO() {
            connection = new MySqlConnection("server=127.0.0.1;uid=root;database=perlombaan_renang;Convert Zero Datetime=True");
        }

        public List<Gaya> GetAllGaya() {
            List<Gaya> listGaya = new List<Gaya>();

            try {
                string query = "select * from `gaya` order by `nama_gaya` asc";
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) {
                    listGaya.Add(new Gaya() { IdGaya = reader.GetInt32("id_gaya"), NamaGaya = reader.GetString("nama_gaya") });
                }
                reader.Close();
                connection.Close();
            } catch (Exception e) {
                MessageBox.Show("Error Retreiving Data Gaya Renang!\nDetail :" + e.Message);
            }

            return listGaya;
        }

        public void InsertGaya(Gaya gayaInput) {

            try {
                connection.Open();
                string query = string.Format("insert into `gaya`(nama_gaya) values('{0}')", gayaInput.NamaGaya);
                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
                connection.Close();
            } catch (Exception e) {
                MessageBox.Show("Error Inserting Gaya Renang!\nKeterangan :" + e.Message);
            }

        }

        public void HapusGaya(Gaya gayaHapus) {

            try {
                connection.Open();
                string query = string.Format("delete from `gaya` where id_gaya={0}", gayaHapus.IdGaya);
                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
                connection.Close();
            } catch (Exception e) {
                MessageBox.Show("Error Deleting Gaya Renang!\nKeterangan :" + e.Message);
            }

        }
            
    }
}
