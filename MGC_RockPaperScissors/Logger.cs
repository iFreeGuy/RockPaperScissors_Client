using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace MGC_RockPaperScissors
{
    class Logger
    {
        public static void Log(string msg)
        {
            Debug.WriteLine(msg);
        }

        public static void Error(string msg)
        {
            Debug.WriteLine("Error: " + msg);
        }

        public static void LogDebug(string msg)
        {
            Debug.WriteLine(msg);
        }
    }
}
