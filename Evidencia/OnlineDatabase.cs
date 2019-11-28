using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;
using Newtonsoft.Json;
using System.Net;

namespace Evidencia
{
	public class OnlineDatabase
	{
		private List<DataTableRecords> data_source_records = null;
		private List<DataTableUsers> data_source_users = null;
		private List<DataTableNamespace> data_source_namespace = null;
		

		public void ShowServerRecords(Evidencia ev)
		{
			try
			{
				MySqlToListRecords(ev);
				ev.TxtOut.Text = string.Empty;
				foreach (DataTableRecords du in data_source_records)
				{
					ev.TxtOut.Text += du.ID.ToString() + "\t" + du.meta_sap + "\t" + du.data_name + "\t" + du.place_room_sap + "\t" + du.place_locker + "\t" + du.place_shelve + Environment.NewLine;

				}

			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.Message);
			}
		}
		public void MySqlToListRecords(Evidencia ev)
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

			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.Message);
			}
			
			//ev.localDatabase.ListRecordToSqlite(data_source_records);

			
			//dbz.ViewSqliteToDb(this);
		}
		//*************************************************************************************************

		public void ShowServerUsers(Evidencia ev)
		{
			try
			{
				MySqlToListUsers(ev);
				ev.TxtOut.Text = string.Empty;
				foreach (DataTableUsers du in data_source_users)
				{
					ev.TxtOut.Text += du.id.ToString() + "\t" + du.nickname + "\t" + du.InitializeKey + "\t" + Environment.NewLine;

				}

			}
			catch (Exception ex )
			{

				MessageBox.Show(ex.Message);
			}
		}
		public void MySqlToListUsers(Evidencia ev)
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

		
		public void ShowServerNamespace(Evidencia ev)
		{
			try
			{
				MySqlToListNamespace(ev);
				ev.TxtOut.Text = string.Empty;
				foreach (DataTableNamespace du in data_source_namespace)
				{
					ev.TxtOut.Text += du.id.ToString() + "\t" + du.original_room + "\t" + du.New + "\t" + Environment.NewLine;

				}

			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.Message);
			}
		}
		public void MySqlToListNamespace(Evidencia ev)
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

				MessageBox.Show(ex.Message);
			}
		}
	}

}
