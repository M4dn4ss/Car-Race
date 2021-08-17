using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_Race
{
    public partial class CarRace : Form
    {
        public CarRace()
        {
            InitializeComponent();
            lblGameOver.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            moveLine(gameSpeed);
            enemy(gameSpeed);
            gameOver();
            coins(gameSpeed);
            coinsCollection();
        }

        int collectedCoin = 0;

        Random r = new Random();
        int x, y;
        void enemy(int speed)
        {
            if (pictureBoxEnemy1.Top >= 500)
            {
                x = r.Next(0, 200);                
                pictureBoxEnemy1.Location = new Point(x, 0);
            }
            else
            {
                pictureBoxEnemy1.Top += speed;
            }

            if (pictureBoxEnemy2.Top >= 500)
            {
                x = r.Next(0, 400);
                pictureBoxEnemy2.Location = new Point(x, 0);
            }
            else
            {
                pictureBoxEnemy2.Top += speed;
            }

            if (pictureBoxEnemy3.Top >= 500)
            {
                x = r.Next(200, 350);
                pictureBoxEnemy3.Location = new Point(x, 0);
            }
            else
            {
                pictureBoxEnemy3.Top += speed;
            }
        }


        void coins(int speed)
        {
            if (pictureBoxCoin1.Top >= 500)
            {
                x = r.Next(0, 200);

                pictureBoxCoin1.Location = new Point(x, 0);
            }
            else
            {
                pictureBoxCoin1.Top += speed;
            }

            if (pictureBoxCoin2.Top >= 500)
            {
                x = r.Next(0, 200);

                pictureBoxCoin2.Location = new Point(x, 0);
            }
            else
            {
                pictureBoxCoin2.Top += speed;
            }

            if (pictureBoxCoin3.Top >= 500)
            {
                x = r.Next(50, 300);

                pictureBoxCoin3.Location = new Point(x, 0);
            }
            else
            {
                pictureBoxCoin3.Top += speed;
            }

            if (pictureBoxCoin4.Top >= 500)
            {
                x = r.Next(0, 400);

                pictureBoxCoin4.Location = new Point(x, 0);
            }
            else
            {
                pictureBoxCoin4.Top += speed;
            }


        }

        void gameOver()
        {
            if (pictureBoxCar.Bounds.IntersectsWith(pictureBoxEnemy1.Bounds))
            {
                timer1.Enabled = false;
                lblGameOver.Visible = true;
            }

            if (pictureBoxCar.Bounds.IntersectsWith(pictureBoxEnemy2.Bounds))
            {
                timer1.Enabled = false;
                lblGameOver.Visible = true;
            }

            if (pictureBoxCar.Bounds.IntersectsWith(pictureBoxEnemy3.Bounds))
            {
                timer1.Enabled = false;
                lblGameOver.Visible = true;
            }
        }
        /// <summary>
        /// Makes the road move
        /// </summary>
        /// <param name="speed"></param>
        void moveLine(int speed)
        {
            if (pictureBox1.Top>=500)
            {
                pictureBox1.Top = 0;
            }
            else
            {
                pictureBox1.Top += speed;
            }

            if (pictureBox2.Top >= 500)
            {
                pictureBox2.Top = 0;
            }
            else
            {
                pictureBox2.Top += speed;
            }

            if (pictureBox3.Top >= 500)
            {
                pictureBox3.Top = 0;
            }
            else
            {
                pictureBox3.Top += speed;
            }

            if (pictureBox4.Top >= 500)
            {
                pictureBox4.Top = 0;
            }
            else
            {
                pictureBox4.Top += speed;
            }

        }

        private void CarRace_Load(object sender, EventArgs e)
        {
            // Rotate car image to right direction
            Image img = pictureBoxCar.Image;
            img.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pictureBoxCar.Image = img;


        }

        void coinsCollection()
        {
            if (pictureBoxCar.Bounds.IntersectsWith(pictureBoxCoin1.Bounds))
            {
                collectedCoin++;
                lblCoin.Text = "Coins=" + collectedCoin.ToString();

                x = r.Next(50, 300);

                pictureBoxCoin1.Location = new Point(x, 0);
            }

            if (pictureBoxCar.Bounds.IntersectsWith(pictureBoxCoin2.Bounds))
            {
                collectedCoin++;
                lblCoin.Text = "Coins=" + collectedCoin.ToString();

                x = r.Next(50, 300);

                pictureBoxCoin2.Location = new Point(x, 0);
            }

            if (pictureBoxCar.Bounds.IntersectsWith(pictureBoxCoin3.Bounds))
            {
                collectedCoin++;
                lblCoin.Text = "Coins=" + collectedCoin.ToString();

                x = r.Next(50, 300);

                pictureBoxCoin3.Location = new Point(x, 0);
            }

            if (pictureBoxCar.Bounds.IntersectsWith(pictureBoxCoin4.Bounds))
            {
                collectedCoin++;
                lblCoin.Text = "Coins=" + collectedCoin.ToString();

                x = r.Next(50, 300);

                pictureBoxCoin4.Location = new Point(x, 0);
            }
        }

        // Makes the whole speeding and slowing effect
        int gameSpeed = 0;
        private void CarRace_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                if (pictureBoxCar.Left > 0)
                {
                    pictureBoxCar.Left += -8;
                }
                
            }

            if (e.KeyCode == Keys.Right)
            {
                if (pictureBoxCar.Right < 380)
                {
                    pictureBoxCar.Left += 8;
                }
                
            }

            if (e.KeyCode == Keys.Up)
            {
                if (gameSpeed < 21)
                {
                    gameSpeed++;
                }
                
            }

            if (e.KeyCode == Keys.Down)
            {
                if (gameSpeed > 0)
                {
                    gameSpeed--;
                }
            }


        }
    }
}
