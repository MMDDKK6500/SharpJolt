using System.Threading.Tasks;
using GamejoltAPI.Core;
using GamejoltAPI.Users;

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

        /*
        public async Task<string> Fetch()
        {
            // TO-DO!
            throw new System.NotImplementedException();
        }
        */
    }
}
