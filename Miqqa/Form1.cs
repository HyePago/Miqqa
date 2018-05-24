using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Miqqa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) // Start Server
        {
        }

        private void join_Click(object sender, EventArgs e)
        {
            int result = Miqqa_sql.SignUp(username.Text, password.Text, nickname.Text);

            if(result == 2)
            {
                MessageBox.Show("중복되는 아이디 입력");
            }
            else if(result == 3)
            {
                MessageBox.Show("중복되는 닉네임 입력");
            }
            else
            {
                MessageBox.Show("회원가입 완료");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String nickname = Miqqa_sql.LogIn(username_login.Text, password_login.Text);

            MessageBox.Show(nickname);
        }
    }
}
