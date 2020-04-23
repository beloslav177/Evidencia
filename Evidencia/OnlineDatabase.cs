using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net;
using System.Drawing;

namespace Evidencia
{
	public class OnlineDatabase
	{
		private List<DataTableRecords> data_source_records = null;
		private List<DataTableUsers> data_source_users = null;
		private List<DataTableNamespace> data_source_namespace = null;

		/// <summary>
		/// Funkcia, ktorá obsahuje funckiu LoadDataRecords a následne tieto údaje vypíše
		/// </summary>
		/// <param name="ev">Pointer na hlavnu triedu s názvom Evidencia</param>
		public void LoadDataRecords(Evidencia ev)
		{
			try
			{
				LoadDataToListRecords(ev);
				ev.TxtOut.Text = string.Empty;
				//foreach (DataTableRecords du in data_source_records)
				//{
				//	ev.TxtOut.Text += du.ID.ToString() + "\t" + du.meta_sap + "\t" + du.data_name + "\t" + du.place_room_sap + "\t" + du.place_locker + "\t" + du.place_shelve + "\t" + du.inr + Environment.NewLine;

				//}

			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.Message);
			}
		}
		/// <summary>
		/// Pripojenie app k phpmyadmin localhost stránke PHP, v ktorej stiahne celý obsah stránky do stringu, pomocou knižnice
		/// JSONConvert odparsuje TEXT a zapíše ho do listu s názvom DataTableRecords
		/// </summary>
		/// <param name="ev">Pointer na hlavnu triedu s názvom Evidencia</param>
		public void LoadDataToListRecords(Evidencia ev)
		{
			try
			{
				string result;
				string server = "http://127.0.0.1/test/recordsTable.php";
				using (WebClient client = new WebClient())
				{
					result = client.DownloadString(new Uri(server));
				};
				data_source_records = null;
				data_source_records = JsonConvert.DeserializeObject<List<DataTableRecords>>(result);

				ev.localDb.ListRecordToSqlite(data_source_records);
				ev.btnOnline.BackColor = Color.Green;

			}
			catch (Exception ex)
			{

				MessageBox.Show("Server nie je zapnutý");
			}
			
			//ev.localDatabase.ListRecordToSqlite(data_source_records);

			
			//dbz.ViewSqliteToDb(this);
		}
		//*************************************************************************************************


		/// <summary>
		/// Funkcia, ktorá obsahuje funckiu LoadDataUsers a následne tieto údaje vypíše
		/// </summary>
		/// <param name="ev">Pointer na hlavnu triedu s názvom Evidencia</param>
		
		public void LoadDataUsers(Evidencia ev)
		{
			try
			{
				LoadDataToListUsers(ev);
				ev.TxtOut.Text = string.Empty;
				//foreach (DataTableUsers du in data_source_users)
				//{
				//	ev.TxtOut.Text += du.id.ToString() + "\t" + du.nickname + "\t" + du.InitializeKey + "\t" + Environment.NewLine;

				//}

			}
			catch (Exception ex )
			{

				MessageBox.Show("Server nie je zapnutý");

			}
		}
		/// <summary>
		/// Pripojenie app k phpmyadmin localhost stránke PHP, v ktorej stiahne celý obsah stránky do stringu, pomocou knižnice
		/// JSONConvert odparsuje TEXT a zapíše ho do listu s názvom DataTableUsers
		/// </summary>
		/// <param name="ev"></param>
		public void LoadDataToListUsers(Evidencia ev)
		{
			try
			{
				string result;
				string server = "http://127.0.0.1/test/usersTable.php";
				using (WebClient client = new WebClient())
				{
					result = client.DownloadString(new Uri(server));
				};
				data_source_users = null;
				data_source_users = JsonConvert.DeserializeObject<List<DataTableUsers>>(result);

				ev.localDb.ListUsersToSqlite(data_source_users);


				//dbz.ViewSqliteToDb(this);

			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.Message);
			}
		}

		//*************************************************************************************************

		/// <summary>
		/// Funkcia, ktorá obsahuje funckiu LoadDataNamespace a následne tieto údaje vypíše
		/// </summary>
		/// <param name="ev">Pointer na hlavnu triedu s názvom Evidencia</param>

		public void LoadDataNamespace(Evidencia ev)
		{
			try
			{
				LoadDataToListNamespace(ev);
				ev.TxtOut.Text = string.Empty;
				//foreach (DataTableNamespace du in data_source_namespace)
				//{
				//	ev.TxtOut.Text += du.id.ToString() + "\t" + du.original_room + "\t" + du.New + "\t" + Environment.NewLine;

				//}

			}
			catch (Exception ex)
			{

				MessageBox.Show("Server nie je zapnutý");
			}
		}

		/// <summary>
		/// Pripojenie app k phpmyadmin localhost stránke PHP, v ktorej stiahne celý obsah stránky do stringu, pomocou knižnice
		/// JSONConvert odparsuje TEXT a zapíše ho do listu s názvom DataTableNamespace
		/// </summary>
		/// <param name="ev"></param>

		public void LoadDataToListNamespace(Evidencia ev)
		{
			try
			{
				string result;
				string server = "http://127.0.0.1/test/namespaceTable.php";
				using (WebClient client = new WebClient())
				{
					result = client.DownloadString(new Uri(server));
				};
				data_source_namespace = null;
				data_source_namespace = JsonConvert.DeserializeObject<List<DataTableNamespace>>(result);

				ev.localDb.ListNamespaceToSqlite(data_source_namespace);
				
			}
			catch (Exception ex)
			{

				MessageBox.Show("Server nie je zapnutý");
			}
		}
	}

}
