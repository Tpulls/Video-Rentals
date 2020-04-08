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
    public partial class frmMovie : Form
    {

        #region Member Variables
        long _PKID = 0;
        DataTable _movieTable = null;
        bool _isNew = false; 


        #endregion
        #region Constructors
        public frmMovie()
        {
            InitializeComponent();
            _isNew = true;
            setupForm();
        }


        public frmMovie(long pkId)
        {
            InitializeComponent();
            _PKID = pkId;
            setupForm();
        }
        #endregion
        #region Button Events
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // IMPORTANT: Always do the EndEdit before saving your DataTable, otherwise, the data will not save or persist. 
            _movieTable.Rows[0].EndEdit();

            // Call the Save method of the Context class to save the change to the database
            Context.SaveDatabasetable(_movieTable);
        }
        #endregion
        #region Form Events
        private void frmMovie_Paint(object sender, PaintEventArgs e)
        {
            // Read the new Property Settings of the ColorTheme
            this.BackColor = Properties.Settings.Default.ColorTheme;
        }
        #endregion
        #region Helper_Methods
        /// <summary>
        /// This method will initialize the DataTable that we will use to bind this form. The data of the table will come from SQL server. 
        /// </summary>
        private void InitializeDataTable()
        {
            string sqlQuery = $"SELECT * FROM Movie WHERE MovieID = {_PKID}";

            // Get an existing movie record based on the _PKID and the data table should be an updateable table.
            _movieTable = Context.GetDataTable(sqlQuery, "Movie");

            if(_isNew)
                {
                DataRow row = _movieTable.NewRow();
                _movieTable.Rows.Add(row);

                }
        }
        private void BindControls()
            {
            // Binding the textbox txtMovieId with the _movieTable and mapping it to the database field called 'MovieId', and use the 
            // 'Text' property of the Textbox to display the value of the field. 
            txtMovieId.DataBindings.Add("Text", _movieTable, "MovieId");
            txtMovieName.DataBindings.Add("Text", _movieTable, "MovieName");
            }
        private void setupForm()
        {
            InitializeDataTable();
            BindControls();
        }

        #endregion


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }



        private void frmMovie_Load(object sender, EventArgs e)
        {

        }

        private void txtMovieId_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
