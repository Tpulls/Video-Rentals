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
    public partial class frmRentalList : Form
    {
        public frmRentalList()
        {
            InitializeComponent();
        }

        private void frmRentalList_Paint(object sender, PaintEventArgs e)
        {
            // Read the new Property Settings of the ColorTheme
            this.BackColor = Properties.Settings.Default.ColorTheme;
        }

        private void frmRentalList_Load(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        private void PopulateGrid()
        {
            string sqlQuery = "SELECT Rental.RentalID, Customer.CustomerName, Rental.DateRented, Rental.DateReturned " +
            "FROM Rental INNER JOIN " +
            "Customer ON Rental.CustomerID = Customer.CustomerID " +
            "ORDER BY Rental.RentalID DESC";
            DataTable table = Context.GetDataTable(sqlQuery, "Rentals");
            dgvRentals.DataSource = table;
        }

        private void lnkAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmRental frm = new frmRental();
            if (frm.ShowDialog() == DialogResult.OK)
                PopulateGrid();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvRentals_DoubleClick(object sender, EventArgs e)
        {
            // Return nothing if the cell is empty
            if (dgvRentals.CurrentCell == null) return;
            long PKID = long.Parse(dgvRentals[0, dgvRentals.CurrentCell.RowIndex].Value.ToString());
            frmRental frm = new frmRental(PKID);
            if (frm.ShowDialog() == DialogResult.OK)
                PopulateGrid();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete the selected item?", Properties.Settings.Default.ProjectName,
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    long PKID = long.Parse(dgvRentals[0, dgvRentals.CurrentCell.RowIndex].Value.ToString());

                    // Use the DeleteRecord method of the Context class and pass the primary key value to delete

                    Context.DeleteRecord("Rental", "RentalID", PKID.ToString());
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


