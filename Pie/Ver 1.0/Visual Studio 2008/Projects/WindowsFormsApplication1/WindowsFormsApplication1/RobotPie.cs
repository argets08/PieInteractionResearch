using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyNamespace;
using NewNamespace;
using speedNamespace;
namespace WindowsFormsApplication1
{
      
    public partial class RobotPie : Form
    {
 
        
        public RobotPie()
        {
             InitializeComponent();
        }
       
        private Point mouse_offset;
        //globalVars Globals = new globalVars();
       private void commandOptions(int a)
          {
                  InputDialog dialog = new InputDialog();
                  InputCombo frmDir = new InputCombo();
                  speedSelect spdSel = new speedSelect();
                  globalVars.robotName = txtRobotName.Text;//has t be replaced by something getting the robots name thru http request
                  string nameIn="abc";
                  switch (a)
                  {
                      case 0:
                          {
                              if (dialog.ShowDialog(this) == DialogResult.OK)
                              {
                                  if (dialog.Value.Equals(""))
                                  {
                                      MessageBox.Show("Please enter a valid name for the bot");
                                  }
                                  else
                                  {
                                      nameIn = dialog.Value.ToString() ;
                                      globalVars.robotCommand = globalVars.robotName + " rename to " + nameIn;
                                  }
                              }
                              else if (dialog.DialogResult == DialogResult.Cancel)
                              {
                                  RobotPie.ActiveForm.Activate();
                              }                     
                          }
                          break;

                      case 1:
                          {
                              GoTo frmGoTo = new GoTo();
                              frmGoTo.Show();
                          }
                          break;
                      case 2:
                          {
                              if (frmDir.ShowDialog(this) == DialogResult.OK)
                              {
                                  if (frmDir.Value.Equals("") || frmDir.Value.Equals("Please Select Direction to Face"))
                                  {
                                      MessageBox.Show("Please Choose a valid Direction to face");
                                  }
                                  else
                                  {
                                      string faceDirection = frmDir.Value;
                                      globalVars.robotCommand = globalVars.robotName + " face " + faceDirection.ToLower();
                                      MessageBox.Show(globalVars.robotCommand);
                                  }
                              }
                              else if (frmDir.DialogResult == DialogResult.Cancel)
                              {
                                  RobotPie.ActiveForm.Activate();
                              }

                          }

                          break;
                      case 3:
                          {
                              drop frmdropObj = new drop();
                              frmdropObj.Show();
                          }
                          break;
                      case 4:
                          {
                              if (spdSel.ShowDialog(this) == DialogResult.OK)
                              {
                                  if (spdSel.Value.Equals("") || spdSel.Value.Equals("Please Select the speed"))
                                  {
                                      MessageBox.Show("Please Choose a valid speed to assign");
                                  }
                                  else
                                  {
                                      string speedVal = spdSel.Value.ToString();
                                      globalVars.robotCommand = globalVars.robotName + " speed " + speedVal.ToLower();
                                      MessageBox.Show(globalVars.robotCommand);
                                  }
                              }
                              else if (spdSel.DialogResult == DialogResult.Cancel)
                              {
                                  RobotPie.ActiveForm.Activate();
                              }

                          }
                          break;
                      case 5:
                          {
                              grab frmGrab = new grab();
                              frmGrab.Show();
                          }
                          break;

                      }
               }
        

        private void RobotPie_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_offset = new Point(-e.X, -e.Y);

        }

        private void RobotPie_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouse_offset.X, mouse_offset.Y);
                Location = mousePos;
            }

        }

        private void btnRename_Paint(object sender, PaintEventArgs e)
        {
            
            //Instantiate a new instance of the GraphicsPath class.
            System.Drawing.Drawing2D.GraphicsPath myGraphicsPath = new
            System.Drawing.Drawing2D.GraphicsPath();
            myGraphicsPath.AddEllipse(new Rectangle(0, 0, 100, 100));
            //Set the control's Region property to the instance
            //of the GraphicsPath class you created above.
            btnRename.Size = new System.Drawing.Size(100, 100);
            btnRename.Region = new Region(myGraphicsPath);

        }

        private void btnRename_Click(object sender, EventArgs e)
        {
           // btnRename.BackColor = Color.Silver;
            commandOptions(0);    //Rename Secondary options
            label1.Text = globalVars.robotCommand;
            //beam robotCommand; out into second life;
         }

        private void btnCloseCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGTL_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsPath myGraphicsPath = new
         System.Drawing.Drawing2D.GraphicsPath();
            myGraphicsPath.AddEllipse(new Rectangle(0, 0, 100, 100));
            btnGTL.Size = new System.Drawing.Size(100, 100);
            btnGTL.Region = new Region(myGraphicsPath);

        }
       
        private void RobotPie_Load(object sender, EventArgs e)
        {

        }

        private void btnCFD_Paint(object sender, PaintEventArgs e)
        {
           System.Drawing.Drawing2D.GraphicsPath myGraphicsPath = new System.Drawing.Drawing2D.GraphicsPath();
           myGraphicsPath.AddEllipse(new Rectangle(0, 0, 100, 100));
           btnCFD.Size = new System.Drawing.Size(100, 100);
           btnCFD.Region = new Region(myGraphicsPath);
        }

        private void btnGrab_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsPath myGraphicsPath = new
         System.Drawing.Drawing2D.GraphicsPath();
            myGraphicsPath.AddEllipse(new Rectangle(0, 0, 100, 100));
            btnGrab.Size = new System.Drawing.Size(100, 100);
            btnGrab.Region = new Region(myGraphicsPath);

        }

        private void btnReset_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsPath myGraphicsPath = new
         System.Drawing.Drawing2D.GraphicsPath();
            myGraphicsPath.AddEllipse(new Rectangle(0, 0, 100, 100));
            btnSpeed.Size = new System.Drawing.Size(100, 100);
            btnSpeed.Region = new Region(myGraphicsPath);

        }

        private void btnDrop_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsPath myGraphicsPath = new
         System.Drawing.Drawing2D.GraphicsPath();
            myGraphicsPath.AddEllipse(new Rectangle(0, 0, 100, 100));
            btnDrop.Size = new System.Drawing.Size(100, 100);
            btnDrop.Region = new Region(myGraphicsPath);
        }

        private void btnGTL_Click(object sender, EventArgs e)
        {
            
            commandOptions(1);    //Go to location page options

            //beam robotCommand; out into second life;
        }

        private void btnCFD_Click(object sender, EventArgs e)
        {
             commandOptions(2);
        }

        private void btnDrop_Click(object sender, EventArgs e)
        {
            commandOptions(3);
        }

        private void btnSpeed_Click(object sender, EventArgs e)
        {
            commandOptions(4);
        }

        private void btnGrab_Click(object sender, EventArgs e)
        {
            commandOptions(5);
        }

    
      

     

    }     
    
}