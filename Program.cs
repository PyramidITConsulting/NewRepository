using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.Write("Please Enter SVN URL: ");
            string svnPath = "https://subversion.pyramidconsultinginc.com:8443/svn/Recall_Project";

            //Console.Write("Please Enter SVN username:");
            string username = "gagana";
            //Console.Write("Please Enter SVN password:");
            string pwd = "Pyramid123rss";

            //Console.Write("Please Enter Local path to pull code from SVN:");
            string path = "D:\\SVNTemp\\";

           // Console.Write(@"Please Enter Installation path of SVN[Default:C:\Program Files\TortoiseSVN\bin]:");
            string installPath = "C:\\Program Files\\TortoiseSVN\\bin";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (String.IsNullOrEmpty(installPath))
            {
                installPath = "C:\\Program Files\\TortoiseSVN\\bin";
            }
            DownloadSVNCode(path, svnPath, username, pwd, installPath);
            Console.ReadLine();
            //DownloadSVNCode("", "", "", "", "");
        }
        private static void DownloadSVNCode(string phyPath, string svnUrl, string uname, string pwd, string svnInstallPath)
        {
            string arguments = " checkout " + svnUrl + " " + phyPath + "  --username " + uname + " --password " + pwd;
            ProcessStartInfo info = new ProcessStartInfo("svn.exe", arguments);
            info.WorkingDirectory = svnInstallPath;
            info.WindowStyle = ProcessWindowStyle.Normal;
            info.UseShellExecute = false;
            Process.Start(info);
            Console.WriteLine("Download started");
        }
    }
}
