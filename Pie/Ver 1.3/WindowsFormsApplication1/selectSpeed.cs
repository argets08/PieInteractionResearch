using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace speedNamespace
{
    public class speedSelect : System.Windows.Forms.Form
    {
        private System.Windows.Forms.ComboBox comboDir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;

        public string Value
        {
            get
            {
                return comboDir.Text;
            }
            set
            {
                comboDir.Text=comboDir.SelectedText;
            }
        }

        public speedSelect()
        {
         InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.comboDir = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // comboDir
            this.comboDir.Location = new System.Drawing.Point(215, 12);
            this.comboDir.Name = "comboDir";
            this.comboDir.Size = new System.Drawing.Size(200, 21);
            this.comboDir.TabIndex = 0;
            this.comboDir.Text = "Please Select the speed";
            // label1
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select a speed value for the bot";
            // cmdOK
            this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdOK.Location = new System.Drawing.Point(215, 51);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 2;
            this.cmdOK.Text = "OK";
            // cmdCancel
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(340, 51);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 2;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // speedSelect
            this.AcceptButton = this.cmdOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(475, 86);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboDir);
            this.Controls.Add(this.cmdCancel);
            this.Name = "speedSelect";
            this.Opacity = 0.9;
            this.Text = "Select Speed";
            this.Load += new System.EventHandler(this.speedSelect_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void speedSelect_Load(object sender, EventArgs e)  //populating the select speed combo list
        {
            
            for (int i = 5; i < 151; i=i+5)
            {
                comboDir.Items.Add(i + ".0");
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            
          }

       }
    }
