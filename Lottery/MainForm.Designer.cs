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
            this.btnReset = new System.Windows.Forms.Button();
            this.combPrize = new System.Windows.Forms.ComboBox();
            this.btnList = new System.Windows.Forms.Button();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.OpenControlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseProgramToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.combCount = new System.Windows.Forms.ComboBox();
            this.labAuthor = new System.Windows.Forms.Label();
            this.timerLottery = new System.Windows.Forms.Timer(this.components);
            this.timerChangeColor = new System.Windows.Forms.Timer(this.components);
            this.contextMenu.SuspendLayout();
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
            this.labSelectTimes.Location = new System.Drawing.Point(714, 57);
            this.labSelectTimes.Name = "labSelectTimes";
            this.labSelectTimes.Size = new System.Drawing.Size(104, 21);
            this.labSelectTimes.TabIndex = 3;
            this.labSelectTimes.Text = "抽獎次數:";
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnStart.Location = new System.Drawing.Point(718, 124);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(100, 84);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "開始抽獎";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnReset.Location = new System.Drawing.Point(718, 268);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(100, 28);
            this.btnReset.TabIndex = 6;
            this.btnReset.Text = "重新開始";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Visible = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // combPrize
            // 
            this.combPrize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combPrize.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.combPrize.FormattingEnabled = true;
            this.combPrize.Location = new System.Drawing.Point(718, 20);
            this.combPrize.Name = "combPrize";
            this.combPrize.Size = new System.Drawing.Size(100, 28);
            this.combPrize.TabIndex = 7;
            // 
            // btnList
            // 
            this.btnList.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnList.Location = new System.Drawing.Point(718, 228);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(100, 28);
            this.btnList.TabIndex = 8;
            this.btnList.Text = "中獎名單";
            this.btnList.UseVisualStyleBackColor = true;
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenControlToolStripMenuItem,
            this.CloseProgramToolStripMenuItem1});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(149, 48);
            // 
            // OpenControlToolStripMenuItem
            // 
            this.OpenControlToolStripMenuItem.Name = "OpenControlToolStripMenuItem";
            this.OpenControlToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.OpenControlToolStripMenuItem.Text = "開啟遠端遙控";
            this.OpenControlToolStripMenuItem.Click += new System.EventHandler(this.OpenControlToolStripMenuItem_Click);
            // 
            // CloseProgramToolStripMenuItem1
            // 
            this.CloseProgramToolStripMenuItem1.Name = "CloseProgramToolStripMenuItem1";
            this.CloseProgramToolStripMenuItem1.Size = new System.Drawing.Size(148, 22);
            this.CloseProgramToolStripMenuItem1.Text = "結束抽獎程式";
            this.CloseProgramToolStripMenuItem1.Click += new System.EventHandler(this.CloseProgramToolStripMenuItem1_Click);
            // 
            // combCount
            // 
            this.combCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combCount.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.combCount.FormattingEnabled = true;
            this.combCount.Location = new System.Drawing.Point(718, 81);
            this.combCount.Name = "combCount";
            this.combCount.Size = new System.Drawing.Size(100, 28);
            this.combCount.TabIndex = 9;
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(846, 487);
            this.ContextMenuStrip = this.contextMenu;
            this.Controls.Add(this.labAuthor);
            this.Controls.Add(this.combCount);
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.combPrize);
            this.Controls.Add(this.btnReset);
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
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Enter += new System.EventHandler(this.btnStart_Click);
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label labSelectTimes;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.ComboBox combPrize;
        private System.Windows.Forms.Button btnList;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem OpenControlToolStripMenuItem;
        private System.Windows.Forms.ComboBox combCount;
        private System.Windows.Forms.Label labAuthor;
        private System.Windows.Forms.ToolStripMenuItem CloseProgramToolStripMenuItem1;
        private System.Windows.Forms.Timer timerLottery;
        private System.Windows.Forms.Timer timerChangeColor;
    }
}

