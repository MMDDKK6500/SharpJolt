using GameJoltAPI.Core;
using GameJoltAPI.Users;
using System.Threading.Tasks;

namespace GamejoltAPI.Score
{
    public class GJScore
    {
        private string gameId;
        private string username;
        private string userToken;
        private string privateKey;

        public GJScore(GJCore core, GJUser user)
        {
            gameId = user.GameID;
            username = user.Username;
            userToken = user.Token;
            privateKey = core.PrivateKey;
        }

        /*public async Task<string> Fetch(int limit, int table_id, string username, string user_token, string guest, int better_than, int worse_than)
        {

            var cmd = $"scores/?game_id={gameId}";
            var str = GJCore.APIUrl + cmd + privateKey;
            var response = await Tools.Get(GJCore.APIUrl + cmd + "&signature=" + str.ToMD5Hash());
            return response;
        }*/
        public async Task<string> GetTables()
        {
            var cmd = $"scores/tables/?game_id={gameId}";
            var str = GJCore.APIUrl + cmd + privateKey;
            var response = await Tools.Get(GJCore.APIUrl + cmd + "&signature=" + str.ToMD5Hash());
            return response;
        }
        public async Task<string> GetRank(int sort, int table_id)
        {
            var cmd = $"scores/get-rank/?game_id={gameId}&sort={sort}";
            if (!string.IsNullOrEmpty(table_id.ToString())) {
                cmd = cmd + $"&table_id={table_id}";
            }
            var str = GJCore.APIUrl + cmd + privateKey;
            var response = await Tools.Get(GJCore.APIUrl + cmd + "&signature=" + str.ToMD5Hash());
            return response;
        }
    }
}
