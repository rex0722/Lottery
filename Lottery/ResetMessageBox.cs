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
    public partial class ResetMessageBox : Form
    {

        public ResetMessageBox()
        {
            InitializeComponent();
        }

        private void ResetMessageBox_Load(object sender, EventArgs e)
        {
            labResetWarning.Text = Strings.resetWarning;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (txtBoxPassword.Text.Equals(Strings.resetPassword))
            {
                DialogResult result = MessageBox.Show(Strings.passwordCorrect, Strings.messageBoxWarningTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                if(result == DialogResult.OK)
                {
                    MainForm.mainForm.reset();
                    this.Close();
                }
            }
            else
                MessageBox.Show(Strings.passwordError, Strings.messageBoxErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
