using ModelInterface;
using System;
using System.Net;
using System.Net.Sockets;

namespace Network
{
    public class NetworkModel:ModelIF
    {
        public void StartTcpServer() 
        {
            TcpListener server = null;

            try
            {
                Int32 port = 13000;
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");

                server = new TcpListener(localAddr, port);
                server.Start(); // クライアントからの接続要求を待機 

                Byte[] bytes = new byte[256];
                string data = null;

                while (true)
                {
                    Console.WriteLine("接続待ちです。");
                    // 接続要求があれば、AcceptTcpClientメソッドにより、クライアントの接続要求を待ち受け
                    using (TcpClient client = server.AcceptTcpClient())
                    {
                        Console.WriteLine("Connected!");
                        data = null;
                        // GetStreamメソッドによりNetworkStreamを取得する。データの送受信には、このNetworkStreamを使用
                        NetworkStream stream = client.GetStream();
                        
                        int i;
                        while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                        {
                            data = System.Text.Encoding.UTF8.GetString(bytes, 0, i);
                            Console.WriteLine("Received: {0}", data);

                            data = data.ToUpper();

                            byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);

                            // Send back a response.
                            stream.Write(msg, 0, msg.Length);
                            Console.WriteLine("Sent: {0}", data);
                        }
                    }
                }
            }
            catch (SocketException e)
            {
                // Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                server.Stop();
            }

        }

    }
}
