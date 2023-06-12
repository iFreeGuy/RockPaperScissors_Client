using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGC_RockPaperScissors
{
    enum APIMessageID
    {
        UnknownError = -99999,
        Login = 1,
        CheckLogin = 2,
        Logout = 3,
        PlayGame = 4,
    }

    enum APIResultCode
    {
        Success = 0,
        Fail = -1,
        NotLogin = -2,
        UnknownError = -99999
    }

    class APIMessage
    {
        public APIMessageID messageID = APIMessageID.UnknownError;
        public APIResultCode resultCode = APIResultCode.UnknownError;
        public string data = "";

        public void debug()
        {
            Logger.Log(string.Format("{0}/{1}/{2}", messageID, resultCode, data));
        }
    }
}
