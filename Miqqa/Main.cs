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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            theTick = 0;
            timer1.Start();
        }

        int theTick;

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            theTick++;
            //Invalidate();
            if(theTick == 30)
            {
                this.Visible = false;
                Form1 form1 = new Form1();
                form1.ShowDialog();
            }
        }
    }
}
