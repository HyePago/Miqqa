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
    public partial class Stage_3 : Form
    {
        string[] fileName = { "./Images/Character/one.png", "./Images/Character/three.png" };
        Boolean mirim_img = true;
        Image mirim_image;
        List<int[]> bombs_location = new List<int[]>();
        // 블록의 위치
        int[,] block_location = new int[,]{
            { 95, 20 },
            { 245, 245 },
            { 320, 320 },
            { 320, 395 },
            { 395, 395 },
            { 395, 320 }
        };

        public Stage_3()
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

        // Key Down Event
        void Stage_1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //MessageBox.Show(e.KeyChar.ToString());
        }
        // Key Down Event(방향키)
        private void stage_1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (keyTick < 6) // 이동 초 제한
            {
                return;
            }

            int x_blank = 20;
            int y_blank = 20;

            int x = mirim.Left - x_blank;
            int y = mirim.Top - y_blank;
            int left = 0, top = 0;


            CharacterEngine characterEngine = new CharacterEngine();
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
        }

        private void key_timer_Tick(object sender, EventArgs e)
        {
            keyTick++;
            theTick++;
        }
    }
}
