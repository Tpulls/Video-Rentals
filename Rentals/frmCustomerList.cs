using Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rentals
{
    public partial class frmCustomerList : Form
    {
        public frmCustomerList()
        {
            InitializeComponent();
        }

        private void frmCustomerList_Paint(object sender, PaintEventArgs e)
        {
            // Read the new Property Settings of the ColorTheme
            this.BackColor = Properties.Settings.Default.ColorTheme;
        }

        private void frmCustomerList_Load(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        private void PopulateGrid()
        {
            DataTable table = new DataTable();
            table = Context.GetDataTable("Customer");
            dgvCustomers.DataSource = table;
        }
        private void dgvCustomers_DoubleClick(object sender, EventArgs e)
        {
            // If no current row or cell selected, do nothing.
            if (dgvCustomers.CurrentCell == null) return;

            //Get the primary key value of the selected row, which is in column 0
            long pkid = long.Parse(dgvCustomers[0, dgvCustomers.CurrentCell.RowIndex].Value.ToString());

            frmCustomer frm = new frmCustomer(pkid);
            if (frm.ShowDialog() == DialogResult.OK) PopulateGrid();

        }
        private void lnkAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmCustomer frm = new frmCustomer();
            if (frm.ShowDialog() == DialogResult.OK) PopulateGrid();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void dgvCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete the selected item?", Properties.Settings.Default.ProjectName,
MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    long PKID = long.Parse(dgvCustomers[0, dgvCustomers.CurrentCell.RowIndex].Value.ToString());

                    // Use the DeleteRecord method of the Context class and pass the primary key value to delete

                    Context.DeleteRecord("Customer", "CustomerId", PKID.ToString());
                    PopulateGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No Records exists.", Properties.Settings.Default.ProjectName);
                }

            }
        }
    }
}
