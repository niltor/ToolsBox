namespace PostmanToMD
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Chose = new System.Windows.Forms.Button();
            this.Output = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.AuthorInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LocalDaemon = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DevDaemon = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Chose
            // 
            this.Chose.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Chose.Location = new System.Drawing.Point(493, 13);
            this.Chose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Chose.Name = "Chose";
            this.Chose.Size = new System.Drawing.Size(142, 38);
            this.Chose.TabIndex = 0;
            this.Chose.Text = "选择json文件";
            this.Chose.UseVisualStyleBackColor = true;
            this.Chose.Click += new System.EventHandler(this.Chose_Click);
            // 
            // Output
            // 
            this.Output.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Output.Location = new System.Drawing.Point(493, 59);
            this.Output.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Output.Name = "Output";
            this.Output.Size = new System.Drawing.Size(145, 38);
            this.Output.TabIndex = 1;
            this.Output.Text = "生成MD文档";
            this.Output.UseVisualStyleBackColor = true;
            this.Output.Click += new System.EventHandler(this.Output_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(62, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "生成人:";
            // 
            // AuthorInput
            // 
            this.AuthorInput.Location = new System.Drawing.Point(126, 13);
            this.AuthorInput.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AuthorInput.Name = "AuthorInput";
            this.AuthorInput.Size = new System.Drawing.Size(116, 23);
            this.AuthorInput.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(50, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "本地域名:";
            // 
            // LocalDaemon
            // 
            this.LocalDaemon.AccessibleDescription = "";
            this.LocalDaemon.Location = new System.Drawing.Point(126, 55);
            this.LocalDaemon.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LocalDaemon.Name = "LocalDaemon";
            this.LocalDaemon.Size = new System.Drawing.Size(286, 23);
            this.LocalDaemon.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(50, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "开发地址:";
            // 
            // DevDaemon
            // 
            this.DevDaemon.Location = new System.Drawing.Point(126, 96);
            this.DevDaemon.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DevDaemon.Name = "DevDaemon";
            this.DevDaemon.Size = new System.Drawing.Size(286, 23);
            this.DevDaemon.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(50, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(586, 45);
            this.label4.TabIndex = 10;
            this.label4.Text = "本工具是将Postman导出的json文件(V2.1)，自动转化成Markdown文档，只支持一层目录的导出。本地域名，是本地测试配置的域名，开发地址是部署到线上" +
    "的地址或域名，不要包含http://或https://。";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 187);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DevDaemon);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LocalDaemon);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AuthorInput);
            this.Controls.Add(this.Output);
            this.Controls.Add(this.Chose);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "PostmanToMD - Made by NilTor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Chose;
        private System.Windows.Forms.Button Output;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox AuthorInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox LocalDaemon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox DevDaemon;
        private System.Windows.Forms.Label label4;
    }
}

