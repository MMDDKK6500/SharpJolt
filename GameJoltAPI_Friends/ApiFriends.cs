using System;
using GamejoltAPI.Core;
using GamejoltAPI.Users;
using System.Threading.Tasks;

namespace GamejoltAPI.Friends
{
    public class GJFriends
    {

        public string username;
        public string user_token;
        public string game_id;
        public string private_key;
        public string apiurl;

        public GJFriends(GJCore GJCore, GJUser GJuser)
        {
            username = GJuser.username;
            user_token = GJuser.user_token;
            game_id = GJCore.game_id;
            private_key = GJCore.private_key;
            apiurl = GJCore.apiurl;
        }

        public async Task<string> GetFriends()
        {
            string cmd = "friends/?game_id=" + game_id + "&username=" + username + "&user_token=" + user_token;
            string fhash = Tools.MD5Hash(apiurl + cmd + private_key);
            string response = await Tools.Get(apiurl + cmd + "&signature=" + fhash);
            return response;
        }

    }
}
