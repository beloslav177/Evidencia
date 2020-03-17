using System;
using System.Collections.Generic;
using System.Diagnostics;
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
		private List<Record> SelectSAP = new List<Record>();
		private List<Record> SelectINR = new List<Record>();
		private List<Record> AllRoom = new List<Record>();
		private List<Record> AllLocker = new List<Record>();
		private List<Record> AllShelve = new List<Record>();

		public string INRtxtBox;
		public string SAPstring;
		public int INRcount;
		public int INRpocetNoRead;
		public string barcodeReaded;
		public int barcodeReadedCount;
		public string INRnoReadedString;
		private string INRreadedString;
		public string INRnoReadedCount;
		public string INRreadedCount;
		public int barcodeCount;
		public string RoomLockerShelve;
		private string miestnostiAll = "Všetky položky";
		private string skrineAll = "Všetky položky";
		private string polickyAll = "Všetky položky";
		public string EspString = "";
		private string INRControl;
		private int INRpocetRead;
		private string INRremoveNoRead;

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

				List<string> skrine = ev.localDb.zaznamyRecord.Select(x => x.place_locker).Distinct().ToList();
				skrine.Sort();
				ev.cmbLocker.Items.Add(skrineAll);
				ev.cmbLocker.Items.AddRange(skrine.ToArray());

				List<string> policky = ev.localDb.zaznamyRecord.Select(x => x.place_shelve).Distinct().ToList();
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
					List<string> INR = SelectRoom.Select(x => x.inr).Distinct().ToList();

					ev.cmbLocker.Enabled = true;

					if ((SelectRoom?.Count ?? 0) == 0)
					{
						RoomLockerShelve = "";
						ev.listBox.DataSource = null; 
						MessageBox.Show("Daná požiadavka sa nenachádza v tabuľke.");
						ev.cmbLocker.Enabled = false;
						ev.cmbShelve.Enabled = false;
						ev.listBox.DataSource = SelectRoom;
					}

					INRnoReadedString = "";
					INRnoReadedString = ">";
					INRpocetNoRead = INR.Count();
					INRnoReadedCount = "<" + INRpocetNoRead.ToString();
					foreach (var model in INR)
					{
						INRnoReadedString += model + "\\r";
					}

					RoomLockerShelve = "M" + ev.cmbRoom.Text;
					ev.txtSender.Text = RoomLockerShelve.ToString();
					ev.listINR.DataSource = INR;
					ev.TxtOut.Text = RoomLockerShelve.ToString() + INRnoReadedCount.ToString() + INRnoReadedString.ToString();

				}
				else
				{
					SelectRoom = ev.localDb.zaznamyRecord;
					List<string> INR = SelectRoom.Select(x => x.inr).Distinct().ToList();

					INRnoReadedString = "";
					INRnoReadedString = ">";
					INRpocetNoRead = INR.Count();
					INRnoReadedCount = "<" + INRpocetNoRead.ToString();
					foreach (var model in INR)
					{
						INRnoReadedString += model + "\\r";
					}

					ev.listINR.DataSource = INR;
					ev.TxtOut.Text = RoomLockerShelve.ToString() + INRnoReadedCount.ToString() + INRnoReadedString.ToString();
					RoomLockerShelve = "M" + ev.cmbRoom.Text;
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

					List<string> INR = SelectLocker.Select(x => x.inr).Distinct().ToList();

					INRnoReadedString = "";
					INRnoReadedString = ">";
					INRpocetNoRead = INR.Count();
					INRnoReadedCount = "<" + INRpocetNoRead.ToString();
					foreach (var model in INR)
					{
						INRnoReadedString += model + "\\r";
					}

					ev.listINR.DataSource = INR;

					if ((SelectLocker?.Count ?? 0) == 0)
					{
						ev.listBox.DataSource = SelectRoom;
						RoomLockerShelve = "";
						RoomLockerShelve = "M" + ev.cmbRoom.Text;
						ev.listBox.DataSource = null;
						MessageBox.Show("Daná požiadavka sa nenachádza v tabuľke.");
						ev.cmbShelve.Enabled = false;
					}
					RoomLockerShelve = "M" + ev.cmbRoom.Text + ":" + ev.cmbLocker.Text;
					ev.txtSender.Text = RoomLockerShelve.ToString();
					ev.TxtOut.Text = RoomLockerShelve.ToString() + INRnoReadedCount.ToString() + INRnoReadedString.ToString();

				}
				else
				{
					ev.listBox.DataSource = ev.localDb.zaznamyRecord.Where(x =>
					x.place_room_sap == ev.cmbRoom.Text).ToList();

					List<string> INR = SelectLocker.Select(x => x.inr).Distinct().ToList();

					INRnoReadedString = "";
					INRnoReadedString = ">";
					INRpocetNoRead = INR.Count();
					INRnoReadedCount = "<" + INRpocetNoRead.ToString();
					foreach (var model in INR)
					{
						INRnoReadedString += model + "\\r";
					}

					ev.listINR.DataSource = INR;
					ev.TxtOut.Text = RoomLockerShelve.ToString() + INRnoReadedCount.ToString() + INRnoReadedString.ToString();

				}
				ev.listBox.DataSource = SelectLocker;

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
						ev.listBox.DataSource = SelectLocker;
						RoomLockerShelve = "";
						RoomLockerShelve = "M" + ev.cmbRoom.Text + ":" + ev.cmbLocker.Text;
						ev.listBox.DataSource = null;
						MessageBox.Show("Daná požiadavka sa nenachádza v tabuľke.");
						INRnoReadedString = "";
					}

					MakeESPstringShelve(ev);
					ev.btnESPstringSend.Enabled = true;
				}
				else
				{
					SelectShelve = ev.localDb.zaznamyRecord.Where(x =>
						(x.place_locker == ev.cmbLocker.Text)).ToList();

					List<string> INR = SelectShelve.Select(x => x.inr).Distinct().ToList();
					List<string> SAP = ev.localDb.zaznamyRecord.Select(x => x.meta_sap).Distinct().ToList();

					INRnoReadedString = "";
					INRnoReadedString = ">";
					INRpocetNoRead = INR.Count();
					INRnoReadedCount = "<" + INRpocetNoRead.ToString();
					foreach (var model in INR)
					{
						INRnoReadedString += model + "\\r";
						INRtxtBox += model;
					}
					INRreadedString = "";
					INRreadedString = "(";
					ev.listINR.DataSource = INR;
					ev.txtReceiver.Text = INRpocetNoRead.ToString();
					ev.TxtOut.Text = RoomLockerShelve.ToString() + INRreadedString + INRnoReadedCount.ToString() + INRnoReadedString.ToString();
					ev.txtInr.Text = INRtxtBox;
					ev.txtInr.SelectionStart = ev.txtInr.TextLength;
					ev.txtInr.ScrollToCaret();
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

		public void SendEspString(Evidencia ev)
		{
			INRreadedString = "(";
			EspString = RoomLockerShelve + INRreadedString + INRreadedCount + INRnoReadedCount + INRnoReadedString;
			ev.tcp.SendMsg(EspString);
		}

		public void SendEspRemove(Evidencia ev)
		{
			EspString = "";
			ev.tcp.SendMsg(EspString);
		}
		public void ControlSapNumber(Evidencia ev)
		{
			if (SAPstring.Contains(ev.SAP))
			{
				string SAPControl;
				string SAPlist;
				string INRremove;
				INRremove = INRnoReadedString;
				SAPlist = SAPstring;
				
				SelectSAP = ev.localDb.zaznamyRecord.Where(x => x.meta_sap == ev.SAP).ToList();
				SelectINR = SelectShelve.Where(x => x.meta_sap != ev.SAP).ToList();
				int INRselectINRcount = SelectINR.Count();
				List<string> INRselector = SelectSAP.Select(x => x.inr).Distinct().ToList();
				foreach (var model in INRselector)
				{
					INRControl = model + "\\r";
				}

				Debug.WriteLine("SelectSAP=" + SelectSAP.ToString() + "; SAP=" + ev.SAP.ToString());
				ev.listBox.DataSource = SelectINR;

				int SAPindexOf = SAPlist.IndexOf(ev.SAP);
				int SAPlength = ev.SAP.Length;
				int SAPStringLength = SAPlist.Length;
				Debug.WriteLine("SAPlist IndexOff=" + SAPindexOf.ToString() + "; SAP Length=" + SAPlength.ToString() + ";  SAPStringLength=" + SAPStringLength.ToString());

				SAPControl = SAPlist.Remove(SAPindexOf, SAPlength);
				SAPStringLength = SAPControl.Length;
				Debug.WriteLine("SAPControl =" + SAPControl.ToString() + "SAPCONTROL LENgth =" + SAPStringLength.ToString());

				int INRindexOf = INRremove.IndexOf(INRControl);
				int INRlength = INRControl.Length;
				int INRStringLength = INRremove.Length;
				Debug.WriteLine("INRstring= " + INRremove + "INRtxtBox IndexOf=" + INRindexOf.ToString() + "; INRlength =" + INRlength.ToString() + ";  INRStringLength=" + INRStringLength.ToString());

				INRremoveNoRead = INRremove.Remove(INRindexOf, INRlength + 2);
				INRStringLength = INRremove.Length;
				Debug.WriteLine("INRControl =" + INRControl.ToString() + "INRStringLength =" + INRStringLength.ToString());
				Debug.WriteLine("INRstring= " + INRremoveNoRead + "INRtxtBox IndexOf=" + INRindexOf.ToString() + "; INRlength =" + INRlength.ToString() + ";  INRStringLength=" + INRStringLength.ToString());
				
				if (SAPlist.Contains(ev.SAP))
				{
					List<string> INR = SelectShelve.Select(x => x.inr).Distinct().ToList();

					RoomLockerShelve = "M" + ev.cmbRoom.Text + ":" + ev.cmbLocker.Text + ":" + ev.cmbShelve.Text;
					INRpocetNoRead--;
					INRnoReadedCount = "<" + INRpocetNoRead.ToString();
					INRreadedString += INRControl;
					INRpocetRead++;
					barcodeReaded += ev.SAP;
					barcodeReadedCount += ev.SAP.Count();
					barcodeCount = barcodeReadedCount / 8;
					INRreadedCount = ")" + INRpocetRead + " [" + barcodeCount + "]";
					ev.txtSender.Text = RoomLockerShelve;
					ev.txtReceiver.Text = INRpocetNoRead.ToString();
					Debug.WriteLine("EspString= " + EspString.ToString());
					ev.listINR.DataSource = INR;
					ev.txtInr.Text = SAPControl;

					EspString = RoomLockerShelve + INRreadedString + INRreadedCount + INRnoReadedCount + INRremoveNoRead;
					ev.TxtOut.Text = RoomLockerShelve.ToString() + INRreadedString + INRreadedCount + INRnoReadedCount.ToString() + INRnoReadedString.ToString();
					ev.tcp.SendMsg(EspString);
					Debug.WriteLine("SAPControl= " + SAPControl.ToString());
					Debug.WriteLine("INRremoveNoRead= " + INRremoveNoRead.ToString());
				}

				if (!SAPlist.Contains(ev.SAP))
				{
					List<string> INR = SelectShelve.Select(x => x.inr).Distinct().ToList();

					RoomLockerShelve = "M" + ev.cmbRoom.Text + ":" + ev.cmbLocker.Text + ":" + ev.cmbShelve.Text;
					INRnoReadedCount = "<" + INRpocetNoRead.ToString();
					barcodeReaded += ev.SAP;
					barcodeReadedCount += ev.SAP.Count();
					barcodeCount = barcodeReadedCount / 8;
					INRreadedCount = ")" + INRpocetRead + " [" + barcodeCount + "]";
					ev.txtSender.Text = RoomLockerShelve;
					ev.txtReceiver.Text = INRpocetNoRead.ToString();
					ev.listINR.DataSource = INR;
					ev.txtInr.Text = SAPControl;

					EspString = RoomLockerShelve + INRreadedString + INRreadedCount + INRnoReadedCount + INRremoveNoRead;
					ev.TxtOut.Text = RoomLockerShelve.ToString() + INRreadedString + INRreadedCount + INRnoReadedCount.ToString() + INRnoReadedString.ToString();
					Debug.WriteLine("EspString= " + EspString.ToString());
					ev.tcp.SendMsg(EspString);
					Debug.WriteLine("SAPlist= " + SAPlist.ToString());
					Debug.WriteLine("INRremoveNoRead= " + INRremoveNoRead.ToString());
				}
			}

			if (!SAPstring.Contains(ev.SAP))
			{
				string SAPControl;
				string SAPlist;
				string INRremove;
				INRremove = INRnoReadedString;
				SAPlist = SAPstring;
				SelectSAP = ev.localDb.zaznamyRecord.Where(x => x.meta_sap == ev.SAP).ToList();
				SelectINR = SelectShelve.Where(x => x.meta_sap != ev.SAP).ToList();
				int INRselectINRcount = SelectINR.Count();
				List<string> INRselector = SelectSAP.Select(x => x.inr).Distinct().ToList();
				foreach (var model in INRselector)
				{
					INRControl = model + "\\r";
				}

				Debug.WriteLine("SelectSAP=" + SelectSAP.ToString() + "; SAP=" + ev.SAP.ToString());
				ev.listBox.DataSource = SelectINR;								
				List<string> INR = SelectShelve.Select(x => x.inr).Distinct().ToList();

				RoomLockerShelve = "M" + ev.cmbRoom.Text + ":" + ev.cmbLocker.Text + ":" + ev.cmbShelve.Text;
				INRnoReadedCount = "<" + INRpocetNoRead.ToString();
				INRnoReadedString = "";
				INRnoReadedString = ">";
				foreach (var model in INR)
				{
					INRnoReadedString += model + "\\r";
					INRtxtBox += model;
				}
				barcodeReaded += ev.SAP;
				barcodeReadedCount += ev.SAP.Count();
				barcodeCount = barcodeReadedCount / 8;
				INRreadedCount = ")" + INRpocetRead + " [" + barcodeCount + "]";
				ev.txtSender.Text = RoomLockerShelve;
				ev.txtReceiver.Text = INRpocetNoRead.ToString();
				ev.listINR.DataSource = INR;
				EspString = RoomLockerShelve + INRreadedString + INRreadedCount + INRnoReadedCount + INRremoveNoRead;
				ev.TxtOut.Text = RoomLockerShelve.ToString() + INRreadedString + INRreadedCount + INRnoReadedCount.ToString() + INRnoReadedString.ToString();
				Debug.WriteLine("EspString= " + EspString.ToString());
				ev.tcp.SendMsg(EspString);
				Debug.WriteLine("SAPlist= " + SAPlist.ToString());
				Debug.WriteLine("INRremoveNoRead= " + INRremoveNoRead.ToString());
			}
		}

		public void MakeESPstringShelve(Evidencia ev)
		{
			List<string> INR = SelectShelve.Select(x => x.inr).Distinct().ToList();
			List<string> SAP = SelectShelve.Select(x => x.meta_sap).Distinct().ToList();

			SAPstring = "";
			INRnoReadedString = "";
			INRnoReadedString = ">";
			INRpocetNoRead = INR.Count();
			INRnoReadedCount = "<" + INRpocetNoRead.ToString();
			INRreadedString = "";
			INRreadedString = "(";
			int INRpocetRead = 0;
			INRreadedCount = ")" + INRpocetRead + " [" + barcodeCount + "]";
			barcodeCount = 0;

			foreach (var model in INR)
			{
				INRnoReadedString += model + "\\r";
				INRtxtBox += model;
			}
			foreach (var model in SAP)
			{
				SAPstring += model;
			}

			RoomLockerShelve = "M" + ev.cmbRoom.Text + ":" + ev.cmbLocker.Text + ":" + ev.cmbShelve.Text;
			ev.txtSender.Text = RoomLockerShelve.ToString();
			ev.txtReceiver.Text = INRpocetNoRead.ToString();
			ev.listINR.DataSource = INR;
			ev.txtReceiver.Text = INRpocetNoRead.ToString();
			ev.TxtOut.Text = RoomLockerShelve + INRreadedString + INRreadedCount + INRnoReadedCount + INRnoReadedString;
			ev.listINR.DataSource = INR;
			ev.txtInr.Text = SAPstring;
		}

		public void FlushESPstring()
		{
			RoomLockerShelve = "";
			INRreadedString = "";
			INRreadedCount = "";
			INRnoReadedCount = "";
			INRremoveNoRead = "";
			barcodeCount = 0;
		}
	}
}
