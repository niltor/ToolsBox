namespace 授权码生成工具
{
    partial class MainForm
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
            this.userTB = new System.Windows.Forms.TextBox();
            this.userLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.daysTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.codeTB = new System.Windows.Forms.TextBox();
            this.generateBT = new System.Windows.Forms.Button();
            this.copyBT = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // userTB
            // 
            this.userTB.Location = new System.Drawing.Point(121, 12);
            this.userTB.Name = "userTB";
            this.userTB.Size = new System.Drawing.Size(250, 21);
            this.userTB.TabIndex = 0;
            // 
            // userLabel
            // 
            this.userLabel.AutoSize = true;
            this.userLabel.Location = new System.Drawing.Point(20, 15);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(95, 12);
            this.userLabel.TabIndex = 1;
            this.userLabel.Text = "用户名/单位名称";
            this.userLabel.Click += new System.EventHandler(this.user_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "有效期";
            // 
            // daysTB
            // 
            this.daysTB.Location = new System.Drawing.Point(121, 47);
            this.daysTB.Name = "daysTB";
            this.daysTB.Size = new System.Drawing.Size(66, 21);
            this.daysTB.TabIndex = 2;
            this.daysTB.Text = "30";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(193, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "天";
            // 
            // codeTB
            // 
            this.codeTB.Location = new System.Drawing.Point(121, 87);
            this.codeTB.Multiline = true;
            this.codeTB.Name = "codeTB";
            this.codeTB.ReadOnly = true;
            this.codeTB.Size = new System.Drawing.Size(424, 48);
            this.codeTB.TabIndex = 5;
            // 
            // generateBT
            // 
            this.generateBT.Location = new System.Drawing.Point(209, 151);
            this.generateBT.Name = "generateBT";
            this.generateBT.Size = new System.Drawing.Size(83, 30);
            this.generateBT.TabIndex = 6;
            this.generateBT.Text = "生成激活码";
            this.generateBT.UseVisualStyleBackColor = true;
            this.generateBT.Click += new System.EventHandler(this.generateBT_Click);
            // 
            // copyBT
            // 
            this.copyBT.Location = new System.Drawing.Point(305, 151);
            this.copyBT.Name = "copyBT";
            this.copyBT.Size = new System.Drawing.Size(83, 30);
            this.copyBT.TabIndex = 7;
            this.copyBT.Text = "复制激活码";
            this.copyBT.UseVisualStyleBackColor = true;
            this.copyBT.Click += new System.EventHandler(this.copyBT_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(74, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "激活码";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 196);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.copyBT);
            this.Controls.Add(this.generateBT);
            this.Controls.Add(this.codeTB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.daysTB);
            this.Controls.Add(this.userLabel);
            this.Controls.Add(this.userTB);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Opacity = 0.95D;
            this.Text = "授权激活码生成工具";
            this.Load += new System.EventHandler(this.授权激活码生成工具_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox userTB;
        private System.Windows.Forms.Label userLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox daysTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox codeTB;
        private System.Windows.Forms.Button generateBT;
        private System.Windows.Forms.Button copyBT;
        private System.Windows.Forms.Label label3;
    }
}

