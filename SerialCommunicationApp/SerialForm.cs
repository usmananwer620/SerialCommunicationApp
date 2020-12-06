using log4net;
using Microsoft.Win32;
using SerialCommunicationApp.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerialCommunicationApp
{
    public partial class SerialForm : Form
    {
        string configFileName = ConfigurationManager.AppSettings["config_file_name"];
        string dataFileName = ConfigurationManager.AppSettings["data_file_name"];
        private static string rootPath;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public SerialForm()
        {
            InitializeComponent();
            rootPath = AppDomain.CurrentDomain.BaseDirectory;
            rootPath = Path.Combine(rootPath, "SerialReaderService");
        }

        private void SerailFormLoad(object sender, EventArgs e)
        {
            log.Info(string.Format("Main application loaded"));
            string keyName = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
            string valueName = "Serial Communication Application";
            if (Registry.GetValue(keyName, valueName, null) == null)
            {
                //code if key Not Exist
                RegistryKey reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                reg.SetValue(valueName, Application.ExecutablePath.ToString());
            }
            DeleteOldFile(Path.Combine(rootPath,"Logs"));
            MenuUserControl menuUserControl = new MenuUserControl();
            ConfigurationsUserControl configurationsUserControl = new ConfigurationsUserControl(menuUserControl);
            this.mainPanel.Controls.Clear();
            menuUserControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.mainPanel.Controls.Add(menuUserControl);
            menuUserControl.ParentForm = this;
            configurationsUserControl.ParentForm = this;
        }

        public static void DeleteOldFile(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);
            string[] files = Directory.GetFiles(directoryPath);
            string destinationDirectory = Path.Combine(rootPath, "BackupLogs");
            if (!Directory.Exists(destinationDirectory))
                Directory.CreateDirectory(destinationDirectory);
            foreach (string file in files)
            {
                FileInfo fi = new FileInfo(file);
                if (fi.LastAccessTime < DateTime.Now.AddDays(-2))
                {
                    File.Copy(file, Path.Combine(destinationDirectory, Path.GetFileName(file)));
                }
            }
        }
    }
}
