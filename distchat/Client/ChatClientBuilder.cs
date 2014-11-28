using System.Net;
using Client.Properties;

namespace Client
{
    static class ChatClientBuilder
    {
        public static ChatClient Build()
        {
            IPAddress serverAddress = IPAddress.Parse(Settings.Default.ServerHost);
            var serverEndPoint = new IPEndPoint(serverAddress, Settings.Default.ServerPort);
            IPAddress clientAddress = IPAddress.Parse(Settings.Default.ClientHost);
            var clientEndPoint = new IPEndPoint(clientAddress, Settings.Default.ClientPort);
            return new ChatClient(Settings.Default.ClientName, clientEndPoint, serverEndPoint);
        }
    }
}
