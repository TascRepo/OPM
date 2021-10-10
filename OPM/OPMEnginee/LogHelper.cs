using System;
using System.IO;

namespace OPM.Enginee
{
    class LogHelper
    {
        private static volatile LogHelper _logIntance;
        private static readonly object _lockObject = new object();

        private LogHelper()
        {

        }

        public static LogHelper WriteLog()
        {
            if (null == _logIntance)
            {
                lock (_lockObject)
                {
                    if (null == _logIntance)
                    {
                        _logIntance = new LogHelper();
                    }
                }
            }
            return _logIntance;
        }
        public static void Content(string strlogs)
        {
            string strDireactory = @"F:\";
            if (Directory.Exists(strDireactory))
            {
                strDireactory = @"F:\";
            }
            else
            {
                strDireactory = @"D:\";
            }
            string strLogFile = "Opmlog.txt";
            //Write file
            using (StreamWriter w = File.AppendText(strDireactory + strLogFile))
            {
                w.WriteLine("{0} {1} : ", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
                w.WriteLine(strlogs + "\n");
            }

        }

    }
}
