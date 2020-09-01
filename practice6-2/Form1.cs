using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practice6_2
{
    public partial class Form1 : Form
    {
        PictureBox invader = new PictureBox();
        PictureBox ball = new PictureBox();
        int counter = 0;
        int score = 0;
        bool start = true;
        bool playing = true;
        bool reset = false;
        public Form1()
        {
            InitializeComponent();
            ship.Image = new Bitmap(Properties.Resources.ship_1, ship.Size);
            ship.Width = 53;
            ship.Height = 53;
            ball.Width = 20;
            ball.Height = 20;
            invader.Image = new Bitmap(Properties.Resources.ship_1, ship.Size);
            ball.Image = new Bitmap(Properties.Resources.pp, ball.Size);
            //timer1.Enabled = true;
            //timer2.Enabled = true;
            timer1.Start();
            timer2.Start();
        }

        private void ShipMove(object sender, KeyEventArgs e)
        {
            if (start==true)
            {
                switch (e.KeyCode)
                {
                    case Keys.Left:
                        if (ship.Left >= 2)
                            ship.Left -= 5;
                        break;
                    case Keys.Right:
                        if (ship.Left <= 283)
                            ship.Left += 5;
                        break;
                    case Keys.Down:
                        if (ship.Top <= 343)
                            ship.Top += 5;
                        break;
                    case Keys.Up:
                        if (ship.Top >= 2)
                            ship.Top -= 5;
                        break;
                    default:
                        break;
                }
            }
        }
        Random rnd = new Random();
        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (Control inv in this.Controls)
            {
                if (inv is PictureBox && inv.Tag == "invad")
                {
                    inv.Top += 5;
                    if (inv.Top > this.ClientSize.Height)
                    {
                        invader.Image = Properties.Resources.Invader;
                        invader.Location = inv.Location;
                        invader.Height = 70;
                        invader.Width = 70;
                        invader.BackColor = Color.Transparent;

                        inv.Top = 0;
                        inv.Left = rnd.Next(0, 290);
                    }
                    if (inv.Bounds.IntersectsWith(ship.Bounds))
                    {
                        timer1.Stop();
                        timer2.Stop();
                        start = false;
                        playing = false;
                    }
                }
                if (inv is PictureBox && inv.Tag == "ball")
                {
                    inv.Top += 10;
                    if (inv.Top > this.ClientSize.Height)
                    {
                        inv.Dispose();
                    }
                    if (inv.Bounds.IntersectsWith(ship.Bounds))
                    {
                        inv.Dispose();
                        score += 200;
                    }
                }

                counter++;
                if (counter == 10)
                {
                    PictureBox invader = new PictureBox();
                    invader.Height = 53;
                    invader.Width = 53;
                    invader.Top = 0;
                    invader.Left = 10;
                    invader.Image = Properties.Resources.Invader;
                    invader.Tag = "invad";
                    this.Controls.Add(invader);
                }
                if (counter%250 == 0)
                {
                    PictureBox ball = new PictureBox();
                    ball.Height = 20;
                    ball.Width = 20;
                    ball.Top = 0;
                    ball.Left = rnd.Next(0,320);
                    ball.Image = Properties.Resources.pp;
                    ball.Tag = "ball";
                    this.Controls.Add(ball);
                }
                if (counter == 200)
                {
                    PictureBox invader = new PictureBox();
                    invader.Height = 53;
                    invader.Width = 53;
                    invader.Top = 0;
                    invader.Left = 100;
                    invader.Image = Properties.Resources.Invader;
                    invader.Tag = "invad";
                    this.Controls.Add(invader);
                }
                if (counter == 400)
                {
                    PictureBox invader = new PictureBox();
                    invader.Height = 53;
                    invader.Width = 53;
                    invader.Top = 0;
                    invader.Left = 200;
                    invader.Image = Properties.Resources.Invader;
                    invader.Tag = "invad";
                    this.Controls.Add(invader);
                }
                if (counter == 600)
                {
                    PictureBox invader = new PictureBox();
                    invader.Height = 53;
                    invader.Width = 53;
                    invader.Top = 0;
                    invader.Left = 290;
                    invader.Image = Properties.Resources.Invader;
                    invader.Tag = "invad";
                    this.Controls.Add(invader);
                }

                /*
                if (counter==3)
                {
                    PictureBox invader;
                    invader = new PictureBox();
                    invader.Image = new Bitmap(Properties.Resources.ship_1, ship.Size);
                    invader_x = rnd.Next(0, 285);
                    invader.Location = new Point(invader_x, 0);
                    invader.BackColor = Color.Transparent;
                    this.Controls.Add(invader);
                    counter = 0;
                }
                else {
                    counter++;
                }
                foreach (Control invader in this.Controls) {

                }
                */

            }
        }

        private void restart() {
            if (!playing)
            {
                foreach (Control inv in this.Controls)
                {
                    for (int i = this.Controls.Count - 1; i >= 0; i--)
                    {
                        if (this.Controls[i] is PictureBox)
                            this.Controls[i].Dispose();
                    }
                }
                ship = new PictureBox();
                ship.Width = 53;
                ship.Height = 53;
                ship.Image = new Bitmap(Properties.Resources.ship_1, ship.Size);
                ship.Top = 300;
                ship.Left = 150;
                this.Controls.Add(ship);
                start = true;
                playing = true;
                reset = true;
                timer1.Start();
                start = true;
                reset = false;
                timer2.Start();
                score = 0;
                counter = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            start = true;
            restart();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            restart();
        }

        //private void timer2_Tick(object sender, EventArgs e)
        //{
        //    //counter2++;
        //}

        private void timer2_Tick_1(object sender, EventArgs e)
        {
            score++;
            label3.Text = score.ToString();
        }
    }
}
