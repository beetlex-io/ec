using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EC;
using Remoting.Service;

namespace Remoting.Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private ProtoClient mClient = new ProtoClient("192.168.7.111");

        private IUserService UserService;

        private void Form1_Load(object sender, EventArgs e)
        {
            UserService = mClient.CreateInstance<IUserService>();
        }

        private void cmdRegister_Click(object sender, EventArgs e)
        {
            User user= UserService.Register(txtName.Text, txtEMail.Text);
            txtCreateTime.Text = user.CreateTime.ToString();
        }
    }
}
