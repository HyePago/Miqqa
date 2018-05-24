using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Miqqa
{
    class Miqqa_sql
    {
        private static String Servidor = "localhost";
        private static String Usuario = "root";
        private static String Senha = "1234";
        private static String db = "miqqa";
        private static String UrlConnection = "Server=" + Servidor + "; Database=" + db + "; Uid=" + Usuario + "; Pwd=" + Senha + ";SslMode=none";

        public static int SignUp(string username, string password, string nickname)
        {
            using (MySqlConnection conn = new MySqlConnection(UrlConnection))
            {
                conn.Open();

                // ID 중복 검사
                string sql_select = "SELECT * FROM user WHERE username='" + username + "';";
                MySqlCommand cmd_id = new MySqlCommand(sql_select, conn);
                MySqlDataReader rdr = cmd_id.ExecuteReader();

                while (rdr.Read())
                {
                    rdr.Close();
                    return 2; // 이미 있는 아이디 입력
                }
                rdr.Close();

                // 닉네임 중복 검사
                string sql_select_nickname = "SELECT * FROM user WHERE nickname='" + nickname + "';";
                MySqlCommand cmd_nickname = new MySqlCommand(sql_select_nickname, conn);
                MySqlDataReader rdr_nickname = cmd_nickname.ExecuteReader();

                while (rdr_nickname.Read())
                {
                    rdr_nickname.Close();
                    return 3; // 이미 있는 닉네임 입력
                }
                rdr_nickname.Close();

                // 회원가입
                string sql = "INSERT INTO user(username, password, nickname) values('" + username + "', '" + password + "', '" + nickname + "');";

                MySqlCommand cmd_insert = new MySqlCommand(sql, conn);
                cmd_insert.ExecuteNonQuery();

                return 1;
            }
        }

        public static string LogIn(string username, string password)
        {
            using (MySqlConnection conn = new MySqlConnection(UrlConnection))
            {
                conn.Open();

                String nickname = null;

                // ID 와 비밀번호 일치하는 지 검사
                string sql_select = "SELECT * FROM user WHERE username='" + username + "' and password='" + password + "';";
                MySqlCommand cmd = new MySqlCommand(sql_select, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    nickname = rdr["nickname"].ToString();
                }

                return nickname;
            }
        }
    }
}
