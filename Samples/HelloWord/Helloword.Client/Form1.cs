using EC;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Helloword.Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private EC.ProtoSyncClient mClient = new ProtoSyncClient("127.0.0.1");

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                try
                {
                    richTextBox1.AppendText(mClient.Send<string>(new Hello { Name=textBox1.Text })+"\r\n");
                    textBox1.Text = "";
                }
                catch (Exception E_)
                {
                    MessageBox.Show(E_.Message);
                }
            }
        
        }

        [MessageID(0x1)]
        [ProtoContract]
        public class Hello
        {
            [ProtoMember(1)]
            public string Name { get; set; }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
