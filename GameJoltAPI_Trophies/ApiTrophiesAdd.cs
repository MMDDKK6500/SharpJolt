using gamejoltapiCore;
using gamejoltapiUsers;
using System.Threading.Tasks;


namespace gamejoltapiTrophies
{
    public class GJTrophies
    {
        public string game_id;
        public string username;
        public string user_token;
        public string private_key;

        public void GJTrophiesAdd(GJCore GJCore, GJUser GJUser)
        {

            //make table id and game_id publics
            game_id = GJCore.game_id;
            username = GJUser.username;
            user_token = GJUser.user_token;
            private_key = GJCore.private_key;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sucess"></param>
        /// <param name="trophy_id"></param>
        /// <returns></returns>
        public async Task<string> AddAchieved(bool sucess, string trophy_id)
        {
            string apiurl = "https://api.gamejolt.com/api/game/v1_2/";
            string cmd = "trophies/" + "add-achieved/" + "?game_id=" + game_id;


        }
    }
}
