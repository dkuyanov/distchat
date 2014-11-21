namespace server
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = new DistChatServer("127.0.0.1", 2130);
            server.Start();
        }
    }
}
