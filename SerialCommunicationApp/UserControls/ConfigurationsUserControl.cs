using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO.Ports;
using System.IO;
using System.Configuration;
using System.ServiceProcess;
using log4net;
using SerialCommunicationApp.UTILS;

namespace SerialCommunicationApp.UserControls
{
    public partial class ConfigurationsUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        string configFileName = ConfigurationManager.AppSettings["config_file_name"];
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        string restartServiceBatchFileName = ConfigurationManager.AppSettings["restart_service_batch_file_name"];
        string startServiceBatchFileName = ConfigurationManager.AppSettings["start_service_batch_file_name"];
        string stopServiceBatchFileName = ConfigurationManager.AppSettings["stop_service_batch_file_name"];
        string installServiceBatchFileName = ConfigurationManager.AppSettings["install_service_batch_file_name"];
        MenuUserControl menuUserControl;
        string appConfigFilePath, rootPath, serviceBatchFilePath, serviceConfigFilePath;

        public ConfigurationsUserControl(MenuUserControl menuUserControl)
        {
            InitializeComponent();
            this.menuUserControl = menuUserControl;
            rootPath = AppDomain.CurrentDomain.BaseDirectory;
            rootPath = Path.Combine(rootPath, "SerialReaderService");
            serviceConfigFilePath = Path.Combine(rootPath, configFileName);
            appConfigFilePath = rootPath + configFileName;
            serviceBatchFilePath = Path.Combine(rootPath, "ServiceBatchFiles");
        }

        private void MenuUserControl_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            string[] availablePorts = SerialPort.GetPortNames();
            cmbAvailablePorts.Items.AddRange(availablePorts);
            cmbBaudRates.Items.Insert(0, "--Select Baud Rate--");
            cmbBaudRates.SelectedIndex = 0;
            cmbAvailablePorts.Items.Insert(0, "--Select Port--");
            cmbAvailablePorts.SelectedIndex = 0;
            string[] lines = File.ReadAllLines(serviceConfigFilePath);
            if (availablePorts.Length > 0)
            {
                cmbAvailablePorts.Text = lines[0];
                cmbBaudRates.Text = lines[1];
                tbRefreshTime.Text = (Convert.ToInt32(lines[2]) / 60000).ToString();
            }
        }

        /// <summary>
        /// Updates the configuration file
        /// </summary>
        /// <param name="comPort"></param>
        /// <param name="baudRate"></param>
        /// <param name="refreshTimeInterval"></param>
        /// <returns></returns>
        public bool ReplaceConfigSettingsInFile(string comPort = null, string baudRate = null, string refreshTimeInterval = null)
        {
            bool isConfigFileUpdated = false;
            {
                try
                {
                    if (!File.Exists(serviceConfigFilePath))
                    {
                        File.Create(serviceConfigFilePath);
                    }
                    string[] lines = File.ReadAllLines(serviceConfigFilePath);
                    if ((comPort != null && comPort.Contains("COM") && cmbAvailablePorts.SelectedIndex != 0) &&
                        (baudRate != null && cmbBaudRates.SelectedIndex != 0) && !string.IsNullOrEmpty(refreshTimeInterval))
                    {
                        File.WriteAllText(serviceConfigFilePath, String.Empty);
                        File.AppendAllText(serviceConfigFilePath, comPort + Environment.NewLine + baudRate + Environment.NewLine + (Convert.ToInt32(refreshTimeInterval)*60*1000) + Environment.NewLine+"MUR01");
                        isConfigFileUpdated = true;
                        DataLoggerControl.Write($"Confiuration file has been updated with PORT = {comPort}, Baud Rate = {baudRate} and Refresh Time Interval = {refreshTimeInterval}");
                    }
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                }
            }
            return isConfigFileUpdated;
        }
        public SerialForm ParentForm { get; set; }

        private void BtnSaveConfigurationClick(object sender, EventArgs e)
        {
            if (ReplaceConfigSettingsInFile(cmbAvailablePorts.Text, cmbBaudRates.Text, tbRefreshTime.Text.Trim()))
            {
                string[] lines = File.ReadAllLines(serviceConfigFilePath);
                if (ParentForm == null)
                    return;
                PanelControl panelControl = ParentForm.Controls["mainPanel"] as PanelControl;
                panelControl.Controls.Clear();
                menuUserControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                menuUserControl.Dock = DockStyle.Fill;
                menuUserControl.dataLbl.Text = $"COM Port: {lines[0]}   Baud Rate: {lines[1]}   Refresh Time: {(Convert.ToInt32(lines[2]) / 60000)}m ";
                panelControl.Controls.Add(menuUserControl);
                menuUserControl.ParentForm = ParentForm;
            }
        }

        private void BtnCancelClick(object sender, EventArgs e)
        {
            string[] lines = File.ReadAllLines(serviceConfigFilePath);
            PanelControl panelControl = ParentForm.Controls["mainPanel"] as PanelControl;
            panelControl.Controls.Clear();
            menuUserControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            menuUserControl.Dock = DockStyle.Fill;
            menuUserControl.dataLbl.Text = $"COM Port: {lines[0]}   Baud Rate: {lines[1]}   Refresh Time: {(Convert.ToInt32(lines[2]) / 60000)}m ";
            panelControl.Controls.Add(menuUserControl);
            menuUserControl.ParentForm = ParentForm;
        }
    }
}
