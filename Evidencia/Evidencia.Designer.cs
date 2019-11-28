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
			this.SuspendLayout();
			// 
			// txtOutput
			// 
			this.txtOutput.Location = new System.Drawing.Point(566, 244);
			this.txtOutput.Multiline = true;
			this.txtOutput.Name = "txtOutput";
			this.txtOutput.Size = new System.Drawing.Size(507, 176);
			this.txtOutput.TabIndex = 0;
			// 
			// btnOnDatabase
			// 
			this.btnOnDatabase.Location = new System.Drawing.Point(12, 12);
			this.btnOnDatabase.Name = "btnOnDatabase";
			this.btnOnDatabase.Size = new System.Drawing.Size(121, 23);
			this.btnOnDatabase.TabIndex = 1;
			this.btnOnDatabase.Text = "Aktualizácia údajov";
			this.btnOnDatabase.UseVisualStyleBackColor = true;
			this.btnOnDatabase.Click += new System.EventHandler(this.btnOnDatabase_Click);
			// 
			// lstBox
			// 
			this.lstBox.FormattingEnabled = true;
			this.lstBox.Location = new System.Drawing.Point(12, 89);
			this.lstBox.Name = "lstBox";
			this.lstBox.Size = new System.Drawing.Size(452, 316);
			this.lstBox.TabIndex = 2;
			// 
			// cmbBoxRoom
			// 
			this.cmbBoxRoom.FormattingEnabled = true;
			this.cmbBoxRoom.Location = new System.Drawing.Point(12, 62);
			this.cmbBoxRoom.Name = "cmbBoxRoom";
			this.cmbBoxRoom.Size = new System.Drawing.Size(121, 21);
			this.cmbBoxRoom.TabIndex = 3;
			this.cmbBoxRoom.SelectedIndexChanged += new System.EventHandler(this.cmbBoxRoom_SelectedIndexChanged);
			// 
			// cmbBoxLocker
			// 
			this.cmbBoxLocker.FormattingEnabled = true;
			this.cmbBoxLocker.Location = new System.Drawing.Point(139, 62);
			this.cmbBoxLocker.Name = "cmbBoxLocker";
			this.cmbBoxLocker.Size = new System.Drawing.Size(121, 21);
			this.cmbBoxLocker.TabIndex = 4;
			this.cmbBoxLocker.SelectedIndexChanged += new System.EventHandler(this.cmbBoxLocker_SelectedIndexChanged);
			// 
			// cmbBoxShelve
			// 
			this.cmbBoxShelve.FormattingEnabled = true;
			this.cmbBoxShelve.Location = new System.Drawing.Point(266, 62);
			this.cmbBoxShelve.Name = "cmbBoxShelve";
			this.cmbBoxShelve.Size = new System.Drawing.Size(121, 21);
			this.cmbBoxShelve.TabIndex = 5;
			this.cmbBoxShelve.SelectedIndexChanged += new System.EventHandler(this.cmbBoxShelve_SelectedIndexChanged);
			// 
			// lblRoom
			// 
			this.lblRoom.AutoSize = true;
			this.lblRoom.Location = new System.Drawing.Point(12, 46);
			this.lblRoom.Name = "lblRoom";
			this.lblRoom.Size = new System.Drawing.Size(56, 13);
			this.lblRoom.TabIndex = 30;
			this.lblRoom.Text = "Miestnosť:";
			// 
			// lblLocker
			// 
			this.lblLocker.AutoSize = true;
			this.lblLocker.Location = new System.Drawing.Point(139, 46);
			this.lblLocker.Name = "lblLocker";
			this.lblLocker.Size = new System.Drawing.Size(40, 13);
			this.lblLocker.TabIndex = 31;
			this.lblLocker.Text = "Skriňa:";
			// 
			// lvlShelve
			// 
			this.lvlShelve.AutoSize = true;
			this.lvlShelve.Location = new System.Drawing.Point(263, 46);
			this.lvlShelve.Name = "lvlShelve";
			this.lvlShelve.Size = new System.Drawing.Size(45, 13);
			this.lvlShelve.TabIndex = 32;
			this.lvlShelve.Text = "Polička:";
			// 
			// btnClearData
			// 
			this.btnClearData.Location = new System.Drawing.Point(393, 60);
			this.btnClearData.Name = "btnClearData";
			this.btnClearData.Size = new System.Drawing.Size(71, 23);
			this.btnClearData.TabIndex = 34;
			this.btnClearData.Text = "Vymazať";
			this.btnClearData.UseVisualStyleBackColor = true;
			this.btnClearData.Click += new System.EventHandler(this.btnClearData_Click);
			// 
			// Evidencia
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.ClientSize = new System.Drawing.Size(1085, 432);
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
		public System.Windows.Forms.Label lblRoom;
		public System.Windows.Forms.Label lblLocker;
		public System.Windows.Forms.Label lvlShelve;
		public System.Windows.Forms.Button btnClearData;
	}
}

