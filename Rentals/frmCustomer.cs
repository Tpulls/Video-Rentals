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
    public partial class frmCustomer : Form
    {
        #region Member Variables
        long _PKID = 0;
        DataTable _customerTable = null;
        bool _isNew = false;

        #endregion
        #region Constructors
        public frmCustomer()
        {
            InitializeComponent();
            _isNew = true;
            setupForm();
        }

        public frmCustomer(long pkId)
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
            _customerTable.Rows[0].EndEdit();

            // Call the Save method of the Context class to save the change to the database
            Context.SaveDatabasetable(_customerTable);
        }
        #endregion
        #region Form Events
        private void frmCustomer_Paint(object sender, PaintEventArgs e)
        {
            // Read the new Property Settings of the ColorTheme
            this.BackColor = Properties.Settings.Default.ColorTheme;
        }

        #endregion
        #region Helper_Methods
        private void setupForm()
        {
            InitializeDataTable();
            BindControls();
        }

        /// <summary>
        ///  This method will initialize the DataTable that we will use to bind this form. The data of the table will come from SQL server. 
        /// </summary>
        private void InitializeDataTable()
        {
            string sqlQuery = $"SELECT * FROM Customer WHERE CustomerID = {_PKID}";

            // Get an existing customer record based on the _PKID and the data table should be an updateable table
            _customerTable = Context.GetDataTable(sqlQuery, "Customer");

            if(_isNew)
            {
                DataRow row = _customerTable.NewRow();
                _customerTable.Rows.Add(row);
            }
        }

        private void BindControls()
        {
            // Binding the textbox txtCustomerId with the _customerTable and mapping it to the database filed called 'CustomerId', and use the 
            // 'Text' property of the Textbox to display the value of the field. 
            txtCustomerId.DataBindings.Add("Text", _customerTable, "CustomerId");
            txtCustomerName.DataBindings.Add("Text", _customerTable, "CustomerName");
            txtCustomerPhone.DataBindings.Add("Text", _customerTable, "CustomerPhone");
        }

        #endregion
        private void frmCustomer_Load(object sender, EventArgs e)
        {

        }

        private void txtCustomerPhone_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
