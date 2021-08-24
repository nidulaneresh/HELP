
namespace ContactManager
{
    partial class Form_ContactDoc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ContactDoc));
            this.PbBackToDashboard = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.TxtSearchDB = new System.Windows.Forms.TextBox();
            this.LblDashboard = new System.Windows.Forms.Label();
            this.ContactGridview = new System.Windows.Forms.DataGridView();
            this.CmdCancel = new System.Windows.Forms.Button();
            this.CmdSaveEmployee = new System.Windows.Forms.Button();
            this.CmdDeleteEmployee = new System.Windows.Forms.Button();
            this.CmdModifyEmployee = new System.Windows.Forms.Button();
            this.CmdCreateEmployee = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PbBackToDashboard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContactGridview)).BeginInit();
            this.SuspendLayout();
            // 
            // PbBackToDashboard
            // 
            this.PbBackToDashboard.BackColor = System.Drawing.Color.Transparent;
            this.PbBackToDashboard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PbBackToDashboard.Image = global::ContactManager.Properties.Resources.Dashboard;
            this.PbBackToDashboard.Location = new System.Drawing.Point(41, 56);
            this.PbBackToDashboard.Name = "PbBackToDashboard";
            this.PbBackToDashboard.Size = new System.Drawing.Size(77, 64);
            this.PbBackToDashboard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbBackToDashboard.TabIndex = 15;
            this.PbBackToDashboard.TabStop = false;
            this.PbBackToDashboard.Click += new System.EventHandler(this.PbBackToDashboard_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1443, 857);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // TxtSearchDB
            // 
            this.TxtSearchDB.Font = new System.Drawing.Font("Gadugi", 14.25F, System.Drawing.FontStyle.Bold);
            this.TxtSearchDB.Location = new System.Drawing.Point(363, 77);
            this.TxtSearchDB.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.TxtSearchDB.Name = "TxtSearchDB";
            this.TxtSearchDB.Size = new System.Drawing.Size(722, 33);
            this.TxtSearchDB.TabIndex = 18;
            this.TxtSearchDB.Enter += new System.EventHandler(this.TxtSearchDB_Enter);
            // 
            // LblDashboard
            // 
            this.LblDashboard.AutoSize = true;
            this.LblDashboard.BackColor = System.Drawing.Color.Transparent;
            this.LblDashboard.Font = new System.Drawing.Font("Rage Italic", 20F);
            this.LblDashboard.ForeColor = System.Drawing.Color.White;
            this.LblDashboard.Location = new System.Drawing.Point(20, 119);
            this.LblDashboard.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.LblDashboard.Name = "LblDashboard";
            this.LblDashboard.Size = new System.Drawing.Size(117, 34);
            this.LblDashboard.TabIndex = 19;
            this.LblDashboard.Text = "Dashboard";
            this.LblDashboard.UseMnemonic = false;
            // 
            // ContactGridview
            // 
            this.ContactGridview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ContactGridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ContactGridview.Location = new System.Drawing.Point(343, 320);
            this.ContactGridview.Name = "ContactGridview";
            this.ContactGridview.RowHeadersWidth = 51;
            this.ContactGridview.Size = new System.Drawing.Size(793, 416);
            this.ContactGridview.TabIndex = 20;
            // 
            // CmdCancel
            // 
            this.CmdCancel.Location = new System.Drawing.Point(1061, 291);
            this.CmdCancel.Name = "CmdCancel";
            this.CmdCancel.Size = new System.Drawing.Size(75, 23);
            this.CmdCancel.TabIndex = 33;
            this.CmdCancel.Text = "Cancel";
            this.CmdCancel.UseVisualStyleBackColor = true;
            this.CmdCancel.Click += new System.EventHandler(this.CmdCancel_Click);
            // 
            // CmdSaveEmployee
            // 
            this.CmdSaveEmployee.Location = new System.Drawing.Point(980, 291);
            this.CmdSaveEmployee.Name = "CmdSaveEmployee";
            this.CmdSaveEmployee.Size = new System.Drawing.Size(75, 23);
            this.CmdSaveEmployee.TabIndex = 32;
            this.CmdSaveEmployee.Text = "Save";
            this.CmdSaveEmployee.UseVisualStyleBackColor = true;
            this.CmdSaveEmployee.Click += new System.EventHandler(this.CmdSaveEmployee_Click);
            // 
            // CmdDeleteEmployee
            // 
            this.CmdDeleteEmployee.Location = new System.Drawing.Point(671, 291);
            this.CmdDeleteEmployee.Name = "CmdDeleteEmployee";
            this.CmdDeleteEmployee.Size = new System.Drawing.Size(110, 23);
            this.CmdDeleteEmployee.TabIndex = 31;
            this.CmdDeleteEmployee.Text = "Delete Selected";
            this.CmdDeleteEmployee.UseVisualStyleBackColor = true;
            this.CmdDeleteEmployee.Click += new System.EventHandler(this.CmdDeleteEmployee_Click);
            // 
            // CmdModifyEmployee
            // 
            this.CmdModifyEmployee.Location = new System.Drawing.Point(552, 291);
            this.CmdModifyEmployee.Name = "CmdModifyEmployee";
            this.CmdModifyEmployee.Size = new System.Drawing.Size(113, 23);
            this.CmdModifyEmployee.TabIndex = 30;
            this.CmdModifyEmployee.Text = "Modify Selected";
            this.CmdModifyEmployee.UseVisualStyleBackColor = true;
            this.CmdModifyEmployee.Click += new System.EventHandler(this.CmdModifyEmployee_Click);
            // 
            // CmdCreateEmployee
            // 
            this.CmdCreateEmployee.Location = new System.Drawing.Point(343, 291);
            this.CmdCreateEmployee.Name = "CmdCreateEmployee";
            this.CmdCreateEmployee.Size = new System.Drawing.Size(120, 23);
            this.CmdCreateEmployee.TabIndex = 29;
            this.CmdCreateEmployee.Text = "Add New ContactDoc";
            this.CmdCreateEmployee.UseVisualStyleBackColor = true;
            this.CmdCreateEmployee.Click += new System.EventHandler(this.CmdCreateEmployee_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(343, 249);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 23);
            this.button1.TabIndex = 34;
            this.button1.Text = "Import CSV";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.BtnImportCSV_Click);
            // 
            // Form_ContactDoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1443, 857);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CmdCancel);
            this.Controls.Add(this.CmdSaveEmployee);
            this.Controls.Add(this.CmdDeleteEmployee);
            this.Controls.Add(this.CmdModifyEmployee);
            this.Controls.Add(this.CmdCreateEmployee);
            this.Controls.Add(this.ContactGridview);
            this.Controls.Add(this.LblDashboard);
            this.Controls.Add(this.TxtSearchDB);
            this.Controls.Add(this.PbBackToDashboard);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form_ContactDoc";
            this.Text = "Form_ContactDoc";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form_ContactDoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PbBackToDashboard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContactGridview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox PbBackToDashboard;
        private System.Windows.Forms.TextBox TxtSearchDB;
        private System.Windows.Forms.Label LblDashboard;
        private System.Windows.Forms.DataGridView ContactGridview;
        private System.Windows.Forms.Button CmdCancel;
        private System.Windows.Forms.Button CmdSaveEmployee;
        private System.Windows.Forms.Button CmdDeleteEmployee;
        private System.Windows.Forms.Button CmdModifyEmployee;
        private System.Windows.Forms.Button CmdCreateEmployee;
    private System.Windows.Forms.Button button1;
  }
}