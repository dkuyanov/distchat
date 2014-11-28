using System;
using System.Windows.Forms;

namespace Client
{
    public partial class FormClient : Form
    {
        private readonly ChatClient chatClient; 

        public FormClient(ChatClient client)
        {
            chatClient = client;
            InitializeComponent();
        }

        private void FormClient_Load(object sender, EventArgs e)
        {
            
        }

        private void MessageReceived(object sender, ChatClient.MessageEventArgs e)
        {
            try
            {
                if (InvokeRequired)
                    Invoke(new Action<string, string>(WriteMessage), e.From, e.Message);
                else
                    WriteMessage(e.From, e.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка", ex.Message);
            }
        }

        private void WriteMessage(string from, string message)
        {
            tbMessages.Text += string.Format("{0} - {1} : {2}\r\n", DateTime.Now, from, message);
        }

        private void FormClient_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                chatClient.Deinitialize();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка", ex.Message);
            }
        }

        private void btSend_Click(object sender, EventArgs e)
        {
            try
            {
                if(!string.IsNullOrEmpty(tbMessageToSend.Text))
                    chatClient.Send(tbMessageToSend.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка", ex.Message);
            }
        }

        private void btConnect_Click(object sender, EventArgs e)
        {
            try
            {
                chatClient.MessageReceived += MessageReceived;
                chatClient.Initialize();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка", ex.Message);
            }
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                chatClient.Read();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка", ex.Message);
            }
        }
    }
}
