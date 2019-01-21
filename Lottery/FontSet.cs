using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottery
{
    class FontSet
    {
        static PrivateFontCollection prc = new PrivateFontCollection();
        static Font lotteryLabelFontStyle, btnFontStyle, labelFontStyle, combFontStyle, txtFontStyle;
        static Font winnerMessageFontStyle, winnerListLabelFontStyle, authorLabFontStyle, chBoxFontStyle;
        static Single fontDiameter;

        public static void loadFont()
        {
            prc.AddFontFile("../../Font/HanyiSentyJournal.ttf");
            fontDiameter = Convert.ToSingle(MainForm.mainForm.diameterWidth);
        }

        public static Font getLotteryLabelFontStyle()
        {
            lotteryLabelFontStyle = new Font("標楷體", 12 * fontDiameter, FontStyle.Regular);
            return lotteryLabelFontStyle;
        }

        public static Font getBtnFontStyle()
        {
            btnFontStyle = new Font(prc.Families[0], 14 * fontDiameter, FontStyle.Regular);
            return btnFontStyle;
        }

        public static Font getLabelFontStyle()
        {
            labelFontStyle = new Font("微軟正黑體", 20 * fontDiameter, FontStyle.Bold);
            return labelFontStyle;
        }

        public static Font getCombFontStyle()
        {
            combFontStyle = new Font(prc.Families[0], 12 * fontDiameter, FontStyle.Regular);
            return combFontStyle;
        }

        public static Font getTxtFontStyle()
        {
            txtFontStyle = new Font(prc.Families[0], 16 * fontDiameter, FontStyle.Regular);
            return txtFontStyle;
        }

        public static Font getWinnerMessageFontStyle()
        {
            winnerMessageFontStyle = new Font(prc.Families[0], 50 * fontDiameter, FontStyle.Regular);
            return winnerMessageFontStyle;
        }

        public static Font getWinnerListLabelFontStyle()
        {
            winnerListLabelFontStyle = new Font(prc.Families[0], 12 * fontDiameter, FontStyle.Regular);
            return winnerListLabelFontStyle;
        }

        public static Font getAuthorLabFontStyle()
        {
            authorLabFontStyle = new Font(prc.Families[0], 32 * fontDiameter, FontStyle.Bold);
            return authorLabFontStyle;
        }

        public static Font getchBoxFontStyle()
        {
            chBoxFontStyle = new Font("微軟正黑體", 12 * fontDiameter, FontStyle.Regular);
            return chBoxFontStyle;
        }


    }
}
