namespace WindowsFormsApp2
{
    partial class world
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lifeLabel = new System.Windows.Forms.Label();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // lifeLabel
            // 
            this.lifeLabel.AutoSize = true;
            this.lifeLabel.ForeColor = System.Drawing.Color.White;
            this.lifeLabel.Location = new System.Drawing.Point(803, 26);
            this.lifeLabel.Name = "lifeLabel";
            this.lifeLabel.Size = new System.Drawing.Size(59, 25);
            this.lifeLabel.TabIndex = 0;
            this.lifeLabel.Text = "Life: ";
            //this.lifeLabel.Click += new System.EventHandler(this.lifeLabel_Click);
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.ForeColor = System.Drawing.Color.White;
            this.scoreLabel.Location = new System.Drawing.Point(23, 26);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(74, 25);
            this.scoreLabel.TabIndex = 1;
            this.scoreLabel.Text = "Score:";
            this.scoreLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // world
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(900, 700);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.lifeLabel);
            this.Name = "world";
            this.Text = "world";
            this.Load += new System.EventHandler(this.world_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Drawship);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawAsteroid);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Drawbullet);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawVortex);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.world_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();
            

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lifeLabel;
        private System.Windows.Forms.Label scoreLabel;
    }
}