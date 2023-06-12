using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;



namespace MGC_RockPaperScissors
{
    class TestJSON
    {
        public string id;
        public string password;
    }


    class TestAPI
    {
        public static void Hello()
        {
            var result = RestAPI.Get(MSC_Config.URLAPIServer + "/test/hello");

            if (result.Success)
            {
                Logger.Log(result.Data);
            }
        }

        public static void Echo()
        {
            string data = "{ \"id\": \"101\", \"name\" : \"Alex\" }";

            var result = RestAPI.Post(MSC_Config.URLAPIServer + "/test/echo", data);

            if (result.Success)
            {
                Logger.Log(result.Data);
            }
        }

        public static void TestJSONAPI_Raw()
        {
            JObject jobj = new JObject(new JProperty("id", "idTest"), new JProperty("password", "passwordTest"));
            string json = jobj.ToString();

            Logger.Log(json);

            JObject jobjFrom = JObject.Parse(json);

            string id = jobjFrom["id"].Value<string>();

            Logger.Log(id);
        }

        public static void TestJSONAPI_Class()
        {
            TestJSON test = new TestJSON();
            test.id = "testID";
            test.password = "testPassword";

            string json = JsonConvert.SerializeObject(test);

            Logger.Log(json);

            TestJSON testFrom = JsonConvert.DeserializeObject<TestJSON>(json);

            Logger.Log(testFrom.id);
        }
    }
}









