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
        bool isFirst = true, isFirstRound = true, isSocketCreate = false, isLotteryRunning = false;

        const int firstTop = 1001, firstRight = 1002, firstBottom = 1003, firstLeft = 1004;
        const int secondTop = 2001, secondRight = 2002, secondBottom = 2003, secondLeft = 2004;
        int perviousID = 0, currentID = 0, lotteryCount = 0;
        int offsetX = 0, offsetY = 0, rowCount = 0, initailX, initailY, heightInterval = 10, widthInterval = 25;
        int firstRoundCountMaximum = 15, secondRoundCountMaximum = 10; 
        int panelWidth = 0, panelHeight = 0, labelWidth = 35, labelHeight = 35;
        int totalParticipant = 100, currentSide = firstTop;

        const double defaultWidth = 1366, defaultHeight = 768;
        public double diameterWidth, diameterHeight;

        string strConn = Strings.databasePath;
        string insertCmd, perviousPrizeItem = "";

        OleDbConnection myConn;
        OleDbCommand Cmd;

        Label[] labelSet = new Label[100];
        List<int> selectItem = new List<int>();
        List<string> recordWinner = new List<string>();
        List<Label> tempTagWinner = new List<Label>();

        WinnerMessage winnerMessage = new WinnerMessage();
        public static MainForm mainForm;

        const int listenPort = 3456;
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
            winnerMessage.ShowDialog();
            Control.CheckForIllegalCrossThreadCalls = false;
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
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

                new Thread(new ThreadStart(serverWaitConnect)).Start();
                isSocketCreate = true;
            }

            MessageBox.Show(Strings.ipAddress + ips[3].ToString() + Strings.nextLine + Strings.socketServiceTurnOnSuccess,
                Strings.messageBoxInformationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CloseProgramMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(Strings.turnOffLotteryProgram, Strings.messageBoxInformationTitle,
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
            }
            else
            {
                dataInsert();
                btnStart.Enabled = true;
                winnerMessage.winnerList = recordWinner;
                winnerMessage.ShowDialog();
                recordWinner.Clear();
                isLotteryRunning = false;
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
            lotteryFunction();
        }

        private void labelCreate()
        {
            for (int i = 0; i < labelSet.Length; i++)
            {
                rowCount++;
                labelSet[i] = new Label();
                labelSet[i].Text = Strings.lotteryLabelText[i];
                labelSet[i].Font = FontSet.getLotteryLabelFontStyle();
                labelSet[i].Name = Strings.label + 0;
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

        private void tagWinner(List<Label> list)
        {
            for(int i = 0; i < list.Count; i++) 
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
            musicPlayer.FileName = Strings.normalBackgroundMusic;
            musicPlayer.Play();
        }

        public static void selectingSoundOutput()
        {
            MusicPlayer musicPlayer = new MusicPlayer();
            musicPlayer.FileName = Strings.selectingBackgroundMusic;
            musicPlayer.Play();
        }

        public static void selectedFinishSoundOutput()
        {
            MusicPlayer musicPlayer = new MusicPlayer();
            musicPlayer.FileName = Strings.winnerBackgroundMusic;
            musicPlayer.Play();
        }

        private void dataInsert()
        {
            myConn = new OleDbConnection(strConn);
            myConn.Open();
            for(int i = 0; i < recordWinner.Count; i++)
            {
                insertCmd = "INSERT INTO record(獎項,中獎人) VALUES('"+combPrize.Text+"','" + recordWinner[i] +"')";
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
            {
                result = false;
            }
            else
            {
                result = true;
            }
            reader.Close();
            myConn.Close();

            return result;
        }

        private void clearDatabase()
        {
            OleDbConnection myConn = new OleDbConnection(Strings.databasePath);
            myConn.Open();

            OleDbCommand Cmd = new OleDbCommand(Strings.deleteCommand, myConn);
            Cmd.ExecuteNonQuery();
            myConn.Close();  
        }

        private void loadComboboxData()
        {
            for(int i = 0; i < Strings.comboxItem.Length; i++)
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
        }

        private void initialUnitFont()
        {
            combPrize.Font = FontSet.getCombFontStyle();
            labSelectTimes.Font = FontSet.getLabelFontStyle();
            combCount.Font = FontSet.getTxtFontStyle();
            btnStart.Font = FontSet.getBtnFontStyle();
            btnList.Font = FontSet.getBtnFontStyle();
            labAuthor.Font = FontSet.getAuthorLabFontStyle();
        }

        private void initialUnitLocation()
        {
            panel.Location = new Point(0, 0);
            labSelectTimes.Location = new Point(Convert.ToInt32(panelWidth * 0.92), Convert.ToInt32(panelHeight * 0.25));
            combCount.Location = new Point(Convert.ToInt32(panelWidth * 0.92), Convert.ToInt32(panelHeight * 0.30));
            combPrize.Location = new Point(Convert.ToInt32(panelWidth * 0.92), Convert.ToInt32(panelHeight * 0.35));
            btnStart.Location = new Point(Convert.ToInt32(panelWidth * 0.92), Convert.ToInt32(panelHeight * 0.40));
            btnList.Location = new Point(Convert.ToInt32(panelWidth * 0.92), Convert.ToInt32(panelHeight * 0.53));
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
        }

        public void lotteryFunction()
        {
            lotteryCount = int.Parse(combCount.Text);

            if (isFirst && !isDatabaseEmpty())
            {
                DialogResult record;
                record = MessageBox.Show(Strings.resetList, Strings.messageBoxInformationTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (record == DialogResult.OK)
                {
                    clearDatabase();
                    startLottery();
                }
            }
            else
            {
                if (perviousPrizeItem.Equals(combPrize.Text))
                {
                    DialogResult result;
                    result = MessageBox.Show(combPrize.Text + Strings.prizeItemsDuplicate, Strings.messageBoxInformationTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.OK)
                    {
                        startLottery();
                    }
                }
                else
                    startLottery();
            }
        }

        private void startLottery()
        {

            if (totalParticipant <= 1)
            {
                MessageBox.Show(Strings.lotteryError1, Strings.messageBoxWarningTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (lotteryCount >= totalParticipant)
            {
                MessageBox.Show(Strings.lotteryError2, Strings.messageBoxWarningTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (isFirst)
                    isFirst = false;
                else
                {
                    tagWinner(tempTagWinner);
                    selectedFinish();
                }

                Random time = new Random();

                timerLottery.Interval = (time.Next(0, 4) + 2) * 1000;
                timerLottery.Start();
                timerChangeColor.Start();

                btnStart.Enabled = false;
                isLotteryRunning = true;
                perviousPrizeItem = combPrize.Text;
                selectingSoundOutput();
            }

        }

        private void serverWaitConnect()
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

    }
}