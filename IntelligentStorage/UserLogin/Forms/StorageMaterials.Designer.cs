namespace UserLogin
{
    partial class StorageMaterials
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StorageMaterials));
            this.label1 = new System.Windows.Forms.Label();
            this.button_Scan = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.button_SaveIn = new System.Windows.Forms.Button();
            this.labelSavePos = new System.Windows.Forms.Label();
            this.text_SavePos = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.text_MaterialName = new System.Windows.Forms.TextBox();
            this.label_Number = new System.Windows.Forms.Label();
            this.text_MaterialNum = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.text_Rfid = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(76, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "标签号";
            // 
            // button_Scan
            // 
            this.button_Scan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_Scan.BackColor = System.Drawing.Color.White;
            this.button_Scan.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_Scan.Location = new System.Drawing.Point(158, 291);
            this.button_Scan.Name = "button_Scan";
            this.button_Scan.Size = new System.Drawing.Size(59, 28);
            this.button_Scan.TabIndex = 2;
            this.button_Scan.Text = "扫描";
            this.button_Scan.UseVisualStyleBackColor = false;
            this.button_Scan.Click += new System.EventHandler(this.button_Scan_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_Cancel.BackColor = System.Drawing.Color.White;
            this.button_Cancel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_Cancel.Location = new System.Drawing.Point(307, 291);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(60, 28);
            this.button_Cancel.TabIndex = 3;
            this.button_Cancel.Text = "取消";
            this.button_Cancel.UseVisualStyleBackColor = false;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // button_SaveIn
            // 
            this.button_SaveIn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_SaveIn.BackColor = System.Drawing.Color.White;
            this.button_SaveIn.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_SaveIn.Location = new System.Drawing.Point(233, 291);
            this.button_SaveIn.Name = "button_SaveIn";
            this.button_SaveIn.Size = new System.Drawing.Size(59, 28);
            this.button_SaveIn.TabIndex = 4;
            this.button_SaveIn.Text = "存入";
            this.button_SaveIn.UseVisualStyleBackColor = false;
            this.button_SaveIn.Click += new System.EventHandler(this.button_SaveIn_Click);
            // 
            // labelSavePos
            // 
            this.labelSavePos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelSavePos.AutoSize = true;
            this.labelSavePos.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelSavePos.Location = new System.Drawing.Point(73, 87);
            this.labelSavePos.Name = "labelSavePos";
            this.labelSavePos.Size = new System.Drawing.Size(98, 21);
            this.labelSavePos.TabIndex = 5;
            this.labelSavePos.Text = "存放位置";
            // 
            // text_SavePos
            // 
            this.text_SavePos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.text_SavePos.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.text_SavePos.Location = new System.Drawing.Point(170, 82);
            this.text_SavePos.Multiline = true;
            this.text_SavePos.Name = "text_SavePos";
            this.text_SavePos.Size = new System.Drawing.Size(197, 26);
            this.text_SavePos.TabIndex = 40;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(73, 198);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 21);
            this.label2.TabIndex = 7;
            this.label2.Text = "物品名称";
            // 
            // text_MaterialName
            // 
            this.text_MaterialName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.text_MaterialName.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.text_MaterialName.Location = new System.Drawing.Point(170, 191);
            this.text_MaterialName.Multiline = true;
            this.text_MaterialName.Name = "text_MaterialName";
            this.text_MaterialName.Size = new System.Drawing.Size(197, 28);
            this.text_MaterialName.TabIndex = 40;
            // 
            // label_Number
            // 
            this.label_Number.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_Number.AutoSize = true;
            this.label_Number.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Number.Location = new System.Drawing.Point(76, 248);
            this.label_Number.Name = "label_Number";
            this.label_Number.Size = new System.Drawing.Size(54, 21);
            this.label_Number.TabIndex = 9;
            this.label_Number.Text = "数量";
            // 
            // text_MaterialNum
            // 
            this.text_MaterialNum.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.text_MaterialNum.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.text_MaterialNum.Location = new System.Drawing.Point(170, 240);
            this.text_MaterialNum.Multiline = true;
            this.text_MaterialNum.Name = "text_MaterialNum";
            this.text_MaterialNum.Size = new System.Drawing.Size(197, 29);
            this.text_MaterialNum.TabIndex = 40;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(492, 82);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 156);
            this.pictureBox1.TabIndex = 41;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(443, 290);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(260, 24);
            this.label3.TabIndex = 42;
            this.label3.Text = "欢迎使用智能仓储系统";
            // 
            // text_Rfid
            // 
            this.text_Rfid.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.text_Rfid.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.text_Rfid.FormattingEnabled = true;
            this.text_Rfid.Location = new System.Drawing.Point(170, 138);
            this.text_Rfid.Name = "text_Rfid";
            this.text_Rfid.Size = new System.Drawing.Size(197, 24);
            this.text_Rfid.TabIndex = 44;
            this.text_Rfid.SelectedIndexChanged += new System.EventHandler(this.text_Rfid_SelectedIndexChanged);
            // 
            // StorageMaterials
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(747, 428);
            this.Controls.Add(this.text_Rfid);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.text_MaterialNum);
            this.Controls.Add(this.label_Number);
            this.Controls.Add(this.text_MaterialName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.text_SavePos);
            this.Controls.Add(this.labelSavePos);
            this.Controls.Add(this.button_SaveIn);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_Scan);
            this.Controls.Add(this.label1);
            this.Name = "StorageMaterials";
            this.Text = "存放物品";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.StorageMaterials_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Scan;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Button button_SaveIn;
        private System.Windows.Forms.Label labelSavePos;
        private System.Windows.Forms.TextBox text_SavePos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox text_MaterialName;
        private System.Windows.Forms.Label label_Number;
        private System.Windows.Forms.TextBox text_MaterialNum;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox text_Rfid;
    }
}