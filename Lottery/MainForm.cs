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
        bool isFirst = true, isFirstRound = true;

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

        System.Timers.Timer t_ChangeColor, t_Lottery;


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
            selectingSoundOutput();
            labelCreate();
            winnerMessage.ShowDialog();
            timerLoad();
            Control.CheckForIllegalCrossThreadCalls = false;
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        private void OpenControlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IPEndPoint ipont = new IPEndPoint(IPAddress.Any, listenPort);
            serverSocket.Bind(ipont);
            serverSocket.Listen(10);

            new Thread(new ThreadStart(serverWaitConnect)).Start();
            MessageBox.Show(Strings.ipAddress + ips[3].ToString() + Strings.nextLine + Strings.socketServiceTurnOnSuccess, 
                Strings.messageBoxInformationTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CloseProgramToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(Strings.turnOffLotteryProgram, Strings.messageBoxInformationTitle, 
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
                this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetMessageBox rmb = new ResetMessageBox();
            rmb.Show();
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

        private void timerLottery_Tick(object sender, EventArgs e)
        {
            Console.WriteLine("YABE----- timerLottery_Tick on!");
            timerChangeColor.Stop();
            timerLottery.Stop();
            totalParticipant--;
            lotteryCount--;
            tempTagWinner.Add(labelSet[selectItem[currentID]]);
            recordWinner.Add(labelSet[selectItem[currentID]].Text);

            if(lotteryCount > 0)
            {
                labelSet[selectItem[currentID]].BackColor = Color.White;
                selectedFinish();
                timerLottery.Start();
                timerChangeColor.Start();
                combCount.Text = lotteryCount.ToString();
            }
            else
            {
                dataInsert();
                btnStart.Enabled = true;
                btnStart.Focus(); 
                winnerMessage.winnerList = recordWinner;
                winnerMessage.ShowDialog();
                recordWinner.Clear();
            }
        }

        private void timerChangeColor_Tick(object sender, EventArgs e)
        {
            Console.WriteLine("YABE----- timerChangeColor_Tick on!");
            Random random = new Random();
            currentID = random.Next(0, totalParticipant);
            labelSet[selectItem[perviousID]].BackColor = Color.Gray;
            labelSet[selectItem[currentID]].BackColor = Color.White;
            perviousID = currentID;
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

        private void startLottery()
        {
            Console.WriteLine("YABE----- startLottery on!");
            
            if (totalParticipant <= 1)
            {
                MessageBox.Show(Strings.lotteryError1, Strings.messageBoxWarningTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Console.WriteLine("YABE----- startLottery , 275");
            }
            else if (lotteryCount >= totalParticipant)
            {
                Console.WriteLine("YABE----- startLottery , 279");
                MessageBox.Show(Strings.lotteryError2, Strings.messageBoxWarningTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else {
                Console.WriteLine("YABE----- startLottery , 283");
                if (isFirst)
                    isFirst = false;
                else
                {
                    tagWinner(tempTagWinner);
                    selectedFinish();
                }

                Console.WriteLine("YABE----- startLottery , 292");
                Random time = new Random();
                t_Lottery.Interval = (time.Next(0, 4) + 2) * 1000;
                t_Lottery.Start();
                t_ChangeColor.Start();
                btnStart.Enabled = false;
                perviousPrizeItem = combPrize.Text;
                Console.WriteLine("YABE----- startLottery , 299");
            }
            
        }

        public void reset()
        {       
            offsetX = 0;
            offsetY = 0;
            rowCount = 0;
            perviousID = 0;
            currentID = 0;
            lotteryCount = 0;
            heightInterval = 10;
            widthInterval = 25;
            totalParticipant = 100;
            isFirst = true;
            isFirstRound = true;
            currentSide = firstTop;
            selectItem.Clear();
            tempTagWinner.Clear();
            recordWinner.Clear();
            panel.Controls.Clear();
            initailX = Convert.ToInt32(this.Width * 0.203);
            initailY = Convert.ToInt32(this.Height * 0.035);
            labelCreate();
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

        public static void selectingSoundOutput()
        {
            MusicPlayer musicPlayer = new MusicPlayer();
            musicPlayer.FileName = Strings.normalBackgroundMusic;
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

            btnStart.Focus();
        }

        private void initialUnitFont()
        {
            combPrize.Font = FontSet.getCombFontStyle();
            labSelectTimes.Font = FontSet.getLabelFontStyle();
            combCount.Font = FontSet.getTxtFontStyle();
            btnStart.Font = FontSet.getBtnFontStyle();
            btnReset.Font = FontSet.getBtnFontStyle();
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
            btnReset.Location = new Point(Convert.ToInt32(panelWidth * 0.92), Convert.ToInt32(panelHeight * 0.75));
            labAuthor.Location = new Point(Convert.ToInt32(panelWidth * 0.87), Convert.ToInt32(panelHeight * 0.97));
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
            btnReset.Width = Convert.ToInt32(Convert.ToDouble(btnReset.Width) * diameterWidth);
            btnReset.Height = Convert.ToInt32(Convert.ToDouble(btnReset.Height) * diameterHeight);
        }

        public void lotteryFunction()
        {
            Console.WriteLine("YABE----- lotteryFunction on!");

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

        private void serverWaitConnect()
        {
            while (true)
            {
                Console.WriteLine("Waiting...connect");
                Socket clientSocket = serverSocket.Accept();
                IPEndPoint clientip = (IPEndPoint)clientSocket.RemoteEndPoint;
                
               
                SocketListener listener = new SocketListener(clientSocket);
                listener.startLotteryCallback += new SocketListener.startLotteryDelegate(this.lotteryFunction);
                new Thread(new ThreadStart(listener.run)).Start();
            }

        }

        private void timerLoad()
        {
            t_ChangeColor = new System.Timers.Timer();
            t_ChangeColor.Interval = 100;
            t_ChangeColor.Elapsed += T_ChangeColor_Elapsed; ;

            t_Lottery = new System.Timers.Timer();
            t_Lottery.Interval = 100;
            t_Lottery.Elapsed += T_Lottery_Elapsed;
        }

        private void T_ChangeColor_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Console.WriteLine("YABE----- T_ChangeColor_Elapsed on!");
            Random random = new Random();
            currentID = random.Next(0, totalParticipant);
            labelSet[selectItem[perviousID]].BackColor = Color.Gray;
            labelSet[selectItem[currentID]].BackColor = Color.White;
            perviousID = currentID;
        }

        private void T_Lottery_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Console.WriteLine("YABE----- T_Lottery_Elapsed on!");
            t_ChangeColor.Stop();
            t_Lottery.Stop();
            totalParticipant--;
            lotteryCount--;
            tempTagWinner.Add(labelSet[selectItem[currentID]]);
            recordWinner.Add(labelSet[selectItem[currentID]].Text);

            if (lotteryCount > 0)
            {
                labelSet[selectItem[currentID]].BackColor = Color.White;
                selectedFinish();
                t_Lottery.Start();
                t_ChangeColor.Start();
                combCount.Text = lotteryCount.ToString();
            }
            else
            {
                dataInsert();
                btnStart.Enabled = true;
                btnStart.Focus();
                winnerMessage.winnerList = recordWinner;
                winnerMessage.ShowDialog();
                recordWinner.Clear();
            }
        }
    }
}