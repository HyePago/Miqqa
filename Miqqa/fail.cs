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
    public partial class fail : Form
    {
        public fail()
        {
            InitializeComponent();

            thetime.BackColor = Color.Transparent;
            theitem.BackColor = Color.Transparent;
        }

        private void fail_Load(object sender, EventArgs e)
        {
            thetime.Text = (time / 20) + "초";
            theitem.Text = item + "개";
        }

        public int item;
        public int time;
    }
}
