using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Chat.Client
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
        public string Name
        {
            get;
            set;
        }
        public EC.ProtoClient Client
        {
            get;
            set;
        }

        private void cmdLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("enter you name!");
                return;
            }
            if (Client.Send(new Login { Name = txtName.Text }))
            {
                Name = txtName.Text;
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                MessageBox.Show(Client.Connection.LastError.Message);
            }
        }
    }
}
