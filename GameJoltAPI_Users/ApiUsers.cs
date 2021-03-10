using gamejoltapiCore;
using System.Threading.Tasks;


namespace gamejoltapiUsers
{
    public class GJUser
    {
        public string username;
        public string user_token;
        public string game_id;
        public string private_key;

        public GJUser(GJCore GJCore, string user_name, string usertoken)
        {
            username = user_name;
            user_token = usertoken;
            game_id = GJCore.game_id;
            private_key = GJCore.private_key;
        }
        
        public async Task<string> authUser()
        {
            string apiurl = "https://api.gamejolt.com/api/game/v1_2/";
            string cmd = "users/?game_id=" + game_id + "&username=" + username + "&user_token=" + user_token;
            string fhash = Tools.MD5Hash(apiurl + cmd);
            string res = await Tools.Get(apiurl + cmd + "&signature=" + fhash);
            return res;
        }

    }
}
