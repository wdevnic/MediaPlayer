using System;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using WMPLib;

namespace Media_Player
{
    
    public class LyricsProcessor
    {
      
        public static async Task<SongModel> GetSongDataAsync(string songName, string artistName, IWMPMedia mediaFile)
        {
            string url = "";
            

            if (songName != null)
            {
                url = $"http://www.stands4.com/services/v2/lyrics.php?uid=7164&tokenid=ducwjAIOYkJO4Trn&term={songName}&format=json";
            }

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    
                    string content = await response.Content.ReadAsStringAsync();

                    JObject songData = JObject.Parse(content);
                    JArray songArray = (JArray)songData["result"];
                    var srchItem = songArray.SelectTokens("$.[?(@.artist== '" + artistName + "')]").First();

                    SongModel song = srchItem.ToObject<SongModel>();
                    song.MediaFile = mediaFile;


                    return song;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

        }
    }

    

    

}





