using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MGC_RockPaperScissors
{
    class RestAPIResult
    {
        public bool Success = false;
        public string Data = String.Empty;
    }

    class RestAPI
    {
        public static RestAPIResult Get(string url)
        {
            RestAPIResult result = new RestAPIResult();

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.ContentType = "application/json";
                using (WebResponse response = request.GetResponse())
                using (Stream dataStream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(dataStream))
                {
                    result.Data = reader.ReadToEnd();
                }

                result.Success = true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.ToString());

                result.Success = false;
                result.Data = ex.ToString();
            }

            return result;
        }

        public static RestAPIResult Post(string url, string data)
        {
            RestAPIResult result = new RestAPIResult();

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/json";
                request.Timeout = 30 * 1000;

                byte[] bytes = Encoding.ASCII.GetBytes(data);
                request.ContentLength = bytes.Length;

                using (Stream reqStream = request.GetRequestStream())
                {
                    reqStream.Write(bytes, 0, bytes.Length);
                }

                using (WebResponse resp = request.GetResponse())
                {
                    Stream respStream = resp.GetResponseStream();
                    using (StreamReader sr = new StreamReader(respStream))
                    {
                        result.Data = sr.ReadToEnd();
                    }
                }

                result.Success = true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.ToString());

                result.Success = false;
                result.Data = ex.ToString();
            }

            return result;
        }
    }
}
