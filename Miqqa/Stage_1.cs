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
        // Character
        string[] fileName = { "./Images/Character/one.png", "./Images/Character/three.png" };
        Boolean mirim_img = true;
        Image mirim_image;
        CharacterEngine characterEngine = new CharacterEngine();

        // 블록의 위치
        int[,] blockLocation = new int[25,2];
        List<PictureBox> block = new List<PictureBox>();

        // 폭탄 (게임에서 던지는 폭탄)
        List<PictureBox> bombs = new List<PictureBox>();
        List<int[]> bombsLocation = new List<int[]>();
        List<int> bombsCount = new List<int>();

        // 폭탄 이미지
        Image bombImage = Image.FromFile("./Images/Bomb/one.png");
        Image bombPopImage = Image.FromFile("./Images/Bomb/bomb.jpg");

        // 물풍선 (사용자가 던지는 물풍선)
        List<PictureBox> waterball = new List<PictureBox>();
        List<int[]> waterballLocation = new List<int[]>();
        List<int> waterballCount = new List<int>();


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

            block.Add(pictureBox1);
            blockLocation[0, 0] = pictureBox1.Location.X;
            blockLocation[0, 1] = pictureBox1.Location.Y;
            block.Add(pictureBox2);
            blockLocation[1, 0] = pictureBox2.Location.X;
            blockLocation[1, 1] = pictureBox2.Location.Y;
            block.Add(pictureBox3);
            blockLocation[2, 0] = pictureBox3.Location.X;
            blockLocation[2, 1] = pictureBox3.Location.Y;
            block.Add(pictureBox4);
            blockLocation[3, 0] = pictureBox4.Location.X;
            blockLocation[3, 1] = pictureBox4.Location.Y;
            block.Add(pictureBox5);
            blockLocation[4, 0] = pictureBox5.Location.X;
            blockLocation[4, 1] = pictureBox5.Location.Y;
            block.Add(pictureBox6);
            blockLocation[5, 0] = pictureBox6.Location.X;
            blockLocation[5, 1] = pictureBox6.Location.Y;
            block.Add(pictureBox7);
            blockLocation[6, 0] = pictureBox7.Location.X;
            blockLocation[6, 1] = pictureBox7.Location.Y;
            block.Add(pictureBox8);
            blockLocation[7, 0] = pictureBox8.Location.X;
            blockLocation[7, 1] = pictureBox8.Location.Y;
            block.Add(pictureBox9);
            blockLocation[8, 0] = pictureBox9.Location.X;
            blockLocation[8, 1] = pictureBox9.Location.Y;
            block.Add(pictureBox10);
            blockLocation[9, 0] = pictureBox10.Location.X;
            blockLocation[9, 1] = pictureBox10.Location.Y;
            block.Add(pictureBox11);
            blockLocation[10, 0] = pictureBox11.Location.X;
            blockLocation[10, 1] = pictureBox11.Location.Y;
            block.Add(pictureBox12);
            blockLocation[11, 0] = pictureBox12.Location.X;
            blockLocation[11, 1] = pictureBox12.Location.Y;
            block.Add(pictureBox13);
            blockLocation[12, 0] = pictureBox13.Location.X;
            blockLocation[12, 1] = pictureBox13.Location.Y;
            block.Add(pictureBox14);
            blockLocation[13, 0] = pictureBox14.Location.X;
            blockLocation[13, 1] = pictureBox14.Location.Y;
            block.Add(pictureBox15);
            blockLocation[14, 0] = pictureBox15.Location.X;
            blockLocation[14, 1] = pictureBox15.Location.Y;
            block.Add(pictureBox16);
            blockLocation[15, 0] = pictureBox16.Location.X;
            blockLocation[15, 1] = pictureBox16.Location.Y;
            block.Add(pictureBox17);
            blockLocation[16, 0] = pictureBox17.Location.X;
            blockLocation[16, 1] = pictureBox17.Location.Y;
            block.Add(pictureBox18);
            blockLocation[17, 0] = pictureBox18.Location.X;
            blockLocation[17, 1] = pictureBox18.Location.Y;
            block.Add(pictureBox19);
            blockLocation[18, 0] = pictureBox19.Location.X;
            blockLocation[18, 1] = pictureBox19.Location.Y;
            block.Add(pictureBox20);
            blockLocation[19, 0] = pictureBox20.Location.X;
            blockLocation[19, 1] = pictureBox20.Location.Y;
            block.Add(pictureBox21);
            blockLocation[20, 0] = pictureBox21.Location.X;
            blockLocation[20, 1] = pictureBox21.Location.Y;
            block.Add(pictureBox22);
            blockLocation[21, 0] = pictureBox22.Location.X;
            blockLocation[21, 1] = pictureBox22.Location.Y;
            block.Add(pictureBox23);
            blockLocation[22, 0] = pictureBox23.Location.X;
            blockLocation[22, 1] = pictureBox23.Location.Y;
            block.Add(pictureBox24);
            blockLocation[23, 0] = pictureBox24.Location.X;
            blockLocation[23, 1] = pictureBox24.Location.Y;
            block.Add(pictureBox25);
            blockLocation[24, 0] = pictureBox25.Location.X;
            blockLocation[24, 1] = pictureBox25.Location.Y;
        }

        int keyTick; // 이동 속도 제한
        int theTick; // 스테이지 깨는 시간

        // Key Timer
        private void key_timer_Tick(object sender, EventArgs e)
        {
            keyTick++;
            theTick++;


            current_time.Text = (theTick / 50) + "초";

            // 폭탄 및 물풍선이 터지는 작업
            for(int i=0; i<waterballCount.Count; i++)
            {
                waterballCount[i]++; // 시간 추가

                if(waterballCount[i] == 70)
                {
                    // 폭탄이 놓인 지 3.5초가 지났다면
                    waterball[i].Image = bombPopImage;
                    waterball[i].BackgroundImage = bombPopImage;

                    int waterballLeft = waterball[i].Left;
                    int waterballTop = waterball[i].Top;

                    if(waterballLeft >= 95)
                    {
                        waterballLeft -= 75;
                    }

                    waterball[i].Location = new System.Drawing.Point(waterballLeft, waterballTop);

                    if(waterballLeft < 770)
                    {
                        waterball[i].Size = new System.Drawing.Size(225, 75);
                    } else
                    {
                        waterball[i].Size = new System.Drawing.Size(150, 75);
                    }

                    waterball[i].BackColor = Color.Transparent;
                    waterball[i].BackgroundImageLayout = ImageLayout.Stretch;

                    // 블록이 사라지는 동작
                    for(int j=0; j<block.Count; j++)
                    {
                        for (int k = waterball[i].Location.X; k < waterball[i].Location.X + waterball[i].Size.Width; k += 75)
                        {
                            if (blockLocation[j, 0] == k && blockLocation[j, 1] == waterball[i].Location.Y)
                            {
                                block[j].Visible = false;   
                                blockLocation[j, 0] = 0;
                                blockLocation[j, 1] = 0;
                                // 아이템이 나오도록
                            }
                        }
                    }
                }

                // 폭탄이 사라지는 과정
                if(waterballCount[i] == 90)
                {
                    waterball[i].Visible = false;
                    waterball.RemoveAt(i);
                    waterballLocation.RemoveAt(i);
                    waterballCount.RemoveAt(i);
                }
            }
        }

        // Key Down Event
        void Stage_1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //MessageBox.Show(e.KeyChar.ToString());
        }


        // Key Down Event(방향키)
        private void stage_1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            // 물풍선
            if(e.KeyCode == Keys.Space)
            {
                // Space를 누를 경우
                PictureBox waterPicture = new PictureBox();
                waterPicture.Size = new System.Drawing.Size(75, 75);
                waterPicture.Location = new System.Drawing.Point(mirim.Left, mirim.Top); // 누른 시점의 캐릭터의 위치

                waterPicture.BackgroundImage = bombImage;
                waterPicture.BackColor = Color.Transparent;
                waterPicture.BackgroundImageLayout = ImageLayout.Stretch;

                Controls.Add(waterPicture);

                // 리스트에 추가
                waterball.Add(waterPicture);
                waterballLocation.Add(new int[] { waterPicture.Location.X, waterPicture.Location.Y });
                waterballCount.Add(0);
            }

            if (keyTick < 3) // 이동 초 제한
            {
                return;
            }

            int x_blank = 20;
            int y_blank = 20;

            int x = mirim.Left - x_blank;
            int y = mirim.Top - y_blank;
            int left = 0, top = 0;

            characterEngine.character_move(ref x, ref y, e, ref keyTick, ref left, ref top, blockLocation); //bomb

            // 이미지 변경
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

            mirim.Left += left;
            mirim.Top += top;
        }
    }
}