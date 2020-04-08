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
    public partial class frmRental : Form
    {
        #region Member Variables

        long _PKID = 0;
        DataTable _rentalTable = null, _rentalItemsTable = null;
        bool _isNew = false;

        #endregion
        #region Constructors
        public frmRental()
        {
            InitializeComponent();
            InitializeNewRental();
        }

        public frmRental(long pkid)
        {
            InitializeComponent();
            InitializeExistingRental(pkid);
        }

        #endregion
        #region Form Events

        private void frmRental_Paint(object sender, PaintEventArgs e)
        {
            // Read the new Property Settings of the ColorTheme
            this.BackColor = Properties.Settings.Default.ColorTheme;
        }
        private void frmRental_Load(object sender, EventArgs e)
        {
            PopulateComboBox();
            BindControls();
        }

        #endregion
        #region Button Events
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            // Before we create a Child record, we will force our program to create the parent record based on the
            // selections the user made in the Customer ComboBox and DateRented DateTimePicker
            if (_isNew && _PKID <=0)
            {
                string columnNames = "CustomerId, DateRented, DateReturned";

                // When sending dates in SQL, we will use a string using the format of 'yyy-MM-dd'
                string dateRented = dtpDateRented.Value.ToString("yyyy-MM-dd");
                long customerId = long.Parse(cboCustomer.SelectedValue.ToString());
                string columnValues = $"{customerId}, '{dateRented}', null";
                // Push the parent data to the database using the InsertParentTable of the Context Class. It
                // will then return the primary key id of the newly created Parent record and we simply store 
                // it in the _PKID variable. 
                _PKID = Context.InsertParentTable("Rental", columnNames, columnValues);
                // Display the _PKID value in the txtRentalId textbox
                txtRentalId.Text = _PKID.ToString();
                // Call the InitializeDataTable method again to refresh it using the newly created parent
                // record from the database. 
                InitializeDataTable();
                gbxItems.Enabled = true;

            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dtpDateReturned.Text.Equals(" ") == false)
                _rentalTable.Rows[0]["DateReturned"] = dtpDateReturned.Value.ToString("yyyy-MM-dd");

            // Always do an EndEdit before saving, otherwise the data will not persis in the database
            _rentalTable.Rows[0].EndEdit();
            Context.SaveDatabasetable(_rentalTable);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete the item?", Properties.Settings.Default.ProjectName, 
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    long PKID = long.Parse(dgvRentalItems[0, dgvRentalItems.CurrentCell.RowIndex].Value.ToString());

                    // Use the DeleteRecord method of the Context class and pass the primary key value to delete

                    Context.DeleteRecord("RentalItem", "RentalItemID", PKID.ToString());
                    PopulateGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No Records exists.", Properties.Settings.Default.ProjectName);
                }

            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            frmRentalItem frm = new frmRentalItem(txtRentalId.Text);
            if (frm.ShowDialog() == DialogResult.OK)
                PopulateGrid();
        }

        #endregion
        #region Helper_Methods
        private void InitializeNewRental()
        {
            _isNew = true;
            InitializeDataTable();
            gbxItems.Enabled = false;
        }

        private void InitializeDataTable()
        {
            _rentalTable = Context.GetDataTable($"SELECT * FROM Rental WHERE RentalId = {_PKID}", "Rental");
            PopulateGrid();
        }

        private void InitializeExistingRental(long pkid)
        {
            _PKID = pkid;
            InitializeDataTable();
            gbxItems.Enabled = true;
        }

        private void PopulateGrid()
        {
            string sqlQuery = "SELECT RentalItem.RentalItemID, Movie.MovieName, RentalItem.RentalID " +
                              "FROM RentalItem INNER JOIN " +
                              "Movie ON RentalItem.MovieID = Movie.MovieId " +
                              $"WHERE RentalId = {_PKID} " +
                              "ORDER BY RentalItem.RentalItemID DESC";
            _rentalItemsTable = Context.GetDataTable(sqlQuery, "RentalItem");
            dgvRentalItems.DataSource = _rentalItemsTable;
        }
        /// <summary>
        /// This method will populate the ComboBox by calling the GetDataTable of the Context class and pass the table name of the source database table
        /// </summary>
        private void PopulateComboBox()
        {
            // Get all records from our source database table - Customer
            DataTable table = Context.GetDataTable("Customer");

            // Set the ValueMember. The ValueMember is the name of the primary key field of your source database table. 
            // This is the value that will be stored in the database when a user selects a row from the combobox
            cboCustomer.ValueMember = "CustomerId";

            // Set the DisplayMember. The DisplayMember is the name of the primary key field of your source database table.
            // This is the value that will be stored in the database when a user selects a row from the ComboBox.
            cboCustomer.DisplayMember = "CustomerName";

            // Set the data source of the ComboBox by using the DataTable we have created above = table. 
            cboCustomer.DataSource = table;
        }

        private void dgvRentalItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvRentalItems_DoubleClick(object sender, EventArgs e)
        {
            if (dgvRentalItems.CurrentCell == null) return;
            long pkId = long.Parse(dgvRentalItems[0, dgvRentalItems.CurrentCell.RowIndex].Value.ToString());
            frmRentalItem frm = new frmRentalItem(pkId);
            if (frm.ShowDialog() == DialogResult.OK)
                PopulateGrid();
        }

        private void BindControls()
        {
            txtRentalId.DataBindings.Add("Text", _rentalTable, "RentalId");
            cboCustomer.DataBindings.Add("SelectedValue", _rentalTable, "CustomerId");
            dtpDateRented.DataBindings.Add("Text", _rentalTable, "DateRented");
            dtpDateReturned.DataBindings.Add("Text", _rentalTable, "DateReturned");

            // When creating a NEW rental, we want to make sure that our Customer ComboBox is empty or nothing is selected
            // and our DateReturned DateTimePicker is also empty. 
            if (_isNew)
                cboCustomer.SelectedIndex = -1;

            if (_isNew || string.IsNullOrEmpty(_rentalTable.Rows[0]["DateReturned"].ToString())) 
            {
                dtpDateRented.Format = DateTimePickerFormat.Custom;
                dtpDateReturned.CustomFormat = " ";
            }
        }
    }

    #endregion

}




