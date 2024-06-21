using System.Windows.Forms;

namespace DesktopApplication
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.dataGridViewPurchasedTickets = new System.Windows.Forms.DataGridView();
            this.btnLogout = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPurchasedTickets)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewPurchasedTickets
            // 
            this.dataGridViewPurchasedTickets.AllowUserToAddRows = false;
            this.dataGridViewPurchasedTickets.AllowUserToDeleteRows = false;
            this.dataGridViewPurchasedTickets.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewPurchasedTickets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPurchasedTickets.Location = new System.Drawing.Point(13, 14);
            this.dataGridViewPurchasedTickets.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridViewPurchasedTickets.Name = "dataGridViewPurchasedTickets";
            this.dataGridViewPurchasedTickets.ReadOnly = true;
            this.dataGridViewPurchasedTickets.Size = new System.Drawing.Size(1180, 600);
            this.dataGridViewPurchasedTickets.TabIndex = 0;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(1054, 642);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(159, 48);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 720);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.dataGridViewPurchasedTickets);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Debra Home";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPurchasedTickets)).EndInit();
            this.ResumeLayout(false);

        }

        private DataGridView dataGridViewPurchasedTickets;
        private Button btnLogout;
    }

    #endregion
}
