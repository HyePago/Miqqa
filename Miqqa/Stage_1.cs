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
        CharacterEngine characterEngine = new CharacterEngine();

        // 블록의 위치
        int[,] block_location = new int[,]{
            { 95, 20 },
            { 245, 245 },
            { 320, 320 },
            { 320, 395 },
            { 395, 395 },
            { 395, 320 },
            { 545, 170 }
        };
        List<PictureBox> block = new List<PictureBox>();

        // 아이템의 위치
        int[,] item_location = new int[,]
        {
            { 245, 245 },
            { 320, 320 },
            { 395, 320 },
            { 545, 170 }
        };
        int[,] finish_location = new int[,]
        {
            {395, 395 } 
        };

        // 폭탄
        List<PictureBox> bombs = new List<PictureBox>();
        List<int[]> bombs_location = new List<int[]>();
        List<int> bombs_count = new List<int>();
        List<PictureBox> waterball = new List<PictureBox>();
        Image bomb_image = Image.FromFile("./Images/Bomb/one.png");
        Image bomb_pop_image = Image.FromFile("./Images/Bomb/bomb.jpg");

        // 초콜릿 아이템
        List<PictureBox> choco = new List<PictureBox>();
        List<int[]> choco_location = new List<int[]>();
        List<int> choco_count = new List<int>();
        PictureBox chocolate = new PictureBox();

        // FINISH
        Image finishImage = Image.FromFile("./Images/Bomb/finish.png");
        PictureBox finish = new PictureBox();

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
            theHeart = 0;
            bombTick = 0;
            key_timer.Start();
            end = false;

            block.Add(pictureBox1);
            block.Add(pictureBox2);
            block.Add(pictureBox3);
            block.Add(pictureBox4);
            block.Add(pictureBox5);
            block.Add(pictureBox6);
            block.Add(pictureBox7);


        }

        int keyTick; // 이동 속도 제한
        int theTick; // 스테이지 깨는 시간
        int bombTick; // 폭탄 나오는 시간
        int bomb_x, bomb_y; // 폭탄 위치
        int theHeart; // 생명력 깎이는 거 제한
        bool end;

        // Key Timer
        private void key_timer_Tick(object sender, EventArgs e)
        {
            keyTick++;
            theTick++;
            bombTick++;
            theHeart++;

            for(int i=0; i<bombs_count.Count; i++)
            {
                bombs_count[i]++;
            }

            if(bombTick > 100) // 폭탄 투척
            {
                bombTick = 0;
                PictureBox bombPicture = new PictureBox();

                characterEngine.randomBomb(block_location, ref bomb_x, ref bomb_y);

                bombPicture.Size = new System.Drawing.Size(75, 75);
                bombPicture.Location = new System.Drawing.Point(bomb_x, bomb_y);
                bombPicture.BackColor = Color.Transparent;
                bombPicture.BackgroundImageLayout = ImageLayout.Stretch;
                bombPicture.Image = Image.FromFile("./Images/Bomb/waterball.gif");
                bombPicture.BackgroundImage = bombPicture.Image;
                Controls.Add(bombPicture);

                bombs.Add(bombPicture);
                bombs_location.Add(new int[]{ bomb_x, bomb_y });
                bombs_count.Add(0);             
            }

            // 폭탄 터지는 작업
            for(int i=0; i<bombs_count.Count; i++)
            {
                if(bombs_count[i] == 70) // 폭탄이 놓인지 3.5초가 지났으면
                {
                    bombs_location.RemoveAt(i);
                    bombs[i].BackgroundImage = bomb_pop_image;
                    int bombs_left = bombs[i].Left;
                    int bombs_top = bombs[i].Top;

                    if(bombs_left >= 95)
                    {
                        bombs_left -= 75;
                    }

                    bombs[i].Location = new System.Drawing.Point(bombs_left, bombs_top);

                    if (bombs_left < 770)
                    {
                        bombs[i].Size = new System.Drawing.Size(225, 75);
                    } else if (bombs_left < 95) {
                        bombs[i].Size = new System.Drawing.Size(150, 75);
                    } else
                    {
                        bombs[i].Size = new System.Drawing.Size(150, 75);
                    }


                    bombs[i].BackColor = Color.Transparent;
                    bombs[i].BackgroundImageLayout = ImageLayout.Stretch;

                    // 블록이 사라지는 동작
                    for(int j=0; j<block.Count(); j++)
                    {
                        for(int k=bombs[i].Location.X; k < bombs[i].Location.X + bombs[i].Size.Width; k+= 75)
                        {
                            if(block_location[j,0] == k && block_location[j,1] == bombs[i].Location.Y)
                            {
                                block[j].Visible = false;

                                // 아이템이 나오도록
                                for(int c=0; c < item_location.GetLength(0); c++)
                                {
                                    if(block_location[j,0] == item_location[c, 0] && block_location[j,1] == item_location[c, 1])
                                    {
                                        chocolate.Size = new System.Drawing.Size(75, 75);
                                        chocolate.Location = new System.Drawing.Point(item_location[c, 0], item_location[c, 1]);
                                        chocolate.BackColor = Color.Transparent;
                                        chocolate.BackgroundImageLayout = ImageLayout.Stretch;
                                        chocolate.Image = Image.FromFile("./Images/Item/chocolate.png");
                                        chocolate.BackgroundImage = chocolate.Image;
                                        Controls.Add(chocolate);

                                        choco.Add(chocolate);
                                        choco_location.Add(new int[] { item_location[c, 0], item_location[c, 1] });
                                        choco_count.Add(0);
                                    } 
                                }

                                if(block_location[j, 0] == finish_location[0, 0] && block_location[j,1] == finish_location[0, 1])
                                {
                                    finish.Size = new System.Drawing.Size(75, 75);
                                    finish.Location = new System.Drawing.Point(finish_location[0, 0], finish_location[0, 1]);
                                    finish.BackColor = Color.Transparent;
                                    finish.BackgroundImageLayout = ImageLayout.Stretch;
                                    finish.Image = finishImage;
                                    finish.BackgroundImage = chocolate.Image;
                                    Controls.Add(finish);
                                }

                                block.RemoveAt(j);
                                block_location[j, 0] = 0;
                                block_location[j, 1] = 0;
                            }
                        }
                    }
                }

                if(bombs_count[i] >= 70 && bombs_count[i] <= 90) // 캐릭터가 부딪치는 작업- 생명 하나 줄어드는 작업
                {
                    for (int k = bombs[i].Location.X; k < bombs[i].Location.X + bombs[i].Size.Width; k += 75)
                    {
                        if(mirim.Location.X == k && mirim.Location.Y == bombs[i].Location.Y)
                        {
                            if (theHeart > 20)
                            {
                                if (heart2.Visible == true)
                                {
                                    heart2.Visible = false;
                                }
                                else if (heart1.Visible == true)
                                {
                                    heart1.Visible = false;
                                }
                                else
                                {
                                    end = true;
                                    break;
                                }
                                theHeart = 0;
                            }
                        }
                    }
                }

                if (end == true) break;

                if (bombs_count[i] == 90)
                {
                    bombs[i].Visible = false;
                    bombs.RemoveAt(i);
                    bombs_count.RemoveAt(i);
                }
            }

            if(end == true)
            {
                Failed_End();
            }
        }

        void Failed_End()
        {
            key_timer.Stop();

            this.Visible = false;
            Stage_2 stage_2 = new Stage_2();
            stage_2.ShowDialog();
        }

        private static DateTime Delay(int MS)
        {
            DateTime ThisMoment = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, MS);
            DateTime AfterWards = ThisMoment.Add(duration);

            while (AfterWards >= ThisMoment)
            {
                System.Windows.Forms.Application.DoEvents();
                ThisMoment = DateTime.Now;
            }

            return DateTime.Now;
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
            PictureBox waterPicture = new PictureBox();
            int num = 0;
            if (e.KeyCode == Keys.Space)
            {
                waterPicture.Size = new System.Drawing.Size(75, 75);
                waterPicture.Location = new System.Drawing.Point(mirim.Left, mirim.Top); //*물풍선 위치는 space바 누를때마다 누른 지점(즉 캐릭터 위치에 물풍선 !)
                num = 1;
                int x_balloon = waterPicture.Location.X;
                int y_balloon = waterPicture.Location.Y;
                waterPicture.BackgroundImage = bomb_image;
                waterPicture.BackColor = Color.Transparent;
                waterPicture.BackgroundImageLayout = ImageLayout.Stretch;

                Controls.Add(waterPicture);
                if (num == 1)
                {
                    Delay(1000);
                    waterPicture.Size = new System.Drawing.Size(225, 75);
                    waterPicture.Location = new System.Drawing.Point(x_balloon -75, y_balloon);
                    waterPicture.BackgroundImage = bomb_pop_image;
                    Controls.Add(waterPicture);
                    // 블록이 사라지는 동작
                    for (int j = 0; j < block.Count(); j++)
                    {
                        for (int k = waterPicture.Location.X; k < waterPicture.Location.X + waterPicture.Size.Width; k += 75)
                        {
                            if (block_location[j, 0] == k && block_location[j, 1] == waterPicture.Location.Y)
                            {
                                block[j].Visible = false;
                                
                                // 아이템이 나오도록
                                for (int c = 0; c < item_location.GetLength(0); c++)
                                {
                                    if (block_location[j, 0] == item_location[c, 0] && block_location[j, 1] == item_location[c, 1])
                                    {
                                        chocolate.Size = new System.Drawing.Size(75, 75);
                                        chocolate.Location = new System.Drawing.Point(item_location[c, 0], item_location[c, 1]);
                                        chocolate.BackColor = Color.Transparent;
                                        chocolate.BackgroundImageLayout = ImageLayout.Stretch;
                                        chocolate.Image = Image.FromFile("./Images/Item/chocolate.png");
                                        chocolate.BackgroundImage = chocolate.Image;
                                        Controls.Add(chocolate);

                                        choco.Add(chocolate);
                                        choco_location.Add(new int[] { item_location[c, 0], item_location[c, 1] });
                                        choco_count.Add(0);
                                    }
                                }

                                if (block_location[j, 0] == finish_location[0, 0] && block_location[j, 1] == finish_location[0, 1])
                                {
                                    finish.Size = new System.Drawing.Size(75, 75);
                                    finish.Location = new System.Drawing.Point(finish_location[0, 0], finish_location[0, 1]);
                                    finish.BackColor = Color.Transparent;
                                    finish.BackgroundImageLayout = ImageLayout.Stretch;
                                    finish.Image = finishImage;
                                    finish.BackgroundImage = finish.Image;
                                    Controls.Add(finish);
                                }
                                //block.RemoveAt(j);
                                block_location[j, 0] = 0;
                                block_location[j, 1] = 0;
                            }
                        }
                    }
                    Delay(1000);
                    Controls.Remove(waterPicture);
                }
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

            characterEngine.character_move(ref x, ref y, e, ref keyTick, ref left, ref top, block_location, bombs_location);

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

            for (int i = 0; i < choco_count.Count; i++)
            {
                int choco_left = choco[i].Left;
                int choco_top = choco[i].Top;

                if (mirim.Left == choco_left && mirim.Top == choco_top) // 초콜릿을 먹었을 떄
                {
                    choco[i].Visible = false;
                    choco.RemoveAt(i);
                    choco_location.RemoveAt(i);
                    choco_count.RemoveAt(i);
                    //heart1.Visible = true;

                    if (heart1.Visible == false)
                    {
                        heart1.Visible = true;
                    }
                    else if (heart2.Visible == false)
                    {
                        heart2.Visible = true;
                    }
                }
            }

            if (finish_location[0, 0] == mirim.Left && finish_location[0, 1] == mirim.Top)
            {
                finish.Visible = false;
                finish_location[0, 0] = 0;
                finish_location[0, 1] = 0;

                for(int i=0; i<block.Count(); i++)
                {
                    block[i].Visible = false;

                    block_location[i, 0] = 0;
                    block_location[i, 1] = 0;
                }

                // 아이템이 나오도록
                for (int c = 0; c < 4; c++)
                {
                    chocolate.Size = new System.Drawing.Size(75, 75);
                    chocolate.Location = new System.Drawing.Point(item_location[c, 0], item_location[c, 1]);
                    chocolate.BackColor = Color.Transparent;
                    chocolate.BackgroundImageLayout = ImageLayout.Stretch;
                    chocolate.Image = Image.FromFile("./Images/Item/chocolate.png");
                    chocolate.BackgroundImage = chocolate.Image;
                    chocolate.Visible = true;
                    Controls.Add(chocolate);

                    choco.Add(chocolate);
                    choco_location.Add(new int[] { item_location[c, 0], item_location[c, 1] });
                    choco_count.Add(0);
                }
            }
        }
    }
}