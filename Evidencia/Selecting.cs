using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evidencia
{
	public class Selecting
	{
		//TODO:  oksušať reťazec znakov v barcode,  nanovo vytvoriť nový projekt s inými názvami, selecting v comboboxe vytvoriť aj možnosť vybrať všetky, 
		private List<Record> SelectRoom = new List<Record>();
		private List<Record> SelectLocker = new List<Record>();
		private List<Record> SelectShelve = new List<Record>();
		private List<Record> AllRoom = new List<Record>();
		private List<Record> AllLocker = new List<Record>();
		private List<Record> AllShelve = new List<Record>();
		private string miestnostiAll = "Všetky položky";
		private string skrineAll = "Všetky položky";
		private string polickyAll = "Všetky položky";
		public void SelectDataToCombo(Evidencia ev)
		{
			try
			{

				Dictionary<string, string> miestnostiDic = new Dictionary<string, string>();
				foreach (var item in ev.localDb.zaznamyNamespace)
				{
					miestnostiDic.Add(item.New, item.original_room);
				}
				List<string> miestnosti = ev.localDb.zaznamyNamespace.Select(x => x.New).ToList();
				miestnosti.Sort();
				ev.cmbRoom.Items.AddRange(miestnosti.ToArray());
				ev.cmbRoom.Items.Add(miestnostiAll);

				List<string> skrine = ev.localDb.zaznamyRecord.Select(x => x.place_locker).Distinct().ToList();
				skrine.Sort();
				ev.cmbLocker.Items.AddRange(skrine.ToArray());
				ev.cmbLocker.Items.Add(skrineAll);

				List<string> policky = ev.localDb .zaznamyRecord.Select(x => x.place_shelve).Distinct().ToList();
				policky.Sort();
				ev.cmbShelve.Items.AddRange(policky.ToArray());
				ev.cmbShelve.Items.Add(polickyAll);

				if (ev.cmbRoom.SelectedIndex < 1)
				{
					ev.cmbLocker.Enabled = false;
					ev.cmbShelve.Enabled = false;
				}
				else
				{
					ev.cmbLocker.Enabled = true;
					ev.cmbShelve.Enabled = true;
				}

			}
			catch (Exception exc)
			{
				MessageBox.Show(exc.Message);
			}
		}
		public void showRooms(Evidencia ev)
		{
			try
			{
				string roomSap = ev.localDb.zaznamyNamespace.Find(x => x.New == ev.cmbRoom.Text).original_room;
				
				SelectRoom = ev.localDb.zaznamyRecord.Where(x =>
					(x.place_room_sap == roomSap)).ToList();
				AllRoom = ev.localDb.zaznamyRecord;


				if ((SelectRoom?.Count ?? 0) == 0)
				{
					ev.listBox.DataSource = null;
					MessageBox.Show("Daná požiadavka sa nenachádza v tabuľke.");
				}
				if (ev.cmbRoom.Text == miestnostiAll)
				{

					foreach (var item in AllRoom)
					{
						ev.listBox.DataSource = AllRoom;
					}
				}
				else
				{
					foreach (var item in SelectRoom)
					{
						ev.listBox.DataSource = SelectRoom;
					}
					ev.cmbLocker.Enabled = true;
				}

			}
			catch (Exception exc)
			{

				MessageBox.Show(exc.Message);
			}

		}
		public void showLockers(Evidencia ev)
		{
			try
			{
				SelectLocker = SelectRoom.Where(x =>
						(x.place_locker == ev.cmbLocker.Text)).ToList();
				if ((SelectLocker?.Count ?? 0) == 0)
				{
					MessageBox.Show("Daná požiadavka sa nenachádza v tabuľke.");
				}
				if (ev.cmbLocker.Text == skrineAll)
				{

					foreach (var item in AllLocker)
					{
						ev.listBox.DataSource = AllLocker;
					}
				}
				else
				{
					foreach (var item in SelectLocker)
					{
						ev.listBox.DataSource = SelectLocker;
					}
					ev.cmbShelve.Enabled = true;
				}


			}
			catch (Exception exc)
			{

				MessageBox.Show(exc.Message);
			}
		}
		public void showShelves(Evidencia ev)
		{
			try
			{
				SelectShelve = SelectLocker.Where(x =>
						(x.place_shelve == ev.cmbShelve.Text)).ToList();
				if ((SelectShelve?.Count ?? 0) == 0)
				{
					MessageBox.Show("Daná požiadavka sa nenachádza v tabuľke.");
				}
				if (ev.cmbShelve.Text == polickyAll)
				{
					ev.listBox.DataSource = AllShelve;
				}
				else
				{
					foreach (var item in SelectShelve)
					{
						ev.listBox.DataSource = SelectShelve;
					}

				}

			}
			catch (Exception exc)
			{

				MessageBox.Show(exc.Message);
			}
		}

		public void cmbBoxEnabled(Evidencia ev)
		{
			if (ev.cmbRoom.SelectedIndex < 1)
			{
				ev.cmbLocker.Enabled = false;
				ev.cmbShelve.Enabled = false;
			}
			else
			{
				ev.cmbLocker.Enabled = true;
				ev.cmbShelve.Enabled = true;
			}
		}

	}
}
