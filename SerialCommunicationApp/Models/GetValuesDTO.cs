using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialCommunicationApp.Models
{
    public class GetValuesDTO
    {
        public int id { get; set; }
        public string serialNumber { get; set; }
        public string voltage { get; set; }
        public string current { get; set; }
        public string temperature { get; set; }
        public string lifeEnergy { get; set; }
        public string voltageState { get; set; }
        public string currentState { get; set; }
        public string temperatureState { get; set; }
        public string calibrationState { get; set; }
        public string stateOfCharge { get; set; }
        public string stateOfContactor { get; set; }
        public string stateOfBalancing { get; set; }
        public string rtcStatus { get; set; }
        public string sD_Card_Status { get; set; }
        public string balancing_During_Charge { get; set; }
        public string sD_Card_Logging_Status { get; set; }
        public string number_of_SD_Logging_Days { get; set; }
    }
}
