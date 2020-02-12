namespace Lottery
{
    partial class WinnerMessage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WinnerMessage));
            this.label1 = new System.Windows.Forms.Label();
            this.labWinner = new System.Windows.Forms.Label();
            this.picBoxBack = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxBack)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("標楷體", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.ForeColor = System.Drawing.Color.Crimson;
            this.label1.Location = new System.Drawing.Point(85, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 64);
            this.label1.TabIndex = 0;
            this.label1.Text = "恭喜";
            this.label1.Click += new System.EventHandler(this.picBoxBack_Click);
            // 
            // labWinner
            // 
            this.labWinner.AutoSize = true;
            this.labWinner.Font = new System.Drawing.Font("新細明體", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labWinner.ForeColor = System.Drawing.Color.Crimson;
            this.labWinner.Location = new System.Drawing.Point(200, 160);
            this.labWinner.Name = "labWinner";
            this.labWinner.Size = new System.Drawing.Size(0, 96);
            this.labWinner.TabIndex = 1;
            this.labWinner.Click += new System.EventHandler(this.picBoxBack_Click);
            // 
            // picBoxBack
            // 
            this.picBoxBack.BackColor = System.Drawing.Color.White;
            this.picBoxBack.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picBoxBack.BackgroundImage")));
            this.picBoxBack.Location = new System.Drawing.Point(0, 0);
            this.picBoxBack.Name = "picBoxBack";
            this.picBoxBack.Size = new System.Drawing.Size(100, 50);
            this.picBoxBack.TabIndex = 3;
            this.picBoxBack.TabStop = false;
            this.picBoxBack.Click += new System.EventHandler(this.picBoxBack_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(613, 465);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.picBoxBack_Click);
            // 
            // WinnerMessage
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(700, 530);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.picBoxBack);
            this.Controls.Add(this.labWinner);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WinnerMessage";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "WinnerMessage";
            this.Load += new System.EventHandler(this.WinnerMessage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxBack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labWinner;
        private System.Windows.Forms.PictureBox picBoxBack;
        private System.Windows.Forms.Button btnClose;
    }
}