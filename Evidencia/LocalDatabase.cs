using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evidencia
{
	public class LocalDatabase
	{
		private string dbFile = Application.StartupPath + @"\majetok.db";

		private SQLiteConnection con;
		private SQLiteCommand cmd;
		private SQLiteDataReader reader;

		public List<Record> zaznamyRecord;
		public List<User> zaznamyUser;
		public List<Namespace> zaznamyNamespace;

		public int ListRecordToSqlite(List<DataTableRecords> udaje)
		{
			string truncateTable = "DELETE FROM kteem_record";
			//MessageBox.Show(dbFile);
			
			try
			{
				con = new SQLiteConnection("Data Source=" + dbFile);
				con.Open();
				cmd = con.CreateCommand();
				cmd.CommandText = truncateTable;
				cmd.ExecuteNonQuery();
				
				string insertCmd = "INSERT INTO kteem_record (id, meta_prev, meta_book, meta_page, meta_kategoria, meta_kategoria_number, meta_sap, " +
					"main_kategoria, main_number, main_year_tuke, main_year_kteem, main_year_record, private, id_owner, id_owner_temp, " +
					"data_name, data_sort1, data_sort2, data_production_code, data_price_sk, data_price_eu, data_repair, data_discard, data_rfid, " +
					"place_room_sap, place_room, place_locker, place_shelve, borrowed, borrowed_date, dummy1, dummy2, dummy3, dummy4) VALUES";


				//string insertCmd = "INSERT INTO kteem_record (id, meta_prev, meta_book, meta_page, meta_kategoria, meta_kategoria_number, meta_sap," +
				//	" main_kategoria, main_number, main_year_tuke, main_year_kteem, main_year_record, private, id_owner, id_owner_temp, data_name, " +
				//	"data_sort1, data_sort2, data_production_code, data_price_sk, data_price_eu, place_room_sap, place_locker, place_shelve) VALUES";
				foreach (DataTableRecords udaj in udaje)
				{

					if (insertCmd != "INSERT INTO kteem_record (id, meta_prev, meta_book, meta_page, meta_kategoria, meta_kategoria_number, meta_sap, " +
					"main_kategoria, main_number, main_year_tuke, main_year_kteem, main_year_record, private, id_owner, id_owner_temp, " +
					"data_name, data_sort1, data_sort2, data_production_code, data_price_sk, data_price_eu, data_repair, data_discard, data_rfid, " +
					"place_room_sap, place_room, place_locker, place_shelve, borrowed, borrowed_date, dummy1, dummy2, dummy3, dummy4) VALUES") insertCmd += " ";

					insertCmd += "(" + udaj.ID + "," + "'" + udaj.meta_prev + "'" + "," + udaj.meta_book + "," + udaj.meta_page + "," + "'" + udaj.meta_kategoria + "'" + "," +
						udaj.meta_kategoria_number + "," + udaj.meta_sap + "," + "'" + udaj.main_kategoria + "'" + "," + udaj.main_number + "," + udaj.main_year_tuke + "," + udaj.main_year_kteem + "," +
						udaj.main_year_record + "," + "'" + udaj.Private + "'" + "," + "'" + udaj.id_owner + "'" + "," + udaj.id_owner_temp + "," + "'" + udaj.data_name + "'" + "," +
						"'" + udaj.data_sort1 + "'" + "," + "'" + udaj.data_sort2 + "'" + "," + "'" + udaj.data_production_code + "'" + "," + udaj.data_price_sk + "," +
						udaj.data_price_eu + "," + "'" + udaj.data_repair + "'" + "," + "'" + udaj.data_discard + "'" + "," + "'" + udaj.data_rfid + "'" + "," +
						"'" + udaj.place_room_sap + "'" + "," + "'" + udaj.place_room + "'" + "," + "'" + udaj.place_locker + "'" + "," + udaj.place_shelve + "," + udaj.borrowed + "," + "'" + udaj.borrowed_date + "'" + "," +
						"'" + udaj.dummy1 + "'" + "," + "'" + udaj.dummy2 + "'" + "," + "'" + udaj.dummy3 + "'" + "," + "'" + udaj.dummy4 + "'" + ")" + ",";


					//if (insertCmd != "INSERT INTO kteem_record(id, meta_prev, meta_book, meta_page, meta_kategoria, meta_kategoria_number, meta_sap, main_kategoria," +
					//	" main_number, main_year_tuke, main_year_kteem, main_year_record, private, id_owner, id_owner_temp, data_name, data_sort1, data_sort2," +
					//	" data_production_code, data_price_sk, data_price_eu, place_room_sap, place_locker, place_shelve) VALUES") insertCmd += " ";
					//insertCmd += "(" + udaj.ID + "," + "'" + udaj.meta_prev + "'" + "," + udaj.meta_book + "," + udaj.meta_page + ","+ "'" + udaj.meta_kategoria + "'" +
					//	"," + udaj.meta_kategoria_number + "," + udaj.meta_sap + "," + "'" + udaj.main_kategoria + "'" + "," + udaj.main_number  +  "," + udaj.main_year_tuke + 
					//	"," + udaj.main_year_kteem + "," + udaj.main_year_record + "," + "'" + udaj.Private + "'" + "," + "'" + udaj.id_owner + "'" + "," + udaj.id_owner_temp + 
					//	"," + "'" + udaj.data_name + "'" + "," + "'" + udaj.data_sort1 + "'" + "," + "'" + udaj.data_sort2 + "'" + "," + "'" + udaj.data_production_code + "'" + ","  + udaj.data_price_sk  + udaj.data_price_eu  +  ","  +  "," + "'" + udaj.place_room_sap + "'" + "," + "'" + udaj.place_locker + "'" + "," + udaj.place_shelve + ")" + ",";

				}
				insertCmd = insertCmd.TrimEnd(',');
				cmd.CommandText = insertCmd;
				cmd.ExecuteNonQuery();
				con.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				Debug.WriteLine(ex.Message);
				Debug.WriteLine(ex.StackTrace);
			}
			return 0;

		}
		public void SqliteRecordToList(Evidencia ev)
		{
			zaznamyRecord = new List<Record>();
			string selectSqliteTable = "SELECT id, meta_prev, meta_book, meta_page, meta_kategoria, meta_kategoria_number, meta_sap, " +
				"main_kategoria, main_number, main_year_tuke, main_year_kteem, main_year_record, private, id_owner, id_owner_temp, " +
				"data_name, data_sort1, data_sort2, data_production_code, data_price_sk, data_price_eu, data_repair, data_discard, data_rfid, " +
				"place_room_sap, place_room, place_locker, place_shelve, borrowed, borrowed_date, dummy1, dummy2, dummy3, dummy4 FROM kteem_record";
			try
			{
				con = new SQLiteConnection("Data Source=" + dbFile);
				con.Open();
				cmd = con.CreateCommand();
				cmd.CommandText = selectSqliteTable;
				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					zaznamyRecord.Add(new Record()
					{
						id = reader[0].ToString(),
						meta_prev = reader[1].ToString(),
						meta_book = reader[2].ToString(),
						meta_page = reader[3].ToString(),
						meta_kategoria = reader[4].ToString(),
						meta_kategoria_number = reader[5].ToString(),
						meta_sap = reader[6].ToString(),
						main_kategoria = reader[7].ToString(),
						main_number = reader[8].ToString(),
						main_year_tuke = reader[9].ToString(),
						main_year_kteem = reader[10].ToString(),
						main_year_record = reader[11].ToString(),
						Private = reader[12].ToString(),
						id_owner = reader[13].ToString(),
						id_owner_temp = reader[14].ToString(),
						data_name = reader[15].ToString(),
						data_sort1 = reader[16].ToString(),
						data_sort2 = reader[17].ToString(),
						data_production_code = reader[18].ToString(),
						data_price_sk = reader[19].ToString(),
						data_price_eu = reader[20].ToString(),
						data_repair = reader[21].ToString(),
						data_discard = reader[22].ToString(),
						data_rfid = reader[23].ToString(),
						place_room_sap = reader[24].ToString(),
						place_room = reader[25].ToString(),
						place_locker = reader[26].ToString(),
						place_shelve = reader[27].ToString(),
						borrowed = reader[28].ToString(),
						borrowed_date = reader[29].ToString(),
						dummy1 = reader[30].ToString(),
						dummy2 = reader[31].ToString(),
						dummy3 = reader[32].ToString(),
						dummy4 = reader[33].ToString()
					});
				}
				reader.Close();
				cmd.ExecuteNonQuery();
				
				foreach (var zaznam in zaznamyRecord)
				{
					
					//ev.listBox.DataSource = zaznamyRecord;
				}

				con.Close();
			}
			catch (Exception exc)
			{
				MessageBox.Show(exc.Message);
			}
		}

		public int ListUsersToSqlite(List<DataTableUsers> udaje)
		{
			string truncateTable = "DELETE FROM kteem_users";
			try
			{
				con = new SQLiteConnection("Data Source=" + dbFile);
				con.Open();
				cmd = con.CreateCommand();
				cmd.CommandText = truncateTable;
				cmd.ExecuteNonQuery();
				string insertCmd = "INSERT INTO kteem_users (id, nickname, access, Name, Surname, InitializeKey) VALUES";

				foreach (DataTableUsers udaj in udaje)
				{

					if (insertCmd != "INSERT INTO kteem_users (id, nickname, access, Name, Surname, InitializeKey) VALUES") insertCmd += " ";

					insertCmd += "(" + udaj.id + "," + "'" + udaj.nickname + "'" + "," + udaj.access + "," + "'" + udaj.Name + "'" + "," + "'" + udaj.Surname + "'" + "," + "'" + udaj.InitializeKey + "'" + ")" + ",";

				}
				insertCmd = insertCmd.TrimEnd(',');
				cmd.CommandText = insertCmd;
				cmd.ExecuteNonQuery();
				con.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				Debug.WriteLine(ex.Message);
				Debug.WriteLine(ex.StackTrace);
			}
			return 0;

		}
		public void SqliteUserToList(Evidencia ev)
		{
			zaznamyUser = new List<User>();
			string selectSqliteTable = "SELECT * FROM kteem_users";
			try
			{
				con = new SQLiteConnection("Data Source=" + dbFile);
				con.Open();
				cmd = con.CreateCommand();
				cmd.CommandText = selectSqliteTable;
				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					zaznamyUser.Add(new User()
					{
						id = reader[0].ToString(),
						nickname = reader[1].ToString(),
						access = reader[2].ToString(),
						Name = reader[3].ToString(),
						Surname = reader[4].ToString(),
						InitializeKey = reader[5].ToString()
					});
				}
				reader.Close();
				cmd.ExecuteNonQuery();
				
				foreach (var zaznam in zaznamyUser)
				{
					//ev.listBox.DataSource = zaznamyUser;
					
				}

				con.Close();
			}
			catch (Exception exc)
			{
				MessageBox.Show(exc.Message);
			}
		}

		public int ListNamespaceToSqlite(List<DataTableNamespace> udaje)
		{
			string truncateTable = "DELETE FROM kteem_namespace";
			try
			{
				con = new SQLiteConnection("Data Source=" + dbFile);
				con.Open();
				cmd = con.CreateCommand();
				cmd.CommandText = truncateTable;
				cmd.ExecuteNonQuery();
				string insertCmd = "INSERT INTO kteem_namespace (id, original_room, original_locker, original_shelve, new) VALUES";

				foreach (DataTableNamespace udaj in udaje)
				{

					if (insertCmd != "INSERT INTO kteem_namespace (id, original_room, original_locker, original_shelve, new) VALUES") insertCmd += " ";

					insertCmd += "(" + udaj.id + "," + "'" + udaj.original_room + "'" + "," + "'" + udaj.original_locker + "'" + "," + "'" + udaj.original_shelve + "'" + "," + "'" + udaj.New + "'" + ")" + ",";

				}
				insertCmd = insertCmd.TrimEnd(',');
				cmd.CommandText = insertCmd;
				cmd.ExecuteNonQuery();
				con.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				Debug.WriteLine(ex.Message);
				Debug.WriteLine(ex.StackTrace);
			}
			return 0;

		}
		public void SqliteNamespaceToList(Evidencia ev)
		{
			zaznamyNamespace = new List<Namespace>();
			string selectSqliteTable = "SELECT id, original_room, original_locker, original_shelve, new FROM kteem_namespace";
			try
			{
				con = new SQLiteConnection("Data Source=" + dbFile);
				con.Open();
				cmd = con.CreateCommand();
				cmd.CommandText = selectSqliteTable;
				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					zaznamyNamespace.Add(new Namespace()
					{
						id = reader[0].ToString(),
						original_room = reader[1].ToString(),
						original_locker = reader[2].ToString(),
						original_shelve = reader[3].ToString(),
						New = reader[4].ToString()
					});
				}
				reader.Close();
				cmd.ExecuteNonQuery();
				
				foreach (var zaznam in zaznamyNamespace)
				{
					//ev.listBox.DataSource = zaznamyNamespace;
				}

				con.Close();
			}
			catch (Exception exc)
			{
				MessageBox.Show(exc.Message);
			}
		}

	}
}
