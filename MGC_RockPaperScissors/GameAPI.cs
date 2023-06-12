using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGC_RockPaperScissors
{
    class GameAPI
    {
        public static APIMessage playGame(ParamSessionKeyOnly param)
        {
            string data = JsonConvert.SerializeObject(param);

            var result = RestAPI.Post(MSC_Config.URLAPIServer + "/playGame", data);

            if (result.Success)
            {
                var msg = JsonConvert.DeserializeObject<APIMessage>(result.Data);

                return msg;
            }

            return null;
        }
    }
}
