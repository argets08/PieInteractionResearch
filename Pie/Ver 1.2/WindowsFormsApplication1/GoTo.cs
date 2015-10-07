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
           
        }
        private void GoTo_Load(object sender, EventArgs e)
        {
           
        }
        
        //populating combo boxes
        private void populate(int numCode)
        {
            switch (numCode)
            {
                case 0: string[] waypointList = {"House","Lobby","Pharmacy","Room0","Room1","Room2","Room3","Room4","Room5","Room6","Room7","Room8","Room9","Room10","Room11","Storage",
                                      "Pharmacist","Loading","Shelf1","Shelf2","Curb","Door0","Warehouse","Street0","Street1","Street2"};

                        comboBox1.Items.AddRange(waypointList);
                         break;
                case 1: string[] directions = { "Forward", "Back", "Right", "Left" };
                        comboBox2.Items.AddRange(directions);
                        for (int i = 1; i < 360; i++)
                            {
                                comboBox2.Items.Add(i + ".0");
                            }
                        break;
                case 2: string[] directions1 = { "North", "North East", "East", "South East", "South", "South West", "West", "North West" };
                        comboBox3.Items.AddRange(directions1);
                        for (int i = 1; i < 360; i++)
                        {
                            comboBox3.Items.Add(i + ".0");
                        }
                        break;
            }

        }
       

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_Enter(object sender, EventArgs e)
        {
            comboBox1.Text = string.Empty;
        }
        //confirm button to execute commands
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                if (!(comboBox1.Text.Equals("")) && !(comboBox1.Text.Equals("Select Location to move to...")))
                {
                    globalVars.robotCommand = globalVars.robotName + " wp " + comboBox1.Text.ToString().ToLower();
                    MessageBox.Show(globalVars.robotCommand);
                    this.Close();
                }
               
            }
            else if (radioButton2.Checked == true) 
            {
                if (!(comboBox2.Text.Equals(""))
                    && !(comboBox2.Text.Equals("Select Direction or Degrees relative to current position, to move the Robot in..."))
                    )
                {
                    globalVars.robotCommand = globalVars.robotName + " moveddr " + comboBox2.Text.ToString().ToLower() + " " + numericUpDown1.Value.ToString();
                    MessageBox.Show(globalVars.robotCommand);
                    this.Close();
                }
                else { MessageBox.Show("Invalid Selection of parameters"); }
                resetForm();
            }
            else if (radioButton3.Checked == true)
            {
                if (!(comboBox3.Text.Equals(""))
                    && !(comboBox3.Text.Equals("Select Direction or Degrees relative to current position, to move the Robot in..."))
                   )
                {if(comboBox3.Text.Equals("North East")){comboBox3.Text="45.0";}
                else if(comboBox3.Text.Equals("South East")){comboBox3.Text="135.0";}
                else if (comboBox3.Text.Equals("South West")){comboBox3.Text="225.0";}
                else if (comboBox3.Text.Equals("North West")) { comboBox3.Text = "315.0"; }

                globalVars.robotCommand = globalVars.robotName + " movedda " + comboBox3.Text.ToString().ToLower() + " " + numericUpDown2.Value.ToString();
                    MessageBox.Show(globalVars.robotCommand);
                    this.Close();
                }
            }
            else { MessageBox.Show("Invalid Selection of parameters"); }
            resetForm();
           }
        //code executed when the form is shown
        private void GoTo_Shown(object sender, EventArgs e)
        {
            resetForm();
        }
        //code executed when the first radio option is selected
        private void radioButton1_Click(object sender, EventArgs e)
        {
            radioButton2.Visible = false;
            radioButton3.Visible = false;
            populate(0);
            comboBox1.Visible = true;
        }

        //code executed when the second radio option is selected
        private void radioButton2_Click(object sender, EventArgs e)
        {
            radioButton1.Visible = false;
            radioButton3.Visible = false;
            comboBox2.Visible = true;
            populate(1);
            label1.Visible = true;
            numericUpDown1.Visible = true;
         }

        //code executed when the third radio option is selected
        private void radioButton3_Click(object sender, EventArgs e)
        {
            radioButton1.Visible = false;
            radioButton2.Visible = false;
            comboBox2.Visible = false;
            comboBox1.Visible = false;
            comboBox3.Visible = true;
            populate(2);
            label1.Visible = false;
            label2.Visible = true;
            numericUpDown1.Visible = false;
            numericUpDown2.Visible = true;
        }

        private void resetForm()
        {
            radioButton1.Checked = false;
            radioButton1.Visible = true;
            radioButton2.Visible = true;
            radioButton3.Visible = true;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            comboBox1.Visible = false;
            comboBox2.Visible = false;
            comboBox3.Visible = false;
            comboBox1.Text = "Select Location to move to...";
            comboBox2.Text = "Select Direction or Degrees relative to current position, to move the Robot in...";
            comboBox3.Text = "Select Direction or Degrees relative to current position, to move the Robot in...";
            label1.Visible = false;
            label2.Visible = false;
            numericUpDown1.Visible = false;
            numericUpDown1.Value = 1;
            numericUpDown2.Value = 1;
            numericUpDown2.Visible = false;
           

        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true || radioButton2.Checked == true || radioButton3.Checked == true)
            {
                resetForm();
            }
        }

        

    }
}
