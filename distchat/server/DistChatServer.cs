using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace server
{
    class DistChatServer
    {
        private readonly Socket listener;
        private readonly List<IPEndPoint> clients;
        private bool isStarted = false;

        public DistChatServer(string host, int port)
        {
            clients = new List<IPEndPoint>();
            IPAddress address = IPAddress.Parse(host);
            listener = new Socket(address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(new IPEndPoint(address, port));
        }

        public void Start()
        {
            isStarted = true;
            Console.WriteLine("{0} - Server started at {1}", DateTime.Now,
                ((IPEndPoint) listener.LocalEndPoint).Address);
            listener.Listen(10);
            while (isStarted)
            {
                var client = listener.Accept();
                ReceiveClientMessage(client);
            }
        }

        private void ReceiveClientMessage(Socket client)
        {
            var endPoint = (IPEndPoint)client.RemoteEndPoint;
            if (!clients.Contains(endPoint))
                clients.Add(endPoint);
            var data = new byte[1024];
            int msgLen = client.Receive(data);
            data = data.ToList().GetRange(0, msgLen).ToArray();
            Console.WriteLine("{0} - Message received from {1}", DateTime.Now, endPoint.Address);
            SendMessage(endPoint, data);
        }

        private void SendMessage(IPEndPoint from, byte[] data)
        {
            foreach (var client in clients)
            {
                if (client.Equals(from))
                    continue;
                SendMessageTo(client, data);
            }
        }

        private void SendMessageTo(IPEndPoint dest, byte[] data)
        {
            listener.SendTo(data, dest);
            Console.WriteLine("{0} - Message send to {1}", DateTime.Now, dest.Address);
        }
    }
}
