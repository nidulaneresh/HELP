
namespace ContactManager
{
    partial class Form_Employee
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Employee));
            this.TxtSearchDB = new System.Windows.Forms.TextBox();
            this.LblDashboard = new System.Windows.Forms.Label();
            this.GrdEmployees = new System.Windows.Forms.DataGridView();
            this.CmdCreateEmployee = new System.Windows.Forms.Button();
            this.CmdModifyEmployee = new System.Windows.Forms.Button();
            this.CmdDeleteEmployee = new System.Windows.Forms.Button();
            this.CmdSaveEmployee = new System.Windows.Forms.Button();
            this.CmdCreateTrainee = new System.Windows.Forms.Button();
            this.CmdCancel = new System.Windows.Forms.Button();
            this.TxtHistory = new System.Windows.Forms.TextBox();
            this.LblHistory = new System.Windows.Forms.Label();
            this.ChkEmployee = new System.Windows.Forms.CheckBox();
            this.ChkTrainees = new System.Windows.Forms.CheckBox();
            this.PbBackToDashboard = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.LblMandatoryField = new System.Windows.Forms.Label();
            this.LblReadOnlyField = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.LblModifiableField = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.LblLegend = new System.Windows.Forms.Label();
            this.contactBookBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.employeeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CmdVCardImport = new System.Windows.Forms.Button();
            this.CmdCSVImport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GrdEmployees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbBackToDashboard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contactBookBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtSearchDB
            // 
            this.TxtSearchDB.Font = new System.Drawing.Font("Gadugi", 14.25F, System.Drawing.FontStyle.Bold);
            this.TxtSearchDB.Location = new System.Drawing.Point(363, 77);
            this.TxtSearchDB.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.TxtSearchDB.Name = "TxtSearchDB";
            this.TxtSearchDB.Size = new System.Drawing.Size(722, 33);
            this.TxtSearchDB.TabIndex = 17;
            this.TxtSearchDB.TextChanged += new System.EventHandler(this.TxtSearchDB_TextChanged);
            // 
            // LblDashboard
            // 
            this.LblDashboard.AutoSize = true;
            this.LblDashboard.BackColor = System.Drawing.Color.Transparent;
            this.LblDashboard.Font = new System.Drawing.Font("Rage Italic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDashboard.ForeColor = System.Drawing.Color.White;
            this.LblDashboard.Location = new System.Drawing.Point(20, 119);
            this.LblDashboard.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.LblDashboard.Name = "LblDashboard";
            this.LblDashboard.Size = new System.Drawing.Size(117, 34);
            this.LblDashboard.TabIndex = 20;
            this.LblDashboard.Text = "Dashboard";
            this.LblDashboard.UseMnemonic = false;
            // 
            // GrdEmployees
            // 
            this.GrdEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdEmployees.Location = new System.Drawing.Point(12, 254);
            this.GrdEmployees.Name = "GrdEmployees";
            this.GrdEmployees.Size = new System.Drawing.Size(1460, 476);
            this.GrdEmployees.TabIndex = 21;
            this.GrdEmployees.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdEmployees_CellClick);
            this.GrdEmployees.Scroll += new System.Windows.Forms.ScrollEventHandler(this.GrdEmployees_Scroll);
            // 
            // CmdCreateEmployee
            // 
            this.CmdCreateEmployee.Location = new System.Drawing.Point(10, 225);
            this.CmdCreateEmployee.Name = "CmdCreateEmployee";
            this.CmdCreateEmployee.Size = new System.Drawing.Size(120, 23);
            this.CmdCreateEmployee.TabIndex = 22;
            this.CmdCreateEmployee.Text = "Add New Employee";
            this.CmdCreateEmployee.UseVisualStyleBackColor = true;
            this.CmdCreateEmployee.Click += new System.EventHandler(this.CmdCreateEmployee_Click);
            // 
            // CmdModifyEmployee
            // 
            this.CmdModifyEmployee.Location = new System.Drawing.Point(363, 225);
            this.CmdModifyEmployee.Name = "CmdModifyEmployee";
            this.CmdModifyEmployee.Size = new System.Drawing.Size(113, 23);
            this.CmdModifyEmployee.TabIndex = 23;
            this.CmdModifyEmployee.Text = "Modify Selected";
            this.CmdModifyEmployee.UseVisualStyleBackColor = true;
            this.CmdModifyEmployee.Click += new System.EventHandler(this.CmdModifyEmployee_Click);
            // 
            // CmdDeleteEmployee
            // 
            this.CmdDeleteEmployee.Location = new System.Drawing.Point(482, 225);
            this.CmdDeleteEmployee.Name = "CmdDeleteEmployee";
            this.CmdDeleteEmployee.Size = new System.Drawing.Size(110, 23);
            this.CmdDeleteEmployee.TabIndex = 24;
            this.CmdDeleteEmployee.Text = "Delete Selected";
            this.CmdDeleteEmployee.UseVisualStyleBackColor = true;
            this.CmdDeleteEmployee.Click += new System.EventHandler(this.CmdDeleteEmployee_Click);
            // 
            // CmdSaveEmployee
            // 
            this.CmdSaveEmployee.Location = new System.Drawing.Point(742, 225);
            this.CmdSaveEmployee.Name = "CmdSaveEmployee";
            this.CmdSaveEmployee.Size = new System.Drawing.Size(75, 23);
            this.CmdSaveEmployee.TabIndex = 25;
            this.CmdSaveEmployee.Text = "Save";
            this.CmdSaveEmployee.UseVisualStyleBackColor = true;
            this.CmdSaveEmployee.Click += new System.EventHandler(this.CmdSaveEmployee_Click);
            // 
            // CmdCreateTrainee
            // 
            this.CmdCreateTrainee.Location = new System.Drawing.Point(138, 225);
            this.CmdCreateTrainee.Name = "CmdCreateTrainee";
            this.CmdCreateTrainee.Size = new System.Drawing.Size(120, 23);
            this.CmdCreateTrainee.TabIndex = 27;
            this.CmdCreateTrainee.Text = "Add New Trainee";
            this.CmdCreateTrainee.UseVisualStyleBackColor = true;
            this.CmdCreateTrainee.Click += new System.EventHandler(this.CmdCreateTrainee_Click);
            // 
            // CmdCancel
            // 
            this.CmdCancel.Location = new System.Drawing.Point(823, 225);
            this.CmdCancel.Name = "CmdCancel";
            this.CmdCancel.Size = new System.Drawing.Size(75, 23);
            this.CmdCancel.TabIndex = 28;
            this.CmdCancel.Text = "Cancel";
            this.CmdCancel.UseVisualStyleBackColor = true;
            this.CmdCancel.Click += new System.EventHandler(this.CmdCancel_Click);
            // 
            // TxtHistory
            // 
            this.TxtHistory.BackColor = System.Drawing.SystemColors.ControlLight;
            this.TxtHistory.Location = new System.Drawing.Point(12, 803);
            this.TxtHistory.Multiline = true;
            this.TxtHistory.Name = "TxtHistory";
            this.TxtHistory.ReadOnly = true;
            this.TxtHistory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtHistory.Size = new System.Drawing.Size(959, 146);
            this.TxtHistory.TabIndex = 30;
            // 
            // LblHistory
            // 
            this.LblHistory.AutoSize = true;
            this.LblHistory.BackColor = System.Drawing.Color.Transparent;
            this.LblHistory.Font = new System.Drawing.Font("Rage Italic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblHistory.ForeColor = System.Drawing.Color.White;
            this.LblHistory.Location = new System.Drawing.Point(13, 759);
            this.LblHistory.Name = "LblHistory";
            this.LblHistory.Size = new System.Drawing.Size(87, 34);
            this.LblHistory.TabIndex = 32;
            this.LblHistory.Text = "History";
            // 
            // ChkEmployee
            // 
            this.ChkEmployee.AutoSize = true;
            this.ChkEmployee.Checked = true;
            this.ChkEmployee.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkEmployee.Location = new System.Drawing.Point(1262, 231);
            this.ChkEmployee.Name = "ChkEmployee";
            this.ChkEmployee.Size = new System.Drawing.Size(107, 17);
            this.ChkEmployee.TabIndex = 33;
            this.ChkEmployee.Text = "Show Employees";
            this.ChkEmployee.UseVisualStyleBackColor = true;
            this.ChkEmployee.CheckedChanged += new System.EventHandler(this.ChkEmployee_CheckedChanged);
            // 
            // ChkTrainees
            // 
            this.ChkTrainees.AutoSize = true;
            this.ChkTrainees.Checked = true;
            this.ChkTrainees.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkTrainees.Location = new System.Drawing.Point(1375, 231);
            this.ChkTrainees.Name = "ChkTrainees";
            this.ChkTrainees.Size = new System.Drawing.Size(97, 17);
            this.ChkTrainees.TabIndex = 34;
            this.ChkTrainees.Text = "Show Trainees";
            this.ChkTrainees.UseVisualStyleBackColor = true;
            this.ChkTrainees.CheckedChanged += new System.EventHandler(this.ChkEmployee_CheckedChanged);
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
            this.PbBackToDashboard.TabIndex = 16;
            this.PbBackToDashboard.TabStop = false;
            this.PbBackToDashboard.Click += new System.EventHandler(this.PbBackToDashboard_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1484, 961);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.ErrorImage = null;
            this.pictureBox2.Location = new System.Drawing.Point(308, 72);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(50, 41);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 35;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Thistle;
            this.pictureBox3.Location = new System.Drawing.Point(1281, 807);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(20, 20);
            this.pictureBox3.TabIndex = 36;
            this.pictureBox3.TabStop = false;
            // 
            // LblMandatoryField
            // 
            this.LblMandatoryField.AutoSize = true;
            this.LblMandatoryField.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMandatoryField.ForeColor = System.Drawing.Color.White;
            this.LblMandatoryField.Location = new System.Drawing.Point(1304, 806);
            this.LblMandatoryField.Name = "LblMandatoryField";
            this.LblMandatoryField.Size = new System.Drawing.Size(122, 20);
            this.LblMandatoryField.TabIndex = 37;
            this.LblMandatoryField.Text = "Mandatory Field";
            // 
            // LblReadOnlyField
            // 
            this.LblReadOnlyField.AutoSize = true;
            this.LblReadOnlyField.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblReadOnlyField.ForeColor = System.Drawing.Color.White;
            this.LblReadOnlyField.Location = new System.Drawing.Point(1304, 845);
            this.LblReadOnlyField.Name = "LblReadOnlyField";
            this.LblReadOnlyField.Size = new System.Drawing.Size(121, 20);
            this.LblReadOnlyField.TabIndex = 39;
            this.LblReadOnlyField.Text = "Read Only Field";
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.LightGray;
            this.pictureBox4.Location = new System.Drawing.Point(1281, 845);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(20, 20);
            this.pictureBox4.TabIndex = 38;
            this.pictureBox4.TabStop = false;
            // 
            // LblModifiableField
            // 
            this.LblModifiableField.AutoSize = true;
            this.LblModifiableField.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblModifiableField.ForeColor = System.Drawing.Color.White;
            this.LblModifiableField.Location = new System.Drawing.Point(1304, 884);
            this.LblModifiableField.Name = "LblModifiableField";
            this.LblModifiableField.Size = new System.Drawing.Size(119, 20);
            this.LblModifiableField.TabIndex = 41;
            this.LblModifiableField.Text = "Modifiable Field";
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.White;
            this.pictureBox5.Location = new System.Drawing.Point(1281, 884);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(20, 20);
            this.pictureBox5.TabIndex = 40;
            this.pictureBox5.TabStop = false;
            // 
            // LblLegend
            // 
            this.LblLegend.AutoSize = true;
            this.LblLegend.BackColor = System.Drawing.Color.Transparent;
            this.LblLegend.Font = new System.Drawing.Font("Rage Italic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblLegend.ForeColor = System.Drawing.Color.White;
            this.LblLegend.Location = new System.Drawing.Point(1301, 759);
            this.LblLegend.Name = "LblLegend";
            this.LblLegend.Size = new System.Drawing.Size(86, 34);
            this.LblLegend.TabIndex = 42;
            this.LblLegend.Text = "Legend";
            // 
            // contactBookBindingSource
            // 
            //this.contactBookBindingSource.DataSource = typeof(ContactManager.ContactBook);
            // 
            // employeeBindingSource
            // 
            //this.employeeBindingSource.DataSource = typeof(ContactManager.Employee);
            // 
            // CmdVCardImport
            // 
            this.CmdVCardImport.Location = new System.Drawing.Point(998, 225);
            this.CmdVCardImport.Margin = new System.Windows.Forms.Padding(2);
            this.CmdVCardImport.Name = "CmdVCardImport";
            this.CmdVCardImport.Size = new System.Drawing.Size(120, 23);
            this.CmdVCardImport.TabIndex = 55;
            this.CmdVCardImport.Text = "Import VCard";
            this.CmdVCardImport.UseVisualStyleBackColor = true;
            this.CmdVCardImport.Click += new System.EventHandler(this.CmdVCardImport_Click);
            // 
            // CmdCSVImport
            // 
            this.CmdCSVImport.Location = new System.Drawing.Point(1122, 225);
            this.CmdCSVImport.Margin = new System.Windows.Forms.Padding(2);
            this.CmdCSVImport.Name = "CmdCSVImport";
            this.CmdCSVImport.Size = new System.Drawing.Size(120, 23);
            this.CmdCSVImport.TabIndex = 54;
            this.CmdCSVImport.Text = "Import CSV";
            this.CmdCSVImport.UseVisualStyleBackColor = true;
            this.CmdCSVImport.Click += new System.EventHandler(this.CmdCSVImport_Click);
            // 
            // Form_Employee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1484, 961);
            this.Controls.Add(this.CmdVCardImport);
            this.Controls.Add(this.CmdCSVImport);
            this.Controls.Add(this.LblLegend);
            this.Controls.Add(this.LblModifiableField);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.LblReadOnlyField);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.LblMandatoryField);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.ChkTrainees);
            this.Controls.Add(this.ChkEmployee);
            this.Controls.Add(this.LblHistory);
            this.Controls.Add(this.TxtHistory);
            this.Controls.Add(this.CmdCancel);
            this.Controls.Add(this.CmdCreateTrainee);
            this.Controls.Add(this.CmdSaveEmployee);
            this.Controls.Add(this.CmdDeleteEmployee);
            this.Controls.Add(this.CmdModifyEmployee);
            this.Controls.Add(this.CmdCreateEmployee);
            this.Controls.Add(this.GrdEmployees);
            this.Controls.Add(this.LblDashboard);
            this.Controls.Add(this.TxtSearchDB);
            this.Controls.Add(this.PbBackToDashboard);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Employee";
            this.Text = "Employee";
            this.Load += new System.EventHandler(this.Form_Employee_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GrdEmployees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbBackToDashboard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contactBookBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox PbBackToDashboard;
        private System.Windows.Forms.TextBox TxtSearchDB;
        private System.Windows.Forms.Label LblDashboard;
        private System.Windows.Forms.DataGridView GrdEmployees;
        private System.Windows.Forms.Button CmdCreateEmployee;
        private System.Windows.Forms.Button CmdModifyEmployee;
        private System.Windows.Forms.Button CmdDeleteEmployee;
        private System.Windows.Forms.Button CmdSaveEmployee;
        private System.Windows.Forms.Button CmdCreateTrainee;
        private System.Windows.Forms.Button CmdCancel;
        private System.Windows.Forms.TextBox TxtHistory;
        private System.Windows.Forms.Label LblHistory;
        private System.Windows.Forms.CheckBox ChkEmployee;
        private System.Windows.Forms.CheckBox ChkTrainees;
        private System.Windows.Forms.BindingSource contactBookBindingSource;
        private System.Windows.Forms.BindingSource employeeBindingSource;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label LblMandatoryField;
        private System.Windows.Forms.Label LblReadOnlyField;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label LblModifiableField;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label LblLegend;
        private System.Windows.Forms.Button CmdVCardImport;
        private System.Windows.Forms.Button CmdCSVImport;
    }
}