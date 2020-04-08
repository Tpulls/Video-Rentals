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
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            frmCustomerList frm = new frmCustomerList();
            frm.ShowDialog();
        }

        private void btnMovies_Click(object sender, EventArgs e)
        {
            frmMovieList frm = new frmMovieList();
            frm.ShowDialog();

        }

        private void btnRentals_Click(object sender, EventArgs e)
        {
            frmRentalList frm = new frmRentalList();
            frm.ShowDialog();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            frmSettings frm = new frmSettings();
            frm.ShowDialog();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnexit_Paint(object sender, PaintEventArgs e)
        {
            // Read the new Property Settings of the ColorTheme
            this.BackColor = Properties.Settings.Default.ColorTheme;
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {

        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            frmReport frm = new frmReport();
            frm.ShowDialog();
        }
    }
}
