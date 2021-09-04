
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
            this.TxtSearchDB = new System.Windows.Forms.TextBox();
            this.LblDashboard = new System.Windows.Forms.Label();
            this.GrdContactDocs = new System.Windows.Forms.DataGridView();
            this.CmdCancel = new System.Windows.Forms.Button();
            this.CmdSaveContactDoc = new System.Windows.Forms.Button();
            this.CmdDeleteContactDoc = new System.Windows.Forms.Button();
            this.CmdModifyContactDoc = new System.Windows.Forms.Button();
            this.CmdCreateContactDoc = new System.Windows.Forms.Button();
            this.LblHistory = new System.Windows.Forms.Label();
            this.TxtHistory = new System.Windows.Forms.TextBox();
            this.PbBackToDashboard = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.LblLegend = new System.Windows.Forms.Label();
            this.LblModifiableField = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.LblReadOnlyField = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.LblMandatoryField = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.GrdContactDocs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbBackToDashboard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtSearchDB
            // 
            this.TxtSearchDB.Font = new System.Drawing.Font("Gadugi", 14.25F, System.Drawing.FontStyle.Bold);
            this.TxtSearchDB.Location = new System.Drawing.Point(363, 77);
            this.TxtSearchDB.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.TxtSearchDB.Name = "TxtSearchDB";
            this.TxtSearchDB.Size = new System.Drawing.Size(722, 33);
            this.TxtSearchDB.TabIndex = 18;
            this.TxtSearchDB.TextChanged += new System.EventHandler(this.TxtSearchDB_TextChanged);
            this.TxtSearchDB.Enter += new System.EventHandler(this.TxtSearchDB_Enter);
            // 
            // LblDashboard
            // 
            this.LblDashboard.AutoSize = true;
            this.LblDashboard.BackColor = System.Drawing.Color.Transparent;
            this.LblDashboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.LblDashboard.ForeColor = System.Drawing.Color.White;
            this.LblDashboard.Location = new System.Drawing.Point(20, 119);
            this.LblDashboard.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.LblDashboard.Name = "LblDashboard";
            this.LblDashboard.Size = new System.Drawing.Size(147, 31);
            this.LblDashboard.TabIndex = 19;
            this.LblDashboard.Text = "Dashboard";
            this.LblDashboard.UseMnemonic = false;
            // 
            // GrdContactDocs
            // 
            this.GrdContactDocs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GrdContactDocs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdContactDocs.Location = new System.Drawing.Point(12, 254);
            this.GrdContactDocs.Name = "GrdContactDocs";
            this.GrdContactDocs.RowHeadersWidth = 51;
            this.GrdContactDocs.Size = new System.Drawing.Size(1460, 476);
            this.GrdContactDocs.TabIndex = 20;
            this.GrdContactDocs.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GrdContactDocs_CellClick);
            // 
            // CmdCancel
            // 
            this.CmdCancel.Location = new System.Drawing.Point(823, 225);
            this.CmdCancel.Name = "CmdCancel";
            this.CmdCancel.Size = new System.Drawing.Size(75, 23);
            this.CmdCancel.TabIndex = 33;
            this.CmdCancel.Text = "Cancel";
            this.CmdCancel.UseVisualStyleBackColor = true;
            this.CmdCancel.Click += new System.EventHandler(this.CmdCancel_Click);
            // 
            // CmdSaveContactDoc
            // 
            this.CmdSaveContactDoc.Location = new System.Drawing.Point(742, 225);
            this.CmdSaveContactDoc.Name = "CmdSaveContactDoc";
            this.CmdSaveContactDoc.Size = new System.Drawing.Size(75, 23);
            this.CmdSaveContactDoc.TabIndex = 32;
            this.CmdSaveContactDoc.Text = "Save";
            this.CmdSaveContactDoc.UseVisualStyleBackColor = true;
            this.CmdSaveContactDoc.Click += new System.EventHandler(this.CmdSaveContactDoc_Click);
            // 
            // CmdDeleteContactDoc
            // 
            this.CmdDeleteContactDoc.Location = new System.Drawing.Point(482, 225);
            this.CmdDeleteContactDoc.Name = "CmdDeleteContactDoc";
            this.CmdDeleteContactDoc.Size = new System.Drawing.Size(110, 23);
            this.CmdDeleteContactDoc.TabIndex = 31;
            this.CmdDeleteContactDoc.Text = "Delete Selected";
            this.CmdDeleteContactDoc.UseVisualStyleBackColor = true;
            this.CmdDeleteContactDoc.Click += new System.EventHandler(this.CmdDeleteContactDoc_Click);
            // 
            // CmdModifyContactDoc
            // 
            this.CmdModifyContactDoc.Location = new System.Drawing.Point(363, 225);
            this.CmdModifyContactDoc.Name = "CmdModifyContactDoc";
            this.CmdModifyContactDoc.Size = new System.Drawing.Size(113, 23);
            this.CmdModifyContactDoc.TabIndex = 30;
            this.CmdModifyContactDoc.Text = "Modify Selected";
            this.CmdModifyContactDoc.UseVisualStyleBackColor = true;
            this.CmdModifyContactDoc.Click += new System.EventHandler(this.CmdModifyContactDoc_Click);
            // 
            // CmdCreateContactDoc
            // 
            this.CmdCreateContactDoc.Location = new System.Drawing.Point(12, 225);
            this.CmdCreateContactDoc.Name = "CmdCreateContactDoc";
            this.CmdCreateContactDoc.Size = new System.Drawing.Size(120, 23);
            this.CmdCreateContactDoc.TabIndex = 29;
            this.CmdCreateContactDoc.Text = "Add New ContactDoc";
            this.CmdCreateContactDoc.UseVisualStyleBackColor = true;
            this.CmdCreateContactDoc.Click += new System.EventHandler(this.CmdCreateContactDoc_Click);
            // 
            // LblHistory
            // 
            this.LblHistory.AutoSize = true;
            this.LblHistory.BackColor = System.Drawing.Color.Transparent;
            this.LblHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.LblHistory.ForeColor = System.Drawing.Color.White;
            this.LblHistory.Location = new System.Drawing.Point(13, 759);
            this.LblHistory.Name = "LblHistory";
            this.LblHistory.Size = new System.Drawing.Size(100, 31);
            this.LblHistory.TabIndex = 36;
            this.LblHistory.Text = "History";
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
            this.TxtHistory.TabIndex = 35;
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
            this.pictureBox1.Size = new System.Drawing.Size(1484, 962);
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
            this.pictureBox2.TabIndex = 37;
            this.pictureBox2.TabStop = false;
            // 
            // LblLegend
            // 
            this.LblLegend.AutoSize = true;
            this.LblLegend.BackColor = System.Drawing.Color.Transparent;
            this.LblLegend.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblLegend.ForeColor = System.Drawing.Color.White;
            this.LblLegend.Location = new System.Drawing.Point(1301, 759);
            this.LblLegend.Name = "LblLegend";
            this.LblLegend.Size = new System.Drawing.Size(104, 31);
            this.LblLegend.TabIndex = 49;
            this.LblLegend.Text = "Legend";
            // 
            // LblModifiableField
            // 
            this.LblModifiableField.AutoSize = true;
            this.LblModifiableField.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblModifiableField.ForeColor = System.Drawing.Color.White;
            this.LblModifiableField.Location = new System.Drawing.Point(1304, 884);
            this.LblModifiableField.Name = "LblModifiableField";
            this.LblModifiableField.Size = new System.Drawing.Size(119, 20);
            this.LblModifiableField.TabIndex = 48;
            this.LblModifiableField.Text = "Modifiable Field";
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.White;
            this.pictureBox5.Location = new System.Drawing.Point(1281, 884);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(20, 20);
            this.pictureBox5.TabIndex = 47;
            this.pictureBox5.TabStop = false;
            // 
            // LblReadOnlyField
            // 
            this.LblReadOnlyField.AutoSize = true;
            this.LblReadOnlyField.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblReadOnlyField.ForeColor = System.Drawing.Color.White;
            this.LblReadOnlyField.Location = new System.Drawing.Point(1304, 845);
            this.LblReadOnlyField.Name = "LblReadOnlyField";
            this.LblReadOnlyField.Size = new System.Drawing.Size(121, 20);
            this.LblReadOnlyField.TabIndex = 46;
            this.LblReadOnlyField.Text = "Read Only Field";
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.LightGray;
            this.pictureBox4.Location = new System.Drawing.Point(1281, 845);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(20, 20);
            this.pictureBox4.TabIndex = 45;
            this.pictureBox4.TabStop = false;
            // 
            // LblMandatoryField
            // 
            this.LblMandatoryField.AutoSize = true;
            this.LblMandatoryField.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMandatoryField.ForeColor = System.Drawing.Color.White;
            this.LblMandatoryField.Location = new System.Drawing.Point(1304, 806);
            this.LblMandatoryField.Name = "LblMandatoryField";
            this.LblMandatoryField.Size = new System.Drawing.Size(122, 20);
            this.LblMandatoryField.TabIndex = 44;
            this.LblMandatoryField.Text = "Mandatory Field";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Thistle;
            this.pictureBox3.Location = new System.Drawing.Point(1281, 807);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(20, 20);
            this.pictureBox3.TabIndex = 43;
            this.pictureBox3.TabStop = false;
            // 
            // Form_ContactDoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1484, 962);
            this.Controls.Add(this.LblLegend);
            this.Controls.Add(this.LblModifiableField);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.LblReadOnlyField);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.LblMandatoryField);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.LblHistory);
            this.Controls.Add(this.TxtHistory);
            this.Controls.Add(this.CmdCancel);
            this.Controls.Add(this.CmdSaveContactDoc);
            this.Controls.Add(this.CmdDeleteContactDoc);
            this.Controls.Add(this.CmdModifyContactDoc);
            this.Controls.Add(this.CmdCreateContactDoc);
            this.Controls.Add(this.GrdContactDocs);
            this.Controls.Add(this.LblDashboard);
            this.Controls.Add(this.TxtSearchDB);
            this.Controls.Add(this.PbBackToDashboard);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_ContactDoc";
            this.Text = "ContactDoc";
            this.Load += new System.EventHandler(this.Form_ContactDoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GrdContactDocs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbBackToDashboard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox PbBackToDashboard;
        private System.Windows.Forms.TextBox TxtSearchDB;
        private System.Windows.Forms.Label LblDashboard;
        private System.Windows.Forms.DataGridView GrdContactDocs;
        private System.Windows.Forms.Button CmdCancel;
        private System.Windows.Forms.Button CmdSaveContactDoc;
        private System.Windows.Forms.Button CmdDeleteContactDoc;
        private System.Windows.Forms.Button CmdModifyContactDoc;
        private System.Windows.Forms.Button CmdCreateContactDoc;
        private System.Windows.Forms.Label LblHistory;
        private System.Windows.Forms.TextBox TxtHistory;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label LblLegend;
        private System.Windows.Forms.Label LblModifiableField;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label LblReadOnlyField;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label LblMandatoryField;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}