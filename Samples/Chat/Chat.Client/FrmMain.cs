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
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }



        private EC.ProtoClient mClient = new EC.ProtoClient("127.0.0.1");

        private string Name;

        private void OnLogin(Login e)
        {
            richTextBox1.AppendText(string.Format(">{0} login @ {1}\r\n", e.Name, e.From));
        }

        private void OnSay(Say e)
        {
            richTextBox1.AppendText(string.Format( ">{0} say \t{1} from:{2}\r\n {3}\r\n", e.Name, DateTime.Now, e.From,e.Content));
        }

        private void OnSignout(Signout e)
        {
            richTextBox1.AppendText(string.Format(">{0} signout @ {1}\r\n", e.Name, e.From));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mClient.Receive = (o, p) => {
                if (p.Message is Say)
                {
                    Invoke(new Action<Say>(OnSay), p.Message);
                }
                else if (p.Message is Login)
                {
                    Invoke(new Action<Login>(OnLogin), p.Message);
                }
                else if (p.Message is Signout)
                {
                    Invoke(new Action<Signout>(OnSignout), p.Message);
                }
            };
            FrmLogin login = new FrmLogin();
            login.Client = mClient;
            login.ShowDialog(this);
            Name = login.Name;
            richTextBox1.AppendText(string.Format(">login {0}\r\n", DateTime.Now));
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    if(mClient.Send(new Say{ Content=textBox1.Text}))
                    {
                        richTextBox1.AppendText(string.Format(">{0} say\t{1}\r\n {2}\r\n", Name, DateTime.Now,textBox1.Text));
                        textBox1.Text = "";
                    }

                }
            }
        }
    }
}
