using GameJoltAPI.Core;
using GameJoltAPI.Users;
using System.Threading.Tasks;

namespace GamejoltAPI.Friends
{
    public class GJFriends
    {
        private string username;
        private string userToken;
        private string gameId;
        private string privateKey;

        public GJFriends(GJCore core, GJUser user)
        {
            username = user.Username;
            userToken = user.Token;
            gameId = core.GameID;
            privateKey = core.PrivateKey;
        }

        public async Task<string> GetFriends()
        {
            string cmd = "friends/?game_id=" + gameId + "&username=" + username + "&user_token=" + userToken;
            var str = GJCore.APIUrl + cmd + privateKey;
            string response = await Tools.Get(GJCore.APIUrl + cmd + "&signature=" + str.ToMD5Hash());
            return response;
        }
    }
}
