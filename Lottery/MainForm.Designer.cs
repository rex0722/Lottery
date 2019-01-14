namespace Lottery
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel = new System.Windows.Forms.Panel();
            this.labSelectTimes = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.combPrize = new System.Windows.Forms.ComboBox();
            this.btnList = new System.Windows.Forms.Button();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.InternetControlMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseProgramMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenControlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseProgramToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.combCount = new System.Windows.Forms.ComboBox();
            this.labAuthor = new System.Windows.Forms.Label();
            this.timerLottery = new System.Windows.Forms.Timer(this.components);
            this.timerChangeColor = new System.Windows.Forms.Timer(this.components);
            this.picLeft = new System.Windows.Forms.PictureBox();
            this.labWinner = new System.Windows.Forms.Label();
            this.labHuman = new System.Windows.Forms.Label();
            this.labWinnerCount = new System.Windows.Forms.Label();
            this.btnCleanDatabase = new System.Windows.Forms.Button();
            this.chBoxRepeat = new System.Windows.Forms.CheckBox();
            this.contextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLeft)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel.BackgroundImage")));
            this.panel.Location = new System.Drawing.Point(2, 57);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(46, 39);
            this.panel.TabIndex = 0;
            // 
            // labSelectTimes
            // 
            this.labSelectTimes.AutoSize = true;
            this.labSelectTimes.BackColor = System.Drawing.Color.White;
            this.labSelectTimes.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labSelectTimes.Image = ((System.Drawing.Image)(resources.GetObject("labSelectTimes.Image")));
            this.labSelectTimes.Location = new System.Drawing.Point(917, 32);
            this.labSelectTimes.Name = "labSelectTimes";
            this.labSelectTimes.Size = new System.Drawing.Size(104, 21);
            this.labSelectTimes.TabIndex = 5;
            this.labSelectTimes.Text = "抽獎次數:";
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnStart.Location = new System.Drawing.Point(921, 178);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(100, 84);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "開始抽獎";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // combPrize
            // 
            this.combPrize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combPrize.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.combPrize.FormattingEnabled = true;
            this.combPrize.Location = new System.Drawing.Point(921, 104);
            this.combPrize.Name = "combPrize";
            this.combPrize.Size = new System.Drawing.Size(100, 28);
            this.combPrize.TabIndex = 4;
            this.combPrize.SelectionChangeCommitted += new System.EventHandler(this.combPrize_SelectionChangeCommitted);
            // 
            // btnList
            // 
            this.btnList.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnList.Location = new System.Drawing.Point(921, 278);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(100, 28);
            this.btnList.TabIndex = 2;
            this.btnList.Text = "中獎名單";
            this.btnList.UseVisualStyleBackColor = true;
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InternetControlMenuItem,
            this.CloseProgramMenuItem});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(149, 48);
            // 
            // InternetControlMenuItem
            // 
            this.InternetControlMenuItem.Name = "InternetControlMenuItem";
            this.InternetControlMenuItem.Size = new System.Drawing.Size(148, 22);
            this.InternetControlMenuItem.Text = "開啟遠端控制";
            this.InternetControlMenuItem.Click += new System.EventHandler(this.InternetControlMenuItem_Click);
            // 
            // CloseProgramMenuItem
            // 
            this.CloseProgramMenuItem.Name = "CloseProgramMenuItem";
            this.CloseProgramMenuItem.Size = new System.Drawing.Size(148, 22);
            this.CloseProgramMenuItem.Text = "關閉抽獎程式";
            this.CloseProgramMenuItem.Click += new System.EventHandler(this.CloseProgramMenuItem_Click);
            // 
            // OpenControlToolStripMenuItem
            // 
            this.OpenControlToolStripMenuItem.Name = "OpenControlToolStripMenuItem";
            this.OpenControlToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.OpenControlToolStripMenuItem.Text = "開啟遠端遙控";
            // 
            // CloseProgramToolStripMenuItem1
            // 
            this.CloseProgramToolStripMenuItem1.Name = "CloseProgramToolStripMenuItem1";
            this.CloseProgramToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.CloseProgramToolStripMenuItem1.Text = "結束抽獎程式";
            // 
            // combCount
            // 
            this.combCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combCount.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.combCount.FormattingEnabled = true;
            this.combCount.Location = new System.Drawing.Point(921, 56);
            this.combCount.Name = "combCount";
            this.combCount.Size = new System.Drawing.Size(100, 28);
            this.combCount.TabIndex = 3;
            // 
            // labAuthor
            // 
            this.labAuthor.AutoSize = true;
            this.labAuthor.Location = new System.Drawing.Point(635, 426);
            this.labAuthor.Name = "labAuthor";
            this.labAuthor.Size = new System.Drawing.Size(0, 12);
            this.labAuthor.TabIndex = 10;
            // 
            // timerLottery
            // 
            this.timerLottery.Tick += new System.EventHandler(this.timerLottery_Tick);
            // 
            // timerChangeColor
            // 
            this.timerChangeColor.Tick += new System.EventHandler(this.timerChangeColor_Tick);
            // 
            // picLeft
            // 
            this.picLeft.BackColor = System.Drawing.Color.Transparent;
            this.picLeft.Image = ((System.Drawing.Image)(resources.GetObject("picLeft.Image")));
            this.picLeft.Location = new System.Drawing.Point(12, 149);
            this.picLeft.Name = "picLeft";
            this.picLeft.Size = new System.Drawing.Size(160, 215);
            this.picLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLeft.TabIndex = 11;
            this.picLeft.TabStop = false;
            // 
            // labWinner
            // 
            this.labWinner.AutoSize = true;
            this.labWinner.BackColor = System.Drawing.Color.White;
            this.labWinner.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labWinner.Image = ((System.Drawing.Image)(resources.GetObject("labWinner.Image")));
            this.labWinner.Location = new System.Drawing.Point(917, 353);
            this.labWinner.Name = "labWinner";
            this.labWinner.Size = new System.Drawing.Size(104, 21);
            this.labWinner.TabIndex = 12;
            this.labWinner.Text = "中獎人數:";
            // 
            // labHuman
            // 
            this.labHuman.AutoSize = true;
            this.labHuman.BackColor = System.Drawing.Color.White;
            this.labHuman.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labHuman.Image = ((System.Drawing.Image)(resources.GetObject("labHuman.Image")));
            this.labHuman.Location = new System.Drawing.Point(989, 390);
            this.labHuman.Name = "labHuman";
            this.labHuman.Size = new System.Drawing.Size(32, 21);
            this.labHuman.TabIndex = 13;
            this.labHuman.Text = "人";
            // 
            // labWinnerCount
            // 
            this.labWinnerCount.AutoSize = true;
            this.labWinnerCount.BackColor = System.Drawing.Color.White;
            this.labWinnerCount.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labWinnerCount.Image = ((System.Drawing.Image)(resources.GetObject("labWinnerCount.Image")));
            this.labWinnerCount.Location = new System.Drawing.Point(917, 390);
            this.labWinnerCount.Name = "labWinnerCount";
            this.labWinnerCount.Size = new System.Drawing.Size(32, 21);
            this.labWinnerCount.TabIndex = 14;
            this.labWinnerCount.Text = "人";
            // 
            // btnCleanDatabase
            // 
            this.btnCleanDatabase.Enabled = false;
            this.btnCleanDatabase.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnCleanDatabase.Location = new System.Drawing.Point(921, 312);
            this.btnCleanDatabase.Name = "btnCleanDatabase";
            this.btnCleanDatabase.Size = new System.Drawing.Size(100, 28);
            this.btnCleanDatabase.TabIndex = 15;
            this.btnCleanDatabase.Text = "清除資料";
            this.btnCleanDatabase.UseVisualStyleBackColor = true;
            this.btnCleanDatabase.Click += new System.EventHandler(this.btnCleanDatabase_Click);
            // 
            // chBoxRepeat
            // 
            this.chBoxRepeat.AutoSize = true;
            this.chBoxRepeat.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("chBoxRepeat.BackgroundImage")));
            this.chBoxRepeat.Enabled = false;
            this.chBoxRepeat.Location = new System.Drawing.Point(949, 138);
            this.chBoxRepeat.Name = "chBoxRepeat";
            this.chBoxRepeat.Size = new System.Drawing.Size(72, 16);
            this.chBoxRepeat.TabIndex = 17;
            this.chBoxRepeat.Text = "重複抽獎";
            this.chBoxRepeat.UseVisualStyleBackColor = true;
            this.chBoxRepeat.CheckedChanged += new System.EventHandler(this.chBoxRepeat_CheckedChanged);
            // 
            // MainForm
            // 
            this.AcceptButton = this.btnStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1046, 742);
            this.ContextMenuStrip = this.contextMenu;
            this.Controls.Add(this.chBoxRepeat);
            this.Controls.Add(this.btnCleanDatabase);
            this.Controls.Add(this.labWinnerCount);
            this.Controls.Add(this.labHuman);
            this.Controls.Add(this.labWinner);
            this.Controls.Add(this.picLeft);
            this.Controls.Add(this.labAuthor);
            this.Controls.Add(this.combCount);
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.combPrize);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.labSelectTimes);
            this.Controls.Add(this.panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "x";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.contextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLeft)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label labSelectTimes;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ComboBox combPrize;
        private System.Windows.Forms.Button btnList;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem OpenControlToolStripMenuItem;
        private System.Windows.Forms.ComboBox combCount;
        private System.Windows.Forms.Label labAuthor;
        private System.Windows.Forms.ToolStripMenuItem CloseProgramToolStripMenuItem1;
        private System.Windows.Forms.Timer timerLottery;
        private System.Windows.Forms.Timer timerChangeColor;
        private System.Windows.Forms.PictureBox picLeft;
        private System.Windows.Forms.ToolStripMenuItem InternetControlMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CloseProgramMenuItem;
        private System.Windows.Forms.Label labWinner;
        private System.Windows.Forms.Label labHuman;
        private System.Windows.Forms.Label labWinnerCount;
        private System.Windows.Forms.Button btnCleanDatabase;
        private System.Windows.Forms.CheckBox chBoxRepeat;
    }
}

