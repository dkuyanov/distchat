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
            chatClient.MessageReceived += MessageReceived;
            chatClient.Initialize();
        }

        private void MessageReceived(object sender, ChatClient.MessageEventArgs e)
        {
            try
            {
                tbMessages.Invoke(new Action(() =>
                {
                    tbMessages.Text += string.Format("{0} - {1} : {2}", DateTime.Now, e.From, e.Message);
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка", ex.Message);
            }
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
    }
}
