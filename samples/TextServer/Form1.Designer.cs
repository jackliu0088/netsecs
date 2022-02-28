namespace TextServer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            this.btnDisable = new System.Windows.Forms.Button();
            this.btnEnable = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.numBufferSize = new System.Windows.Forms.NumericUpDown();
            this.numDeviceId = new System.Windows.Forms.NumericUpDown();
            this.numPort = new System.Windows.Forms.NumericUpDown();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.radioPassiveMode = new System.Windows.Forms.RadioButton();
            this.radioActiveMode = new System.Windows.Forms.RadioButton();
            this.lbStatus = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.smlTextBox = new System.Windows.Forms.RichTextBox();
            this.sendBtuuon = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numBufferSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDeviceId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(547, 534);
            label3.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(200, 52);
            label3.TabIndex = 19;
            label3.Text = "Device Id";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(248, 532);
            label2.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(101, 52);
            label2.TabIndex = 17;
            label2.Text = "Port";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(227, 439);
            label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(58, 52);
            label1.TabIndex = 16;
            label1.Text = "IP";
            // 
            // btnDisable
            // 
            this.btnDisable.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDisable.Enabled = false;
            this.btnDisable.Location = new System.Drawing.Point(275, 633);
            this.btnDisable.Margin = new System.Windows.Forms.Padding(8, 10, 8, 10);
            this.btnDisable.Name = "btnDisable";
            this.btnDisable.Size = new System.Drawing.Size(224, 74);
            this.btnDisable.TabIndex = 9;
            this.btnDisable.Text = "Disable";
            this.btnDisable.UseVisualStyleBackColor = true;
            this.btnDisable.Click += new System.EventHandler(this.btnDisable_Click);
            // 
            // btnEnable
            // 
            this.btnEnable.Location = new System.Drawing.Point(33, 633);
            this.btnEnable.Margin = new System.Windows.Forms.Padding(8, 10, 8, 10);
            this.btnEnable.Name = "btnEnable";
            this.btnEnable.Size = new System.Drawing.Size(224, 74);
            this.btnEnable.TabIndex = 8;
            this.btnEnable.Text = "Enable";
            this.btnEnable.UseVisualStyleBackColor = true;
            this.btnEnable.Click += new System.EventHandler(this.btnEnable_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(737, 447);
            this.label4.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(227, 52);
            this.label4.TabIndex = 22;
            this.label4.Text = "Buffer Size";
            // 
            // numBufferSize
            // 
            this.numBufferSize.Location = new System.Drawing.Point(980, 445);
            this.numBufferSize.Margin = new System.Windows.Forms.Padding(8, 10, 8, 10);
            this.numBufferSize.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numBufferSize.Name = "numBufferSize";
            this.numBufferSize.Size = new System.Drawing.Size(232, 60);
            this.numBufferSize.TabIndex = 21;
            this.numBufferSize.Value = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            // 
            // numDeviceId
            // 
            this.numDeviceId.Location = new System.Drawing.Point(773, 534);
            this.numDeviceId.Margin = new System.Windows.Forms.Padding(8, 10, 8, 10);
            this.numDeviceId.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numDeviceId.Name = "numDeviceId";
            this.numDeviceId.Size = new System.Drawing.Size(128, 60);
            this.numDeviceId.TabIndex = 20;
            // 
            // numPort
            // 
            this.numPort.Location = new System.Drawing.Point(352, 532);
            this.numPort.Margin = new System.Windows.Forms.Padding(8, 10, 8, 10);
            this.numPort.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numPort.Minimum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numPort.Name = "numPort";
            this.numPort.Size = new System.Drawing.Size(156, 60);
            this.numPort.TabIndex = 18;
            this.numPort.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(301, 439);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(8, 10, 8, 10);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(420, 60);
            this.txtAddress.TabIndex = 15;
            this.txtAddress.Text = "127.0.0.1";
            // 
            // radioPassiveMode
            // 
            this.radioPassiveMode.AutoSize = true;
            this.radioPassiveMode.Location = new System.Drawing.Point(34, 530);
            this.radioPassiveMode.Margin = new System.Windows.Forms.Padding(8, 10, 8, 10);
            this.radioPassiveMode.Name = "radioPassiveMode";
            this.radioPassiveMode.Size = new System.Drawing.Size(198, 56);
            this.radioPassiveMode.TabIndex = 14;
            this.radioPassiveMode.Text = "Passive";
            this.radioPassiveMode.UseVisualStyleBackColor = true;
            // 
            // radioActiveMode
            // 
            this.radioActiveMode.AutoSize = true;
            this.radioActiveMode.Checked = true;
            this.radioActiveMode.Location = new System.Drawing.Point(34, 431);
            this.radioActiveMode.Margin = new System.Windows.Forms.Padding(8, 10, 8, 10);
            this.radioActiveMode.Name = "radioActiveMode";
            this.radioActiveMode.Size = new System.Drawing.Size(177, 56);
            this.radioActiveMode.TabIndex = 13;
            this.radioActiveMode.TabStop = true;
            this.radioActiveMode.Text = "Active";
            this.radioActiveMode.UseVisualStyleBackColor = true;
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbStatus.Location = new System.Drawing.Point(1112, 577);
            this.lbStatus.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(270, 91);
            this.lbStatus.TabIndex = 23;
            this.lbStatus.Text = "Status";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Controls.Add(this.richTextBox1);
            this.panel1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.panel1.Location = new System.Drawing.Point(7, 88);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2269, 299);
            this.panel1.TabIndex = 24;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.richTextBox1.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(8, 10, 8, 10);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(2269, 299);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            this.richTextBox1.WordWrap = false;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(24, 728);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(705, 687);
            this.treeView1.TabIndex = 25;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // smlTextBox
            // 
            this.smlTextBox.Location = new System.Drawing.Point(755, 728);
            this.smlTextBox.Name = "smlTextBox";
            this.smlTextBox.Size = new System.Drawing.Size(575, 687);
            this.smlTextBox.TabIndex = 26;
            this.smlTextBox.Text = "";
            // 
            // sendBtuuon
            // 
            this.sendBtuuon.Location = new System.Drawing.Point(1356, 744);
            this.sendBtuuon.Name = "sendBtuuon";
            this.sendBtuuon.Size = new System.Drawing.Size(244, 58);
            this.sendBtuuon.TabIndex = 27;
            this.sendBtuuon.Text = "发送";
            this.sendBtuuon.UseVisualStyleBackColor = true;
            this.sendBtuuon.Click += new System.EventHandler(this.sendBtuuon_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1356, 866);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(244, 58);
            this.button1.TabIndex = 28;
            this.button1.Text = "发送测试";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1356, 988);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(244, 58);
            this.button2.TabIndex = 29;
            this.button2.Text = "终止";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1782, 806);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(188, 58);
            this.button3.TabIndex = 30;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1626, 494);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(521, 60);
            this.textBox1.TabIndex = 31;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(2285, 1434);
            this.CloseAskString = "啊啊啊啊";
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.sendBtuuon);
            this.Controls.Add(this.smlTextBox);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numBufferSize);
            this.Controls.Add(this.numDeviceId);
            this.Controls.Add(label3);
            this.Controls.Add(this.numPort);
            this.Controls.Add(label2);
            this.Controls.Add(label1);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.radioPassiveMode);
            this.Controls.Add(this.radioActiveMode);
            this.Controls.Add(this.btnDisable);
            this.Controls.Add(this.btnEnable);
            this.EscClose = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(0, 80, 0, 0);
            this.ShowRadius = false;
            this.ShowShadow = true;
            this.Text = "SESC/GEM测试程序";
            this.TitleHeight = 80;
            ((System.ComponentModel.ISupportInitialize)(this.numBufferSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDeviceId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnDisable;
        private Button btnEnable;
        private Label label4;
        private NumericUpDown numBufferSize;
        private NumericUpDown numDeviceId;
        private NumericUpDown numPort;
        private TextBox txtAddress;
        private RadioButton radioPassiveMode;
        private RadioButton radioActiveMode;
        private Label lbStatus;
        private Panel panel1;
        private RichTextBox richTextBox1;
        private TreeView treeView1;
        private RichTextBox smlTextBox;
        private Button sendBtuuon;
        private Button button1;
        private Button button2;
        private Button button3;
        private TextBox textBox1;
    }
}
