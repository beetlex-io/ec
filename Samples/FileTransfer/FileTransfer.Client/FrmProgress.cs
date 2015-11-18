using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileTransfer.Client
{
    public partial class FrmProgress : Form
    {
        public FrmProgress()
        {
            InitializeComponent();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
        public void ChangeProgress(long max, long value)
        {

            progressBar1.Maximum = (int)max;
            progressBar1.Value = (int)value;
            label1.Text = string.Format("{0}/{1}byte", max, value);

        }
        public void ChangeProgress(long value)
        {

            progressBar1.Value += (int)value;
            label1.Text = string.Format("{0}/{1}byte", progressBar1.Value, progressBar1.Maximum);

        }

        private void FrmProgress_Load(object sender, EventArgs e)
        {

        }
    }
}
