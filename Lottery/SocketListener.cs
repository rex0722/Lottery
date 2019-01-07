﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Lottery
{
    class SocketListener
    {
        private Socket socket;
        public delegate void startLotteryDelegate();
        public event startLotteryDelegate startLotteryCallback;

        public SocketListener(Socket socket)
        {
            this.socket = socket;
        }

        public void run()
        {
            while (true)
            {
                Console.WriteLine("Waiting...Message");
                byte[] data = new byte[1024];
                int datalenght = socket.Receive(data);
                if (datalenght == 0) break;
                string input = Encoding.UTF8.GetString(data, 0, datalenght);
                if (input.Equals("start"))
                {
                    Console.WriteLine("Lottery Start!!" + input);
                    startLotteryCallback();
                }
                    
                Console.WriteLine("Get Message:" + input);
            }
            socket.Close();
        }
    }
}