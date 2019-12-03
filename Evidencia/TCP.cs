using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evidencia
{
	public class TCP
	{
		public int Hodnota = 0;
		public NetworkStream netStream;
		public TcpClient tcpClient;
		private int numBytesRead;
		private string Scan = "B";
		private string StopScan = "C";
		private string ContinueScan = "E";
		private string RepeatEnable = "F";
		private string RepeatDisable = "G";
		private char ScanChar = 'B';
		private char StopChar = 'C';
		private char ContinueScanChar = 'E';
		private char RepeatEnableChar = 'F';
		private char RepeatDisableChar = 'G';
		public TCP()
		{ }

		public bool Connect(string hostName, int port)
		{
			tcpClient = new TcpClient();

			try
			{
				tcpClient.Connect(hostName, port);
				netStream = tcpClient.GetStream();
				Debug.WriteLine("Connected");
				return true;
			}
			catch (Exception e)
			{
				Debug.WriteLine("Error..... " + e.StackTrace);
			}
			return false;
		}
		public void Disconnect()
		{
			if ((tcpClient != null) && (tcpClient.Connected))
			{
				tcpClient.GetStream().Close();
				tcpClient.Close();
			}
		}
		public bool SendMsg(char msg)
		{
			if (tcpClient == null) return false;
			try
			{
				if (tcpClient.Connected)
				{
					Stream stream = tcpClient.GetStream();
					ASCIIEncoding asen = new ASCIIEncoding();
					byte[] sendData = asen.GetBytes(msg.ToString());
					stream.Write(sendData, 0, sendData.Length);
					return true;
				}
				else
				{
					Debug.WriteLine("TCP client not connected!");
					return false;
				}
			}
			catch (Exception e)
			{
				Debug.WriteLine("Error..... " + e.StackTrace);
			}
			return false;
		}
		public void ReadMsg(string responseData)
		{
			if (!tcpClient.Connected || tcpClient == null)
				try
				{
					{
						//byte[] data = new byte[1024];
						//using (MemoryStream ms = new MemoryStream())
						//{
						//    Debug.WriteLine("Data sa prijmaju");
						//    while (netStream!= null)
						//    {
						//        numBytesRead = netStream.Read(data, 0, data.Length);
						//        ms.Write(data, 0, numBytesRead);
						//        Debug.WriteLine("numBytesRead=" + numBytesRead.ToString() + "; msCount=" + ms.ToArray().Count());
						//    }
						//    str = Encoding.ASCII.GetString(ms.ToArray(), 0, (int)ms.Length);
						//}

						Byte[] data1 = new byte[1024];
						while (netStream != null)
						{
							responseData = String.Empty;
							numBytesRead = netStream.Read(data1, 0, data1.Length);
							responseData = Encoding.ASCII.GetString(data1, 0, numBytesRead);
						}

					}
				}
				catch (Exception)
				{

					throw;
				}
		}
		public void RemoveChars(Evidencia ev)
		{
			try
			{
				string mystr = "10000000902433280000";
				mystr = mystr.Substring(8, mystr.Length - 13);


				ev.txtTry.Text = mystr;

			}
			catch (Exception exc)
			{

				MessageBox.Show(exc.Message);
			}

		}

		public void serverConnect(Evidencia ev)
		{
			try
			{

				if (tcpClient.Connected)
				{
					ev.btnServerConnecting.Enabled = false;
					ev.btnScaning.Enabled = true;
					ev.btnDisconnect.Enabled = true;
					ev.btnStopScanning.Enabled = false;
					ev.BackgroundWorker.RunWorkerAsync();
				}
				else
				{
					MessageBox.Show("Server nie je zapnutý");
				}
			}
			catch (Exception)
			{
				MessageBox.Show("Server nie je zapnutý");
			}
		}

		public void serverDisconnect(Evidencia ev)
		{

			try
			{
				if (tcpClient.Connected)
				{
					ev.BackgroundWorker.CancelAsync();
					Disconnect();
					ev.btnDisconnect.Enabled = false;
					ev.btnStopScanning.Enabled = false;
					ev.btnScaning.Enabled = false;
				}
				else
				{
					MessageBox.Show("Server nie je zapnutý");
				}
				
			}
			catch (Exception)
			{
				MessageBox.Show("Klient je pripojený k serveru");
			}
		}

		public void scanReader(Evidencia ev)
		{
			try
			{
				//tcp.SendMsg(txtOut.Text);
				ev.btnStopScanning.Enabled = true;
				//ev.txtSender.Text = Scan.ToString(); // "B"

				//SendMsg(ContinueScanChar);
				//ev.txtSender.Text = ContinueScanChar.ToString();   //   "E"

				SendMsg(ScanChar);
				SendMsg(RepeatEnableChar);
				ev.txtSender.Text = RepeatEnableChar.ToString(); //   "F"

				//tcp.SendMsg(RepeatDisable);
				//txtOut.Text = RepeatDisable.ToString();  //   "G"

				ev.btnStopScanning.Enabled = true;
				ev.btnScaning.Enabled = false;

			}
			catch (Exception)
			{
				MessageBox.Show("Klient je pripojený k serveru");
			}
		}

		public void stopScanReader(Evidencia ev)
		{
			SendMsg(StopChar);
			ev.txtSender.Text = StopChar.ToString();

			ev.btnScaning.Enabled = true;
			ev.btnStopScanning.Enabled = false;
		}
	}
}
