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
    public partial class grab : Form
    {
        public grab()
        {
            InitializeComponent();
        }
        static int caseValue = 0;
        static int secondOption = 0;
        private void radioButton1_Click(object sender, EventArgs e)
        {
            radioButton2.Visible = false;
            radioButton3.Visible = false;
            radioButton4.Visible = false;
            radioButton5.Visible = false;
            textBox1.Visible = true;
            caseValue = 1;
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            radioButton1.Visible = false;
            radioButton3.Visible = false;
            radioButton4.Visible = false;
            radioButton5.Visible = false;
            radioButton6.Visible = true;
            radioButton7.Visible = true;
            caseValue = 2;
        }

        private void radioButton3_Click(object sender, EventArgs e)
        {
            radioButton2.Visible = false;
            radioButton1.Visible = false;
            radioButton4.Visible = false;
            radioButton5.Visible = false;
            radioButton8.Visible = true;
            radioButton9.Visible = true;
            caseValue = 3;
        }

        private void radioButton4_Click(object sender, EventArgs e)
        {
            radioButton2.Visible = false;
            radioButton3.Visible = false;
            radioButton1.Visible = false;
            radioButton5.Visible = false;
            radioButton10.Visible = true;
            radioButton11.Visible = true;
            caseValue = 4;
        }

        private void radioButton5_Click(object sender, EventArgs e)
        {
            radioButton2.Visible = false;
            radioButton3.Visible = false;
            radioButton4.Visible = false;
            radioButton1.Visible = false;
            radioButton12.Visible = true;
            radioButton13.Visible = true;
            caseValue = 5;
        }
        private void reset()
        {
            //case number
            caseValue = 0;
            //checked
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;
            radioButton7.Checked = false;
            radioButton8.Checked = false;
            radioButton9.Checked = false;
            radioButton10.Checked = false;
            radioButton11.Checked = false;
            radioButton12.Checked = false;
            radioButton13.Checked = false;

            //visible
            radioButton1.Visible = true;
            radioButton2.Visible = true;
            radioButton3.Visible = true;
            radioButton4.Visible = true;
            radioButton5.Visible = true;
            radioButton6.Visible = false;
            radioButton7.Visible = false;
            radioButton8.Visible = false;
            radioButton9.Visible = false;
            radioButton10.Visible = false;
            radioButton11.Visible = false;
            radioButton12.Visible = false;
            radioButton13.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;




        }
        private void grab_Load(object sender, EventArgs e)
        {

        }

        private void grab_Shown(object sender, EventArgs e)
        {
            reset();
        }

        private void radioButton7_Click(object sender, EventArgs e)
        {
            secondOption = 7;
            radioButton6.Visible = false;
            textBox2.Visible = true;
        }

        private void radioButton6_Click(object sender, EventArgs e)
        {
            secondOption = 6;
            radioButton7.Visible = false;
        }

        private void radioButton8_Click(object sender, EventArgs e)
        {
            secondOption = 8;
            radioButton9.Visible = false;
            textBox3.Visible = true;
        }

        private void radioButton9_Click(object sender, EventArgs e)
        {
            secondOption = 9;
            radioButton8.Visible = false;
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            secondOption = 10;
            radioButton11.Visible = false;
            textBox4.Visible = true;
        }

        private void radioButton11_Click(object sender, EventArgs e)
        {
            secondOption = 11;
            radioButton10.Visible = false;
        }

        private void radioButton13_Click(object sender, EventArgs e)
        {
            secondOption = 13;
            radioButton12.Visible = false;
        }

        private void radioButton12_Click(object sender, EventArgs e)
        {
            secondOption = 12;
            radioButton13.Visible = false;
            textBox5.Visible = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            switch (caseValue)
            {
                case 0: MessageBox.Show("please make a valid Selection");
                    reset();
                    break;
                case 1:
                    {
                        if (textBox1.Text.Equals("") || textBox1.Text.Equals("Enter name of Object to grab"))
                        {
                            MessageBox.Show("Please enter a valid object name");
                            reset();
                        }
                        else
                        {
                            globalVars.robotCommand = globalVars.robotName + " grab " + textBox1.Text;
                            MessageBox.Show(globalVars.robotCommand);
                        }
                    }
                    break;
                case 2:
                    {
                        if (secondOption == 6)
                        {
                            globalVars.robotCommand = globalVars.robotName + " grab nearest";
                            MessageBox.Show(globalVars.robotCommand);
                            this.Close();
                        }

                        else if (secondOption == 7)
                        {
                            if (textBox2.Text.Equals("") || textBox2.Text.Equals("Enter name of Object to grab"))
                            {
                                MessageBox.Show("Please enter a valid object name");
                                reset();
                            }
                            else
                            {
                                globalVars.robotCommand = globalVars.robotName + " grab nearest " + textBox2.Text;
                                MessageBox.Show(globalVars.robotCommand);
                                this.Close();
                            }
                        }

                    }
                    break;
                case 3:
                    {
                        if (secondOption == 9)
                        {
                            globalVars.robotCommand = globalVars.robotName + " grab highest";
                            MessageBox.Show(globalVars.robotCommand);
                            this.Close();
                        }

                        else if (secondOption == 8)
                        {
                            if (textBox3.Text.Equals("") || textBox3.Text.Equals("Enter name of Object to grab"))
                            {
                                MessageBox.Show("Please enter a valid object name");
                                reset();
                            }
                            else
                            {
                                globalVars.robotCommand = globalVars.robotName + " grab highest " + textBox3.Text;
                                MessageBox.Show(globalVars.robotCommand);
                                this.Close();
                            }
                        }

                    }
                    break;
                case 4:
                    {
                        if (secondOption == 11)
                        {
                            globalVars.robotCommand = globalVars.robotName + " grab lowest";
                            MessageBox.Show(globalVars.robotCommand);
                            this.Close();
                        }

                        else if (secondOption == 10)
                        {
                            if (textBox4.Text.Equals("") || textBox4.Text.Equals("Enter name of Object to grab"))
                            {
                                MessageBox.Show("Please enter a valid object name");
                                reset();
                            }
                            else
                            {
                                globalVars.robotCommand = globalVars.robotName + " grab lowest " + textBox4.Text;
                                MessageBox.Show(globalVars.robotCommand);
                                this.Close();
                            }
                        }

                    }
                    break;
                case 5:
                    {
                        if (secondOption == 13)
                        {
                            globalVars.robotCommand = globalVars.robotName + " grab mop";
                            MessageBox.Show(globalVars.robotCommand);
                            this.Close();
                        }

                        else if (secondOption == 12)
                        {
                            if (textBox5.Text.Equals("") || textBox5.Text.Equals("Enter name of Object to grab"))
                            {
                                MessageBox.Show("Please enter a valid object name");
                                reset();
                            }
                            else
                            {
                                globalVars.robotCommand = globalVars.robotName + " grab mop " + textBox5.Text;
                                MessageBox.Show(globalVars.robotCommand);
                                this.Close();
                            }
                        }

                    }
                    break;
            }

        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.Text = string.Empty;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            textBox3.Text = string.Empty;
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            textBox4.Text = string.Empty;
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            textBox5.Text = string.Empty;
        }
    }
}

          


