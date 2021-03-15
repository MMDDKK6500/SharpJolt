using GamejoltAPI.Core;
using System.Threading.Tasks;


namespace GamejoltAPI.Users
{
    public class GJUser
    {
        public string username;
        public string user_token;
        public string game_id;
        public string private_key;
        public string apiurl;

        public GJUser(GJCore GJCore, string user_name, string usertoken)
        {
            username = user_name;
            user_token = usertoken;
            game_id = GJCore.game_id;
            private_key = GJCore.private_key;
            apiurl = GJCore.apiurl;
        }
        
        public async Task<string> Auth()
        {
            string cmd = "users/auth/?game_id=" + game_id + "&username=" + username + "&user_token=" + user_token;
            string fhash = Tools.MD5Hash(apiurl + cmd + private_key);
            string res = await Tools.Get(apiurl + cmd + "&signature=" + fhash);
            return res;
        }


        public async Task<string> Fetch(int user_id)
        {
            string cmd = "users/?game_id=" + game_id + "&username=" + username + "&user_id=" + user_id;
            string fhash = Tools.MD5Hash(apiurl + cmd + private_key);
            string res = await Tools.Get(apiurl + cmd + "&signature=" + fhash);
            return res;
        }

    }
}
