using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat
{
    public partial class ConnProps : Form
    {
        public ConnProp ConnProp =new ConnProp();
        public ConnProps()
        {
            InitializeComponent();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConnProp.Login = login.Text;
            ConnProp.Password = password.Text;
            ConnProp.IP=IPAddress.Parse(ipaddress.Text);
            ConnProp.Command = "0";
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ConnProp.Login = login.Text;
            ConnProp.Password = password.Text;
            ConnProp.IP = IPAddress.Parse(ipaddress.Text);
            ConnProp.Command = "1";
            Close();
        }
    }
}
