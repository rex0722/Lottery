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
            this.label2 = new System.Windows.Forms.Label();
            this.picBoxBack = new System.Windows.Forms.PictureBox();
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
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.ForeColor = System.Drawing.Color.Crimson;
            this.label2.Location = new System.Drawing.Point(512, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 64);
            this.label2.TabIndex = 2;
            this.label2.Text = "中獎!";
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
            // WinnerMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(700, 500);
            this.Controls.Add(this.picBoxBack);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labWinner);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WinnerMessage";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WinnerMessage";
            this.Load += new System.EventHandler(this.WinnerMessage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxBack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labWinner;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox picBoxBack;
    }
}