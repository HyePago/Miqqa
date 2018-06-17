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
        //System.Media.SoundPlayer player = new System.Media.SoundPlayer();

        public Form1()
        {
            InitializeComponent();
            Main main = new Main();
            main.Close();

            password.PasswordChar = '*';
            password_login.PasswordChar = '*';
        }

        private void Form1_Load(object sender, EventArgs e) // Start Server
        {
            //player.SoundLocation = "crazy_bgm.wav";
            //player.Play();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int result = Miqqa_sql.SignUp(username.Text, password.Text, nickname.Text);

            if (result == 2)
            {
                MessageBox.Show("중복되는 아이디 입력");
            }
            else if (result == 3)
            {
                MessageBox.Show("중복되는 닉네임 입력");
            }
            else
            {
                MessageBox.Show("회원가입 완료");
            }
        }

        private void Start_Click(object sender, EventArgs e)
        {
            String nickname = Miqqa_sql.LogIn(username_login.Text, password_login.Text);

            if (nickname != null)
            {
                MessageBox.Show(nickname + "님, 로그인!");
            
                this.Visible = false;
                Stage_1 stage_1 = new Stage_1();
                stage_1.ShowDialog();
            }
            else
            {
                password_login.Clear();
                MessageBox.Show("아이디와 비밀번호를 다시 한 번 확인해주세요.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            way way = new way();
            way.ShowDialog();
        }
    }
}
