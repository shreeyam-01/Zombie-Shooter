using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Windows.Forms;
using System.Timers;

namespace project_1
{
    class makeBullet
    {
        public string direction;
        public int bulletLeft;
        public int bulletTop;

        private int speed=20;
        private PictureBox bullet = new PictureBox();
        private System.Windows.Forms.Timer bulletTimer = new System.Windows.Forms.Timer();

        public void makeaBullet(Form form)
        {
            // Properties
            bullet.BackColor = Color.White;
            bullet.Size = new Size(5, 5);
            bullet.Tag = "bullet";
            bullet.Left = bulletLeft;
            bullet.Top = bulletTop;
            bullet.BringToFront();

            form.Controls.Add(bullet);

            bulletTimer.Interval = speed;
            bulletTimer.Tick += new EventHandler(BulletTimerEvent);
            bulletTimer.Start();
        }

        public void BulletTimerEvent(object sender, EventArgs e)
        {
            if (direction == "left")
            {
                bullet.Left -= speed;
            }
            if (direction == "right")
            {
                bullet.Left += speed;
            }
            if (direction == "up")
            {
                bullet.Top -= speed;
            }
            if (direction == "down")
            {
                bullet.Top += speed;
            }

            if (bullet.Top < 10 || bullet.Left < 10 || bullet.Top > 600 || bullet.Left > 860)
            {
                bulletTimer.Tick -= BulletTimerEvent;
                bulletTimer.Stop();
                bulletTimer.Dispose();
                bullet.Dispose();
                bullet = null;
                bulletTimer = null;
            }
        }
    }
}
