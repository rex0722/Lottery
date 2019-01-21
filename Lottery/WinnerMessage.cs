using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lottery
{
    public partial class WinnerMessage : Form
    {

        bool isFirst = true;
        public List<string> winnerList = new List<string>();

        public WinnerMessage()
        {
            InitializeComponent();
        }

        private void WinnerMessage_Load(object sender, EventArgs e)
        {
            this.Location = new Point(Convert.ToInt32(MainForm.panelWidth * 0.24), Convert.ToInt32(MainForm.panelHeight * 0.15));

            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;

            if (isFirst)
            {
                this.Width = Convert.ToInt32(this.Width * MainForm.mainForm.diameterWidth);
                this.Height = Convert.ToInt32(this.Height * MainForm.mainForm.diameterHeight);
                isFirst = false;
                this.Close();
            }
            else
            {
                MainForm.selectedFinishSoundOutput();
                initialUnit();
                for (int i = 0; i < winnerList.Count; i++)
                    labWinner.Text += winnerList[i] + Strings.nextLine;

                winnerList.Clear();

                WindowEffect.AnimateWindow(this.Handle, 500, WindowEffect.AW_BLEND);
                this.Focus();
            }

        }

        private void initialUnit()
        {
            label1.Font = FontSet.getWinnerMessageFontStyle();
            label2.Font = FontSet.getWinnerMessageFontStyle();
            labWinner.Font = FontSet.getWinnerMessageFontStyle();

            label1.Parent = picBoxBack;
            label2.Parent = picBoxBack;
            labWinner.Parent = picBoxBack;

            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            labWinner.BackColor = Color.Transparent;

            picBoxBack.Width = this.Width;
            picBoxBack.Height = this.Height;
            picBoxBack.Location = new Point(0, 0);
            picBoxBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;

            label1.Location = new Point(Convert.ToInt32(this.Width * 0.121), Convert.ToInt32(this.Height * 0.14));
            label2.Location = new Point(Convert.ToInt32(this.Width * 0.73), Convert.ToInt32(this.Height * 0.5));
            labWinner.Location = new Point(Convert.ToInt32(this.Width * 0.3), Convert.ToInt32(this.Height * 0.28));

            btnClose.Location = new Point(this.Width, this.Height);
        }

        private void picBoxBack_Click(object sender, EventArgs e)
        {
            this.Close();
            labWinner.Text = "";
            MainForm.backgroundSoundOutput();
        }
    }
}