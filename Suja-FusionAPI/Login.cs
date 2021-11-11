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
    public partial class Login : Form
    {
        private static FusionApp App = new FusionApp("APPID");

        public Login()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(tbUsername.Text) | (!string.IsNullOrEmpty(tbpassword.Text)))
            {
                var loginResponse = await App.Login(tbUsername.Text, tbpassword.Text, "", false, false);
                if(loginResponse.Error == false)
                {
                    MainWindow f2 = new MainWindow();
                    f2.ShowDialog();
                    this.Close();
                    MessageBox.Show("Login Successful");
                }
                else
                {

                }
            }
            else
            {

            }
        }
    }
}
