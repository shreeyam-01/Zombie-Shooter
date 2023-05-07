namespace project_1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtammo = new System.Windows.Forms.Label();
            this.health = new System.Windows.Forms.Label();
            this.txtscore = new System.Windows.Forms.Label();
            this.healthBar = new System.Windows.Forms.ProgressBar();
            this.player = new System.Windows.Forms.PictureBox();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            this.SuspendLayout();
            // 
            // txtammo
            // 
            this.txtammo.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtammo.ForeColor = System.Drawing.Color.White;
            this.txtammo.Location = new System.Drawing.Point(-1, 0);
            this.txtammo.Name = "txtammo";
            this.txtammo.Size = new System.Drawing.Size(145, 47);
            this.txtammo.TabIndex = 0;
            this.txtammo.Text = "Ammo: 0";
            this.txtammo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // health
            // 
            this.health.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.health.ForeColor = System.Drawing.Color.White;
            this.health.Location = new System.Drawing.Point(529, 0);
            this.health.Name = "health";
            this.health.Size = new System.Drawing.Size(145, 47);
            this.health.TabIndex = 1;
            this.health.Text = "Health:";
            this.health.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtscore
            // 
            this.txtscore.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtscore.ForeColor = System.Drawing.Color.White;
            this.txtscore.Location = new System.Drawing.Point(315, 0);
            this.txtscore.Name = "txtscore";
            this.txtscore.Size = new System.Drawing.Size(145, 47);
            this.txtscore.TabIndex = 2;
            this.txtscore.Text = "Kills: 0";
            this.txtscore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // healthBar
            // 
            this.healthBar.Location = new System.Drawing.Point(649, 12);
            this.healthBar.Name = "healthBar";
            this.healthBar.Size = new System.Drawing.Size(217, 23);
            this.healthBar.TabIndex = 3;
            this.healthBar.Value = 100;
            // 
            // player
            // 
            this.player.Image = global::project_1.Properties.Resources.up;
            this.player.Location = new System.Drawing.Point(389, 532);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(71, 100);
            this.player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.player.TabIndex = 4;
            this.player.TabStop = false;
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.mainTimerEvent);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(878, 644);
            this.Controls.Add(this.player);
            this.Controls.Add(this.healthBar);
            this.Controls.Add(this.txtscore);
            this.Controls.Add(this.health);
            this.Controls.Add(this.txtammo);
            this.Name = "Form1";
            this.Text = "Zombie Shooter";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label txtammo;
        private Label health;
        private Label txtscore;
        private ProgressBar healthBar;
        private PictureBox player;
        private System.Windows.Forms.Timer gameTimer;
    }
}