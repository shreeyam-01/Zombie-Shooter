namespace project_1
{
    public partial class Form1 : Form
    {
        // 1. Move the player
        bool goLeft, goRight, goUp, goDown;
        string facing="up";
        int speed = 10;

        // 2. Shoot bullet: declare string direction inside the shootBullet
        int ammo = 10;

        // 3. Drop ammo
        Random rndNum = new Random();

        // 4. Make zombies
        List<PictureBox> zombiesList = new List<PictureBox>();
        int zombieSpeed = 3;
        int score;
        int playerHealth = 100;

        // 5. gameover
        bool gameOver;
        
        public Form1()
        {
            InitializeComponent();
            restartGame();
        }

        private void mainTimerEvent(object sender, EventArgs e)
        {
            if (playerHealth > 1)
            {
                healthBar.Value = playerHealth;
            }
            else
            {
                gameOver = true;
                gameTimer.Stop();
                player.Image = Properties.Resources.dead;
            }
            txtammo.Text = "Ammo: " + ammo;
            txtscore.Text = "Kills: " + score;
            
            if(goUp==true && player.Top > 45)
            {
                player.Top -= speed;
            }
            if(goDown==true && player.Top + player.Height < this.ClientSize.Height)
            {
                player.Top += speed;
            }
            if(goRight==true && player.Left + player.Width < this.ClientSize.Width)
            {
                player.Left += speed;
            }
            if(goLeft==true && player.Left > 0)
            {
                player.Left -= speed;
            }

            foreach(Control x in this.Controls)
            {
                if(x is PictureBox && (string)x.Tag == "zombie")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        playerHealth -= 1;
                    }
                }
                if (x is PictureBox && (string)x.Tag == "ammo")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        this.Controls.Remove(x);
                        ((PictureBox)x).Dispose();
                        ammo += 5;
   
                    }
                }

                if (x is PictureBox && (string)x.Tag == "zombie")
                {
                    if (x.Left < player.Left)
                    {
                        x.Left += zombieSpeed;
                        ((PictureBox)x).Image = Properties.Resources.zright;
                    }
                    if (x.Left > player.Left)
                    {
                        x.Left -= zombieSpeed;
                        ((PictureBox)x).Image = Properties.Resources.zleft;
                    }
                    if (x.Top < player.Top)
                    {
                        x.Top += zombieSpeed;
                        ((PictureBox)x).Image = Properties.Resources.zdown;
                    }
                    if (x.Top > player.Top)
                    {
                        x.Top -= zombieSpeed;
                        ((PictureBox)x).Image = Properties.Resources.zup;
                    }
                }

                foreach(Control j in this.Controls)
                {
                    if(j is PictureBox && (string)j.Tag=="bullet" && x is PictureBox && (string)x.Tag == "zombie")
                    {
                        if (x.Bounds.IntersectsWith(j.Bounds))
                        {
                            score++;
                            this.Controls.Remove(j);
                            ((PictureBox)j).Dispose();
                            this.Controls.Remove(x);
                            ((PictureBox)x).Dispose();
                            zombiesList.Remove(((PictureBox)x));
                            makeZombies();
                        }
                    }
                }
            }
        }

        private void shootBullet(string direction)
        {
            makeBullet shootBullet = new makeBullet();
            shootBullet.direction = direction;
            shootBullet.bulletLeft = player.Left + (player.Width / 2);
            shootBullet.bulletTop = player.Top + (player.Height / 2);
            shootBullet.makeaBullet(this);
        }

        private void dropAmmo()
        {
            PictureBox ammo = new PictureBox();
            ammo.Tag = "ammo";
            ammo.Image = Properties.Resources.ammo_Image;
            ammo.SizeMode = PictureBoxSizeMode.AutoSize;
            ammo.Left = rndNum.Next(10, this.ClientSize.Width - ammo.Width);
            ammo.Top = rndNum.Next(60, this.ClientSize.Height - ammo.Height);

            this.Controls.Add(ammo);
            ammo.BringToFront();
            player.BringToFront();
        }
        private void makeZombies()
        {
            PictureBox zombie = new PictureBox();
            zombie.Tag = "zombie";
            zombie.Image = Properties.Resources.zdown;
            zombie.SizeMode = PictureBoxSizeMode.AutoSize;
            zombie.Left = rndNum.Next(0, 900);
            zombie.Top = rndNum.Next(0, 800);

            zombiesList.Add(zombie);
            this.Controls.Add(zombie);
            player.BringToFront();
        }

        private void restartGame()
        {
            player.Image = Properties.Resources.up;

            foreach(PictureBox i in zombiesList)
            {
                this.Controls.Remove(i);
            }
            zombiesList.Clear();
            for(int i = 0; i < 3; i++)
            {
                makeZombies();
            }
            goUp = false;goDown = false;goRight = false;goLeft = false;
            gameOver = false;
            playerHealth = 100;
            score = 0;
            ammo = 10;
            gameTimer.Start();
        }

        private void keyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;          
            }
            if (e.KeyCode == Keys.Up)
            {
                goUp = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = false;
            }

            if (e.KeyCode == Keys.Space && ammo>0 && gameOver==false)
            {
                ammo--;
                shootBullet(facing);
                if (ammo < 1)
                {
                    dropAmmo();
                }
            }

            if(e.KeyCode==Keys.R && gameOver == true)
            {
                restartGame();
            }
        }

        private void keyIsDown(object sender, KeyEventArgs e)
        {
            if (gameOver == true)
            {
                return;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
                facing = "right";
                player.Image = Properties.Resources.right;
            }
            if (e.KeyCode == Keys.Left)
            {
                goLeft = true;
                facing = "left";
                player.Image = Properties.Resources.left;
            }
            if (e.KeyCode == Keys.Up)
            {
                goUp = true;
                facing = "up";
                player.Image = Properties.Resources.up;
            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = true;
                facing = "down";
                player.Image = Properties.Resources.down;
            }
            
        }
    }
}