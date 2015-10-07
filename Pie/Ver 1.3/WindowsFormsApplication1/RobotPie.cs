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
       private void commandOptions(int a)       //command central which houses all commands executed when a button is clicked on the pie!
          {
                  InputDialog dialog = new InputDialog();
                  InputCombo frmDir = new InputCombo();
                  speedSelect spdSel = new speedSelect();
                  string nameIn="abc";
              switch (a)
                  {
                      case 0://rename
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

                      case 1://Go to location
                          {
                              GoTo frmGoTo = new GoTo();
                              frmGoTo.Show();
                          }
                          break;
                      case 2://Change facing direction
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
                      case 3://Drop 
                          {
                              drop frmdropObj = new drop();
                              frmdropObj.Show();
                          }
                          break;
                      case 4://Select Speed
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
                      case 5: //grab object
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

        private void btnRename_Paint(object sender, PaintEventArgs e)       //Rename Button
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
            commandOptions(0);    //Rename Secondary options
        }

        private void btnCloseCancel_Click(object sender, EventArgs e)
        {
            this.Close();
//            globalVars.programDone = true;
        }

        private void btnGTL_Paint(object sender, PaintEventArgs e)      //Go To Location GTL
        {
            System.Drawing.Drawing2D.GraphicsPath myGraphicsPath = new
         System.Drawing.Drawing2D.GraphicsPath();
            myGraphicsPath.AddEllipse(new Rectangle(0, 0, 100, 100));
            btnGTL.Size = new System.Drawing.Size(100, 100);
            btnGTL.Region = new Region(myGraphicsPath);

        }
       
        private void RobotPie_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
        }

        private void btnCFD_Paint(object sender, PaintEventArgs e)      //Chnage Facing Direction CFD
        {
           System.Drawing.Drawing2D.GraphicsPath myGraphicsPath = new System.Drawing.Drawing2D.GraphicsPath();
           myGraphicsPath.AddEllipse(new Rectangle(0, 0, 100, 100));
           btnCFD.Size = new System.Drawing.Size(100, 100);
           btnCFD.Region = new Region(myGraphicsPath);
        }

        private void btnGrab_Paint(object sender, PaintEventArgs e)     //grab button
        {
            System.Drawing.Drawing2D.GraphicsPath myGraphicsPath = new
         System.Drawing.Drawing2D.GraphicsPath();
            myGraphicsPath.AddEllipse(new Rectangle(0, 0, 100, 100));
            btnGrab.Size = new System.Drawing.Size(100, 100);
            btnGrab.Region = new Region(myGraphicsPath);

        }

       private void btnSpeed_Paint(object sender, PaintEventArgs e)    //setting the speed button
        {
            System.Drawing.Drawing2D.GraphicsPath myGraphicsPath = new
         System.Drawing.Drawing2D.GraphicsPath();
            myGraphicsPath.AddEllipse(new Rectangle(0, 0, 100, 100));
            btnSpeed.Size = new System.Drawing.Size(100, 100);
            btnSpeed.Region = new Region(myGraphicsPath);

        }
        
        private void btnDrop_Paint(object sender, PaintEventArgs e)   //setting the drop button
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

        private void btnExecute_Click(object sender, EventArgs e) //essentially to distinguish between the cancel and onfirm buttons, they still do execute the same code!
        {
            this.Close();
   //         globalVars.programDone = true;
        }

       

    
      

     

    }     
    
}