using System;
using gamejoltapiCore;
using gamejoltapiUsers;

namespace gamejoltapiSessions
{
    public class GJSession
    {
        public string game_id;
        public string username;
        public string user_token;
        public string private_key;
        public string apiurl;

        public GJSession(GJCore GJCore, GJUser GJUser)
        {
            //make table id and game_id publics
            game_id = GJUser.game_id;
            username = GJUser.username;
            user_token = GJUser.user_token;
            private_key = GJCore.private_key;
            apiurl = GJCore.apiurl;
        }
    }
}
