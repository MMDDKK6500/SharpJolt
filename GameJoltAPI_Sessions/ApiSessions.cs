using System;
using GamejoltAPI.Core;
using GamejoltAPI.Users;
using System.Threading.Tasks;

namespace GamejoltAPI.Sessions
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

        public async Task<string> Open()
        {
            string cmd = "sessions/open/?game_id=" + game_id + "&username=" + username + "&user_token=" + user_token;
            string fhash = Tools.MD5Hash(apiurl + cmd + private_key);
            string response = await Tools.Get(apiurl + cmd + "&signature=" + fhash);
            return response;
        }

        public async Task<string> Ping(string status)
        {
            string cmd = "sessions/ping/?game_id=" + game_id + "&username=" + username + "&user_token=" + user_token + "&status" + status;
            string fhash = Tools.MD5Hash(apiurl + cmd + private_key);
            string response = await Tools.Get(apiurl + cmd + "&signature=" + fhash);
            return response;
        }

        public async Task<string> Check()
        {
            string cmd = "sessions/check/?game_id=" + game_id + "&username=" + username + "&user_token=" + user_token;
            string fhash = Tools.MD5Hash(apiurl + cmd + private_key);
            string response = await Tools.Get(apiurl + cmd + "&signature=" + fhash);
            return response;
        }

        public async Task<string> Close()
        {
            string cmd = "sessions/close/?game_id=" + game_id + "&username=" + username + "&user_token=" + user_token;
            string fhash = Tools.MD5Hash(apiurl + cmd + private_key);
            string response = await Tools.Get(apiurl + cmd + "&signature=" + fhash);
            return response;
        }

    }
}
