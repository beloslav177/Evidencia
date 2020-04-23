using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Evidencia
{
	public class TCP
	{
		public int Hodnota = 0;
		public NetworkStream netStream;
		public TcpClient tcpClient;
		private int numBytesRead;
		private char StopChar = 'C';
		private char ContinueScanChar = 'E';
		private char RepeatDisableChar = 'G';
		public TCP()
		{ }
		/// <summary>
		/// Funkcia pre pripojenie k IoT zariadeniu
		/// </summary>
		/// <param IPadresaIoTzariadenia="hostName"></param>
		/// <param PortServera="port"></param>
		/// <param Hl.Trieda="ev"></param>
		/// <returns></returns>
		public bool Connect(string hostName, int port, Evidencia ev)
		{
			tcpClient = new TcpClient();

			try
			{
				tcpClient.Connect(hostName, port);
				netStream = tcpClient.GetStream();
				Debug.WriteLine("Connected");
				SendMsg(RepeatDisableChar);
				if (tcpClient.Connected)
				{
					ev.btnColored.BackColor = Color.Green;
				}
				return true;
			}
			catch (Exception e)
			{
				Debug.WriteLine("Error..... " + e.StackTrace);
			}
			return false;
		}
		/// <summary>
		/// Funkcia pre odpojenie od IoT zariadenia
		/// </summary>
		/// <param name="ev"></param>
		public void Disconnect(Evidencia ev)
		{
			if ((tcpClient != null) && (tcpClient.Connected))
			{
				tcpClient.GetStream().Close();
				tcpClient.Close();
				if (!tcpClient.Connected)
				{
					ev.btnColored.BackColor = Color.Red;
				}
			}
		}
		/// <summary>
		/// Funkcia pre poslanie údajov IoT zariadeniu
		/// </summary>
		/// <param Posielanie znaku="msg"></param>
		/// <returns></returns>
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
		/// <summary>
		///  Funkcia pre poslanie údajov IoT zariadeniu
		/// </summary>
		/// <param Posielania reťazca znakov pre IoT zariadenie ohľadom údajov pre displej="EspString"></param>
		/// <returns></returns>
		public bool SendMsg(string EspString)
		{
			if (tcpClient == null) return false;
			try
			{
				if (tcpClient.Connected)
				{
					Stream stream = tcpClient.GetStream();
					ASCIIEncoding asen = new ASCIIEncoding();
					byte[] sendData = asen.GetBytes(EspString);
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
		/// <summary>
		/// Testovacia metóda pre orezanie reťazca znakov
		/// </summary>
		/// <param name="ev"></param>
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

		/// <summary>
		/// Spustenie triedy BackgroundWorker metódy RunWorkerAsync
		/// </summary>
		/// <param name="ev"></param>
		public void serverConnect(Evidencia ev)
		{
			try
			{
				//if (!tcpClient.Connected)
				//{
					ev.btnServerConnecting.Enabled = false;
					ev.btnScaning.Enabled = true;
					ev.btnDisconnect.Enabled = true;
					ev.btnStopScanning.Enabled = false;
					ev.BackgroundWorker.RunWorkerAsync();
				
				//}
				//else
				//{
				//	MessageBox.Show("Server nie je zapnutý");
				//}
			}
			catch (Exception)
			{
				ev.btnDisconnect.Enabled = true;
				MessageBox.Show("Server nie je zapnutý");
			}
		}
		/// <summary>
		/// Funkcia pre vypnutie triedy Backgroundworker metódou CancelAsync, v tejto metode je aj metóda Disconnect, ktorá odpojí aplikáciu z IoT zariadenia
		/// </summary>
		/// <param name="ev"></param>
		public void serverDisconnect(Evidencia ev)
		{

			try
			{
				//if (tcpClient.Connected)
				//{
					ev.BackgroundWorker.CancelAsync();
					Disconnect(ev);
					ev.btnDisconnect.Enabled = false;
					ev.btnStopScanning.Enabled = false;
					ev.btnScaning.Enabled = false;
				
				//}
				//else
				//{
				//	MessageBox.Show("Server nie je zapnutý");
				//}

			}
			catch (Exception)
			{
				MessageBox.Show("Klient je pripojený k serveru");
				ev.btnScaning.Enabled = false;
			}
		}
		/// <summary>
		/// Funkcia pre posielanie údajov do IoT zariadenia, funkcionalita pre modul čítačky zapnutie 
		/// </summary>
		/// <param name="ev"></param>
		public void scanReader(Evidencia ev)
		{
			try
			{
				//tcp.SendMsg(txtOut.Text);
				ev.btnStopScanning.Enabled = true;
				//ev.txtSender.Text = Scan.ToString(); // "B"

				//SendMsg(ContinueScanChar);
				//ev.txtSender.Text = ContinueScanChar.ToString();   //   "E"

				//SendMsg(ScanChar);
				SendMsg(ContinueScanChar);
				//SendMsg(RepeatDisableChar);
				//SendMsg(RepeatEnableChar);
				ev.txtSender.Text = ContinueScanChar.ToString(); //   "F"

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

		/// <summary>
		/// Funkcia pre posielanie údajov do IoT zariadenia, funkcionalita pre modul čítačky vypnutie.
		/// </summary>
		/// <param name="ev"></param>
		public void stopScanReader(Evidencia ev)
		{
			//SendMsg(RepeatDisableChar);
			SendMsg(StopChar);
			ev.txtSender.Text = StopChar.ToString();

			ev.btnScaning.Enabled = true;
			ev.btnStopScanning.Enabled = false;
		}
	}
}
