namespace ReportDeploy
{
    partial class Form1
    {
        /// <summary>
        /// 必需 设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用 资源。
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

        #region Windows 窗体设计器生成 代码

        /// <summary>
        /// 设计器支持所需 方法 - 不要
        /// 使用代码编辑器修改此方法 内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkAll = new System.Windows.Forms.CheckBox();
            this.radioTest = new System.Windows.Forms.RadioButton();
            this.radioTrue = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDeploy = new System.Windows.Forms.Button();
            this.txtConsole = new System.Windows.Forms.RichTextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Report Files（*.rdl）|*.rdl";
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.RestoreDirectory = true;
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(634, 12);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(75, 23);
            this.btnSelectFile.TabIndex = 0;
            this.btnSelectFile.Text = "Choose  Files";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(297, 457);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Corp";
            // 
            // checkAll
            // 
            this.checkAll.AutoSize = true;
            this.checkAll.Location = new System.Drawing.Point(320, 20);
            this.checkAll.Name = "checkAll";
            this.checkAll.Size = new System.Drawing.Size(42, 16);
            this.checkAll.TabIndex = 3;
            this.checkAll.Text = "All";
            this.checkAll.UseVisualStyleBackColor = true;
            this.checkAll.CheckedChanged += new System.EventHandler(this.checkAll_CheckedChanged);
            // 
            // radioTest
            // 
            this.radioTest.AutoSize = true;
            this.radioTest.Checked = true;
            this.radioTest.Location = new System.Drawing.Point(5, 7);
            this.radioTest.Name = "radioTest";
            this.radioTest.Size = new System.Drawing.Size(47, 16);
            this.radioTest.TabIndex = 4;
            this.radioTest.TabStop = true;
            this.radioTest.Text = "test";
            this.radioTest.UseVisualStyleBackColor = true;
            // 
            // radioTrue
            // 
            this.radioTrue.AutoSize = true;
            this.radioTrue.Location = new System.Drawing.Point(5, 30);
            this.radioTrue.Name = "radioTrue";
            this.radioTrue.Size = new System.Drawing.Size(59, 16);
            this.radioTrue.TabIndex = 5;
            this.radioTrue.Text = "actual";
            this.radioTrue.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioTest);
            this.panel1.Controls.Add(this.radioTrue);
            this.panel1.Location = new System.Drawing.Point(320, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(59, 55);
            this.panel1.TabIndex = 6;
            // 
            // btnDeploy
            // 
            this.btnDeploy.Location = new System.Drawing.Point(634, 51);
            this.btnDeploy.Name = "btnDeploy";
            this.btnDeploy.Size = new System.Drawing.Size(75, 23);
            this.btnDeploy.TabIndex = 7;
            this.btnDeploy.Text = "Deploy";
            this.btnDeploy.UseVisualStyleBackColor = true;
            this.btnDeploy.Click += new System.EventHandler(this.btnDeploy_Click);
            // 
            // txtConsole
            // 
            this.txtConsole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConsole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtConsole.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConsole.ForeColor = System.Drawing.Color.Blue;
            this.txtConsole.Location = new System.Drawing.Point(321, 129);
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.ReadOnly = true;
            this.txtConsole.Size = new System.Drawing.Size(402, 340);
            this.txtConsole.TabIndex = 8;
            this.txtConsole.Text = "";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(634, 100);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "Clean";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(320, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "Console：";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 491);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtConsole);
            this.Controls.Add(this.btnDeploy);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.checkAll);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSelectFile);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(764, 529);
            this.MinimumSize = new System.Drawing.Size(764, 529);
            this.Name = "Form1";
            this.Text = "ReportDeploy";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkAll;
        private System.Windows.Forms.RadioButton radioTest;
        private System.Windows.Forms.RadioButton radioTrue;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDeploy;
        private System.Windows.Forms.RichTextBox txtConsole;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label1;
    }
}

