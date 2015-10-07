using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class drop : Form
    {
        public drop()
        {
            InitializeComponent();
            this.TopMost = true;
        }

        private void drop_Load(object sender, EventArgs e)
        {
            radioButton1.Visible = true;
            radioButton1.Checked = false;
            radioButton2.Visible = true;
            radioButton2.Checked = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)//cancel button
        {
            this.Close();
        }

        private void radioButton1_Click(object sender, EventArgs e)//radio button for choice 1
        {
            radioButton2.Checked = false;
        }

        private void radioButton2_Click(object sender, EventArgs e)//choice 2
        {
            radioButton1.Checked = false;
        }

        private void btnOk_Click(object sender, EventArgs e)//confirm button
        {
            if (radioButton1.Checked == true)
            {
                globalVars.robotCommand = globalVars.robotName.ToString() + " drop";
                this.Close();
            }
            else if (radioButton2.Checked == true)
            {
                globalVars.robotCommand = globalVars.robotName.ToString() + " dropc";
                this.Close();
            }
            else if (radioButton1.Checked == false && radioButton2.Checked == false)
            {
                MessageBox.Show("Please select an option first");
            }
            
        }

    }
}
