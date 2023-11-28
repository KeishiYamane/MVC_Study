using Network;
using System;
using System.Net;
using System.Net.Sockets;

namespace Model
{
    class Program
    {
        static void Main(string[] args)
        {
            new NetworkModel().StartTcpServer();
        }
    }
}
