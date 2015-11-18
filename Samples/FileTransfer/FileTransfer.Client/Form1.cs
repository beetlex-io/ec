using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EC;
namespace FileTransfer.Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private ProtoSyncClient mClient = new ProtoSyncClient(System.Configuration.ConfigurationManager.AppSettings["host"]);

        private string mSaveFileName;

        private void Form1_Load(object sender, EventArgs e)
        {
            Bind(CD(""));
        }

        private void Bind(object items)
        {
            if (items != null)
            {
                listView1.Items.Clear();
                foreach (Resource item in (System.Collections.IList)items)
                {
                    listView1.Items.Add(new ResourceItem(item));
                }
            }
        }

        public object CD(string name)
        {
            object result = mClient.Send(new CD { Name = name });
            if (result is Error)
            {
                MessageBox.Show(((Error)result).Message);
                return null;
            }
            return result;
        }

        public class ResourceItem : ListViewItem
        {
            public ResourceItem(Resource data)
                : base(new string[] { data.Name, data.Size })
            {
                Data = data;
                if (data.Type == ResourceType.File)
                    ImageIndex = 1;
                else
                    ImageIndex = 0;
            }
            public Resource Data
            {
                get;
                private set;
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ResourceItem ri = (ResourceItem)listView1.SelectedItems[0];
                if (ri.Data.Type == ResourceType.Folder)
                {
                    Bind(CD(ri.Data.Name));
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmdDownload.Enabled = false;
            if (listView1.SelectedItems.Count > 0)
            {
                ResourceItem ri = (ResourceItem)listView1.SelectedItems[0];
                if (ri.Data.Type == ResourceType.File)
                {
                    cmdDownload.Enabled = true;
                }
            }
        }

        private void cmdDownload_Click(object sender, EventArgs e)
        {
            ResourceItem ri = (ResourceItem)listView1.SelectedItems[0];
            saveFileDialog1.FileName = ri.Data.Name;
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                mSaveFileName = saveFileDialog1.FileName;
                object result = mClient.Send(new Download { File = ri.Data.Name });
                if (result is Error)
                {
                    MessageBox.Show(((Error)result).Message);
                    return;
                }
                FrmProgress frm = new FrmProgress();
                frm.ChangeProgress(((FileInfo)result).Size, 0);
                frm.Show(this);
                cmdDownload.Enabled = false;
                System.Threading.ThreadPool.QueueUserWorkItem(OnDownload, frm);
            }

        }
        private void OnDownload(object state)
        {
            FrmProgress frm = (FrmProgress)state;
            using (FileHelper fh = new FileHelper(mSaveFileName, false))
            {
                while (true)
                {
                    FileBlock fb = mClient.Read<FileBlock>();
                    fh.Write(fb.Data, 0, fb.Data.Length);

                    Invoke(new Action<FrmProgress>(o =>
                    {
                        frm.ChangeProgress(fb.Data.Length);
                        if (fb.Eof)
                        {
                            frm.Hide();
                            cmdDownload.Enabled = true;
                        }
                    }), frm);
                    if (fb.Eof)
                        break;
                }
            }
        }

    }
}
