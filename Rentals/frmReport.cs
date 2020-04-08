using Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rentals
{
    public partial class frmReport : Form
    {
        DataView _dvHistory = null; // Data source of our grid. Easy to filter tahn the DataTable.
        public frmReport()
        {
            InitializeComponent();
        }

        private void frmReport_Paint(object sender, PaintEventArgs e)
        {
            // Read the new Property Settings of the ColorTheme
            this.BackColor = Properties.Settings.Default.ColorTheme;
        }
        private void frmReport_Load(object sender, EventArgs e)
        {
            PopulateGrid();
        }
        private void PopulateGrid()
        {
            string sqlQuery = "SELECT Rental.DateRented, Customer.CustomerName, Movie.MovieName, Rental.DateReturned " +
                  "FROM Customer INNER JOIN " +
                  "Rental ON Customer.CustomerID = Rental.CustomerID INNER JOIN " +
                  "RentalItem ON Rental.RentalID = RentalItem.RentalID CROSS JOIN " +
                  "Movie ORDER BY Rental.DateRented DESC";

            DataTable table = Context.GetDataTable(sqlQuery, "MovieHistory", true);

            _dvHistory = new DataView(table);
            dgvReport.DataSource = _dvHistory;

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
           // THe '%' os a wildcard. It means that whatever we enter in txtSearch, we will search 
            // if CustomerName or MovieName contains the text entered. 
            _dvHistory.RowFilter = $"CustomerName LIKE '%{txtSearch.Text}%' " +
                $"OR MovieName LIKE '%{ txtSearch.Text}' ";



        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            // Use stringBuilder to build our csv files
            StringBuilder csv = new StringBuilder();

            // Loop through each row of the Dataview history and we append each row to our csv string
            foreach (DataRowView drv in _dvHistory)
            {
                csv.AppendLine($"{drv["DateRented"].ToString()}, " +
                    $"{drv["DateRented"].ToString()}, " +
                    $"{drv["CustomerName"].ToString()}, " +
                    $"{drv["MovieName"].ToString()}, " +
                    $"{drv["DateReturned"].ToString()}, ");
            }
            // Writes the csv string in the Debug folder or where the .exe is located. The name of the csv file is 'MovieHistory'. 
            File.WriteAllText(Application.StartupPath + @"\MovieHistory.csv", csv.ToString());
            MessageBox.Show("Export completed.", Properties.Settings.Default.ProjectName);

        }
    }
}
