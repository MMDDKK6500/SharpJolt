using GameJoltAPI.Core;
using GameJoltAPI.Users;
using System.Threading.Tasks;

namespace GamejoltAPI.Sessions
{
    public class GJSession
    {
        private string gameId;
        private string username;
        private string userToken;
        private string privateKey;

        public GJSession(GJCore core, GJUser user)
        {
            gameId = user.GameID;
            username = user.Username;
            userToken = user.Token;
            privateKey = core.PrivateKey;
        }

        public async Task<string> Open()
        {
            var cmd = "sessions/open/?game_id=" + gameId + "&username=" + username + "&user_token=" + userToken;
            var str = GJCore.APIUrl + cmd + privateKey;
            var response = await Tools.Get(GJCore.APIUrl + cmd + "&signature=" + str.ToMD5Hash());
            return response;
        }

        public async Task<string> Ping(string status)
        {
            var cmd = "sessions/ping/?game_id=" + gameId + "&username=" + username + "&user_token=" + userToken + "&status" + status;
            var str = GJCore.APIUrl + cmd + privateKey;
            var response = await Tools.Get(GJCore.APIUrl + cmd + "&signature=" + str.ToMD5Hash());
            return response;
        }

        public async Task<string> Check()
        {
            var cmd = "sessions/check/?game_id=" + gameId + "&username=" + username + "&user_token=" + userToken;
            var str = GJCore.APIUrl + cmd + privateKey;
            var response = await Tools.Get(GJCore.APIUrl + cmd + "&signature=" + str.ToMD5Hash());
            return response;
        }

        public async Task<string> Close()
        {
            var cmd = "sessions/close/?game_id=" + gameId + "&username=" + username + "&user_token=" + userToken;
            var str = GJCore.APIUrl + cmd + privateKey;
            var response = await Tools.Get(GJCore.APIUrl + cmd + "&signature=" + str.ToMD5Hash());
            return response;
        }
    }
}
