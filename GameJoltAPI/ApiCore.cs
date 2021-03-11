using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;

namespace gamejoltapiCore
{

    public class GJCore
    {
        public string game_id;
        public string private_key;
        public string apiurl = "https://api.gamejolt.com/api/game/v1_2/";

        public GJCore(string gameid, string privatekey)
        {
            game_id = gameid;
            private_key = privatekey;
        }

        public async Task<string> GetTime()
        {
            string cmd = "time/?game_id=" + game_id;
            string fhash = Tools.MD5Hash(apiurl + cmd + private_key);
            string response = await Tools.Get(apiurl + cmd + "&signature=" + fhash);
            return response;
        }

    }

    public class Tools
    {
        static readonly HttpClient client = new HttpClient();

        public static async Task<string> Get(string url)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("http://api.gamejolt.com/api/game/v1_2/" + url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
            catch (HttpRequestException)
            {
                return "An error has occured!";
            }
        }

        ////////////Hash
        public static string MD5Hash(string input)
        {
            MD5 m = MD5.Create();
            byte[] data = m.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sbuild = new StringBuilder();

            for (int i = 0; i < data.Length; ++i)
                sbuild.Append(data[i].ToString("x2"));

            return sbuild.ToString();

        }
    }
}
