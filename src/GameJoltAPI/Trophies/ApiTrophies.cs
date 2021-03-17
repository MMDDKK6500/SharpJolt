using GamejoltAPI.Core;
using GamejoltAPI.Users;
using System.Threading.Tasks;


namespace GamejoltAPI.Trophies
{
    public class GJTrophies
    {
        private string gameId;
        private string username;
        private string userToken;
        private string privateKey;

        public GJTrophies(GJCore core, GJUser user)
        {
            gameId = user.GameID;
            username = user.Username;
            userToken = user.Token;
            privateKey = core.PrivateKey;
        }

        public async Task<string> Fetch(bool achieved, string trophyId)
        {
            var cmd = achieved ? $"trophies/?game_id={gameId}&username={username}&user_token={userToken}&archivied={achieved}" :
                                 $"trophies/?game_id={gameId}&username={username}&user_token={userToken}";

            if (!string.IsNullOrEmpty(trophyId))
                cmd = $"trophies/?game_id={gameId}&username={username}&user_token={userToken}&trophy_id={trophyId}";
            else
                cmd = $"trophies/?game_id={gameId}&username={username}&user_token={userToken}";

            var str = cmd + privateKey;
            var response = await Tools.Get(GJCore.APIUrl + cmd + "&signature=" + str.ToMD5Hash());
            return response;
        }

        public async Task<string> Add(string trophyId)
        {
            var cmd = $"trophies/add-achivied/?game_id={gameId}&username={username}&user_token={userToken}&trophy_id={trophyId}";
            var str = GJCore.APIUrl + cmd + privateKey;
            var response = await Tools.Get(GJCore.APIUrl + cmd + "&signature=" + str.ToMD5Hash());
            return response;
        }

        public async Task<string> Remove(string trophy_id)
        {
            var cmd = $"trophies/remove-achieved/?game_id={gameId}&username={username}&user_token={userToken}&trophy_id={trophy_id}";
            var str = GJCore.APIUrl + cmd + privateKey;
            string response = await Tools.Get(GJCore.APIUrl + cmd + "&signature=" + str.ToMD5Hash());
            return response;
        }
    }
}
