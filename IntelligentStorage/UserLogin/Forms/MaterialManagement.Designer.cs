namespace UserLogin
{
    partial class MaterialManagement
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaterialManagement));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.物品录入ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.物品查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.物品删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.取物品ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.记录查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改标签号ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.Timer_Test = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.用户标签ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.物品录入ToolStripMenuItem,
            this.物品查询ToolStripMenuItem,
            this.物品删除ToolStripMenuItem,
            this.取物品ToolStripMenuItem,
            this.记录查询ToolStripMenuItem,
            this.修改标签号ToolStripMenuItem,
            this.用户标签ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(926, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 物品录入ToolStripMenuItem
            // 
            this.物品录入ToolStripMenuItem.Name = "物品录入ToolStripMenuItem";
            this.物品录入ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.物品录入ToolStripMenuItem.Text = "物品入库";
            this.物品录入ToolStripMenuItem.Click += new System.EventHandler(this.物品录入ToolStripMenuItem_Click);
            // 
            // 物品查询ToolStripMenuItem
            // 
            this.物品查询ToolStripMenuItem.Name = "物品查询ToolStripMenuItem";
            this.物品查询ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.物品查询ToolStripMenuItem.Text = "物品查询";
            this.物品查询ToolStripMenuItem.Click += new System.EventHandler(this.物品查询ToolStripMenuItem_Click);
            // 
            // 物品删除ToolStripMenuItem
            // 
            this.物品删除ToolStripMenuItem.Name = "物品删除ToolStripMenuItem";
            this.物品删除ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.物品删除ToolStripMenuItem.Text = "物品删除";
            this.物品删除ToolStripMenuItem.Click += new System.EventHandler(this.物品删除ToolStripMenuItem_Click);
            // 
            // 取物品ToolStripMenuItem
            // 
            this.取物品ToolStripMenuItem.Name = "取物品ToolStripMenuItem";
            this.取物品ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.取物品ToolStripMenuItem.Text = "物品出库";
            this.取物品ToolStripMenuItem.Click += new System.EventHandler(this.取物品ToolStripMenuItem_Click);
            // 
            // 记录查询ToolStripMenuItem
            // 
            this.记录查询ToolStripMenuItem.Name = "记录查询ToolStripMenuItem";
            this.记录查询ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.记录查询ToolStripMenuItem.Text = "记录查询";
            this.记录查询ToolStripMenuItem.Click += new System.EventHandler(this.记录查询ToolStripMenuItem_Click);
            // 
            // 修改标签号ToolStripMenuItem
            // 
            this.修改标签号ToolStripMenuItem.Name = "修改标签号ToolStripMenuItem";
            this.修改标签号ToolStripMenuItem.Size = new System.Drawing.Size(80, 21);
            this.修改标签号ToolStripMenuItem.Text = "修改标签号";
            this.修改标签号ToolStripMenuItem.Click += new System.EventHandler(this.修改标签号ToolStripMenuItem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 29);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(653, 404);
            this.dataGridView1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(662, 283);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "欢迎使用智能仓储系统";
            // 
            // Timer_Test
            // 
            this.Timer_Test.Enabled = true;
            this.Timer_Test.Interval = 1000;
            this.Timer_Test.Tick += new System.EventHandler(this.Timer_Test_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabelTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 436);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(926, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.Color.White;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(56, 17);
            this.toolStripStatusLabel1.Text = "当前时间";
            // 
            // toolStripStatusLabelTime
            // 
            this.toolStripStatusLabelTime.BackColor = System.Drawing.Color.White;
            this.toolStripStatusLabelTime.Name = "toolStripStatusLabelTime";
            this.toolStripStatusLabelTime.Size = new System.Drawing.Size(131, 17);
            this.toolStripStatusLabelTime.Text = "toolStripStatusLabel2";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(707, 98);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(156, 157);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // 用户标签ToolStripMenuItem
            // 
            this.用户标签ToolStripMenuItem.Name = "用户标签ToolStripMenuItem";
            this.用户标签ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.用户标签ToolStripMenuItem.Text = "用户标签";
            this.用户标签ToolStripMenuItem.Click += new System.EventHandler(this.用户标签ToolStripMenuItem_Click);
            // 
            // MaterialManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(926, 458);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MaterialManagement";
            this.Text = "物品仓库";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MaterialManagement_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 物品录入ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 物品查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 物品删除ToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem 取物品ToolStripMenuItem;
        private System.Windows.Forms.Timer Timer_Test;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelTime;
        private System.Windows.Forms.ToolStripMenuItem 记录查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改标签号ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 用户标签ToolStripMenuItem;
    }
}