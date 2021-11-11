using Fusion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Suja_FusionAPI
{
    public partial class MainWindow : Form
    {
        public System.Timers.Timer timer = new System.Timers.Timer();

        public MainWindow()
        {
            InitializeComponent();
            TimerStart();
            UpdateChat();
        }

        private void TimerStart()
        {
            timer.Interval = 3500;
            timer.Elapsed += timer_Elapsed;
            timer.Start();
        }

        public void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            UpdateChat();
        }

        private async void UpdateChat()
        {
            try
            {
                var chat = await FusionApp.GetChat();
                if (chat.Error == false)
                {
                    dataGridView1.Rows.Clear();
                    foreach (var message in chat.Chat)
                    {
                        dataGridView1.Rows.Insert(0, message.Author[1], message.Content);
                    }

                }
                else
                {
                    
                }
            }
            catch
            {

            }
        }

        private void Page2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
            TimerStart();
            UpdateChat();
        }

        private void Page3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
            timer.Stop();
        }

        private void Page4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage4;
            timer.Stop();
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbMessage.Text))
            {
                var sendMessage = await FusionApp.SendMessage(tbMessage.Text);
                if (sendMessage.Error == false)
                {
                    UpdateChat();
                }
                else
                {
                    MessageBox.Show("Message failed to send.");
                }
            }
            else
            {
                MessageBox.Show("Text box Cannot be empty!");
            }
            

        }
    }
}
