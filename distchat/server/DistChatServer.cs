using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace server
{
    class DistChatServer
    {
        private readonly Socket listener;
        private TcpListener tcpListener;
        private readonly List<Tuple<string, IPEndPoint>> clients;
        private const string MSG_DELIMITER = "&&&";
        private const string MSG_CONNECT = "%%connect%%";

        public DistChatServer(string host, int port)
        {
            clients = new List<Tuple<string, IPEndPoint>>();
            IPAddress address = IPAddress.Parse(host);
            listener = new Socket(address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(new IPEndPoint(address, port));
        }

        public void Start()
        {
            Console.WriteLine("{0} - Server started at {1}:{2}", DateTime.Now,
                ((IPEndPoint) listener.LocalEndPoint).Address,
                ((IPEndPoint)listener.LocalEndPoint).Port);
            listener.Listen(10);
            while (true)
            {
                var client = listener.Accept();
                ReceiveClientMessage(client);
            }
        }

        private void ReceiveClientMessage(Socket client)
        {
            var data = new byte[1024];
            int msgLen = client.Receive(data);
            if (msgLen > 0)
            {
                data = data.ToList().GetRange(0, msgLen).ToArray();
                string[] msgObj = Encoding.Unicode.GetString(data)
                    .Split(new[] {MSG_DELIMITER}, StringSplitOptions.RemoveEmptyEntries);
                var endPoint = (IPEndPoint) client.RemoteEndPoint;
                if (clients.All(c => c.Item1 != msgObj[0]))
                    clients.Add(new Tuple<string, IPEndPoint>(msgObj[0], endPoint));
                if (msgObj[1] == MSG_CONNECT)
                {
                    Console.WriteLine("{0} - Connected {1} [{2}:{3}]", DateTime.Now, msgObj[0], endPoint.Address,
                        endPoint.Port);
                }
                else
                {
                    Console.WriteLine("{0} - Message received from {1} [{2}:{3}]", DateTime.Now, msgObj[0],
                        endPoint.Address,
                        endPoint.Port);
                    SendMessage(endPoint, data);
                }
            }
        }

        private void SendMessage(IPEndPoint from, byte[] data)
        {
            foreach (var client in clients)
            {
                if (client.Item2.Equals(from))
                    continue;
                SendMessageTo(client.Item2, data);
            }
        }

        private void SendMessageTo(IPEndPoint dest, byte[] data)
        {
            listener.SendTo(data, dest);
            Console.WriteLine("{0} - Message send to {1}", DateTime.Now, dest.Address);
        }
    }
}
