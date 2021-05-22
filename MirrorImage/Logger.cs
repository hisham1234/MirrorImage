using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MirrorImage
{
    public class Logger
    {
        public void WriteToErrorLog(string msg, string stkTrace)

        {
            string path = System.Configuration.ConfigurationManager.AppSettings["ErrorFilePath"];

            if (!(System.IO.Directory.Exists(path + "\\Errors\\")))

            {

                System.IO.Directory.CreateDirectory(path + "\\Errors\\");

            }

            FileStream fs = new FileStream(path + "\\Errors\\errlog.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);

            StreamWriter s = new StreamWriter(fs);

            s.Close();

            fs.Close();

            FileStream fs1 = new FileStream(path + "\\Errors\\errlog.txt", FileMode.Append, FileAccess.Write);

            StreamWriter s1 = new StreamWriter(fs1);

            

            s1.Write("Message: " + msg + System.Environment.NewLine);

            s1.Write("StackTrace: " + stkTrace + System.Environment.NewLine);

            s1.Write("Date/Time: " + DateTime.Now.ToString() + System.Environment.NewLine);

            s1.Write

            ("============================================" + System.Environment.NewLine);

            s1.Close();

            fs1.Close();

        }

    }
}

