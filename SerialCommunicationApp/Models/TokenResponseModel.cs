using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialCommunicationApp.Models
{
    public class TokenResponseModel
    {
        public string accessToken { get; set; }
        public string encryptedAccessToken { get; set; }
        public int expireInSeconds { get; set; }
        public int userId { get; set; }
    }
}
