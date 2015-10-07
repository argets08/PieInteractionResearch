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
    public partial class GoTo : Form
    {
        public GoTo()
        {
            InitializeComponent();
            waypointPopulate();
        }

        private void GoTo_Load(object sender, EventArgs e)
        {
            
        }
        private void waypointPopulate()
        {
            string[] waypointList ={"House","Lobby","Pharmacy","Room0","Room1","Room2","Room3","Room4","Room5","Room6","Room7","Room8","Room9","Room10","Room11","Storage",
                                      "Pharmacist","Loading","Shelf1","Shelf2","Curb","Door0","Warehouse","Street0","Street1","Street2"};
       
            comboBox1.Items.AddRange(waypointList);
        }

       

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_Enter(object sender, EventArgs e)
        {
            comboBox1.Text = "";
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked && !(comboBox1.Text.Equals("")) && !(comboBox1.Text.Equals("Select Location to move to...")))
            {   
                MessageBox.Show("ok");
                this.Close();
            }
        }

        private void GoTo_Activated(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
        }

       

    }
}
