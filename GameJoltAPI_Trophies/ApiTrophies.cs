using gamejoltapiCore;
using gamejoltapiUsers;
using System.Threading.Tasks;

namespace gamejoltapiTrophies
{
    public class GJTrophies
    {
        public string table_id;
        public string game_id;
        public string username;
        public string user_token;
        public string private_key;

        public GJTrophies(GJCore GJCore, GJUser GJUser, string tableid)
        {
            //make table id and game_id publics
            table_id = tableid;
            game_id = GJCore.game_id;
            username = GJUser.username;
            user_token = GJUser.user_token;
            private_key = GJCore.private_key;
        }

        public async Task<string> Fetch(bool achieved, string trophy_id)
        {
            string cmd;
            string apiurl = "https://api.gamejolt.com/api/game/v1_2/";
            //check if any of the non-required parameters are inputed
            if (achieved)
            {
                cmd = "trophies/?game_id=" + game_id + "&username=" + username + "&user_token=" + user_token + "&achieved=" + achieved;
            }

            if (trophy_id!=null)
            {
                cmd = "trophies/?game_id=" + game_id + "&username=" + username + "&user_token=" + user_token + "&trophy_id" + trophy_id;
            }
            //if not, then set the default command
            cmd = "trophies/?game_id=" + game_id + "&username=" + username + "&user_token=" + user_token;
            //get signature(signature is the MD5 hash of everything + private_key)
            string fhash = Tools.MD5Hash(cmd + private_key);
            //get actual response(with signature)
            string response  = await Tools.Get(apiurl + cmd + "&signature=" + fhash);
            //return response
            return response;
        }
    }
}
