using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Evidencia
{
	public partial class Evidencia : Form
	{
		public TextBox TxtOut { get { return txtOutput; } }
		public TextBox txtTry { get { return txtTrying; } }
		public TextBox txtIP { get { return txtIpAddress; } }
		public TextBox txtInr { get { return txtINR; } }
		public TextBox txtSender { get { return txtSend; } }
		public TextBox txtReceiver { get { return txtReceive; } }		
		public ListBox listBox { get { return lstBox; } }
		public ListBox lstBoxSpravne { get { return listBoxNaskenovane; } }
		public ListBox lstBoxOcakavane { get { return listBoxNenaskenovane; } }
		public ListBox lstBoxNespravne { get { return listBoxNepotrebne; } }
		public ListBox listINR { get { return lstINR; } }
		public ComboBox cmbRoom { get { return cmbBoxRoom; } }
		public ComboBox cmbLocker { get { return cmbBoxLocker; } }
		public ComboBox cmbShelve { get { return cmbBoxShelve; } }
		public Button btnClearDatas { get { return btnClearData; } }
		public Button btnDisconnect { get { return btnDisconnectServer; } }
		public Button btnOnline { get { return btnOnDatabase; } }
		public Button btnScaning { get { return btnScan; } }
		public Button btnServerConnecting { get { return btnServerConnect; } }
		public Button btnOverenie { get { return btnHodnotenie; } }
		public Button btnStopScanning { get { return btnStopScan; } }
		public Button btnColored { get { return btnColor; } }
		public Button btnESPstringSend { get { return btnEspSend; } }
		public BackgroundWorker BackgroundWorker { get { return backGround; } }
		public Label lblProductInformation { get { return lblProductInfo; } }

		public OnlineDatabase onDb = new OnlineDatabase();
		public LocalDatabase localDb = new LocalDatabase();
		public Selecting selecting = new Selecting();
		public TCP tcp = new TCP();

		public int i;
		public string msg;
		public int numBytesRead;
		public string ReadData;
		public int Count;
		public string SAP;


		public Evidencia()
		{
			InitializeComponent();

			localDb.SqliteUserToList(this);
			localDb.SqliteNamespaceToList(this);
			localDb.SqliteRecordToList(this);

			selecting.InitializeSelecting(this);			

			btnStopScanning.Enabled = false;
			btnScaning.Enabled = false;
			btnDisconnect.Enabled = false;
			btnColored.BackColor = Color.Red;


			//selecting.FillScan(this);
			//tcp.RemoveChars(this);

		}

		private void btnOnDatabase_Click(object sender, EventArgs e)
		{
			try
			{
				onDb.LoadDataUsers(this);
				onDb.LoadDataNamespace(this);
				onDb.LoadDataRecords(this);

			}
			catch (Exception)
			{

				MessageBox.Show("WampServer nieje spustený.");
			}
		}

		private void cmbBoxRoom_SelectedIndexChanged(object sender, EventArgs e)
		{
			selecting.listboxDataRoom(this);
		}

		private void cmbBoxLocker_SelectedIndexChanged(object sender, EventArgs e)
		{
			selecting.listboxDataLocker(this);
		}

		private void cmbBoxShelve_SelectedIndexChanged(object sender, EventArgs e)
		{
			selecting.listboxDataShelve(this);
		}

		private void btnClearData_Click(object sender, EventArgs e)
		{
			//cmbRoom.Items.Remove(cmbBoxRoom.Text);
			//cmbLocker.Items.Remove(cmbBoxLocker.Text);
			//cmbShelve.Items.Remove(cmbBoxShelve.Text);

			cmbRoom.SelectedIndex = 11;
			cmbLocker.ResetText();
			cmbShelve.ResetText();

			localDb.SqliteUserToList(this);
			localDb.SqliteNamespaceToList(this);
			localDb.SqliteRecordToList(this);

			selecting.FlushESPstring();
			selecting.SendEspRemove(this);
			
			//selecting.FlushLists();

			cmbShelve.Enabled = false;
			listBox.DataSource = null;
			txtReceiver.Text = string.Empty;
			txtSender.Text = string.Empty;
			TxtOut.Text = string.Empty;
			txtInr.Text = string.Empty;
			lstBoxNespravne.Items.Clear();
			lstBoxSpravne.Items.Clear();
			lstBoxOcakavane.Items.Clear();
			selecting.ScannedBarcodes(this);
		}

		private void Update(object sender, DoWorkEventArgs e)
		{
			tcp.Connect(txtIpAddress.Text, 5045, this);
			if (tcp.tcpClient.Connected && !backGround.CancellationPending)
			{
				try
				{
					byte[] data = new byte[1024];
					using (MemoryStream ms = new MemoryStream())
					{
						Debug.WriteLine("Data sa prijmaju");
						btnColored.BackColor = Color.Green;
						while ((tcp.netStream != null))
						{
							ms.SetLength(0);
							numBytesRead = tcp.netStream.Read(data, 0, data.Length);
							ms.Write(data, 0, numBytesRead);
							Debug.WriteLine("numBytesRead=" + numBytesRead.ToString() + "; msCount=" + ms.ToArray().Count());
							string responseData = "";
							responseData = Encoding.ASCII.GetString(ms.ToArray(), 0, (int)ms.Length);

							if (responseData != string.Empty)
							{
								SAP=responseData.Substring(8, responseData.Length - 14);

								this.Invoke(new Action(() =>
								{									
									txtTry.Text = SAP;
									selecting.FillScannedList(this);
									selecting.ScannedBarcodesAfterScan(this);
									selecting.ControlSapNumber(this);
								}));
								Debug.WriteLine("responseData=" + responseData.ToString() + "; SAP=" + SAP.ToString() );
							}
							responseData = string.Empty;	
						}
					}
				}
				catch (Exception ex)
				{
					tcp.Disconnect(this);
				}
			}
		}

		private void UpdateChanged(object sender, ProgressChangedEventArgs e)
		{
			//prgBarBack.Value = e.ProgressPercentage;
			string sap_nr = (string)e.UserState;
			//txtTrying.Text = string.Empty;

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

		private void btnEspSend_Click_1(object sender, EventArgs e)
		{
			selecting.SendEspString(this);
		}

		private void prgBarBack_Click(object sender, EventArgs e)
		{		
		}

		private void btnHodnotenie_Click(object sender, EventArgs e)
		{
			//selecting.ExportListToCSVviaButton();
			selecting.addRecordViaButton(this, "Scanned.txt");
		}

		private void listBoxNenaskenovane_SelectedIndexChanged(object sender, EventArgs e)
		{
			//lblProductInformation.Text = lstBoxOcakavane.SelectedItem.ToString();
			selecting.productInformationWaiting(this);
		}

		private void listBoxNaskenovane_SelectedIndexChanged(object sender, EventArgs e)
		{
			//lblProductInformation.Text = lstBoxSpravne.SelectedItem.ToString();
			selecting.productInformationCorrect(this);

		}

		private void listBoxNepotrebne_SelectedIndexChanged(object sender, EventArgs e)
		{
			//lblProductInformation.Text = lstBoxNespravne.SelectedItem.ToString();
			selecting.productInformationUnCorrect(this);

		}
	}
}
