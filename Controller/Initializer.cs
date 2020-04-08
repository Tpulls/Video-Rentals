using SQLConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public static class Initializer
    {
        #region Member Variables

        static SQL _sql = new SQL();

        #endregion

        #region Initialize Database

        public static void InitializeDatabase()
        {
            // Call the CreateDatabase method from our SQL class to build the database in SQL server
            _sql.CreateDatabase();
            CreateDatabaseTable();
            SeedDatabaseTables();
        }

        #endregion

        #region Create Database Schema

        /// <summary>
        /// THis method will create the database tables.
        /// </summary>
        private static void CreateDatabaseTable()
        {
            CreateMovieTable();
            CreateCustomerTable();
            CreateRentalTable();
            CreateRentalItemTable();
        }

        /// <summary>
        /// This method will create the Movie table. 
        /// </summary>
        private static void CreateMovieTable()
        {

            // Create the Movie table schema
            string schema = "MovieID int IDENTITY(1,1) PRIMARY KEY, " + "MovieName VARCHAR(70)";
            // Call the Create DatabaseTable method of the SQL class to create the Movie table
            _sql.CreateDatabaseTable("Movie", schema);
        }
        /// <summary>
        /// This method will create the Customer table. 
        /// </summary>
        private static void CreateCustomerTable()
        {
            {

                // Create the Customer table schema
                string schema = "CustomerID int IDENTITY(1,1) PRIMARY KEY, " + "CustomerName VARCHAR(70), " +
                "CustomerPhone VARCHAR(70)";
                // Call the Create DatabaseTable method of the SQL class to create the Customer table
                _sql.CreateDatabaseTable("Customer", schema);
            }
            
        }
        /// <summary>
        /// This method will create the Rental table. 
        /// </summary>
        private static void CreateRentalTable()
        {
            // Create the Rental table schema
            string schema = "RentalID int IDENTITY(1,1) PRIMARY KEY, " + "CustomerID int NOT NULL, " +
                "DateRented DATETIME NOT NULL, " + "DateReturned DATETIME NULL";

            // Call the Create DatabaseTable method of the SQL class to create the Rental table
            _sql.CreateDatabaseTable("Rental", schema);
        }
        /// <summary>
        /// This method will create the Rental Item table. 
        /// </summary>
        private static void CreateRentalItemTable()
        {
            // Create the RentalItem table schema
            string schema = "RentalItemID int IDENTITY(1,1) PRIMARY KEY, " + "RentalID int NOT NULL, " +
                "MovieID int NOT NULL";

            // Call the Create DatabaseTable method of the SQL class to create the RentalItem table
            _sql.CreateDatabaseTable("RentalItem", schema);

        }

        #endregion

        #region Seed Database Tables

        private static void SeedDatabaseTables()
        {

            // Use the Profilling in this method and improve the perforamnce by making sure that the method calls to SeedMoveiTable,
            // SeedCustomerTable etc will not be called if tables in SQL already contains dummy data. 
            // To Help you out in profilling, here's the microsoft link to profilling. 
            // Go to this link https://docs.microsoft.com/en-us/visualstudio/profiling/?view=vs-2019
            // Make sure to capture the performance as you need to include the screenshot in your technical Report and compare it with
            // The screenshot of the 'after' performance.

            SeedMovieTable();
            SeedCustomerTable();
            SeedRentalTable();
            SeedRentalItemTable();
        }

        private static void SeedRentalItemTable()
        {
            List<string> rentalItems = new List<string>
            {
                //RentalItemId, RentalId, MovieId
                "1, 1, 1",
                "2, 1, 2",
                "3, 2, 3",
                "4, 3, 1",
                "5, 3, 2",
                "6, 3, 3",
            };
            //ColumnNames must watch the order of the initialize data above
            string columnNames = "RentalItemId, RentalId, MovieId";

            // Loop through the List and push the data to the database table
            foreach (var rentalItem in rentalItems)
            {
                _sql.InsertRecord("RentalItem", columnNames, rentalItem);
            }
        }

        private static void SeedRentalTable()
        {
            List<string> rentals = new List<string>
            {
                //RentalID, CustomerId, DateRented, DateReturned
                "1, 1, '2019/01/01', null",
                "2, 2, '2019/08/21', null",
                "3, 1, '2019/08/20', null"
            };
            //ColumnNames must watch the prder of the initialize data above
            string columnNames = "RentalID, CustomerId, DateRented, DateReturned";

            // Loop through the List and push the data to the database table
            foreach (var rental in rentals)
            {
                _sql.InsertRecord("Rental", columnNames, rental);
            }
        }

        private static void SeedCustomerTable()
        {
            List<string> customers = new List<string>
            {
                //CustomerID, CustomerName, CustomerPhone
                "1, 'John Smith', '3233 0675'",
                "2, 'Mary Parks', '3855 1515'",
                "3,'Robert Boyd', '3290 9999'",
            };
            //ColumnNames must watch the prder of the initialize data above
            string columnNames = "CustomerId, CustomerName, CustomerPhone";

            // Loop through the List and push the data to the database table
            foreach (var customer in customers)
            {
                _sql.InsertRecord("customer", columnNames, customer);
            }
        }

        private static void SeedMovieTable()
        {
            List<string> movies = new List<string>
            {
                //MovieId, MovieName
                "1, 'The Avengers'",
                "2, 'Star Wars'",
                "3, 'The Matrix'"
            };

            //ColumnNames must watch the prder of the initialize data above
            string columnNames = "MovieID, MovieName";

            // Loop through the List and push the data to the database table
            foreach(var movie in movies)
            {
                _sql.InsertRecord("Movie", columnNames, movie);
            }
        }

        #endregion
    }
}
