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
    public partial class frmRentalItem : Form
    {
        #region Member Variables

        long _PKID = 0, _RentalID = 0;
        DataTable _dtbRentalItems = null, _movieTable = null;
        bool _isNew = false;

        #endregion
        #region Constructors

        /// <summary>
        /// This Constructor is to create a NEW Rental Item and it requires the RentalID (foreign key)
        /// so that this NEW Rental Item will know its parent record in the Rental table.
        /// Since we already have a constructor that accepts a parameter of type long, in this constructor we will 
        /// accept a parameter of type string.
        /// </summary>
        public frmRentalItem(string RentalId)
        {
            _isNew = true;
            _RentalID = long.Parse(RentalId);
            InitializeComponent();
            InitializeDataTable();
        }


        /// <summary>
        ///  This constructor will open an existing Rental Item based on the PKID parameter. 
        /// </summary>
        /// <param name=""></param>
        public frmRentalItem(long pKID)
        {
            InitializeComponent();
            _PKID = pKID;
            InitializeDataTable();
        }

        #endregion

        #region Button Events

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_dtbRentalItems.Rows.Count > 0)
            {
                // Check if a cell has been selected in the DataGridView
                // If not show a MessageBox and stop the method
                if (cboMovie.SelectedIndex == -1)
                {
                    MessageBox.Show("No rentalitem has been selected!",
                        Properties.Settings.Default.ProjectName,
                        MessageBoxButtons.OK);

                    return;
                }

                /*
                 * NOTE:
                 * Make sure to end with EndEdit
                 * Before saving the DataTable
                 */
                // Save the DataTable
                _dtbRentalItems.Rows[0].EndEdit();

                // Save the table
                Context.SaveDatabasetable(_dtbRentalItems);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Form Events
        private void frmRentalItem_Paint(object sender, PaintEventArgs e)
        {
            // Read the new Property Settings of the ColorTheme
            this.BackColor = Properties.Settings.Default.ColorTheme;
        }

        private void frmRentalItem_Load(object sender, EventArgs e)
        {
            BindControls();
            if (_isNew)
                txtRentalId.Text = _RentalID.ToString();
        }

        #endregion
        #region Helper_Methods
        private void InitializeDataTable()
        {
            string sql = $"SELECT * FROM RentalItem WHERE RentalItemId = {_PKID}";
            _dtbRentalItems = Context.GetDataTable(sql, "RentalItem");

            if (_isNew)
            {
                DataRow row = _dtbRentalItems.NewRow();
                _dtbRentalItems.Rows.Add(row);
            }
            InitializeMovieTable();
        }

        #region ComboxBox Events
        private void cboMovie_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check if the Movies SelectedIndex is greater than 0
            // Assign the Movies SelectedValue to the DataTable MovieID
            if (cboMovie.SelectedIndex > 0)
            {
                _dtbRentalItems.Rows[0]["MovieId"] = cboMovie.SelectedValue;
            }

        }

        #endregion

        /// <summary>
        /// Initialize the Movie DataTable
        /// </summary>
        private void InitializeMovieTable()
        {
            // Create and assign a new SQL Query
            string sqlQuery = $"SELECT MovieId, MovieName FROM Movie";

            // Assign the Movie DataTable with the Movie DataTable
            // Create a new column with the MovieID and MovieName
            _movieTable = Context.GetDataTable(sqlQuery, "Movie");

        }

        private void BindControls()
        {
            txtRentalId.DataBindings.Add("Text", _dtbRentalItems, "RentalId");

            // Bind the ValueMember with the MovieID
            // Bind the DisplayMember with the column Display
            // Bind cboMovies with the Movie DataTable
            // Bind the BindContext with the BindingContext
            cboMovie.ValueMember = "MovieId";
            cboMovie.DisplayMember = "MovieName";
            cboMovie.DataSource = _movieTable;
            cboMovie.BindingContext = this.BindingContext;

            // Check if _isNew is true
            // Set the Movies SelectedIndex to -1
            // Else set the Movies SelectedIndex to the DataTable MovieID (Subtract 1)
            if (_isNew)
            {
                cboMovie.SelectedIndex = -1;
            }
            else
            {
                cboMovie.SelectedIndex = int.Parse(_dtbRentalItems.Rows[0]["MovieId"].ToString()) - 1;
            }
        }

        #endregion

        private void txtRentalItemId(object sender, EventArgs e)
        {

        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

    }

}
