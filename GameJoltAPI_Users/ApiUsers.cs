using gamejoltapiCore;

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



    }
}
