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

    public partial class frmMovieList : Form
    {
        public frmMovieList()
        {
            InitializeComponent();
        }

        private void frmMovieList_Paint(object sender, PaintEventArgs e)
        {
            // Read the new Property Settings of the ColorTheme
            this.BackColor = Properties.Settings.Default.ColorTheme;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMovieList_Load(object sender, EventArgs e)
        {
            PopulateGrid(); 
        }

        private void PopulateGrid()
        {
            DataTable table = new DataTable();
            table = Context.GetDataTable("Movie");
            dgvMovies.DataSource = table;
        }

        private void dgvMovies_DoubleClick(object sender, EventArgs e)
        {
            // If no current row or cell selected, do nothing. 
            if (dgvMovies.CurrentCell == null) return;

            // Get the primary key value of the selected row, which is in column 0
            long pkId = long.Parse(dgvMovies[0, dgvMovies.CurrentCell.RowIndex].Value.ToString());

            frmMovie frm = new frmMovie(pkId);
            if (frm.ShowDialog() == DialogResult.OK) PopulateGrid();
        }

        private void lnkAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmMovie frm = new frmMovie();
            if (frm.ShowDialog() == DialogResult.OK) PopulateGrid();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete the selected item?", Properties.Settings.Default.ProjectName,
    MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    long PKID = long.Parse(dgvMovies[0, dgvMovies.CurrentCell.RowIndex].Value.ToString());

                    // Use the DeleteRecord method of the Context class and pass the primary key value to delete

                    Context.DeleteRecord("Movie", "MovieId", PKID.ToString());
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
