﻿using DesktopApplication.Properties;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DesktopApplication
{
    partial class PartnerDashboard : Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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

        private DataGridView gvEvents;
        private Button logoutbtn;

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PartnerDashboard));
            this.gvEvents = new System.Windows.Forms.DataGridView();
            this.logoutbtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvEvents)).BeginInit();
            this.SuspendLayout();
            // 
            // gvEvents
            // 
            this.gvEvents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvEvents.Location = new System.Drawing.Point(12, 23);
            this.gvEvents.Name = "gvEvents";
            this.gvEvents.Size = new System.Drawing.Size(1184, 595);
            this.gvEvents.TabIndex = 0;
            // 
            // logoutbtn
            // 
            this.logoutbtn.BackColor = System.Drawing.Color.Black;
            this.logoutbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logoutbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoutbtn.ForeColor = System.Drawing.Color.White;
            this.logoutbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logoutbtn.Location = new System.Drawing.Point(1055, 635);
            this.logoutbtn.Name = "logoutbtn";
            this.logoutbtn.Size = new System.Drawing.Size(141, 42);
            this.logoutbtn.TabIndex = 1;
            this.logoutbtn.Text = "Logout";
            this.logoutbtn.UseVisualStyleBackColor = false;
            this.logoutbtn.Click += new System.EventHandler(this.logoutbtn_Click);
            // 
            // PartnerDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1209, 700);
            this.Controls.Add(this.logoutbtn);
            this.Controls.Add(this.gvEvents);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PartnerDashboard";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Partner Dashboard";
            this.Load += new System.EventHandler(this.PartnerDashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvEvents)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
