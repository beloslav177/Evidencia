namespace Evidencia
{
	partial class Evidencia
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.txtOutput = new System.Windows.Forms.TextBox();
			this.btnOnDatabase = new System.Windows.Forms.Button();
			this.lstBox = new System.Windows.Forms.ListBox();
			this.cmbBoxRoom = new System.Windows.Forms.ComboBox();
			this.cmbBoxLocker = new System.Windows.Forms.ComboBox();
			this.cmbBoxShelve = new System.Windows.Forms.ComboBox();
			this.lblRoom = new System.Windows.Forms.Label();
			this.lblLocker = new System.Windows.Forms.Label();
			this.lvlShelve = new System.Windows.Forms.Label();
			this.btnClearData = new System.Windows.Forms.Button();
			this.txtTrying = new System.Windows.Forms.TextBox();
			this.txtIpAddress = new System.Windows.Forms.TextBox();
			this.lblIPaddress = new System.Windows.Forms.Label();
			this.btnServerConnect = new System.Windows.Forms.Button();
			this.btnDisconnectServer = new System.Windows.Forms.Button();
			this.btnScan = new System.Windows.Forms.Button();
			this.btnStopScan = new System.Windows.Forms.Button();
			this.backGround = new System.ComponentModel.BackgroundWorker();
			this.txtSend = new System.Windows.Forms.TextBox();
			this.txtReceive = new System.Windows.Forms.TextBox();
			this.lstINR = new System.Windows.Forms.ListBox();
			this.btnEspSend = new System.Windows.Forms.Button();
			this.txtINR = new System.Windows.Forms.TextBox();
			this.btnColor = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtOutput
			// 
			this.txtOutput.Location = new System.Drawing.Point(470, 132);
			this.txtOutput.Multiline = true;
			this.txtOutput.Name = "txtOutput";
			this.txtOutput.Size = new System.Drawing.Size(219, 186);
			this.txtOutput.TabIndex = 0;
			// 
			// btnOnDatabase
			// 
			this.btnOnDatabase.Location = new System.Drawing.Point(313, 76);
			this.btnOnDatabase.Name = "btnOnDatabase";
			this.btnOnDatabase.Size = new System.Drawing.Size(72, 23);
			this.btnOnDatabase.TabIndex = 1;
			this.btnOnDatabase.Text = "Aktualizácia údajov";
			this.btnOnDatabase.UseVisualStyleBackColor = true;
			this.btnOnDatabase.Click += new System.EventHandler(this.btnOnDatabase_Click);
			// 
			// lstBox
			// 
			this.lstBox.FormattingEnabled = true;
			this.lstBox.Location = new System.Drawing.Point(12, 132);
			this.lstBox.Name = "lstBox";
			this.lstBox.Size = new System.Drawing.Size(452, 186);
			this.lstBox.TabIndex = 2;
			// 
			// cmbBoxRoom
			// 
			this.cmbBoxRoom.FormattingEnabled = true;
			this.cmbBoxRoom.Location = new System.Drawing.Point(11, 105);
			this.cmbBoxRoom.Name = "cmbBoxRoom";
			this.cmbBoxRoom.Size = new System.Drawing.Size(121, 21);
			this.cmbBoxRoom.TabIndex = 3;
			this.cmbBoxRoom.SelectedIndexChanged += new System.EventHandler(this.cmbBoxRoom_SelectedIndexChanged);
			// 
			// cmbBoxLocker
			// 
			this.cmbBoxLocker.FormattingEnabled = true;
			this.cmbBoxLocker.Location = new System.Drawing.Point(138, 105);
			this.cmbBoxLocker.Name = "cmbBoxLocker";
			this.cmbBoxLocker.Size = new System.Drawing.Size(121, 21);
			this.cmbBoxLocker.TabIndex = 4;
			this.cmbBoxLocker.SelectedIndexChanged += new System.EventHandler(this.cmbBoxLocker_SelectedIndexChanged);
			// 
			// cmbBoxShelve
			// 
			this.cmbBoxShelve.FormattingEnabled = true;
			this.cmbBoxShelve.Location = new System.Drawing.Point(265, 105);
			this.cmbBoxShelve.Name = "cmbBoxShelve";
			this.cmbBoxShelve.Size = new System.Drawing.Size(121, 21);
			this.cmbBoxShelve.TabIndex = 5;
			this.cmbBoxShelve.SelectedIndexChanged += new System.EventHandler(this.cmbBoxShelve_SelectedIndexChanged);
			// 
			// lblRoom
			// 
			this.lblRoom.AutoSize = true;
			this.lblRoom.Location = new System.Drawing.Point(12, 89);
			this.lblRoom.Name = "lblRoom";
			this.lblRoom.Size = new System.Drawing.Size(56, 13);
			this.lblRoom.TabIndex = 30;
			this.lblRoom.Text = "Miestnosť:";
			// 
			// lblLocker
			// 
			this.lblLocker.AutoSize = true;
			this.lblLocker.Location = new System.Drawing.Point(139, 91);
			this.lblLocker.Name = "lblLocker";
			this.lblLocker.Size = new System.Drawing.Size(40, 13);
			this.lblLocker.TabIndex = 31;
			this.lblLocker.Text = "Skriňa:";
			// 
			// lvlShelve
			// 
			this.lvlShelve.AutoSize = true;
			this.lvlShelve.Location = new System.Drawing.Point(262, 89);
			this.lvlShelve.Name = "lvlShelve";
			this.lvlShelve.Size = new System.Drawing.Size(45, 13);
			this.lvlShelve.TabIndex = 32;
			this.lvlShelve.Text = "Polička:";
			// 
			// btnClearData
			// 
			this.btnClearData.Location = new System.Drawing.Point(392, 103);
			this.btnClearData.Name = "btnClearData";
			this.btnClearData.Size = new System.Drawing.Size(71, 23);
			this.btnClearData.TabIndex = 34;
			this.btnClearData.Text = "Vymazať";
			this.btnClearData.UseVisualStyleBackColor = true;
			this.btnClearData.Click += new System.EventHandler(this.btnClearData_Click);
			// 
			// txtTrying
			// 
			this.txtTrying.Location = new System.Drawing.Point(246, 8);
			this.txtTrying.Multiline = true;
			this.txtTrying.Name = "txtTrying";
			this.txtTrying.Size = new System.Drawing.Size(217, 62);
			this.txtTrying.TabIndex = 35;
			// 
			// txtIpAddress
			// 
			this.txtIpAddress.Location = new System.Drawing.Point(70, 9);
			this.txtIpAddress.Multiline = true;
			this.txtIpAddress.Name = "txtIpAddress";
			this.txtIpAddress.Size = new System.Drawing.Size(109, 22);
			this.txtIpAddress.TabIndex = 36;
			this.txtIpAddress.Text = "192.168.0.101";
			this.txtIpAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// lblIPaddress
			// 
			this.lblIPaddress.AutoSize = true;
			this.lblIPaddress.Location = new System.Drawing.Point(9, 12);
			this.lblIPaddress.Name = "lblIPaddress";
			this.lblIPaddress.Size = new System.Drawing.Size(55, 13);
			this.lblIPaddress.TabIndex = 37;
			this.lblIPaddress.Text = "IP adresa:";
			// 
			// btnServerConnect
			// 
			this.btnServerConnect.Location = new System.Drawing.Point(11, 37);
			this.btnServerConnect.Name = "btnServerConnect";
			this.btnServerConnect.Size = new System.Drawing.Size(101, 23);
			this.btnServerConnect.TabIndex = 38;
			this.btnServerConnect.Text = "Pripojiť k serveru";
			this.btnServerConnect.UseVisualStyleBackColor = true;
			this.btnServerConnect.Click += new System.EventHandler(this.btnServerConnect_Click);
			// 
			// btnDisconnectServer
			// 
			this.btnDisconnectServer.Location = new System.Drawing.Point(11, 63);
			this.btnDisconnectServer.Name = "btnDisconnectServer";
			this.btnDisconnectServer.Size = new System.Drawing.Size(101, 23);
			this.btnDisconnectServer.TabIndex = 39;
			this.btnDisconnectServer.Text = "Odpojiť";
			this.btnDisconnectServer.UseVisualStyleBackColor = true;
			this.btnDisconnectServer.Click += new System.EventHandler(this.btnDisconnectServer_Click);
			// 
			// btnScan
			// 
			this.btnScan.Location = new System.Drawing.Point(118, 37);
			this.btnScan.Name = "btnScan";
			this.btnScan.Size = new System.Drawing.Size(122, 23);
			this.btnScan.TabIndex = 40;
			this.btnScan.Text = "Zapnutie skenera";
			this.btnScan.UseVisualStyleBackColor = true;
			this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
			// 
			// btnStopScan
			// 
			this.btnStopScan.Location = new System.Drawing.Point(118, 65);
			this.btnStopScan.Name = "btnStopScan";
			this.btnStopScan.Size = new System.Drawing.Size(121, 23);
			this.btnStopScan.TabIndex = 41;
			this.btnStopScan.Text = "Vypnutie skenera";
			this.btnStopScan.UseVisualStyleBackColor = true;
			this.btnStopScan.Click += new System.EventHandler(this.btnStopScan_Click);
			// 
			// backGround
			// 
			this.backGround.WorkerReportsProgress = true;
			this.backGround.WorkerSupportsCancellation = true;
			this.backGround.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Update);
			this.backGround.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.UpdateChanged);
			this.backGround.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Completed);
			// 
			// txtSend
			// 
			this.txtSend.Location = new System.Drawing.Point(469, 9);
			this.txtSend.Multiline = true;
			this.txtSend.Name = "txtSend";
			this.txtSend.Size = new System.Drawing.Size(113, 117);
			this.txtSend.TabIndex = 43;
			// 
			// txtReceive
			// 
			this.txtReceive.Location = new System.Drawing.Point(588, 8);
			this.txtReceive.Multiline = true;
			this.txtReceive.Name = "txtReceive";
			this.txtReceive.Size = new System.Drawing.Size(101, 118);
			this.txtReceive.TabIndex = 44;
			// 
			// lstINR
			// 
			this.lstINR.FormattingEnabled = true;
			this.lstINR.Location = new System.Drawing.Point(12, 324);
			this.lstINR.Name = "lstINR";
			this.lstINR.Size = new System.Drawing.Size(677, 56);
			this.lstINR.TabIndex = 45;
			// 
			// btnEspSend
			// 
			this.btnEspSend.Location = new System.Drawing.Point(391, 76);
			this.btnEspSend.Name = "btnEspSend";
			this.btnEspSend.Size = new System.Drawing.Size(71, 23);
			this.btnEspSend.TabIndex = 46;
			this.btnEspSend.Text = "Poslať";
			this.btnEspSend.UseVisualStyleBackColor = true;
			this.btnEspSend.Click += new System.EventHandler(this.btnEspSend_Click_1);
			// 
			// txtINR
			// 
			this.txtINR.Location = new System.Drawing.Point(12, 386);
			this.txtINR.Multiline = true;
			this.txtINR.Name = "txtINR";
			this.txtINR.Size = new System.Drawing.Size(217, 113);
			this.txtINR.TabIndex = 47;
			// 
			// btnColor
			// 
			this.btnColor.Location = new System.Drawing.Point(185, 8);
			this.btnColor.Name = "btnColor";
			this.btnColor.Size = new System.Drawing.Size(54, 23);
			this.btnColor.TabIndex = 48;
			this.btnColor.UseVisualStyleBackColor = true;
			// 
			// Evidencia
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.ClientSize = new System.Drawing.Size(700, 511);
			this.Controls.Add(this.btnColor);
			this.Controls.Add(this.txtINR);
			this.Controls.Add(this.btnEspSend);
			this.Controls.Add(this.lstINR);
			this.Controls.Add(this.txtReceive);
			this.Controls.Add(this.txtSend);
			this.Controls.Add(this.btnStopScan);
			this.Controls.Add(this.btnScan);
			this.Controls.Add(this.btnDisconnectServer);
			this.Controls.Add(this.btnServerConnect);
			this.Controls.Add(this.lblIPaddress);
			this.Controls.Add(this.txtIpAddress);
			this.Controls.Add(this.txtTrying);
			this.Controls.Add(this.btnClearData);
			this.Controls.Add(this.lvlShelve);
			this.Controls.Add(this.lblLocker);
			this.Controls.Add(this.lblRoom);
			this.Controls.Add(this.cmbBoxShelve);
			this.Controls.Add(this.cmbBoxLocker);
			this.Controls.Add(this.cmbBoxRoom);
			this.Controls.Add(this.lstBox);
			this.Controls.Add(this.btnOnDatabase);
			this.Controls.Add(this.txtOutput);
			this.Name = "Evidencia";
			this.Text = "Evidencia Majetku";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtOutput;
		private System.Windows.Forms.Button btnOnDatabase;
		private System.Windows.Forms.ListBox lstBox;
		private System.Windows.Forms.ComboBox cmbBoxRoom;
		private System.Windows.Forms.ComboBox cmbBoxLocker;
		private System.Windows.Forms.ComboBox cmbBoxShelve;
		private System.Windows.Forms.Label lblRoom;
		private System.Windows.Forms.Label lblLocker;
		private System.Windows.Forms.Label lvlShelve;
		private System.Windows.Forms.Button btnClearData;
		private System.Windows.Forms.TextBox txtTrying;
		private System.Windows.Forms.TextBox txtIpAddress;
		private System.Windows.Forms.Label lblIPaddress;
		private System.Windows.Forms.Button btnServerConnect;
		private System.Windows.Forms.Button btnDisconnectServer;
		private System.Windows.Forms.Button btnScan;
		private System.Windows.Forms.Button btnStopScan;
		private System.ComponentModel.BackgroundWorker backGround;
		private System.Windows.Forms.TextBox txtSend;
		private System.Windows.Forms.TextBox txtReceive;
		private System.Windows.Forms.ListBox lstINR;
		private System.Windows.Forms.Button btnEspSend;
		private System.Windows.Forms.TextBox txtINR;
		private System.Windows.Forms.Button btnColor;
	}
}

