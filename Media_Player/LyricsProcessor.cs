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
      /// <summary>
      /// Populate songmodel fields using API
      /// </summary>
      /// <param name="songName">Name of the song</param>
      /// <param name="artistName">Artist name for the song</param>
      /// <param name="mediaFile">Media file for the song</param>
      /// <returns>songmodel object</returns>
        public static async Task<SongModel> GetSongDataAsync(string songName, string artistName, IWMPMedia mediaFile)
        {
            string url = "";
            

            if (songName != null) 
            {
                url = $"http://www.stands4.com/services/v2/lyrics.php?uid=7164&tokenid=ducwjAIOYkJO4Trn&term={songName}&format=json"; // concatonate song name into Rest API call url string
            }

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url)) // make call to API
            {
                if (response.IsSuccessStatusCode)
                {
                    
                    string content = await response.Content.ReadAsStringAsync(); // strong response string
                    SongModel song = new SongModel(); 

                    JObject songData = JObject.Parse(content); // create JObject from string
                    JArray songArray = (JArray)songData["result"]; // parse object to an array of songs

                    try
                    {
                        JToken srchItem = songArray.SelectTokens("$.[?(@.artist== '" + artistName + "')]").First(); // get first instance of song with name artist anme as media file
                        song = srchItem.ToObject<SongModel>(); // parse JToken to SongModel Object
                    }
                    catch (Exception e) // if song not found or there is an issue then populate fields with NA
                    {
                        song.AlbumLink = "NA";                        
                        song.SongLink = "NA";
                        song.ArtistLink = "NA";
                    }
                   
                    song.MediaFile = mediaFile; //set songmodel object media file property


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





