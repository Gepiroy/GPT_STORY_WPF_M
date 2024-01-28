using System.Net.Http;
using System.Net;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using GPT_STORY_WPF_M.DataModels;
using System.Net.Http.Json;

namespace GPT_STORY_WPF_M
{
    public static class Fetcher
    {
        private static string resourceUrl = "http://127.0.0.1:5000/v1/completions/";

        private static HttpClient client = new HttpClient();

        public static void init()
        {
            client.DefaultRequestHeaders.Add(HttpRequestHeader.ContentType.ToString(), "application/json;charset=utf-8");
            client.Timeout = new TimeSpan(0, 20, 0);
        }

        public static string send(string prompt)
        {
            string ret = "error: in Fetch.cs, ret hasn't changed.";

            Logger.log("Sending prompt... ");

            var content = JsonContent.Create(new GPTRequest { prompt = prompt, max_tokens = 400 });

            var task = client.PostAsync(resourceUrl, content);
            task.Wait(1000*60*60); //1 hour timeout

            var response = task.Result;

            Logger.logn("Got result.");

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var reader = response.Content.ReadAsStringAsync();
                string result = reader.Result;
                reader.Wait();

                JToken obj = JToken.Parse(result);
                //Console.WriteLine(obj.ToString());

                var listingdata = JsonConvert.DeserializeObject<GPTResult>(obj.ToString());
                ret = listingdata.choices[0].text;
                Console.WriteLine("ret = " + ret);
            }
            else
            {
                Logger.logn("Status code is NOT OK: " + response);
            }

            return ret;
        }

    }
}
