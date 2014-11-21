using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Client
{
    public class ChatClient
    {
        public EventHandler<MessageEventArgs> MessageReceived;
        private readonly IPEndPoint clientEndPoint;
        private readonly IPEndPoint serverEndPoint;
        private readonly Socket socket;
        private Thread listenThread;
        private readonly object lockObject = true;

        public ChatClient(IPEndPoint clientEndPoint, IPEndPoint serverEndPoint)
        {
            this.clientEndPoint = clientEndPoint;
            this.serverEndPoint = serverEndPoint;
            socket = new Socket(clientEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        }

        public void Initialize()
        {
            socket.Bind(clientEndPoint);
            listenThread = new Thread(ListenServer);
            listenThread.Start();
        }

        public void Send(string message)
        {
            var sendSocket = new Socket(socket.AddressFamily, socket.SocketType, socket.ProtocolType);
            sendSocket.Bind(clientEndPoint);
            byte[] data = Encoding.Unicode.GetBytes(message);
            sendSocket.SendTo(data, serverEndPoint);
        }

        public void Deinitialize()
        {
            listenThread.Abort();
        }

        private void ListenServer()
        {
            socket.Listen(10);
            while (true)
            {
                var server = socket.Accept();
                if (!Equals(server.RemoteEndPoint, serverEndPoint))
                    continue;
                ProcessServerMessage(server);
            }
        }

        private void ProcessServerMessage(Socket server)
        {
            var data = new byte[1024];
            int msgLen = server.Receive(data);
            data = data.ToList().GetRange(0, msgLen).ToArray();
            string message = Encoding.Unicode.GetString(data);
            string from = ((IPEndPoint) server.RemoteEndPoint).Address.ToString();
            OnMessageReceived(new MessageEventArgs(from, message));
        }

        private void OnMessageReceived(MessageEventArgs e)
        {
            if (MessageReceived != null)
                MessageReceived(this, e);
        }

        public class MessageEventArgs : EventArgs
        {
            public string From { get; private set; }
            public string Message { get; private set; }

            public MessageEventArgs(string from, string message)
            {
                From = from;
                Message = message;
            }
        }
    }
}
