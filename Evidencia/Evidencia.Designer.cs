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
            this.listBoxNenaskenovane = new System.Windows.Forms.ListBox();
            this.listBoxNaskenovane = new System.Windows.Forms.ListBox();
            this.listBoxNepotrebne = new System.Windows.Forms.ListBox();
            this.lblNenaskenovane = new System.Windows.Forms.Label();
            this.lblNaskenovanéY = new System.Windows.Forms.Label();
            this.lblNaskenovaneN = new System.Windows.Forms.Label();
            this.lstBox = new System.Windows.Forms.ListBox();
            this.btnHodnotenie = new System.Windows.Forms.Button();
            this.lblProduct = new System.Windows.Forms.Label();
            this.lblProductInfo = new System.Windows.Forms.Label();
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
            this.btnOnDatabase.Location = new System.Drawing.Point(265, 8);
            this.btnOnDatabase.Name = "btnOnDatabase";
            this.btnOnDatabase.Size = new System.Drawing.Size(121, 23);
            this.btnOnDatabase.TabIndex = 1;
            this.btnOnDatabase.Text = "Aktualizácia údajov";
            this.btnOnDatabase.UseVisualStyleBackColor = true;
            this.btnOnDatabase.Click += new System.EventHandler(this.btnOnDatabase_Click);
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
            this.btnClearData.Location = new System.Drawing.Point(138, 63);
            this.btnClearData.Name = "btnClearData";
            this.btnClearData.Size = new System.Drawing.Size(121, 23);
            this.btnClearData.TabIndex = 34;
            this.btnClearData.Text = "Vymazať";
            this.btnClearData.UseVisualStyleBackColor = true;
            this.btnClearData.Click += new System.EventHandler(this.btnClearData_Click);
            // 
            // txtTrying
            // 
            this.txtTrying.Location = new System.Drawing.Point(11, 314);
            this.txtTrying.Multiline = true;
            this.txtTrying.Name = "txtTrying";
            this.txtTrying.Size = new System.Drawing.Size(375, 60);
            this.txtTrying.TabIndex = 35;
            // 
            // txtIpAddress
            // 
            this.txtIpAddress.Location = new System.Drawing.Point(70, 9);
            this.txtIpAddress.Multiline = true;
            this.txtIpAddress.Name = "txtIpAddress";
            this.txtIpAddress.Size = new System.Drawing.Size(109, 22);
            this.txtIpAddress.TabIndex = 36;
            this.txtIpAddress.Text = "192.168.0.104";
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
            this.btnServerConnect.Size = new System.Drawing.Size(121, 23);
            this.btnServerConnect.TabIndex = 38;
            this.btnServerConnect.Text = "Pripojiť k IoT";
            this.btnServerConnect.UseVisualStyleBackColor = true;
            this.btnServerConnect.Click += new System.EventHandler(this.btnServerConnect_Click);
            // 
            // btnDisconnectServer
            // 
            this.btnDisconnectServer.Location = new System.Drawing.Point(11, 63);
            this.btnDisconnectServer.Name = "btnDisconnectServer";
            this.btnDisconnectServer.Size = new System.Drawing.Size(120, 23);
            this.btnDisconnectServer.TabIndex = 39;
            this.btnDisconnectServer.Text = "Odpojiť";
            this.btnDisconnectServer.UseVisualStyleBackColor = true;
            this.btnDisconnectServer.Click += new System.EventHandler(this.btnDisconnectServer_Click);
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(265, 37);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(121, 23);
            this.btnScan.TabIndex = 40;
            this.btnScan.Text = "Uložiť kontrolu";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // btnStopScan
            // 
            this.btnStopScan.Location = new System.Drawing.Point(263, 63);
            this.btnStopScan.Name = "btnStopScan";
            this.btnStopScan.Size = new System.Drawing.Size(122, 23);
            this.btnStopScan.TabIndex = 41;
            this.btnStopScan.Text = "Export kontroly";
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
            this.lstINR.Location = new System.Drawing.Point(235, 443);
            this.lstINR.Name = "lstINR";
            this.lstINR.Size = new System.Drawing.Size(677, 56);
            this.lstINR.TabIndex = 45;
            // 
            // btnEspSend
            // 
            this.btnEspSend.Location = new System.Drawing.Point(138, 37);
            this.btnEspSend.Name = "btnEspSend";
            this.btnEspSend.Size = new System.Drawing.Size(121, 23);
            this.btnEspSend.TabIndex = 46;
            this.btnEspSend.Text = "Poslať";
            this.btnEspSend.UseVisualStyleBackColor = true;
            this.btnEspSend.Click += new System.EventHandler(this.btnEspSend_Click_1);
            // 
            // txtINR
            // 
            this.txtINR.Location = new System.Drawing.Point(11, 426);
            this.txtINR.Multiline = true;
            this.txtINR.Name = "txtINR";
            this.txtINR.Size = new System.Drawing.Size(217, 73);
            this.txtINR.TabIndex = 47;
            // 
            // btnColor
            // 
            this.btnColor.Location = new System.Drawing.Point(185, 8);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(74, 23);
            this.btnColor.TabIndex = 48;
            this.btnColor.UseVisualStyleBackColor = true;
            // 
            // listBoxNenaskenovane
            // 
            this.listBoxNenaskenovane.FormattingEnabled = true;
            this.listBoxNenaskenovane.Location = new System.Drawing.Point(11, 151);
            this.listBoxNenaskenovane.Name = "listBoxNenaskenovane";
            this.listBoxNenaskenovane.Size = new System.Drawing.Size(120, 160);
            this.listBoxNenaskenovane.TabIndex = 49;
            this.listBoxNenaskenovane.SelectedIndexChanged += new System.EventHandler(this.listBoxNenaskenovane_SelectedIndexChanged);
            // 
            // listBoxNaskenovane
            // 
            this.listBoxNaskenovane.FormattingEnabled = true;
            this.listBoxNaskenovane.Location = new System.Drawing.Point(137, 151);
            this.listBoxNaskenovane.Name = "listBoxNaskenovane";
            this.listBoxNaskenovane.Size = new System.Drawing.Size(120, 160);
            this.listBoxNaskenovane.TabIndex = 50;
            this.listBoxNaskenovane.SelectedIndexChanged += new System.EventHandler(this.listBoxNaskenovane_SelectedIndexChanged);
            // 
            // listBoxNepotrebne
            // 
            this.listBoxNepotrebne.FormattingEnabled = true;
            this.listBoxNepotrebne.Location = new System.Drawing.Point(263, 151);
            this.listBoxNepotrebne.Name = "listBoxNepotrebne";
            this.listBoxNepotrebne.Size = new System.Drawing.Size(123, 160);
            this.listBoxNepotrebne.TabIndex = 51;
            this.listBoxNepotrebne.SelectedIndexChanged += new System.EventHandler(this.listBoxNepotrebne_SelectedIndexChanged);
            // 
            // lblNenaskenovane
            // 
            this.lblNenaskenovane.AutoSize = true;
            this.lblNenaskenovane.Location = new System.Drawing.Point(12, 135);
            this.lblNenaskenovane.Name = "lblNenaskenovane";
            this.lblNenaskenovane.Size = new System.Drawing.Size(69, 13);
            this.lblNenaskenovane.TabIndex = 52;
            this.lblNenaskenovane.Text = "Očakávané: ";
            // 
            // lblNaskenovanéY
            // 
            this.lblNaskenovanéY.AutoSize = true;
            this.lblNaskenovanéY.Location = new System.Drawing.Point(139, 135);
            this.lblNaskenovanéY.Name = "lblNaskenovanéY";
            this.lblNaskenovanéY.Size = new System.Drawing.Size(109, 13);
            this.lblNaskenovanéY.TabIndex = 53;
            this.lblNaskenovanéY.Text = "Správne umiestnenie:";
            // 
            // lblNaskenovaneN
            // 
            this.lblNaskenovaneN.AutoSize = true;
            this.lblNaskenovaneN.Location = new System.Drawing.Point(262, 135);
            this.lblNaskenovaneN.Name = "lblNaskenovaneN";
            this.lblNaskenovaneN.Size = new System.Drawing.Size(121, 13);
            this.lblNaskenovaneN.TabIndex = 54;
            this.lblNaskenovaneN.Text = "Nesprávne umiestnenie:";
            // 
            // lstBox
            // 
            this.lstBox.FormattingEnabled = true;
            this.lstBox.Location = new System.Drawing.Point(695, 177);
            this.lstBox.Name = "lstBox";
            this.lstBox.Size = new System.Drawing.Size(390, 238);
            this.lstBox.TabIndex = 2;
            // 
            // btnHodnotenie
            // 
            this.btnHodnotenie.Location = new System.Drawing.Point(392, 8);
            this.btnHodnotenie.Name = "btnHodnotenie";
            this.btnHodnotenie.Size = new System.Drawing.Size(71, 23);
            this.btnHodnotenie.TabIndex = 55;
            this.btnHodnotenie.Text = "Uložiť";
            this.btnHodnotenie.UseVisualStyleBackColor = true;
            this.btnHodnotenie.Click += new System.EventHandler(this.btnHodnotenie_Click);
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Location = new System.Drawing.Point(12, 402);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(60, 13);
            this.lblProduct.TabIndex = 58;
            this.lblProduct.Text = "Zariadenie:";
            // 
            // lblProductInfo
            // 
            this.lblProductInfo.AutoSize = true;
            this.lblProductInfo.Location = new System.Drawing.Point(78, 402);
            this.lblProductInfo.Name = "lblProductInfo";
            this.lblProductInfo.Size = new System.Drawing.Size(0, 13);
            this.lblProductInfo.TabIndex = 59;
            // 
            // Evidencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1086, 511);
            this.Controls.Add(this.lblProductInfo);
            this.Controls.Add(this.lblProduct);
            this.Controls.Add(this.btnHodnotenie);
            this.Controls.Add(this.lblNaskenovaneN);
            this.Controls.Add(this.lblNaskenovanéY);
            this.Controls.Add(this.lblNenaskenovane);
            this.Controls.Add(this.listBoxNepotrebne);
            this.Controls.Add(this.listBoxNaskenovane);
            this.Controls.Add(this.listBoxNenaskenovane);
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
            this.Text = "EvidenciaMajetkuKTPE";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtOutput;
		private System.Windows.Forms.Button btnOnDatabase;
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
        private System.Windows.Forms.ListBox listBoxNenaskenovane;
        private System.Windows.Forms.ListBox listBoxNaskenovane;
        private System.Windows.Forms.ListBox listBoxNepotrebne;
        private System.Windows.Forms.Label lblNenaskenovane;
        private System.Windows.Forms.Label lblNaskenovanéY;
        private System.Windows.Forms.Label lblNaskenovaneN;
        private System.Windows.Forms.ListBox lstBox;
        private System.Windows.Forms.Button btnHodnotenie;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label lblProductInfo;
    }
}

