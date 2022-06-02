using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class world : Form
    {
       //Initializes the world and all the initial positions of objects created
        public world()
        {

            InitializeComponent();

            A1.x = 0;
            A1.y = 100;

            A2.x = 0;
            A2.y = 200;

            A3.x = 0;
            A3.y = 300;

            A4.x = 50;
            A4.y = 350;

            A5.x = 150;
            A5.y = 350;

            A6.x = 250;
            A6.y = 350;

            A7.x = 0;
            A7.y = 350;

            V1.x = 370;
            V1.y = 50;

            V2.x = 50;
            V2.y = 300;
            
        }
        private void getmax()
        {

        }
        
        private void world_Load(object sender, EventArgs e)
        {
            
        }
        
        private void instantiateasteroid()
        {
            
        }

        //creates all the asteroids in world
        Asteroid A1 = new Asteroid();
        Asteroid A2 = new Asteroid();
        Asteroid A3 = new Asteroid();
        Asteroid A4 = new Asteroid();
        Asteroid A5 = new Asteroid();
        Asteroid A6 = new Asteroid();
        Asteroid A7 = new Asteroid();

        //creates all the vortex in world
        Vortex V1 = new Vortex();
        Vortex V2 = new Vortex();

        //instantiates all variabels for ship, bullets, score and life
        public int xcord = 200;
        public int ycord = 200;
        public int xcordbullet;
        public int ycordbullet;
        public int score = 0;
        public int life = 3;

        //creates all the graphic objects needed to render images
        Graphics graphicsObj;
        Graphics graphicsObj1;
        Graphics graphicsObj2;
        Graphics graphicsObj3;

        //essentially a vector for bullet system
        ArrayList bullets = new ArrayList();
        public int bulletCount = 0;

        //function that draws the ship at location given
        public void Drawship(object sender, PaintEventArgs f)
        {
            graphicsObj = this.CreateGraphics();
            Pen shippen = new Pen(Color.BlueViolet, 10);
            Rectangle drawship = new Rectangle(xcord, ycord, 10, 10);
            graphicsObj.DrawRectangle(shippen, drawship);

        }

        //draws bullets at the location given.
        public void Drawbullet(object sender, PaintEventArgs f)
        {
            foreach (int[] coords in bullets)
            {
                graphicsObj2 = this.CreateGraphics();
                Pen bulletpen = new Pen(Color.LightGoldenrodYellow, 3);
                Rectangle bullet = new Rectangle(coords[0], coords[1], 3, 3);
                graphicsObj.DrawEllipse(bulletpen, bullet);
            }

        }

        //this function assesses user input for ship movement
        //based on key presses (arrow keys)
        //also adds bullet to vector if space key is pressed
        private void world_KeyDown(object sender, KeyEventArgs f)
        {
            
            if (f.KeyData == Keys.Right)
            {
                Invalidate();
                xcord += 5;
                if (xcord == 500)
                {
                    xcord = 0;
                }
            }
            if (f.KeyData == Keys.Left)
            {
                Invalidate();
                xcord -= 5;
                if (xcord == 0)
                {
                    xcord = 500;
                }
            }
            if (f.KeyData == Keys.Up)
            {
                Invalidate();
                ycord -= 5;
                if (ycord == 0)
                {
                    ycord = 400;
                }
            }
            if (f.KeyData == Keys.Down)
            {
                Invalidate();
                ycord += 5;
                if (ycord == 400)
                {
                    ycord = 0;
                }
            }
            if (f.KeyData == Keys.Down && f.KeyData == Keys.Left)
            {
                xcord -= 5;
                ycord += 5;
            }
            if (f.KeyData == Keys.Space)
            {
                xcordbullet = xcord;
                ycordbullet = ycord;

                int[] coordinateArr = new int[2] { xcordbullet, ycordbullet };
                bullets.Add(coordinateArr);
            }
        }

        
        //function that draws vortex at given position
        public void DrawVortex(object sender, PaintEventArgs e)
        {
            graphicsObj3 = this.CreateGraphics();
            Pen vortexpen = new Pen(Color.Green, 5);

            Rectangle vortex1 = new Rectangle(V1.x, V1.y, 20, 20);
            graphicsObj3.FillEllipse(Brushes.Green, vortex1);

            Rectangle vortex2 = new Rectangle(V2.x, V2.y, 20, 20);
            graphicsObj3.FillEllipse(Brushes.Green, vortex2);
        }

        //function that draws asteroids at given position
        public void DrawAsteroid(object sender, PaintEventArgs e)
        {
            graphicsObj1 = this.CreateGraphics();
            Pen asteroidpen = new Pen(Color.Red, 5);

            Rectangle drawasteroid1 = new Rectangle(A1.x, A1.y, 20, 20);
            graphicsObj1.DrawEllipse(asteroidpen, drawasteroid1);
            
            Rectangle drawasteroid2 = new Rectangle(A2.x, A2.y, 20, 20);
            graphicsObj1.DrawEllipse(asteroidpen, drawasteroid2);

            Rectangle drawasteroid3 = new Rectangle(A3.x, A3.y, 20, 20);
            graphicsObj1.DrawEllipse(asteroidpen, drawasteroid3);

            Rectangle drawasteroid4 = new Rectangle(A4.x, A4.y, 20, 20);
            graphicsObj1.DrawEllipse(asteroidpen, drawasteroid4);

            Rectangle drawasteroid5 = new Rectangle(A5.x, A5.y, 20, 20);
            graphicsObj1.DrawEllipse(asteroidpen, drawasteroid5);

            Rectangle drawasteroid6 = new Rectangle(A6.x, A6.y, 20, 20);
            graphicsObj1.DrawEllipse(asteroidpen, drawasteroid6);

            Rectangle drawasteroid7 = new Rectangle(A7.x, A7.y, 20, 20);
            graphicsObj1.DrawEllipse(asteroidpen, drawasteroid7);

        }

        //determines when object intersects with vortex
        public bool vortexintersect(int vortx, int vorty)
        {
            int distancex = Math.Abs(vortx - xcord);
            int distancey = Math.Abs(vorty - ycord);

            if (distancex > ((10 / 2) + 20)) { return false; }
            if (distancey > ((10 / 2) + 20)) { return false; }

            if (distancex <= (10 / 2)) { return true; }
            if (distancey <= (10 / 2)) { return true; }

            

            return (false);
        }

        //determines when ship intersects with ship
        public bool intersects(int astx,int asty)
        {
            int distancex = Math.Abs(astx - xcord);
            int distancey = Math.Abs(asty - ycord);

            if (distancex > ((10 / 2 )+ 20)) { return false; }
            if (distancey > ((10 / 2) + 20)) { return false; }

            if (distancex <= (10 / 2)) { return true; }
            if (distancey <= (10 / 2)) { return true; }


            int cornerintersection = (distancex - (10 / 2)) ^ 2 + (distancey - (10 / 2)) ^ 2;

            return (cornerintersection <= (20 ^ 2));
        }

        //determines when bullets hit asteroids
        public bool bulintersect(int astx, int asty,int bulx,int buly)
        {
            int distancex = Math.Abs(astx - bulx);
            int distancey = Math.Abs(asty - buly);

            if (distancex > (3 + 20)) { return false; }
            if (distancey > (3 + 20)) { return false; }

            if (distancex <= 3) { return true; }
            if (distancey <= 3) { return true; }


            return (false);
        }

        //sends everything to its initial position
        public void sendtoinitial()
        {
            xcord = 200;
            ycord = 200;

            A1.x = 0;
            A2.x = 0;
            A3.x = 0;
            A4.x = 50;
            A5.x = 150;
            A6.x = 250;
            A7.x = 0;

            A1.y = 100;
            A2.y = 200;
            A3.y = 300;
            A4.y = 350;
            A5.y = 350;
            A6.y = 350;
            A7.y = 350;
        }

        //timer function that does the checking for everything
        private void timer1_Tick(object sender, EventArgs e)
        {
            //conditional statemnts check if asteroids hit boundaries
            if (A1.y !=0)
            {
                A1.x += 4;
                A1.y -= 1;
                Invalidate();
            }
            else if (A1.y == 0)
            {
                A1.x = 0;
                A1.y = 100;
                Invalidate();
            }

            if (A2.y != 0)
            {
                A2.x += 3;
                A2.y -= 2;
                Invalidate();
            }
            else if (A2.y == 0)
            {
                A2.x = 0;
                A2.y = 200;
                Invalidate();
            }

            if (A3.y != 0)
            {
                A3.x += 3;
                A3.y -= 10;
                Invalidate();
            }
            else if (A3.y == 0)
            {
                A3.x = 0;
                A3.y = 300;
                Invalidate();
            }

            if (A4.y != 0)
            {
                A4.x += 3;
                A4.y -= 5;
                Invalidate();
            }
            else if (A4.y == 0)
            {
                A4.x = 50;
                A4.y = 350;
                Invalidate();
            }

            if (A5.x != 500)
            {
                A5.x += 5;
                A5.y -= 4;
                Invalidate();
            }
            else if (A5.x == 500)
            {
                A5.x = 150;
                A5.y = 350;
                Invalidate();
            }

            if (A6.x != 475)
            {
                A6.x += 5;
                A6.y -= 3;
                Invalidate();
            }
            else if (A6.x == 475)
            {
                A6.x = 250;
                A6.y = 350;
                Invalidate();
            }

            if (A7.x != 500)
            {
                A7.x += 4;
                A7.y -= 4;
                Invalidate();
            }
            else if (A7.x == 500)
            {
                A7.x = 0;
                A7.y = 350;
                Invalidate();
            }
            //forloop that increments the bullet position by 10 pixels
            foreach (int[] coords in bullets)
            {
                coords[1] -= 10;
            }


            //for loop to check wether each bullet in vector has hit an asteroid 
            foreach (int[] coords in bullets)
            {
               if (bulintersect(A1.x,A1.y,coords[0],coords[1]))
                {
                    score += 10;
                    A1.x = 0;
                    A1.y = 100;
                }
                if (bulintersect(A2.x, A2.y, coords[0], coords[1]))
                {
                    score += 10;
                    A2.x = 0;
                    A2.y = 200;
                }
                if (bulintersect(A3.x, A3.y, coords[0], coords[1]))
                {
                    score += 10;
                    A3.x = 0;
                    A3.y = 300;
                }
                if (bulintersect(A4.x, A4.y, coords[0], coords[1]))
                {
                    score += 10;
                    A4.x = 50;
                    A4.y = 350;
                }
                if (bulintersect(A5.x, A5.y, coords[0], coords[1]))
                {
                    score += 10;
                    A5.x = 150;
                    A5.y = 350;
                }
                if (bulintersect(A6.x, A6.y, coords[0], coords[1]))
                {
                    score += 10;
                    A6.x = 250;
                    A6.y = 350;
                }
                if (bulintersect(A7.x, A7.y, coords[0], coords[1]))
                {
                    score += 10;
                    A7.x = 0;
                    A7.y = 350;
                }
            }

            //conditional statements to check if ship hit asteroid
            //you loose a life as a result and asteroids restart to original position
            if (intersects(A1.x, A1.y))
            {
                life--;
                sendtoinitial();
            }

            if (intersects(A2.x, A2.y))
            {
                life--;
                sendtoinitial();
            }

            if (intersects(A3.x, A3.y))
            {
                life--;
                sendtoinitial();
            }
            if (intersects(A4.x, A4.y))
            {
                life--;
                sendtoinitial();
            }
            if (intersects(A5.x, A5.y))
            {
                life--;
                sendtoinitial();
            }
            if (intersects(A6.x, A6.y))
            {
                life--;
                sendtoinitial();
            }
            if (intersects(A7.x, A7.y))
            {
                life--;
                sendtoinitial();
            }


            //checks if ship hits vortex and sends ship to original position
            if (vortexintersect(V1.x, V1.y))
            {
                xcord = 200;
                ycord = 200;
                
            }

            if (vortexintersect(V2.x, V2.y))
            {
                xcord = 200;
                ycord = 200;
            }

            //determines if game is over
            if (life == 0)
            {
                Form3 openForm = new Form3(score);
                openForm.Show();
                
                this.Close();
            }

            lifeLabel.Text = ("Lifes: " + life.ToString());
            scoreLabel.Text = ("Score: " + score.ToString());
            
   
        }

       

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


    }
}

