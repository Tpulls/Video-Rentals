namespace Rentals
{
    partial class frmRentalList
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
            this.btnClose = new System.Windows.Forms.Button();
            this.dgvRentals = new System.Windows.Forms.DataGridView();
            this.lnkAdd = new System.Windows.Forms.LinkLabel();
            this.btnMovieList = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRentals)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(338, 416);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(103, 27);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dgvRentals
            // 
            this.dgvRentals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRentals.Location = new System.Drawing.Point(12, 79);
            this.dgvRentals.Name = "dgvRentals";
            this.dgvRentals.RowHeadersWidth = 51;
            this.dgvRentals.RowTemplate.Height = 24;
            this.dgvRentals.Size = new System.Drawing.Size(429, 331);
            this.dgvRentals.TabIndex = 10;
            this.dgvRentals.DoubleClick += new System.EventHandler(this.dgvRentals_DoubleClick);
            // 
            // lnkAdd
            // 
            this.lnkAdd.AutoSize = true;
            this.lnkAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkAdd.Location = new System.Drawing.Point(7, 47);
            this.lnkAdd.Name = "lnkAdd";
            this.lnkAdd.Size = new System.Drawing.Size(201, 29);
            this.lnkAdd.TabIndex = 9;
            this.lnkAdd.TabStop = true;
            this.lnkAdd.Text = "Add New Rental";
            this.lnkAdd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAdd_LinkClicked);
            // 
            // btnMovieList
            // 
            this.btnMovieList.AutoSize = true;
            this.btnMovieList.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMovieList.Location = new System.Drawing.Point(7, 8);
            this.btnMovieList.Name = "btnMovieList";
            this.btnMovieList.Size = new System.Drawing.Size(136, 29);
            this.btnMovieList.TabIndex = 8;
            this.btnMovieList.Text = "Rental List";
            // 
            // frmRentalList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 450);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvRentals);
            this.Controls.Add(this.lnkAdd);
            this.Controls.Add(this.btnMovieList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmRentalList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rental List";
            this.Load += new System.EventHandler(this.frmRentalList_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmRentalList_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRentals)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvRentals;
        private System.Windows.Forms.LinkLabel lnkAdd;
        private System.Windows.Forms.Label btnMovieList;
    }
}