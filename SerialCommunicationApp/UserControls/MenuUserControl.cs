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
using log4net;
using System.IO.Ports;
using System.Configuration;
using System.IO;
using System.Threading;
using DevExpress.Data.TreeList;
using System.Diagnostics;
using SerialCommunicationApp.UTILS;
using SerialCommunicationApp.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SerialCommunicationApp.UserControls
{
    public partial class MenuUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        SerialPort serialPort1;
        string _serialPortReply = string.Empty;
        string _reply;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        string configFileName = ConfigurationManager.AppSettings["config_file_name"];
        string restartServiceBatchFileName = ConfigurationManager.AppSettings["restart_service_batch_file_name"];
        string startServiceBatchFileName = ConfigurationManager.AppSettings["start_service_batch_file_name"];
        string stopServiceBatchFileName = ConfigurationManager.AppSettings["stop_service_batch_file_name"];
        string installServiceBatchFileName = ConfigurationManager.AppSettings["install_service_batch_file_name"];
        string dataFileName = ConfigurationManager.AppSettings["data_file_name"];
        string[] availablePorts;
        string appConfigFilePath, rootPath, serviceBatchFilePath, serviceConfigFilePath, _serialCommandResponse, _fwDateCommandResponse, _tndCommandResponse, _getValuesResponse, _getCellResponse;

        public MenuUserControl()
        {
            InitializeComponent();
            availablePorts = SerialPort.GetPortNames();
            rootPath = AppDomain.CurrentDomain.BaseDirectory;
            rootPath = Path.Combine(rootPath, "SerialReaderService");
            serviceConfigFilePath = Path.Combine(rootPath, configFileName);
            appConfigFilePath = Path.Combine(rootPath, configFileName);
            serviceBatchFilePath = rootPath;
            availablePorts = SerialPort.GetPortNames();
            serialPort1 = new SerialPort();
            log.Info("Menu user control has started!");
        }

        public SerialForm ParentForm { get; set; }

        private void MenuUserControl_Load(object sender, EventArgs e)
        {
            string[] lines = new string[3];
            lines = File.ReadAllLines(serviceConfigFilePath);
            this.dataLbl.Text = $"COM Port: {lines[0]}   Baud Rate: {lines[1]}   Refresh Time: {(Convert.ToInt32(lines[2]) / 60000)}m ";
            this.Dock = DockStyle.Fill;
        }

        private void BtnRefreshServiceClick(object sender, EventArgs e)
        {
            try
            {

                AppService.RunServiceBatchFile(serviceBatchFilePath, installServiceBatchFileName);

                #region service code
                //    string[] availablePorts = SerialPort.GetPortNames();
                //    string[] lines = new string[3];
                //    if (!File.Exists(appConfigFilePath))
                //    {
                //        File.Create(appConfigFilePath);
                //    }

                //    if (availablePorts.Length > 0)
                //    {
                //        if (File.Exists(appConfigFilePath))
                //        {
                //            lines = File.ReadAllLines(appConfigFilePath);

                //            if (serialPort1.IsOpen)
                //            {
                //                serialPort1.Close();
                //            }
                //            serialPort1.PortName = lines[0];
                //            serialPort1.Open();

                //            if (availablePorts.Contains(lines[0]))
                //            {
                //                serialPort1.BaudRate = Convert.ToInt32(lines[1]);
                //                serialPort1.ReadTimeout = 180000;
                //                portResponseLbl.Text = "";
                //                SendingSerialNumCommand();
                //                CreateModule();
                //                StartReadingFromDevice();
                //            }
                //            else
                //            {
                //                log.Warn($"Please update your configurations from available ports and their respective baud rates");
                //                serialPort1.Close();
                //                return;
                //            }
                //        }
                //    }
                //    else
                //    {
                //        log.Warn($"No serial port available! Please check your serial ports availability.");
                //        portResponseLbl.Text = $"COM Port is not available. Please check your ports and try again.";
                //        return;
                //    }
                    #endregion
            }
            catch (Exception ex)
            {
                log.Error($"### Reading Error {ex}");
                this.portResponseLbl.Text = ex.Message;
                serialPort1.Close();
            }
        }

        private void SendingSerialNumCommand()
        {
            #region GET_SER_NUM#
            if (serialPort1.IsOpen)
            {
                int portResponse = 3;
                while (portResponse > 0)
                {
                    try
                    {
                        Thread.Sleep(4000);
                        serialPort1.Write("CHECK#");
                        Thread.Sleep(4000);
                        _serialPortReply = serialPort1.ReadTo("!");
                        if (_serialPortReply.Contains("OKAY"))
                        {
                            DataLoggerControl.Write($"CHECK Command is successfull on port {serialPort1.PortName}");
                            DataLoggerControl.Write($"CHECK Command response is: {_serialPortReply}");

                            DataLoggerControl.Write($"Command sent: GET_SER_NUM#");
                            Thread.Sleep(4000);
                            serialPort1.Write("GET_SER_NUM#");
                            Thread.Sleep(4000);
                            _serialPortReply = serialPort1.ReadTo("!");
                            Thread.Sleep(2000);
                            if (_serialPortReply.Contains("ERROR") || _serialPortReply == "")
                            {
                                DataLoggerControl.Write($"GET_SER_NUM# ERROR response: {_serialPortReply}{Environment.NewLine}");
                            }
                            else
                            {
                                DataLoggerControl.Write($"Command response: {_serialPortReply}{Environment.NewLine}");
                            }
                            portResponse = 0;
                        }
                        else if (_serialPortReply.Contains("ERROR"))
                        {
                            DataLoggerControl.Write($"CHECK# {_serialPortReply}{Environment.NewLine}");
                            portResponse--;
                        }
                    }
                    catch (Exception ex)
                    {
                        log.Error($"{ex}");
                        DataLoggerControl.Write($"GET_SER_NUM# Command: {ex.Message}");
                        _serialPortReply = string.Empty;
                        portResponse--;
                    }
                }
            }
            #endregion
        }

        public void StartReadingFromDevice()
        {
            try
            {
                List<string> getValuesAndGetCells = new List<string>();
                bool isGetValues = false;
                bool isGetCell = false;
                if (serialPort1.IsOpen)
                {
                    log.Info($"COM port is open and starting reading data from {serialPort1.PortName}");

                    #region GET_VALUES# and GET_CELL#
                    int portResponse = 3;
                    while (portResponse > 0)
                    {
                        try
                        {
                            Thread.Sleep(4000);
                            serialPort1.Write("CHECK#");
                            Thread.Sleep(4000);
                            _getValuesResponse = serialPort1.ReadTo("!");
                            if (_getValuesResponse.Contains("OKAY"))
                            {
                                DataLoggerControl.Write($"CHECK Command is successfull on port {serialPort1.PortName}");
                                DataLoggerControl.Write($"CHECK Command response is: {_getValuesResponse}");

                                DataLoggerControl.Write($"Command sent: GET_VALUES#");
                                Thread.Sleep(4000);
                                serialPort1.Write("GET_VALUES#");
                                Thread.Sleep(4000);
                                _getValuesResponse = serialPort1.ReadTo("!");
                                Thread.Sleep(2000);
                                if (_getValuesResponse.Contains("ERROR") || _getValuesResponse == "")
                                {
                                    DataLoggerControl.Write($"GET_VALUES# ERROR response: {_getValuesResponse}{Environment.NewLine}");
                                }
                                else
                                {
                                    getValuesAndGetCells.Add(_getValuesResponse);
                                    isGetValues = true;
                                    DataLoggerControl.Write($"Command response: {_getValuesResponse}{Environment.NewLine}");
                                }

                                Thread.Sleep(4000);
                                serialPort1.Write("GET_CELL#");
                                Thread.Sleep(4000);
                                _getCellResponse = serialPort1.ReadTo("!");
                                Thread.Sleep(2000);
                                if (_getCellResponse.Contains("ERROR") || _getCellResponse == "")
                                {
                                    DataLoggerControl.Write($"GET_CELL# ERROR response: {_getCellResponse}{Environment.NewLine}");
                                }
                                else
                                {
                                    getValuesAndGetCells.Add(_getCellResponse);
                                    isGetCell = true;
                                    DataLoggerControl.Write($"Command response: {_getCellResponse}{Environment.NewLine}");
                                }

                                portResponse = 0;
                            }
                            else if (_getValuesResponse.Contains("ERROR"))
                            {
                                DataLoggerControl.Write($"{_getValuesResponse}{Environment.NewLine}");
                                portResponse--;
                            }
                        }
                        catch (Exception ex)
                        {
                            log.Error($"{ex}");
                            DataLoggerControl.Write($"GET_VALUES# Command: {ex.Message}");
                            _getValuesResponse = string.Empty;
                            portResponse--;
                        }
                    }

                    if (isGetCell && isGetValues)
                    {
                        foreach (var item in getValuesAndGetCells)
                        {
                            AppService.RunTestModulePostAsync(item, _serialPortReply);
                        }
                    }

                    #endregion GET_VALUES# and GET_CELL#

                    #region GET_FW#
                    portResponse = 3;
                    while (portResponse > 0)
                    {
                        try
                        {
                            Thread.Sleep(4000);
                            serialPort1.Write("CHECK#");
                            Thread.Sleep(4000);
                            _reply = serialPort1.ReadTo("!");
                            if (_reply.Contains("OKAY"))
                            {
                                DataLoggerControl.Write($"CHECK Command is successfull on port {serialPort1.PortName}");
                                DataLoggerControl.Write($"CHECK Command response is: {_reply}");

                                DataLoggerControl.Write($"Command sent: GET_FW#");
                                Thread.Sleep(4000);
                                serialPort1.Write("GET_FW#");
                                Thread.Sleep(4000);
                                _reply = serialPort1.ReadTo("!");
                                Thread.Sleep(2000);
                                if (_reply.Contains("ERROR") || _reply == "")
                                {
                                    DataLoggerControl.Write($"GET_FW# ERROR response: {_reply}{Environment.NewLine}");
                                }
                                else
                                {
                                    DataLoggerControl.Write($"Command response: {_reply}{Environment.NewLine}");
                                }
                                portResponse = 0;
                            }
                            else if (_reply.Contains("ERROR"))
                            {
                                DataLoggerControl.Write($"CHECK# {_reply}{Environment.NewLine}");
                                portResponse--;
                            }
                        }
                        catch (Exception ex)
                        {
                            log.Error($"{ex}");
                            DataLoggerControl.Write($"GET_FW# Command: {ex.Message}");
                            _reply = string.Empty;
                            portResponse--;
                        }
                    }
                    #endregion

                }
                else
                {
                    log.Warn($"COM Port {serialPort1.PortName} is not opened!");
                }
                _reply = string.Empty;
            }
            catch (Exception ex)
            {
                log.Error($"### Initialising Reading Error {ex}");
                log.Warn($"{ex.Message}. Service is re-started.");
            }
        }

        /// <summary>
        /// Creating module at the start of the service
        /// </summary>
        private bool CreateModule()
        {
            #region GET_TND# and GET_FW_DATE#
            bool isFW_DATE = false;
            bool isTND = false;
            bool isTestModuleCreated = false;

            int portResponse = 3;
            while (portResponse > 0)
            {
                try
                {
                    if (serialPort1.IsOpen)
                    {
                        Thread.Sleep(4000);
                        serialPort1.Write("CHECK#");
                        Thread.Sleep(4000);
                        _tndCommandResponse = serialPort1.ReadTo("!");
                        if (_tndCommandResponse.Contains("OKAY"))
                        {
                            DataLoggerControl.Write($"CHECK Command is successfull on port {serialPort1.PortName}");
                            DataLoggerControl.Write($"CHECK Command response is: {_tndCommandResponse}");

                            DataLoggerControl.Write($"Command sent: GET_TND#");
                            Thread.Sleep(4000);
                            serialPort1.Write("GET_TND#");
                            Thread.Sleep(4000);
                            _tndCommandResponse = serialPort1.ReadTo("!");
                            Thread.Sleep(2000);
                            if (_tndCommandResponse.Contains("ERROR") || _tndCommandResponse == "")
                            {
                                DataLoggerControl.Write($"GET_TND# ERROR response: {_tndCommandResponse}{Environment.NewLine}");
                            }
                            else
                            {
                                isTND = true;
                                DataLoggerControl.Write($"Command response: {_tndCommandResponse}{Environment.NewLine}");
                            }

                            DataLoggerControl.Write($"Command sent: GET_FW_DATE#");
                            Thread.Sleep(4000);
                            serialPort1.Write("GET_FW_DATE#");
                            Thread.Sleep(4000);
                            _fwDateCommandResponse = serialPort1.ReadTo("!");
                            Thread.Sleep(2000);
                            if (_fwDateCommandResponse.Contains("ERROR") || _fwDateCommandResponse == "")
                            {
                                DataLoggerControl.Write($"GET_FW_DATE# ERROR response: {_fwDateCommandResponse}{Environment.NewLine}");
                            }
                            else
                            {
                                isFW_DATE = true;
                                isTestModuleCreated = true;
                                DataLoggerControl.Write($"Command response: {_fwDateCommandResponse}{Environment.NewLine}");
                            }
                            portResponse = 0;
                        }
                        else if (_tndCommandResponse.Contains("ERROR"))
                        {
                            DataLoggerControl.Write($"CHECK# {_tndCommandResponse}{Environment.NewLine}");
                            portResponse--;
                        }
                    }
                    else
                    {
                        log.Warn($"Serial port {serialPort1.PortName} is not opened!");
                    }

                    //Module creation at the start of the service
                    if (isFW_DATE && isTND)
                    {
                        ModuleObject moduleObject = PrepareModuleObject(_fwDateCommandResponse, _tndCommandResponse);
                        AppService.RunModulePostAsync(moduleObject);
                        isTestModuleCreated = true;
                    }
                }
                catch (Exception ex)
                {
                    log.Error($"{ex}");
                    DataLoggerControl.Write($"GET_TND# Command: {ex.Message}");
                    _tndCommandResponse = string.Empty;
                    _fwDateCommandResponse = string.Empty;
                    portResponse--;
                }
            }

            return isTestModuleCreated;
            #endregion GET_TND# and GET_FW_DATE#
        }

        private ModuleObject PrepareModuleObject(string _fwDateCommandResponse, string _tndCommandResponse)
        {
            ModuleObject moduleObject = new ModuleObject();
            moduleObject.serialNumber = _serialPortReply;
            moduleObject.name = _serialPortReply;
            moduleObject.sitesName = _serialPortReply;
            moduleObject.geT_FW_DATE = _fwDateCommandResponse;
            moduleObject.geT_TND = _tndCommandResponse;
            return moduleObject;
        }

        private void BtnUpdateConfigurationClick(object sender, EventArgs e)
        {
            log.Info(string.Format("Update button is clicked"));
            if (XtraMessageBox.Show($"You need to stop the service before updating configurations file.{Environment.NewLine}" +
                $"Do you want to stop the service?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
                AppService.RunServiceBatchFile(serviceBatchFilePath, stopServiceBatchFileName);
            else
                return;
            if (ParentForm == null)
                return;
            PanelControl panelControl = ParentForm.Controls["mainPanel"] as PanelControl;
            ConfigurationsUserControl configurationsUserControl = new ConfigurationsUserControl(this);
            panelControl.Controls.Clear();
            configurationsUserControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelControl.Controls.Add(configurationsUserControl);
            configurationsUserControl.ParentForm = ParentForm;
        }
    }
}
