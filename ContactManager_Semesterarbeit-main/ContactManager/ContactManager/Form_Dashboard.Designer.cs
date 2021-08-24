
namespace ContactManager
{
    partial class Form_Dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Dashboard));
            this.TxtSearchDB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.PbEmployee = new System.Windows.Forms.PictureBox();
            this.PbCustomer = new System.Windows.Forms.PictureBox();
            this.PbContactDoc = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PbEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbContactDoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtSearchDB
            // 
            this.TxtSearchDB.Font = new System.Drawing.Font("Gadugi", 14.25F, System.Drawing.FontStyle.Bold);
            this.TxtSearchDB.Location = new System.Drawing.Point(363, 77);
            this.TxtSearchDB.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.TxtSearchDB.Name = "TxtSearchDB";
            this.TxtSearchDB.Size = new System.Drawing.Size(722, 33);
            this.TxtSearchDB.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Rage Italic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(359, 237);
            this.label1.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 34);
            this.label1.TabIndex = 14;
            this.label1.Text = "Employee";
            this.label1.UseMnemonic = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Rage Italic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(741, 237);
            this.label2.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 34);
            this.label2.TabIndex = 15;
            this.label2.Text = "Contact Doc";
            this.label2.UseMnemonic = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Rage Italic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1178, 237);
            this.label3.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 34);
            this.label3.TabIndex = 16;
            this.label3.Text = "Customer";
            this.label3.UseMnemonic = false;
            // 
            // PbEmployee
            // 
            this.PbEmployee.BackColor = System.Drawing.Color.White;
            this.PbEmployee.Image = global::ContactManager.Properties.Resources.Employee;
            this.PbEmployee.Location = new System.Drawing.Point(170, 232);
            this.PbEmployee.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.PbEmployee.Name = "PbEmployee";
            this.PbEmployee.Size = new System.Drawing.Size(300, 300);
            this.PbEmployee.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbEmployee.TabIndex = 13;
            this.PbEmployee.TabStop = false;
            this.PbEmployee.Click += new System.EventHandler(this.PbEmployee_Click);
            // 
            // PbCustomer
            // 
            this.PbCustomer.BackColor = System.Drawing.Color.White;
            this.PbCustomer.Image = global::ContactManager.Properties.Resources.Customer;
            this.PbCustomer.Location = new System.Drawing.Point(986, 232);
            this.PbCustomer.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.PbCustomer.Name = "PbCustomer";
            this.PbCustomer.Size = new System.Drawing.Size(300, 300);
            this.PbCustomer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbCustomer.TabIndex = 12;
            this.PbCustomer.TabStop = false;
            this.PbCustomer.Click += new System.EventHandler(this.PbCustomer_Click);
            // 
            // PbContactDoc
            // 
            this.PbContactDoc.BackColor = System.Drawing.Color.White;
            this.PbContactDoc.Image = global::ContactManager.Properties.Resources.ContactDoc;
            this.PbContactDoc.Location = new System.Drawing.Point(580, 232);
            this.PbContactDoc.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.PbContactDoc.Name = "PbContactDoc";
            this.PbContactDoc.Size = new System.Drawing.Size(300, 300);
            this.PbContactDoc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbContactDoc.TabIndex = 11;
            this.PbContactDoc.TabStop = false;
            this.PbContactDoc.Click += new System.EventHandler(this.PbContactDoc_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1484, 961);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // Form_Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1484, 961);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PbEmployee);
            this.Controls.Add(this.PbCustomer);
            this.Controls.Add(this.PbContactDoc);
            this.Controls.Add(this.TxtSearchDB);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "Form_Dashboard";
            this.Text = "Form_Dashboard";
            this.Load += new System.EventHandler(this.Form_Dashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PbEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbContactDoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox TxtSearchDB;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox PbContactDoc;
        private System.Windows.Forms.PictureBox PbCustomer;
        private System.Windows.Forms.PictureBox PbEmployee;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}