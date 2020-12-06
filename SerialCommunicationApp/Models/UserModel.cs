using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialCommunicationApp.Models
{
    public class UserModel
    {
        public string userNameOrEmailAddress { get; set; }
        public string password { get; set; }
        public bool rememberClient { get; set; }
    }
}
