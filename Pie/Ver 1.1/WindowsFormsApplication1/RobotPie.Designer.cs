namespace WindowsFormsApplication1
{
    partial class RobotPie
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RobotPie));
            this.btnCloseCancel = new System.Windows.Forms.Button();
            this.btnRename = new System.Windows.Forms.Button();
            this.btnGTL = new System.Windows.Forms.Button();
            this.btnCFD = new System.Windows.Forms.Button();
            this.btnGrab = new System.Windows.Forms.Button();
            this.btnDrop = new System.Windows.Forms.Button();
            this.btnSpeed = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCloseCancel
            // 
            this.btnCloseCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCloseCancel.BackgroundImage")));
            this.btnCloseCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCloseCancel.Location = new System.Drawing.Point(251, 204);
            this.btnCloseCancel.Name = "btnCloseCancel";
            this.btnCloseCancel.Size = new System.Drawing.Size(33, 22);
            this.btnCloseCancel.TabIndex = 9;
            this.btnCloseCancel.UseVisualStyleBackColor = true;
            this.btnCloseCancel.Click += new System.EventHandler(this.btnCloseCancel_Click);
            // 
            // btnRename
            // 
            this.btnRename.BackColor = System.Drawing.Color.Silver;
            this.btnRename.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnRename.FlatAppearance.BorderSize = 2;
            this.btnRename.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnRename.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRename.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnRename.Location = new System.Drawing.Point(75, 190);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(64, 50);
            this.btnRename.TabIndex = 10;
            this.btnRename.Text = "Rename";
            this.btnRename.UseVisualStyleBackColor = false;
            this.btnRename.Paint += new System.Windows.Forms.PaintEventHandler(this.btnRename_Paint);
            this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // btnGTL
            // 
            this.btnGTL.BackColor = System.Drawing.Color.Silver;
            this.btnGTL.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnGTL.FlatAppearance.BorderSize = 2;
            this.btnGTL.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnGTL.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGTL.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnGTL.Location = new System.Drawing.Point(140, 72);
            this.btnGTL.Name = "btnGTL";
            this.btnGTL.Size = new System.Drawing.Size(64, 50);
            this.btnGTL.TabIndex = 12;
            this.btnGTL.Text = "Go to Location";
            this.btnGTL.UseVisualStyleBackColor = false;
            this.btnGTL.Paint += new System.Windows.Forms.PaintEventHandler(this.btnGTL_Paint);
            this.btnGTL.Click += new System.EventHandler(this.btnGTL_Click);
            // 
            // btnCFD
            // 
            this.btnCFD.BackColor = System.Drawing.Color.Silver;
            this.btnCFD.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnCFD.FlatAppearance.BorderSize = 2;
            this.btnCFD.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCFD.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCFD.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCFD.Location = new System.Drawing.Point(302, 72);
            this.btnCFD.Name = "btnCFD";
            this.btnCFD.Size = new System.Drawing.Size(64, 50);
            this.btnCFD.TabIndex = 13;
            this.btnCFD.Text = "Change facing direction";
            this.btnCFD.UseVisualStyleBackColor = false;
            this.btnCFD.Paint += new System.Windows.Forms.PaintEventHandler(this.btnCFD_Paint);
            this.btnCFD.Click += new System.EventHandler(this.btnCFD_Click);
            // 
            // btnGrab
            // 
            this.btnGrab.BackColor = System.Drawing.Color.Silver;
            this.btnGrab.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnGrab.FlatAppearance.BorderSize = 2;
            this.btnGrab.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnGrab.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGrab.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnGrab.Location = new System.Drawing.Point(361, 190);
            this.btnGrab.Name = "btnGrab";
            this.btnGrab.Size = new System.Drawing.Size(64, 50);
            this.btnGrab.TabIndex = 14;
            this.btnGrab.Text = "Grab an Object";
            this.btnGrab.UseVisualStyleBackColor = false;
            this.btnGrab.Paint += new System.Windows.Forms.PaintEventHandler(this.btnGrab_Paint);
            this.btnGrab.Click += new System.EventHandler(this.btnGrab_Click);
            // 
            // btnDrop
            // 
            this.btnDrop.BackColor = System.Drawing.Color.Silver;
            this.btnDrop.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnDrop.FlatAppearance.BorderSize = 2;
            this.btnDrop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDrop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDrop.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDrop.Location = new System.Drawing.Point(154, 290);
            this.btnDrop.Name = "btnDrop";
            this.btnDrop.Size = new System.Drawing.Size(64, 50);
            this.btnDrop.TabIndex = 15;
            this.btnDrop.Text = "Drop the held object";
            this.btnDrop.UseVisualStyleBackColor = false;
            this.btnDrop.Paint += new System.Windows.Forms.PaintEventHandler(this.btnDrop_Paint);
            this.btnDrop.Click += new System.EventHandler(this.btnDrop_Click);
            // 
            // btnSpeed
            // 
            this.btnSpeed.BackColor = System.Drawing.Color.Silver;
            this.btnSpeed.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSpeed.FlatAppearance.BorderSize = 2;
            this.btnSpeed.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSpeed.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSpeed.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSpeed.Location = new System.Drawing.Point(293, 290);
            this.btnSpeed.Name = "btnSpeed";
            this.btnSpeed.Size = new System.Drawing.Size(64, 50);
            this.btnSpeed.TabIndex = 16;
            this.btnSpeed.Text = "Set Speed of the robot";
            this.btnSpeed.UseVisualStyleBackColor = false;
            this.btnSpeed.Paint += new System.Windows.Forms.PaintEventHandler(this.btnReset_Paint);
            this.btnSpeed.Click += new System.EventHandler(this.btnSpeed_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(249, 396);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "label1";
            // 
            // RobotPie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(517, 448);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSpeed);
            this.Controls.Add(this.btnDrop);
            this.Controls.Add(this.btnGrab);
            this.Controls.Add(this.btnCFD);
            this.Controls.Add(this.btnGTL);
            this.Controls.Add(this.btnRename);
            this.Controls.Add(this.btnCloseCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RobotPie";
            this.TransparencyKey = System.Drawing.Color.Red;
            this.Load += new System.EventHandler(this.RobotPie_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.RobotPie_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.RobotPie_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCloseCancel;
        private System.Windows.Forms.Button btnRename;
        private System.Windows.Forms.Button btnGTL;
        private System.Windows.Forms.Button btnCFD;
        private System.Windows.Forms.Button btnGrab;
        private System.Windows.Forms.Button btnDrop;
        private System.Windows.Forms.Button btnSpeed;
        private System.Windows.Forms.Label label1;
    }
}

