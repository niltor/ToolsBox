using System;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace 授权码生成工具
{
    public partial class MainForm : System.Windows.Forms.Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void 授权激活码生成工具_Load(object sender, EventArgs e)
        {

        }

        private void user_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 生成激活码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void generateBT_Click(object sender, EventArgs e)
        {
            var user = userTB.Text;
            var days = daysTB.Text;
            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(days))
            {
                MessageBox.Show("用户名及有效期不可为空");
            }
            else
            {
                var code = GenerateShortCode(user, days);
                codeTB.Text = code;
            }
        }

        string generateCode(string user, string days)
        {
            var bytes = Encoding.UTF8.GetBytes(user + "^" + days + "^" + DateTime.Now.ToString("yyyy-MM-dd"));
            var base64String = Convert.ToBase64String(bytes);

            var base64Bytes = Encoding.ASCII.GetBytes(base64String);
            var result = string.Join("", base64Bytes.Select(r => r.ToString("X2")).ToArray());
            return result;
        }

        string GenerateShortCode(string user, string days)
        {
            var bytes = Encoding.UTF8.GetBytes(days);
            var md5 = ToMD5(user + DateTime.Now.Millisecond);

            var str = string.Join("", bytes.Select(r => r.ToString("X2")).ToArray());
            var result = str + "-" + md5.Substring(md5.Length-10) ;
            return result;
        }


        public static string ToMD5(string str)
        {
            var md5 = MD5.Create();
            Byte[] bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
            StringBuilder sb = new StringBuilder();
            foreach (var item in bytes)
            {
                sb.Append(item.ToString("X2"));
            }
            return sb.ToString();
        }

        /// <summary>
        /// 复制激活码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void copyBT_Click(object sender, EventArgs e)
        {
            var code = codeTB.Text;
            if (string.IsNullOrEmpty(code))
            {
                MessageBox.Show("无效的激活码");
            }
            else
            {
                Clipboard.SetText(code);
                MessageBox.Show("已成功复制到剪切板");
            }

        }
    }
}
