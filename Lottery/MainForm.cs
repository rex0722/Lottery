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
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Lottery
{
    public partial class MainForm : Form
    {
        public static bool buttonStartEnable = true;
        bool isFirst = true, isFirstRound = true; 
        bool isSocketCreate = false, isLotteryRunning = false;

        const int firstTop = 1001, firstRight = 1002, firstBottom = 1003, firstLeft = 1004;
        const int secondTop = 2001, secondRight = 2002, secondBottom = 2003, secondLeft = 2004;
        const int listenPort = 3456;
        int perviousID = 0, currentID = 0, lotteryCount = 0, winnerCount = 0;
        int offsetX = 0, offsetY = 0, rowCount = 0, initailX, initailY, heightInterval = 10, widthInterval = 25;
        int firstRoundCountMaximum = 15, secondRoundCountMaximum = 10; 
        int panelWidth = 0, panelHeight = 0, labelWidth = 35, labelHeight = 35;
        int totalParticipant = 100, currentSide = firstTop;

        const double defaultWidth = 1366, defaultHeight = 768;
        public double diameterWidth, diameterHeight;

        string strConn = Strings.databasePath;
        string insertCmd, perviousPrizeItem = "";
        string localIpAddress;

        OleDbConnection myConn;
        OleDbCommand Cmd;

        Label[] labelSet = new Label[100];
        List<int> selectItem = new List<int>();
        List<int> databaseWinnerIndex = new List<int>();
        List<string> databaseWinnerText = new List<string>();
        List<string> recordWinner = new List<string>();
        List<string> recordPrize = new List<string>();
        List<Label> tempTagWinner = new List<Label>();

        public static MainForm mainForm;
        WinnerMessage winnerMessage = new WinnerMessage();
    
        Socket serverSocket;
        IPAddress[] ips = Dns.GetHostAddresses("");
        

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            mainForm = this;
            initialUnitSetting();
            initialSize();
            FontSet.loadFont();
            loadComboboxData();
            initialUnitFont();
            initialUnitLocation();
            backgroundSoundOutput();
            labelCreate();
            loadLocalIpAddress();
            winnerMessage.ShowDialog();
            Control.CheckForIllegalCrossThreadCalls = false;
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            if (isFirst && !isDatabaseEmpty())
            {
                DialogResult record;
                record = MessageBox.Show(Strings.keep_record_start_lottery, Strings.messagebox_information_title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (record == DialogResult.Yes)
                {
                    loadPreviousRecord();
                    adjustParameterAfterLoadRecord();
                }
                else
                {
                    clearDatabase();
                }
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }

        private void InternetControlMenuItem_Click(object sender, EventArgs e)
        {
            if (!isSocketCreate)
            {
                IPEndPoint ipont = new IPEndPoint(IPAddress.Any, listenPort);
                serverSocket.Bind(ipont);
                serverSocket.Listen(10);

                new Thread(new ThreadStart(serverWaitingConnect)).Start();
                isSocketCreate = true;
            }

            if(localIpAddress.Equals("") || localIpAddress == null)
            {
                MessageBox.Show(Strings.connect_error, Strings.messagebox_error_title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else
                MessageBox.Show(Strings.socket_service_turn_on_success + Strings.ipAddress + localIpAddress,
                    Strings.messagebox_information_title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CloseProgramMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(Strings.turn_off_lottery_program, Strings.messagebox_information_title,
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                this.Close();
                Environment.Exit(Environment.ExitCode);
            }
        }

        private void timerLottery_Tick(object sender, EventArgs e)
        {
            timerChangeColor.Stop();
            timerLottery.Stop();
            timerLottery.Enabled = false;
            timerChangeColor.Enabled = false;
            totalParticipant--;
            lotteryCount--;
            winnerCount++;
            tempTagWinner.Add(labelSet[selectItem[currentID]]);
            recordWinner.Add(labelSet[selectItem[currentID]].Text);

            if (lotteryCount > 0)
            {
                labelSet[selectItem[currentID]].BackColor = Color.White;
                selectedFinish();
                timerLottery.Enabled = true;
                timerChangeColor.Enabled = true;
                timerLottery.Start();
                timerChangeColor.Start();
                combCount.Text = lotteryCount.ToString();
                labWinnerCount.Text = winnerCount.ToString();
            }
            else
            {
                dataInsert();
                selectedFinish();
                prizeDuplicateCheck();
                combPrize.Enabled = true;
                btnStart.Focus();
                winnerMessage.winnerList = recordWinner;
                isLotteryRunning = false;
                labWinnerCount.Text = winnerCount.ToString();
                winnerMessage.ShowDialog();
                recordWinner.Clear();
            }
        }

        private void timerChangeColor_Tick(object sender, EventArgs e)
        {
            Random random = new Random();
            currentID = random.Next(0, totalParticipant);
            labelSet[selectItem[perviousID]].BackColor = Color.Gray;
            labelSet[selectItem[currentID]].BackColor = Color.White;
            perviousID = currentID;
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            WinnerList wl = new WinnerList();
            wl.ShowDialog();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            startLottery();
        }

        private void combPrize_SelectionChangeCommitted(object sender, EventArgs e)
        {
            prizeDuplicateCheck();
        }

        private void chBoxRepeat_CheckedChanged(object sender, EventArgs e)
        {
            if (chBoxRepeat.Checked)
            {
                btnStart.Enabled = true;
                buttonStartEnable = true;
            }           
            else
                prizeDuplicateCheck();
        }

        private void initialUnitSetting()
        {
            panel.Width = this.Width;
            panel.Height = this.Height;
            panelWidth = panel.Width;
            panelHeight = panel.Height;
            panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;

            labAuthor.Text = Strings.author;
            labAuthor.Parent = panel;
            labAuthor.BackColor = Color.Transparent;
            labAuthor.ForeColor = Color.Gold;         

            picLeft.Parent = panel;
            labWinnerCount.Text = winnerCount.ToString();
        }

        private void initialUnitFont()
        {
            combPrize.Font = FontSet.getTxtFontStyle();
            labSelectTimes.Font = FontSet.getLabelFontStyle();
            combCount.Font = FontSet.getTxtFontStyle();
            btnStart.Font = FontSet.getBtnFontStyle();
            btnList.Font = FontSet.getBtnFontStyle();
            labAuthor.Font = FontSet.getAuthorLabFontStyle();
            labWinner.Font = FontSet.getLabelFontStyle();
            labWinnerCount.Font = FontSet.getLabelFontStyle();
            labHuman.Font = FontSet.getLabelFontStyle();
            chBoxRepeat.Font = FontSet.getchBoxFontStyle();
        }

        private void initialUnitLocation()
        {
            panel.Location = new Point(0, 0);
            labSelectTimes.Location = new Point(Convert.ToInt32(panelWidth * 0.92), Convert.ToInt32(panelHeight * 0.25));
            combCount.Location = new Point(Convert.ToInt32(panelWidth * 0.92), Convert.ToInt32(panelHeight * 0.28));
            combPrize.Location = new Point(Convert.ToInt32(panelWidth * 0.92), Convert.ToInt32(panelHeight * 0.35));
            chBoxRepeat.Location = new Point(Convert.ToInt32(panelWidth * 0.935), Convert.ToInt32(panelHeight * 0.40));
            btnStart.Location = new Point(Convert.ToInt32(panelWidth * 0.92), Convert.ToInt32(panelHeight * 0.45));
            btnList.Location = new Point(Convert.ToInt32(panelWidth * 0.92), Convert.ToInt32(panelHeight * 0.58));
            labWinner.Location = new Point(Convert.ToInt32(panelWidth * 0.92), Convert.ToInt32(panelHeight * 0.65));
            labWinnerCount.Location = new Point(Convert.ToInt32(panelWidth * 0.94), Convert.ToInt32(panelHeight * 0.68));
            labHuman.Location = new Point(Convert.ToInt32(panelWidth * 0.97), Convert.ToInt32(panelHeight * 0.68));
            labAuthor.Location = new Point(Convert.ToInt32(panelWidth * 0.28), Convert.ToInt32(panelHeight * 0.45));
            picLeft.Location = new Point(Convert.ToInt32(panelWidth * 0.02), Convert.ToInt32(panelHeight * 0.5));
        }

        private void initialSize()
        {
            diameterWidth = this.Width / defaultWidth;
            diameterHeight = this.Height / defaultHeight;

            initailX = Convert.ToInt32(defaultWidth * 0.203 * diameterWidth);
            initailY = Convert.ToInt32(defaultHeight * 0.035 * diameterHeight);

            labelWidth = Convert.ToInt32(labelWidth * diameterWidth);
            labelHeight = Convert.ToInt32(labelHeight * diameterHeight);

            widthInterval = Convert.ToInt32(widthInterval * diameterWidth);
            heightInterval = Convert.ToInt32(heightInterval * diameterHeight);

            combPrize.Width = Convert.ToInt32(Convert.ToDouble(combPrize.Width) * diameterWidth);
            combPrize.Height = Convert.ToInt32(Convert.ToDouble(combPrize.Height) * diameterHeight);
            combCount.Width = Convert.ToInt32(Convert.ToDouble(combCount.Width) * diameterWidth);
            combCount.Height = Convert.ToInt32(Convert.ToDouble(combCount.Height) * diameterHeight);
            labSelectTimes.Width = Convert.ToInt32(Convert.ToDouble(labSelectTimes.Width) * diameterWidth);
            labSelectTimes.Height = Convert.ToInt32(Convert.ToDouble(labSelectTimes.Height) * diameterHeight);
            btnStart.Width = Convert.ToInt32(Convert.ToDouble(btnStart.Width) * diameterWidth);
            btnStart.Height = Convert.ToInt32(Convert.ToDouble(btnStart.Height) * diameterHeight);
            btnList.Width = Convert.ToInt32(Convert.ToDouble(btnList.Width) * diameterWidth);
            btnList.Height = Convert.ToInt32(Convert.ToDouble(btnList.Height) * diameterHeight);
            picLeft.Width = Convert.ToInt32(Convert.ToDouble(picLeft.Width) * diameterWidth);
            picLeft.Height = Convert.ToInt32(Convert.ToDouble(picLeft.Height) * diameterHeight);
            labHuman.Width = Convert.ToInt32(Convert.ToDouble(labHuman.Width) * diameterWidth);
            labHuman.Height = Convert.ToInt32(Convert.ToDouble(labHuman.Height) * diameterHeight);
            labWinnerCount.Width = Convert.ToInt32(Convert.ToDouble(labWinnerCount.Width) * diameterWidth);
            labWinnerCount.Height = Convert.ToInt32(Convert.ToDouble(labWinnerCount.Height) * diameterHeight);
            labWinner.Width = Convert.ToInt32(Convert.ToDouble(labWinner.Width) * diameterWidth);
            labWinner.Height = Convert.ToInt32(Convert.ToDouble(labWinner.Height) * diameterHeight);
            chBoxRepeat.Width = Convert.ToInt32(Convert.ToDouble(chBoxRepeat.Width) * diameterWidth);
            chBoxRepeat.Height = Convert.ToInt32(Convert.ToDouble(chBoxRepeat.Height) * diameterHeight);
        }

        private void loadComboboxData()
        {
            for (int i = 0; i < Strings.comboxItem.Length; i++)
            {
                combPrize.Items.Add(Strings.comboxItem[i]);
            }
            combPrize.Text = combPrize.Items[0].ToString();

            for (int j = 0; j < Strings.lotteryCountList.Length; j++)
            {
                combCount.Items.Add(Strings.lotteryCountList[j]);
            }
            combCount.Text = combCount.Items[0].ToString();
        }

        private void labelCreate()
        {
            for (int i = 0; i < labelSet.Length; i++)
            {
                rowCount++;
                labelSet[i] = new Label();
                labelSet[i].Text = Strings.lotteryLabelText[i];
                labelSet[i].Font = FontSet.getLotteryLabelFontStyle();
                labelSet[i].Name = Strings.label + i;
                labelSet[i].AutoSize = false;
                labelSet[i].Width = labelWidth;
                labelSet[i].Height = labelHeight;
                labelSet[i].TextAlign = ContentAlignment.MiddleCenter;
                labelSet[i].Location = new Point(initailX + offsetX, initailY + offsetY);
                labelSet[i].BackColor = Color.Gray;

                if (isFirstRound)
                {
                    switch (currentSide)
                    {
                        case firstTop:
                            if (rowCount >= firstRoundCountMaximum)
                            {
                                rowCount = 0;
                                currentSide = firstRight;
                                offsetY += labelSet[i].Height + heightInterval;
                            }
                            else
                                offsetX += labelSet[i].Width + widthInterval;
                            break;
                        case firstRight:
                            if (rowCount >= firstRoundCountMaximum)
                            {
                                rowCount = 0;
                                currentSide = firstBottom;
                                offsetX -= labelSet[i].Width + widthInterval;
                            }
                            else
                                offsetY += labelSet[i].Height + heightInterval;
                            break;
                        case firstBottom:
                            if (rowCount >= firstRoundCountMaximum)
                            {
                                rowCount = 0;
                                currentSide = firstLeft;
                                offsetY -= labelSet[i].Height + heightInterval;
                            }
                            else
                                offsetX -= labelSet[i].Width + widthInterval;
                            break;
                        case firstLeft:
                            if (rowCount >= firstRoundCountMaximum)
                            {
                                rowCount = 0;
                                currentSide = secondTop;
                                isFirstRound = false;
                                initailX = Convert.ToInt32(defaultWidth * 0.26 * diameterWidth);
                                initailY = Convert.ToInt32(defaultHeight * 0.09 * diameterHeight);
                                offsetX = 0;
                                offsetY = 0;
                                widthInterval = Convert.ToInt32(43 * diameterWidth);
                                heightInterval = Convert.ToInt32(23 * diameterHeight);
                            }
                            else
                                offsetY -= labelSet[i].Height + heightInterval;
                            break;
                    }

                }
                else
                {
                    switch (currentSide)
                    {
                        case secondTop:

                            if (rowCount >= secondRoundCountMaximum)
                            {
                                rowCount = 0;
                                currentSide = secondRight;
                                offsetY += labelSet[i].Height + heightInterval;
                            }
                            else
                                offsetX += labelSet[i].Width + widthInterval;
                            break;
                        case secondRight:

                            if (rowCount >= secondRoundCountMaximum)
                            {
                                rowCount = 0;
                                currentSide = secondBottom;
                                offsetX -= labelSet[i].Width + widthInterval;
                            }
                            else
                                offsetY += labelSet[i].Height + heightInterval;
                            break;
                        case secondBottom:
                            if (rowCount >= secondRoundCountMaximum)
                            {
                                rowCount = 0;
                                currentSide = secondLeft;
                                offsetY -= labelSet[i].Height + heightInterval;
                            }
                            else
                                offsetX -= labelSet[i].Width + widthInterval;
                            break;
                        case secondLeft:
                            if (rowCount <= secondRoundCountMaximum)
                            {
                                offsetY -= labelSet[i].Height + heightInterval;
                            }
                            break;
                    }
                }
                panel.Controls.Add(labelSet[i]);
                selectItem.Add(i);
            }
        }

        public void startLottery()
        {
            lotteryCount = int.Parse(combCount.Text);

            if(totalParticipant == 0)
            {
                MessageBox.Show(Strings.lottery_error1, Strings.messagebox_warning_title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (lotteryCount > totalParticipant)
            {
                MessageBox.Show(Strings.lottery_error2, Strings.messagebox_warning_title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (lotteryCount == totalParticipant)
            {
                totalParticipant -= lotteryCount;
                winnerCount += lotteryCount;
                tagWinner(tempTagWinner);
                tempTagWinner.Clear();
                foreach (int i in selectItem)
                {
                    tempTagWinner.Add(labelSet[i]);
                    recordWinner.Add(labelSet[i].Text);
                }

                dataInsert();
                winnerMessage.winnerList = recordWinner;
                labWinnerCount.Text = winnerCount.ToString();
                winnerMessage.ShowDialog();
                tagWinner(tempTagWinner);
                tempTagWinner.Clear();
            }
            else
            {
                recordPrize.Add(combPrize.Text);
                chBoxRepeat.Checked = false;
                chBoxRepeat.Enabled = false;
                combPrize.Enabled = false;

                if (isFirst)
                    isFirst = false;
                else
                    tagWinner(tempTagWinner);

                Random time = new Random();

                timerLottery.Interval = (time.Next(0, 4) + 2) * 1000;
                timerLottery.Start();
                timerChangeColor.Start();
                btnStart.Enabled = false;
                buttonStartEnable = false;
                isLotteryRunning = true;
                perviousPrizeItem = combPrize.Text;
                selectingSoundOutput();
            }

        }

        private void tagWinner(List<Label> list)
        {
            for (int i = 0; i < list.Count; i++)
                list[i].BackColor = Color.Gold;
        }

        private void selectedFinish()
        {
            selectItem.RemoveAt(perviousID);
            if (totalParticipant > 0)
            {
                Random perviousRan = new Random();
                perviousID = perviousRan.Next(0, totalParticipant);
            }
        }

        public static void backgroundSoundOutput()
        {
            MusicPlayer musicPlayer = new MusicPlayer();
            musicPlayer.FileName = Strings.normal_background_music;
            musicPlayer.Play();
        }

        public static void selectingSoundOutput()
        {
            MusicPlayer musicPlayer = new MusicPlayer();
            musicPlayer.FileName = Strings.selecting_background_music;
            musicPlayer.Play();
        }

        public static void selectedFinishSoundOutput()
        {
            MusicPlayer musicPlayer = new MusicPlayer();
            musicPlayer.FileName = Strings.winner_background_music;
            musicPlayer.Play();
        }

        private void loadLocalIpAddress()
        {
            foreach (IPAddress i in ips)
            {
                if (i.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIpAddress += i.ToString() + Strings.nextLine;
                }
            }
        }

        private void serverWaitingConnect()
        {
            while (true)
            {
                Console.WriteLine("Waiting for Mobile Phone Connect...");
                Socket clientSocket = serverSocket.Accept();
                IPEndPoint clientip = (IPEndPoint)clientSocket.RemoteEndPoint;

                if (!isLotteryRunning)
                {
                    SocketListener listener = new SocketListener(clientSocket);
                    new Thread(new ThreadStart(listener.run)).Start();
                }
                else
                    clientSocket.Close();
            }

        }

        private void dataInsert()
        {
            myConn = new OleDbConnection(strConn);
            myConn.Open();
            for (int i = 0; i < recordWinner.Count; i++)
            {
                insertCmd = "INSERT INTO record(獎項,中獎人) VALUES('" + combPrize.Text + "','" + recordWinner[i] + "')";
                Cmd = new OleDbCommand(insertCmd, myConn);
                Cmd.ExecuteNonQuery();
            }
            myConn.Close();
        }

        private bool isDatabaseEmpty()
        {
            bool result;
            OleDbConnection myConn = new OleDbConnection(Strings.databasePath);
            myConn.Open();

            OleDbCommand Cmd = new OleDbCommand(Strings.selectCommand, myConn);
            OleDbDataReader reader = Cmd.ExecuteReader();

            if (reader.Read())
                result = false;
            else
                result = true;

            reader.Close();
            myConn.Close();

            return result;
        }

        private void loadPreviousRecord()
        {
            OleDbConnection myConn = new OleDbConnection(Strings.databasePath);
            myConn.Open();

            OleDbCommand Cmd = new OleDbCommand(Strings.selectCommand, myConn);
            OleDbDataReader reader = Cmd.ExecuteReader();

            if (reader.Read())
            {
                OleDbDataAdapter adapter = new OleDbDataAdapter(Strings.selectCommand, myConn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    databaseWinnerText.Add(dt.Rows[i].ItemArray[1].ToString());
                    if (!recordPrize.Contains(dt.Rows[i].ItemArray[0].ToString()))
                        recordPrize.Add(dt.Rows[i].ItemArray[0].ToString());
                }
            }
            else
                Console.WriteLine("資料庫無資料");

            reader.Close();
            myConn.Close();
        }

        private void clearDatabase()
        {
            OleDbConnection myConn = new OleDbConnection(Strings.databasePath);
            myConn.Open();

            OleDbCommand Cmd = new OleDbCommand(Strings.deleteCommand, myConn);
            Cmd.ExecuteNonQuery();
            myConn.Close();
        }

        private void adjustParameterAfterLoadRecord()
        {
            foreach (string text in databaseWinnerText)
            {
                for (int i = 0; i < Strings.lotteryLabelText.Length; i++)
                {
                    if (text.Equals(Strings.lotteryLabelText[i]))
                    {
                        labelSet[i].BackColor = Color.Gold;
                        databaseWinnerIndex.Add(i);
                    }

                }
            }

            foreach (int index in databaseWinnerIndex)
                selectItem.RemoveAt(selectItem.IndexOf(index));

            isFirst = false;
            winnerCount = databaseWinnerIndex.Count;
            labWinnerCount.Text = databaseWinnerIndex.Count.ToString();
            totalParticipant -= databaseWinnerIndex.Count;
            prizeDuplicateCheck();
        }

        private void prizeDuplicateCheck()
        {
            foreach (string text in recordPrize)
            {
                if (combPrize.Text.Equals(text))
                {
                    btnStart.Enabled = false;
                    buttonStartEnable = false;
                    chBoxRepeat.Enabled = true;
                    break;
                }
                else
                {
                    btnStart.Enabled = true;
                    buttonStartEnable = true;
                    chBoxRepeat.Checked = false;
                    chBoxRepeat.Enabled = false;
                }
            }

        }

    }
}