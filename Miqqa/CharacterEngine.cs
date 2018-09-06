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
    class CharacterEngine
    {
        string[] fileName = { "./Images/Character/one.png", "./Images/Character/three.png" };

        //public void character_move(ref int x, ref int y, PreviewKeyDownEventArgs e, ref int keyTick, ref int left, ref int top, int[ , ] block_location, List<int[]> bombs_location)
        public void character_move(ref int x, ref int y, PreviewKeyDownEventArgs e, ref int keyTick, ref int left, ref int top, int[ , ] block_location)
        {
            left = 0;
            top = 0;

            int character_x = 0;
            int character_y = 0;

            switch (e.KeyCode)
            {
                case Keys.Left:
                    if(x >= 75)
                    {
                        left -= 75;
                    }
                    break;
                case Keys.Right:
                    if(x < 825)
                    {
                        left += 75;
                    }
                    break;
                case Keys.Up:
                    if (y >= 75)
                    {
                        top -= 75;
                    }
                    break;
                case Keys.Down:
                    if(y < 600)
                    {
                        top += 75;
                    }
                    break;
            }

            character_x = x + 20 + left;
            character_y = y + 20 + top;

            for(int i=0; i<block_location.GetLength(0); i++)
            {
                if(character_x == block_location[i,0] && character_y == block_location[i, 1])
                {
                    top = 0;
                    left = 0;
                    break;
                }
            }

            keyTick = 0;
        }

        public void randomBomb(int[,] block_location, ref int bomb_x, ref int bomb_y)
        {
            Random rand = new Random();
            int x = rand.Next(1, 12);
            int y = rand.Next(1, 9);

            x = x * 75 + 20;
            y = y * 75 + 20;

            for(int i=0; i<block_location.GetLength(0); i++)
            {
                if(x==block_location[i, 0] && y == block_location[i, 1])
                {
                    x = rand.Next(1, 13);
                    y = rand.Next(1, 10);
                    i = -1;
                }
            }

            bomb_x = x;
            bomb_y = y;
        }
    }
}