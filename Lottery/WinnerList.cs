using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Lottery
{
    public partial class WinnerList : Form
    {
        public WinnerList()
        {
            InitializeComponent();
        }

        private void WinnerList_Load(object sender, EventArgs e)
        {
            //loadRecordItem();
            loadData();
            //setUnitFontStyle();
            //labRecordIndex.Text = Lottery.Properties.Settings.Default.Times.ToString();
        }

        private void loadData()
        {
            OleDbConnection myConn = new OleDbConnection(Strings.databasePath);
            myConn.Open();

            OleDbCommand Cmd = new OleDbCommand(Strings.selectCommand, myConn);
            OleDbDataReader reader = Cmd.ExecuteReader();
            
            if (reader.Read())
            {
                OleDbDataAdapter adapter = new OleDbDataAdapter(Strings.selectCommand, myConn);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "record");
                dataDisplay.DataSource = dataSet.Tables["record"];
            }
            else
            {
                dataDisplay.DataSource = null;
            }
            reader.Close();
            myConn.Close();
        }

        private void setUnitFontStyle()
        {
            /*
            labRecordText.Font = FontSet.getWinnerListLabelFontStyle();
            labRecordIndex.Font = FontSet.getWinnerListLabelFontStyle();
            labPastRecordText.Font = FontSet.getWinnerListLabelFontStyle();
            combRecordItem.Font = FontSet.getWinnerListLabelFontStyle();
            btnSelect.Font = FontSet.getWinnerListLabelFontStyle();
            */
        }

        private void loadRecordItem()
        {
          /*  for (int i = 1; i <= Lottery.Properties.Settings.Default.Times; i++)
                combRecordItem.Items.Add(i);

            combRecordItem.Text = combRecordItem.Items[Convert.ToInt32(combRecordItem.Items.Count - 1)].ToString();
            */
        }

    }
}