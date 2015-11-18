using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EC;
namespace FileTransfer.Server
{
    [Controller]
    public class Program
    {
        static void Main(string[] args)
        {
            EC.ECServer.Open();
            System.Threading.Thread.Sleep(-1);
        }

        public object OnCD(ISession session, CD e)
        {

            try
            {
                "{0} CD {1}".Log4Info(session.Channel.EndPoint, e.Name);
                List<Resource> result = new List<Resource>();
                CurrentFolder folder = GetFolder(session);
                if (e.Name == @"\")
                {
                    folder.Root();
                }
                else if (e.Name == "..")
                {
                    folder.Previous();
                }
                else if (!string.IsNullOrEmpty(e.Name))
                {
                    string name = folder.Path + e.Name;
                    if (System.IO.Directory.Exists(name))
                        folder.Add(e.Name);
                }
                else
                {
                }
                if (folder.SubFolder)
                {
                    result.Add(new Resource { Name = @"\", Type = ResourceType.Folder });
                    result.Add(new Resource { Name = @"..", Type = ResourceType.Folder });
                }
                foreach (string f in System.IO.Directory.GetDirectories(folder.Path))
                {
                    System.IO.DirectoryInfo info = new System.IO.DirectoryInfo(f);

                    result.Add(new Resource { Name = info.Name, Type = ResourceType.Folder });

                }
                foreach (string f in System.IO.Directory.GetFiles(folder.Path))
                {
                    System.IO.FileInfo info = new System.IO.FileInfo(f);
                    result.Add(new Resource { Name = info.Name, Type = ResourceType.File, Size = ((double)info.Length / (double)1024).ToString("0.00/KB") });

                }
                return result;
            }
            catch (Exception e_)
            {
                return new Error { Message = e_.Message };
            }
        }

        public object OnDownload(ISession session, Download e)
        {

            try
            {
                CurrentFolder folder = GetFolder(session);
                string filename = folder.Path + e.File;
                if (!System.IO.File.Exists(filename))
                {
                    return new Error { Message = e.File + " not found!" };
                }
                session["DOWNLOAD_TAG"] = new FileHelper(filename);
                System.IO.FileInfo fi = new System.IO.FileInfo(filename);
                return new FileInfo { Name=fi.Name, Size= fi.Length };
            }
            catch (Exception e_)
            {
                return new Error { Message = e_.Message };
            }
        }

        private CurrentFolder GetFolder(ISession session)
        {
            CurrentFolder result = (CurrentFolder)session["FOLDER"];
            if (result == null)
            {
                result = new CurrentFolder(session.Application[AppModel.BASE_PATH].ToString());
                session["FOLDER"] = result;
            }
            return result;
        }
    }
    public class CurrentFolder
    {
        private List<string> subfoldrs = new List<string>();

        public CurrentFolder(string root)
        {
            mRoot = root;
        }

        private string mRoot;

        public bool SubFolder
        {
            get
            {
                return subfoldrs.Count > 0;
            }
        }
        public void Add(string folder)
        {
            subfoldrs.Add(folder);
        }
        public void Root()
        {
            subfoldrs.Clear();
        }
        public void Previous()
        {
            if (subfoldrs.Count > 0)
                subfoldrs.RemoveAt(subfoldrs.Count - 1);
        }
        public string Path
        {
            get
            {
                if (subfoldrs.Count == 0)
                    return mRoot;
                return mRoot + string.Join(System.IO.Path.DirectorySeparatorChar.ToString(), subfoldrs.ToArray()) + System.IO.Path.DirectorySeparatorChar;
            }
        }
    }

    public class AppModel : IAppModel
    {
        public const string BASE_PATH = "BASE_PATH";
        public string Command(string cmd)
        {
            return null;
        }

        public void Init(IApplication application)
        {
            application[BASE_PATH] = System.Configuration.ConfigurationManager.AppSettings["path"];
            application.SendCompleted += (o, e) => {
                object tag = e.Info.Data.Tag;
                if (tag is FileInfo || tag is FileBlock)
                {
                    FileHelper fh = (FileHelper)e.Session["DOWNLOAD_TAG"];
                    if (fh != null)
                    {
                       
                        FileBlock fb = new FileBlock();
                        fb.Data = fh.Read();
                        fb.Eof = fh.Eof;
                        if (fb.Eof)
                        {
                            fh.Dispose();
                            e.Session["DOWNLOAD_TAG"] = null;
                        }
                        e.Application.Server.Send(fb, e.Session.Channel);
                    }

                }
            };
        }

        public string Name
        {
            get { return "FileTransfer"; }
        }
    }

}
