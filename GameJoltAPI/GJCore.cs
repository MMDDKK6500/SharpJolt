using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;

namespace GamejoltAPI.Core
{

    public class GJCore
    {
        public const string APIUrl = "https://api.gamejolt.com/api/game/v1_2/";

        private string gameId;
        private string privateKey;

        public string GameID
        {
            get => gameId;
        }


        public GJCore(string gameId, string privateKey)
        {
            this.gameId = gameId;
            this.privateKey = privateKey;
        }

        public async Task<string> GetTime()
        {
            string cmd = "time/?game_id=" + gameId;
            string fhash = Tools.MD5Hash(APIUrl + cmd + privateKey);
            string response = await Tools.Get(APIUrl + cmd + "&signature=" + fhash);
            return response;
        }

    }

    public static class Tools
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task<string> Get(string url)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(GJCore.APIUrl + url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
            catch (HttpRequestException ex)
            {
                return $"An internal error has occured: {ex.Message}";
            }
        }
    }

    public static class Extensions
    {
        public static string ToMD5Hash(this string input)
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
