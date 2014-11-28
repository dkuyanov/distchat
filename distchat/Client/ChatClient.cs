using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Client
{
    public class ChatClient
    {
        public EventHandler<MessageEventArgs> MessageReceived;

        private readonly IPEndPoint serverEndPoint;
        private readonly TcpClient client;
        private NetworkStream stream;
        private Thread listenThread;
        private readonly string clientName;
        private const string MSG_DELIMITER = "&&&";
        private const string MSG_CONNECT = "%%connect%%";

        public ChatClient(string clientName, IPEndPoint clientEndPoint, IPEndPoint serverEndPoint)
        {
            this.serverEndPoint = serverEndPoint;
            this.clientName = clientName;
            client = new TcpClient(clientEndPoint);
        }

        public void Initialize()
        {
            client.Connect(serverEndPoint);
            stream = client.GetStream();
            Send(MSG_CONNECT);
            //listenThread = new Thread(ListenServer);
            //listenThread.Start();
        }

        public void Send(string message)
        {
            byte[] data = Encoding.Unicode.GetBytes(string.Format("{0}{1}{2}", clientName, MSG_DELIMITER, message));
            stream.Write(data, 0, data.Length);
        }

        public void Deinitialize()
        {
            if (listenThread != null)
                listenThread.Abort();
            client.Close();
        }

        private void ListenServer()
        {
            while (true)
                Read();
        }

        public void Read()
        {
            if (stream.CanRead && stream.DataAvailable)
                ProcessServerMessage(stream);
        }

        private void ProcessServerMessage(NetworkStream stream)
        {
            var data = new byte[client.ReceiveBufferSize];
            int dataLength = stream.Read(data, 0, client.ReceiveBufferSize);
            if (dataLength > 0)
            {
                string[] messageObj = Encoding.Unicode.GetString(data)
                    .Split(new[] {"&&&"}, StringSplitOptions.RemoveEmptyEntries);
                string message = messageObj[1];
                string from = messageObj[0];
                OnMessageReceived(new MessageEventArgs(from, message));
            }
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
