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
                var afterDays = Convert.ToDouble(days);
                var code = GenerateShortCode(user, afterDays);
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

        string GenerateShortCode(string user, double days)
        {
            var timestamp = (Int32)(DateTime.UtcNow.AddDays(days)
                .Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            var unit16 = Convert.ToString(timestamp, 16);
            var prefix = ToMD5(user);
            var suffix = ToMD5(DateTime.Now.Millisecond.ToString());
            var strbuilder = new StringBuilder();
            for (int i = 0; i < 5; i++)
            {
                strbuilder.Append(suffix[i]);
                strbuilder.Append(prefix[i]);
            }

            string result = unit16.ToUpper() + strbuilder.ToString();
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
