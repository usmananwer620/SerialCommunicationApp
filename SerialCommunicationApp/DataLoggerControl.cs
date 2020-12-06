using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialCommunicationApp
{
    public class DataLoggerControl
    {
        private static string _Path = string.Empty;
        private static bool DEBUG = true;
        static string dataFileName = ConfigurationManager.AppSettings["data_file_name"];

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static void Write(string msg)
        {
            _Path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\Logs";
            if (!Directory.Exists(_Path))
                Directory.CreateDirectory(_Path);
            try
            {
                using (StreamWriter writer = new StreamWriter(Path.Combine(_Path, dataFileName + "_" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + ".txt"), true))
                {
                    Log(msg, writer);
                    writer.Close();
                }
            }
            catch (Exception e)
            {
                log.Error($"{e}");
            }
        }

        static private void Log(string msg, TextWriter w)
        {
            try
            {
                w.Write("[{0} {1}]", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
                w.Write("\t");
                w.WriteLine(" {0}", msg);
            }
            catch (Exception e)
            {
                log.Error($"{e}");
            }
        }
    }
}
