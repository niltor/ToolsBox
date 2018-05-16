using System;
using System.Windows.Forms;

namespace PostmanToMD
{
    public partial class Form1 : Form
    {

        private string jsonFilePath;

        public Form1()
        {
            InitializeComponent();
        }

        private void Chose_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                openFile.InitialDirectory = "c:\\";
                openFile.Filter = "json files (*.json)|*.json";
                openFile.FilterIndex = 2;
                openFile.RestoreDirectory = true;

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    jsonFilePath = openFile.FileName;
                }
            }
        }

        private void Output_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(AuthorInput.Text) || string.IsNullOrEmpty(LocalDaemon.Text)
                || string.IsNullOrEmpty(DevDaemon.Text))
            {
                MessageBox.Show("生成人、域名和地址不可为空");
                return;
            }
            SaveFileDialog saveFile = new SaveFileDialog
            {
                Filter = "markdown files (*.md)|*.md",
                FilterIndex = 2,
                RestoreDirectory = true
            };

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(jsonFilePath) && !string.IsNullOrEmpty(saveFile.FileName))
                {
                    var task = new PostManToMarkDown(LocalDaemon.Text, DevDaemon.Text);
                    task.Run(jsonFilePath, saveFile.FileName,AuthorInput.Text);

                    MessageBox.Show("保存成功");
                }
                else
                {
                    MessageBox.Show("请先选择json文件");
                }
            }
        }
    }
}
