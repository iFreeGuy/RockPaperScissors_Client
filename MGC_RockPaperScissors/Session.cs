using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGC_RockPaperScissors
{
    enum SessionState
    {
        NotLogin,
        Login,
        PlayGame,
    }

    class Session
    {
        private static Session inst_ = null;

        private Session()
        {
        }

        public static Session Inst
        {
            get
            {
                if (inst_ == null)
                {
                    inst_ = new Session();
                }

                return inst_;
            }
        }

        public SessionState State
        {
            get;
            set;
        } = SessionState.NotLogin;

        public string SessionKey
        {
            get;
            set;
        } = "";
            
    }
}
