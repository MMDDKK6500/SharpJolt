using GamejoltAPI.Core;
using System.Threading.Tasks;


namespace GamejoltAPI.Users
{
    public class GJUser
    {
        private string username;
        private string userToken;
        private string gameId;
        private string privateKey;

        public string Username
        {
            get => username;
        }

        public string GameID
        {
            get => gameId;
        }

        public string Token
        {
            get => userToken;
        }

        public GJUser(GJCore core, string username, string userToken)
        {
            this.username = username;
            this.userToken = userToken;
            gameId = core.GameID;
            privateKey = core.PrivateKey;
        }

        public async Task<string> Auth()
        {
            var cmd = "users/auth/?game_id=" + gameId + "&username=" + username + "&user_token=" + userToken;
            var str = GJCore.APIUrl + cmd + privateKey;
            var res = await Tools.Get(GJCore.APIUrl + cmd + "&signature=" + str.ToMD5Hash());
            return res;
        }


        public async Task<string> Fetch(int user_id)
        {
            string cmd = "users/?game_id=" + gameId + "&username=" + username + "&user_id=" + user_id;
            var str = GJCore.APIUrl + cmd + privateKey;
            string res = await Tools.Get(GJCore.APIUrl + cmd + "&signature=" + str.ToMD5Hash());
            return res;
        }

    }
}
