namespace UserLogin
{
    partial class EditEPCInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditEPCInfo));
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxWriteEPC = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxAceessCodes = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.curRfidText = new System.Windows.Forms.TextBox();
            this.btn_ScanRfid = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(70, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "写EPC号";
            // 
            // textBoxWriteEPC
            // 
            this.textBoxWriteEPC.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxWriteEPC.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxWriteEPC.Location = new System.Drawing.Point(74, 167);
            this.textBoxWriteEPC.Multiline = true;
            this.textBoxWriteEPC.Name = "textBoxWriteEPC";
            this.textBoxWriteEPC.Size = new System.Drawing.Size(168, 31);
            this.textBoxWriteEPC.TabIndex = 40;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(74, 227);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "访问密码";
            // 
            // textBoxAceessCodes
            // 
            this.textBoxAceessCodes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxAceessCodes.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxAceessCodes.Location = new System.Drawing.Point(74, 265);
            this.textBoxAceessCodes.Multiline = true;
            this.textBoxAceessCodes.Name = "textBoxAceessCodes";
            this.textBoxAceessCodes.PasswordChar = '*';
            this.textBoxAceessCodes.Size = new System.Drawing.Size(168, 35);
            this.textBoxAceessCodes.TabIndex = 40;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(499, 90);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(148, 162);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(446, 285);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(260, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "欢迎使用智能仓储系统";
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonConfirm.BackColor = System.Drawing.Color.White;
            this.buttonConfirm.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonConfirm.Location = new System.Drawing.Point(167, 332);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(75, 33);
            this.buttonConfirm.TabIndex = 6;
            this.buttonConfirm.Text = "确认";
            this.buttonConfirm.UseVisualStyleBackColor = false;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(74, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 19);
            this.label4.TabIndex = 41;
            this.label4.Text = "当前标签号";
            // 
            // curRfidText
            // 
            this.curRfidText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.curRfidText.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.curRfidText.Location = new System.Drawing.Point(78, 81);
            this.curRfidText.Multiline = true;
            this.curRfidText.Name = "curRfidText";
            this.curRfidText.Size = new System.Drawing.Size(164, 30);
            this.curRfidText.TabIndex = 42;
            // 
            // btn_ScanRfid
            // 
            this.btn_ScanRfid.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_ScanRfid.BackColor = System.Drawing.SystemColors.Window;
            this.btn_ScanRfid.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ScanRfid.Location = new System.Drawing.Point(271, 81);
            this.btn_ScanRfid.Name = "btn_ScanRfid";
            this.btn_ScanRfid.Size = new System.Drawing.Size(78, 30);
            this.btn_ScanRfid.TabIndex = 43;
            this.btn_ScanRfid.Text = "扫描";
            this.btn_ScanRfid.UseVisualStyleBackColor = false;
            this.btn_ScanRfid.Click += new System.EventHandler(this.btn_ScanRfid_Click);
            // 
            // EditEPCInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_ScanRfid);
            this.Controls.Add(this.curRfidText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBoxAceessCodes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxWriteEPC);
            this.Controls.Add(this.label1);
            this.Name = "EditEPCInfo";
            this.Text = "写EPC号";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxWriteEPC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxAceessCodes;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox curRfidText;
        private System.Windows.Forms.Button btn_ScanRfid;
    }
}