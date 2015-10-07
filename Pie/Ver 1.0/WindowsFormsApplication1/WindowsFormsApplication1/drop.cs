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
        }

        private void drop_Load(object sender, EventArgs e)
        {
            radioButton1.Visible = true;
            radioButton1.Checked = false;
            radioButton2.Visible = true;
            radioButton2.Checked = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            radioButton2.Checked = false;
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                globalVars.robotCommand = globalVars.robotName.ToString() + " drop";
            }
            else if (radioButton2.Checked == true)
            {
                globalVars.robotCommand = globalVars.robotName.ToString() + " dropc";
            }
            MessageBox.Show(globalVars.robotCommand);
            this.Close();
        }

    }
}
