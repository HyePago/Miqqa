using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Miqqa
{
    public partial class Stage_1 : Form
    {
        string[] fileName = { "./Images/Character/one.png", "./Images/Character/three.png" };
        Boolean mirim_img = true;
        Image mirim_image;

        public Stage_1()
        {
            InitializeComponent();

            mirim.BackColor = Color.Transparent;

            this.PreviewKeyDown += new PreviewKeyDownEventHandler(stage_1_PreviewKeyDown);
            this.KeyPress += new KeyPressEventHandler(Stage_1_KeyPress);

            mirim_image = Image.FromFile(fileName[0]);
            mirim.BackgroundImage = mirim_image;

            keyTick = 0;
            theTick = 0;
            key_timer.Start();
        }

        int keyTick; // 이동 속도 제한
        int theTick; // 스테이지 깨는 시간

        // Key Timer
        private void key_timer_Tick(object sender, EventArgs e)
        {
            keyTick++;
            theTick++;
        }

        // Key Down Event
        void Stage_1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //MessageBox.Show(e.KeyChar.ToString());
        }
        // Key Down Event(방향키)
        private void stage_1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(keyTick < 6) // 이동 초 제한
            {
                return;
            }

            int x_blank = 20;
            int y_blank = 20;

            int x = mirim.Left - x_blank;
            int y = mirim.Top - y_blank;
            switch (e.KeyCode)
            {
                case Keys.Left:
                    if (x >= 75)
                    {
                        mirim.Left -= 75;
                        if(mirim_img == true)
                        {
                            mirim_image = Image.FromFile(fileName[1]);
                            mirim.BackgroundImage = mirim_image;
                            mirim_img = false;
                        } else
                        {
                            mirim_image = Image.FromFile(fileName[0]);
                            mirim.BackgroundImage = mirim_image;
                            mirim_img = true;
                        }
                    }
                    break;
                case Keys.Right:
                    if (x < 825) {
                        mirim.Left += 75;
                        if (mirim_img == true)
                        {
                            mirim_image = Image.FromFile(fileName[1]);
                            mirim.BackgroundImage = mirim_image;
                            mirim_img = false;
                        }
                        else
                        {
                            mirim_image = Image.FromFile(fileName[0]);
                            mirim.BackgroundImage = mirim_image;
                            mirim_img = true;
                        }
                    }
                    break;
                case Keys.Up:
                    if (y >= 75)
                    {
                        mirim.Top -= 75;
                        if (mirim_img == true)
                        {
                            mirim_image = Image.FromFile(fileName[1]);
                            mirim.BackgroundImage = mirim_image;
                            mirim_img = false;
                        }
                        else
                        {
                            mirim_image = Image.FromFile(fileName[0]);
                            mirim.BackgroundImage = mirim_image;
                            mirim_img = true;
                        }
                    }
                    break;
                case Keys.Down:
                    if (y < 600)
                    {
                        mirim.Top += 75;
                        if (mirim_img == true)
                        {
                            mirim_image = Image.FromFile(fileName[1]);
                            mirim.BackgroundImage = mirim_image;
                            mirim_img = false;
                        }
                        else
                        {
                            mirim_image = Image.FromFile(fileName[0]);
                            mirim.BackgroundImage = mirim_image;
                            mirim_img = true;
                        }
                    }
                    break;
            }

            keyTick = 0;
        }
    }
}
