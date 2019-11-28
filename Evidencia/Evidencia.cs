using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evidencia
{
	public partial class Evidencia : Form
	{

		public TextBox TxtOut { get { return txtOutput; } }
		public ListBox listBox { get { return lstBox; } }
		public ComboBox cmbRoom { get { return cmbBoxRoom; } }
		public ComboBox cmbLocker { get { return cmbBoxLocker; } }
		public ComboBox cmbShelve { get { return cmbBoxShelve; } }

		public OnlineDatabase onDb = new OnlineDatabase();
		public LocalDatabase localDb = new LocalDatabase();
		public Selecting selecting = new Selecting();

		public Evidencia()
		{
			InitializeComponent();

			localDb.SqliteUserToList(this);
			localDb.SqliteNamespaceToList(this);
			localDb.SqliteRecordToList(this);

			selecting.SelectDataToCombo(this);
			selecting.cmbBoxEnabled(this);

		}

		private void btnOnDatabase_Click(object sender, EventArgs e)
		{
			onDb.ShowServerUsers(this);
			onDb.ShowServerNamespace(this);
			onDb.ShowServerRecords(this);
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

		private void btnClearData_Click(object sender, EventArgs e)
		{
			cmbLocker.Items.Remove(cmbBoxLocker.Text);
			cmbRoom.Items.Remove(cmbBoxRoom.Text);
			cmbShelve.Items.Remove(cmbBoxShelve.Text);
			listBox.DataSource = null;
			cmbLocker.Enabled = false;
			cmbShelve.Enabled = false;
		}
	}
}
