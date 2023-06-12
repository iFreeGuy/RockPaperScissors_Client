using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGC_RockPaperScissors
{
    class LoginAPI
    {
        public static APIMessage login(ParamLogin param)
        {
            string data = JsonConvert.SerializeObject(param);

            var result = RestAPI.Post(MSC_Config.URLAPIServer + "/login", data);

            if (result.Success)
            {
                var msg = JsonConvert.DeserializeObject<APIMessage>(result.Data);

                return msg;
            }

            return null;
        }

        public static APIMessage logout(ParamSessionKeyOnly param)
        {
            string data = JsonConvert.SerializeObject(param);

            var result = RestAPI.Post(MSC_Config.URLAPIServer + "/logout", data);

            if (result.Success)
            {
                var msg = JsonConvert.DeserializeObject<APIMessage>(result.Data);

                return msg;
            }

            return null;
        }
    }
}














