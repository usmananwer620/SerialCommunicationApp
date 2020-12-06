using Newtonsoft.Json;
using SerialCommunicationApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerialCommunicationApp.UTILS
{
    public class AppService
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void RunServiceBatchFile(string rootPath, string serviceBatchFileName)
        {
            string bat = Path.Combine(rootPath, serviceBatchFileName);
            ProcessStartInfo processBat = new ProcessStartInfo(bat);
            Process proc = new Process();
            proc.StartInfo = processBat;
            proc.StartInfo.Verb = "runas";
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            proc.StartInfo.ErrorDialog = false;
            proc.Start();
        }

        public static async void RunTestModulePostAsync(string commandResponse, string serialCommandResponse)
        {
            serialCommandResponse = serialCommandResponse.Substring(0, serialCommandResponse.Length - 3);

            var baseAddress = "http://66.70.142.79:81/api/";
            using (HttpClient moduleClient = new HttpClient())
            {
                moduleClient.BaseAddress = new Uri(baseAddress);
                moduleClient.DefaultRequestHeaders.Accept.Clear();
                moduleClient.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                moduleClient.DefaultRequestHeaders.Add("Abp.TenantId", "4");

                TestModuleObject testModuleObj = new TestModuleObject();
                testModuleObj.serialNumber = serialCommandResponse;
                testModuleObj.inputValues = commandResponse;
                testModuleObj.Id = 0;
                HttpResponseMessage testModuleResponse = await moduleClient.PostAsJsonAsync("services/app/TestModule/Create", testModuleObj);
                if (testModuleResponse.IsSuccessStatusCode)
                {
                    var testModuleResponseContent = await testModuleResponse.Content.ReadAsStringAsync();
                    log.Info($"Test Module Post response: {testModuleResponseContent }");
                }
            }
        }

        public static async void RunModulePostAsync(Object objmodule)
        {
            ModuleObject moduleObject = objmodule as ModuleObject;
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var json = JsonConvert.SerializeObject(moduleObject);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Add("Abp.TenantId", "4");
                HttpResponseMessage response = await client.PostAsJsonAsync("http://66.70.142.79:81/api/services/app/Module/Create",
                                                                            moduleObject);
                if (response.IsSuccessStatusCode)
                {
                    var readTask = response.Content.ReadAsAsync<ModuleObject>();
                    readTask.Wait();
                    var insertedStudent = readTask.Result;

                    log.Info($"serial {moduleObject.serialNumber} inserted with site Name: {moduleObject.sitesName}");
                }
                else
                {
                    log.Info(response.StatusCode);
                }
            }
        }

    }
}
