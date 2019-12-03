using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evidencia
{
	public partial class Evidencia : Form
	{

		public TextBox TxtOut { get { return txtOutput; } }
		public TextBox txtTry { get { return txtTrying; } }
		public TextBox txtIP { get { return txtIpAddress; } }
		public TextBox txtSender { get { return txtSend; } }
		public TextBox txtReceiver { get { return txtReceive; } }
		public ListBox listBox { get { return lstBox; } }
		public ComboBox cmbRoom { get { return cmbBoxRoom; } }
		public ComboBox cmbLocker { get { return cmbBoxLocker; } }
		public ComboBox cmbShelve { get { return cmbBoxShelve; } }
		public Button btnClearDatas { get { return btnClearData; } }
		public Button btnDisconnect { get { return btnDisconnectServer; } }
		public Button btnOnline { get { return btnOnDatabase; } }
		public Button btnScaning { get { return btnScan; } }
		public Button btnServerConnecting { get { return btnServerConnect; } }
		public Button btnStopScanning { get { return btnStopScan; } }
		public BackgroundWorker BackgroundWorker { get { return backGround; } }

		public OnlineDatabase onDb = new OnlineDatabase();
		public LocalDatabase localDb = new LocalDatabase();
		public Selecting selecting = new Selecting();
		public TCP tcp = new TCP();

		public int i;
		public string msg;
		public int numBytesRead;
		public string ReadData;
		public int Count;
		public string responseData;


		public Evidencia()
		{
			InitializeComponent();

			localDb.SqliteUserToList(this);
			localDb.SqliteNamespaceToList(this);
			localDb.SqliteRecordToList(this);

			selecting.SelectDataToCombo(this);
			selecting.cmbBoxEnabled(this);

			btnStopScanning.Enabled = false;
			btnScaning.Enabled = false;
			btnDisconnect.Enabled = false;

			tcp.RemoveChars(this);

		}

		private void btnOnDatabase_Click(object sender, EventArgs e)
		{
			onDb.LoadDataUsers(this);
			onDb.LoadDataNamespace(this);
			onDb.LoadDataRecords(this);
		}

		private void cmbBoxRoom_SelectedIndexChanged(object sender, EventArgs e)
		{
			selecting.showRooms(this);
		}

		private void cmbBoxLocker_SelectedIndexChanged(object sender, EventArgs e)
		{
			selecting.showLockers(this);
		}

		private void cmbBoxShelve_SelectedIndexChanged(object sender, EventArgs e)
		{
			selecting.showShelves(this);
		}

		private void btnShowAllReords_Click(object sender, EventArgs e)
		{
			selecting.ShowAllTableRecords(this);
		}

		private void btnClearData_Click(object sender, EventArgs e)
		{
			cmbLocker.Items.Remove(cmbBoxLocker.Text);
			cmbRoom.Items.Remove(cmbBoxRoom.Text);
			cmbShelve.Items.Remove(cmbBoxShelve.Text);
			listBox.DataSource = null;
			cmbLocker.Enabled = false;
			cmbShelve.Enabled = false;
			txtReceiver.Text = string.Empty;
			txtSender.Text = string.Empty;
			TxtOut.Text = string.Empty;
		}

		private void Update(object sender, DoWorkEventArgs e)
		{
			tcp.Connect(txtIpAddress.Text, 5045);
			if (tcp.tcpClient.Connected && !backGround.CancellationPending)
			{
				try
				{
					byte[] data = new byte[1024];
					using (MemoryStream ms = new MemoryStream())
					{
						Debug.WriteLine("Data sa prijmaju");
						while ((tcp.netStream != null))
						{
							numBytesRead = tcp.netStream.Read(data, 0, data.Length);
							ms.Write(data, 0, numBytesRead);
							Debug.WriteLine("numBytesRead=" + numBytesRead.ToString() + "; msCount=" + ms.ToArray().Count());
							responseData = string.Empty;
							responseData = Encoding.ASCII.GetString(ms.ToArray(), 0, (int)ms.Length);
							ReadData = responseData;

							while (responseData != string.Empty)
							{
								backGround.ReportProgress(0, responseData);
								responseData = responseData.Substring(9, responseData.Length - 14);

								//UpdateChanged(15, responseData);
							}
						}
					}
				}
				catch (Exception)
				{
					tcp.Disconnect();
				}
			}
			//if (backGround.CancellationPending)
			//{
			//    e.Cancel = true;
			//    backGround.ReportProgress(i, "TEst: uz som na");
			//    backGround.ReportProgress(i, msg);
			//    return;
			//}
			//backGround.ReportProgress(100);
		}

		private void UpdateChanged(object sender, ProgressChangedEventArgs e)
		{
			prgBarBack.Value = e.ProgressPercentage;
			msg = (string)e.UserState;


			txtReceiver.Text = responseData;
		}

		private void Completed(object sender, RunWorkerCompletedEventArgs e)
		{
			if (e.Cancelled)
			{
				//lblPrgStatus.Text = "Task Cancelled.";
			}
			else if (e.Error != null)
			{
				//  lblPrgStatus.Text = "Error while performing background operation.";
			}
			else
			{
				//lblPrgStatus.Text = "Odoslajuca sprava: " + txtIn.Text;
			}
			btnServerConnect.Enabled = true;
		}

		private void btnServerConnect_Click(object sender, EventArgs e)
		{
			tcp.serverConnect(this);
		}
		
		private void btnDisconnectServer_Click(object sender, EventArgs e)
		{
			tcp.serverDisconnect(this);
		}

		private void btnScan_Click(object sender, EventArgs e)
		{
			tcp.scanReader(this);
		}


		private void btnStopScan_Click(object sender, EventArgs e)
		{
			tcp.stopScanReader(this);
		}

	}
}
