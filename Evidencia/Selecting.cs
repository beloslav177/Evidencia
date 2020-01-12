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
		//TODO: vybrať všetky v combobox pre SelectLocker, ak vyberiem room a po stlačení tlačidla vymazať daná vybraná položka v room sa nezobrazi v combobox zznova

		private List<Record> SelectRoom = new List<Record>();
		private List<Record> SelectLocker = new List<Record>();
		private List<Record> SelectShelve = new List<Record>();
		private List<Record> AllRoom = new List<Record>();
		private List<Record> AllLocker = new List<Record>();
		private List<Record> AllShelve = new List<Record>();
		private string miestnostiAll = "Všetky položky";
		private string skrineAll = "Všetky položky";
		private string polickyAll = "Všetky položky";

		public void loadDataToComboBoxes(Evidencia ev)
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
				ev.cmbRoom.Items.Add(miestnostiAll);
				ev.cmbRoom.Items.AddRange(miestnosti.ToArray());

				List<string> skrine = ev.localDb.zaznamyRecord.Select(x => x.place_locker).Distinct().ToList() ;
				skrine.Sort();
				ev.cmbLocker.Items.Add(skrineAll);
				ev.cmbLocker.Items.AddRange(skrine.ToArray());

				List<string> policky = ev.localDb .zaznamyRecord.Select(x => x.place_shelve).Distinct().ToList();
				policky.Sort();
				ev.cmbShelve.Items.Add(polickyAll);
				ev.cmbShelve.Items.AddRange(policky.ToArray());

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

		public void listboxDataRoom(Evidencia ev)
		{
			try
			{
				ev.cmbLocker.Enabled = false;
				ev.cmbShelve.Enabled = false;
				string roomSap;

				if (ev.cmbRoom.Text != miestnostiAll)
				{
					roomSap = ev.localDb.zaznamyNamespace.Find(x => x.New == ev.cmbRoom.Text).original_room;
					SelectRoom = ev.localDb.zaznamyRecord.Where(x =>
						(x.place_room_sap == roomSap)).ToList();
						ev.cmbLocker.Enabled = true;

					if ((SelectRoom?.Count ?? 0) == 0)
					{
						ev.listBox.DataSource = null;						
						MessageBox.Show("Daná požiadavka sa nenachádza v tabuľke.");
						ev.cmbLocker.Enabled = false;
						ev.cmbShelve.Enabled = false;
					}
				}
				else
				{
					SelectRoom = ev.localDb.zaznamyRecord;
				}
				ev.listBox.DataSource = SelectRoom;

			}
			catch (Exception exc)
			{

				MessageBox.Show(exc.Message);
			}

		}
		public void listboxDataLocker(Evidencia ev)
		{
			try
			{
				ev.cmbShelve.Enabled = false;
				if (ev.cmbLocker.Text != skrineAll)
				{
					SelectLocker = SelectRoom.Where(x =>
						(x.place_locker == ev.cmbLocker.Text)).ToList();
					ev.cmbShelve.Enabled = true;

					if ((SelectLocker?.Count ?? 0) == 0)
					{
						ev.listBox.DataSource = null;
						MessageBox.Show("Daná požiadavka sa nenachádza v tabuľke.");
						ev.cmbShelve.Enabled = false;
					}
					ev.listBox.DataSource = SelectLocker;
				}
				else
				{
					ev.listBox.DataSource = ev.localDb.zaznamyRecord.Where(x =>
					x.place_room_sap == ev.cmbRoom.Text).ToList();
				}
					
			}
			catch (Exception exc)
			{

				MessageBox.Show(exc.Message);
			}
		}
		public void listboxDataShelve(Evidencia ev)
		{
			try
			{
				if (ev.cmbShelve.Text != polickyAll)
				{
					SelectShelve = SelectLocker.Where(x =>
						(x.place_shelve == ev.cmbShelve.Text)).ToList();
					if ((SelectShelve?.Count ?? 0) == 0)
					{
						ev.listBox.DataSource = null;
						MessageBox.Show("Daná požiadavka sa nenachádza v tabuľke.");
					}
				}
				else
				{
					SelectShelve = ev.localDb.zaznamyRecord.Where(x =>
						(x.place_locker == ev.cmbLocker.Text)).ToList();
				}
				ev.listBox.DataSource = SelectShelve;

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
