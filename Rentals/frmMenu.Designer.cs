namespace Rentals
{
    partial class frmMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnMovies = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCustomer = new System.Windows.Forms.Button();
            this.btnRentals = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnexit = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMovies
            // 
            this.btnMovies.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMovies.Location = new System.Drawing.Point(25, 66);
            this.btnMovies.Name = "btnMovies";
            this.btnMovies.Size = new System.Drawing.Size(292, 38);
            this.btnMovies.TabIndex = 0;
            this.btnMovies.Text = "Movies";
            this.btnMovies.UseVisualStyleBackColor = true;
            this.btnMovies.Click += new System.EventHandler(this.btnMovies_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(296, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "Video Rentals";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnCustomer
            // 
            this.btnCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomer.Location = new System.Drawing.Point(25, 119);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(292, 38);
            this.btnCustomer.TabIndex = 2;
            this.btnCustomer.Text = "Customers";
            this.btnCustomer.UseVisualStyleBackColor = true;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // btnRentals
            // 
            this.btnRentals.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRentals.Location = new System.Drawing.Point(25, 172);
            this.btnRentals.Name = "btnRentals";
            this.btnRentals.Size = new System.Drawing.Size(292, 38);
            this.btnRentals.TabIndex = 3;
            this.btnRentals.Text = "Rentals";
            this.btnRentals.UseVisualStyleBackColor = true;
            this.btnRentals.Click += new System.EventHandler(this.btnRentals_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.Location = new System.Drawing.Point(25, 225);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(292, 38);
            this.btnSettings.TabIndex = 4;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnexit
            // 
            this.btnexit.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnexit.Location = new System.Drawing.Point(25, 353);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(292, 38);
            this.btnexit.TabIndex = 5;
            this.btnexit.Text = "Exit";
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            this.btnexit.Paint += new System.Windows.Forms.PaintEventHandler(this.btnexit_Paint);
            // 
            // btnReport
            // 
            this.btnReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.Location = new System.Drawing.Point(25, 280);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(292, 38);
            this.btnReport.TabIndex = 6;
            this.btnReport.Text = "Report";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 403);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnRentals);
            this.Controls.Add(this.btnCustomer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnMovies);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main  Menu";
            this.Load += new System.EventHandler(this.frmMenu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMovies;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCustomer;
        private System.Windows.Forms.Button btnRentals;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.Button btnReport;
    }
}

