
namespace ContactManager
{
    partial class Form_Customer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Customer));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PbBackToDashboard = new System.Windows.Forms.PictureBox();
            this.TxtSearchDB = new System.Windows.Forms.TextBox();
            this.LblDashboard = new System.Windows.Forms.Label();
            this.LblHistory = new System.Windows.Forms.Label();
            this.CmdTest = new System.Windows.Forms.Button();
            this.TxtHistory = new System.Windows.Forms.TextBox();
            this.CmdShowHelp = new System.Windows.Forms.Button();
            this.CmdCancel = new System.Windows.Forms.Button();
            this.CmdSaveCustomer = new System.Windows.Forms.Button();
            this.CmdDeleteCustomer = new System.Windows.Forms.Button();
            this.CmdModifyCustomer = new System.Windows.Forms.Button();
            this.CmdCreateCustomer = new System.Windows.Forms.Button();
            this.GrdCustomer = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbBackToDashboard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdCustomer)).BeginInit();
            this.SuspendLayout();
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
            // TxtSearchDB
            // 
            this.TxtSearchDB.Font = new System.Drawing.Font("Gadugi", 14.25F, System.Drawing.FontStyle.Bold);
            this.TxtSearchDB.Location = new System.Drawing.Point(363, 77);
            this.TxtSearchDB.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.TxtSearchDB.Name = "TxtSearchDB";
            this.TxtSearchDB.Size = new System.Drawing.Size(722, 33);
            this.TxtSearchDB.TabIndex = 17;
            // 
            // LblDashboard
            // 
            this.LblDashboard.AutoSize = true;
            this.LblDashboard.BackColor = System.Drawing.Color.Transparent;
            this.LblDashboard.Font = new System.Drawing.Font("Rage Italic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDashboard.ForeColor = System.Drawing.Color.White;
            this.LblDashboard.Location = new System.Drawing.Point(20, 119);
            this.LblDashboard.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.LblDashboard.Name = "LblDashboard";
            this.LblDashboard.Size = new System.Drawing.Size(117, 34);
            this.LblDashboard.TabIndex = 21;
            this.LblDashboard.Text = "Dashboard";
            this.LblDashboard.UseMnemonic = false;
            // 
            // LblHistory
            // 
            this.LblHistory.AutoSize = true;
            this.LblHistory.BackColor = System.Drawing.Color.Transparent;
            this.LblHistory.Font = new System.Drawing.Font("Rage Italic", 20F);
            this.LblHistory.ForeColor = System.Drawing.Color.White;
            this.LblHistory.Location = new System.Drawing.Point(13, 759);
            this.LblHistory.Name = "LblHistory";
            this.LblHistory.Size = new System.Drawing.Size(87, 34);
            this.LblHistory.TabIndex = 43;
            this.LblHistory.Text = "History";
            // 
            // CmdTest
            // 
            this.CmdTest.Location = new System.Drawing.Point(886, 926);
            this.CmdTest.Name = "CmdTest";
            this.CmdTest.Size = new System.Drawing.Size(75, 23);
            this.CmdTest.TabIndex = 42;
            this.CmdTest.Text = "Test";
            this.CmdTest.UseVisualStyleBackColor = true;
            // 
            // TxtHistory
            // 
            this.TxtHistory.BackColor = System.Drawing.SystemColors.ControlLight;
            this.TxtHistory.Location = new System.Drawing.Point(12, 803);
            this.TxtHistory.Multiline = true;
            this.TxtHistory.Name = "TxtHistory";
            this.TxtHistory.ReadOnly = true;
            this.TxtHistory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtHistory.Size = new System.Drawing.Size(868, 146);
            this.TxtHistory.TabIndex = 41;
            // 
            // CmdShowHelp
            // 
            this.CmdShowHelp.Location = new System.Drawing.Point(1397, 926);
            this.CmdShowHelp.Name = "CmdShowHelp";
            this.CmdShowHelp.Size = new System.Drawing.Size(75, 23);
            this.CmdShowHelp.TabIndex = 40;
            this.CmdShowHelp.Text = "Show Help";
            this.CmdShowHelp.UseVisualStyleBackColor = true;
            // 
            // CmdCancel
            // 
            this.CmdCancel.Location = new System.Drawing.Point(823, 225);
            this.CmdCancel.Name = "CmdCancel";
            this.CmdCancel.Size = new System.Drawing.Size(75, 23);
            this.CmdCancel.TabIndex = 39;
            this.CmdCancel.Text = "Cancel";
            this.CmdCancel.UseVisualStyleBackColor = true;
            // 
            // CmdSaveCustomer
            // 
            this.CmdSaveCustomer.Location = new System.Drawing.Point(742, 225);
            this.CmdSaveCustomer.Name = "CmdSaveCustomer";
            this.CmdSaveCustomer.Size = new System.Drawing.Size(75, 23);
            this.CmdSaveCustomer.TabIndex = 37;
            this.CmdSaveCustomer.Text = "Save";
            this.CmdSaveCustomer.UseVisualStyleBackColor = true;
            // 
            // CmdDeleteCustomer
            // 
            this.CmdDeleteCustomer.Location = new System.Drawing.Point(482, 225);
            this.CmdDeleteCustomer.Name = "CmdDeleteCustomer";
            this.CmdDeleteCustomer.Size = new System.Drawing.Size(110, 23);
            this.CmdDeleteCustomer.TabIndex = 36;
            this.CmdDeleteCustomer.Text = "Delete Selected";
            this.CmdDeleteCustomer.UseVisualStyleBackColor = true;
            // 
            // CmdModifyCustomer
            // 
            this.CmdModifyCustomer.Location = new System.Drawing.Point(363, 225);
            this.CmdModifyCustomer.Name = "CmdModifyCustomer";
            this.CmdModifyCustomer.Size = new System.Drawing.Size(113, 23);
            this.CmdModifyCustomer.TabIndex = 35;
            this.CmdModifyCustomer.Text = "Modify Selected";
            this.CmdModifyCustomer.UseVisualStyleBackColor = true;
            // 
            // CmdCreateCustomer
            // 
            this.CmdCreateCustomer.Location = new System.Drawing.Point(12, 225);
            this.CmdCreateCustomer.Name = "CmdCreateCustomer";
            this.CmdCreateCustomer.Size = new System.Drawing.Size(120, 23);
            this.CmdCreateCustomer.TabIndex = 34;
            this.CmdCreateCustomer.Text = "Add New Customer";
            this.CmdCreateCustomer.UseVisualStyleBackColor = true;
            // 
            // GrdCustomer
            // 
            this.GrdCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdCustomer.Location = new System.Drawing.Point(12, 254);
            this.GrdCustomer.Name = "GrdCustomer";
            this.GrdCustomer.Size = new System.Drawing.Size(1460, 476);
            this.GrdCustomer.TabIndex = 33;
            // 
            // Form_Customer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1484, 961);
            this.Controls.Add(this.LblHistory);
            this.Controls.Add(this.CmdTest);
            this.Controls.Add(this.TxtHistory);
            this.Controls.Add(this.CmdShowHelp);
            this.Controls.Add(this.CmdCancel);
            this.Controls.Add(this.CmdSaveCustomer);
            this.Controls.Add(this.CmdDeleteCustomer);
            this.Controls.Add(this.CmdModifyCustomer);
            this.Controls.Add(this.CmdCreateCustomer);
            this.Controls.Add(this.GrdCustomer);
            this.Controls.Add(this.LblDashboard);
            this.Controls.Add(this.TxtSearchDB);
            this.Controls.Add(this.PbBackToDashboard);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form_Customer";
            this.Text = "Form_Customer";
            this.Load += new System.EventHandler(this.Form_Customer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbBackToDashboard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdCustomer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox PbBackToDashboard;
        private System.Windows.Forms.TextBox TxtSearchDB;
        private System.Windows.Forms.Label LblDashboard;
        private System.Windows.Forms.Label LblHistory;
        private System.Windows.Forms.Button CmdTest;
        private System.Windows.Forms.TextBox TxtHistory;
        private System.Windows.Forms.Button CmdShowHelp;
        private System.Windows.Forms.Button CmdCancel;
        private System.Windows.Forms.Button CmdSaveCustomer;
        private System.Windows.Forms.Button CmdDeleteCustomer;
        private System.Windows.Forms.Button CmdModifyCustomer;
        private System.Windows.Forms.Button CmdCreateCustomer;
        private System.Windows.Forms.DataGridView GrdCustomer;
    }
}