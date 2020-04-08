namespace Rentals
{
    partial class frmRentalItem
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
            this.cboMovie = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRentalId = new System.Windows.Forms.TextBox();
            this.txtBox = new System.Windows.Forms.Label();
            this.btnMovieList = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cboMovie
            // 
            this.cboMovie.FormattingEnabled = true;
            this.cboMovie.Location = new System.Drawing.Point(177, 115);
            this.cboMovie.Name = "cboMovie";
            this.cboMovie.Size = new System.Drawing.Size(243, 24);
            this.cboMovie.TabIndex = 30;
            this.cboMovie.SelectedIndexChanged += new System.EventHandler(this.cboMovie_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 25);
            this.label1.TabIndex = 29;
            this.label1.Text = "Movie: ";
            // 
            // txtRentalId
            // 
            this.txtRentalId.Location = new System.Drawing.Point(177, 69);
            this.txtRentalId.Name = "txtRentalId";
            this.txtRentalId.Size = new System.Drawing.Size(120, 22);
            this.txtRentalId.TabIndex = 28;
            // 
            // txtBox
            // 
            this.txtBox.AutoSize = true;
            this.txtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBox.Location = new System.Drawing.Point(15, 69);
            this.txtBox.Name = "txtBox";
            this.txtBox.Size = new System.Drawing.Size(107, 25);
            this.txtBox.TabIndex = 27;
            this.txtBox.Text = "Rental ID:";
            // 
            // btnMovieList
            // 
            this.btnMovieList.AutoSize = true;
            this.btnMovieList.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMovieList.Location = new System.Drawing.Point(281, 9);
            this.btnMovieList.Name = "btnMovieList";
            this.btnMovieList.Size = new System.Drawing.Size(145, 29);
            this.btnMovieList.TabIndex = 26;
            this.btnMovieList.Text = "Rental Item";
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(244, 164);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(86, 27);
            this.btnSave.TabIndex = 32;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(336, 165);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(86, 27);
            this.btnClose.TabIndex = 31;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // frmRentalItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 208);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.cboMovie);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRentalId);
            this.Controls.Add(this.txtBox);
            this.Controls.Add(this.btnMovieList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmRentalItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rental Item";
            this.Load += new System.EventHandler(this.frmRentalItem_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmRentalItem_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboMovie;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRentalId;
        private System.Windows.Forms.Label txtBox;
        private System.Windows.Forms.Label btnMovieList;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
    }
}