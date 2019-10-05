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
        public static async Task GetSongDataAsync(SongModel song)
        {
            string songName = song.MediaFile.getItemInfo("Title");
            string artistName = song.MediaFile.getItemInfo("Artist");
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

          //          content = "{\"result\":[{\"song\":\"You Are My Treasure\",\"song-link\":\"https:\\/\\/www.lyrics.com\\/lyric\\/1028226\",\"artist\":\"Jack Greene\",\"artist-link\":\"https:\\/\\/www.lyrics.com\\/artist\\/page\\/1634\",\"album\":\"Sings His Best\",\"album-link\":\"https:\\/\\/www.lyrics.com\\/album\\/92452\"},{\"song\":\"You Are My Treasure\",\"song-link\":\"https:\\/\\/www.lyrics.com\\/lyric\\/1213343\",\"artist\":\"Jack Greene\",\"artist-link\":\"https:\\/\\/www.lyrics.com\\/artist\\/page\\/1634\",\"album\":\"Greatest Hits [Gusto]\",\"album-link\":\"https:\\/\\/www.lyrics.com\\/album\\/92451\"},{\"song\":\"You Are My Treasure\",\"song-link\":\"https:\\/\\/www.lyrics.com\\/lyric\\/2286202\",\"artist\":\"Jack Greene\",\"artist-link\":\"https:\\/\\/www.lyrics.com\\/artist\\/page\\/1634\",\"album\":\"Jolly Green Giant\",\"album-link\":\"https:\\/\\/www.lyrics.com\\/album\\/256589\"},{\"song\":\"You Are My Treasure\",\"song-link\":\"https:\\/\\/www.lyrics.com\\/lyric\\/4549010\",\"artist\":\"Jack Greene\",\"artist-link\":\"https:\\/\\/www.lyrics.com\\/artist\\/page\\/1634\",\"album\":\"Best of the Best [CD\\/Cassette Single]\",\"album-link\":\"https:\\/\\/www.lyrics.com\\/album\\/477513\"},{\"song\":\"You Are My Treasure\",\"song-link\":\"https:\\/\\/www.lyrics.com\\/lyric\\/5944264\",\"artist\":\"Jack Greene\",\"artist-link\":\"https:\\/\\/www.lyrics.com\\/artist\\/page\\/1634\",\"album\":\"You Are My Treasure\",\"album-link\":\"https:\\/\\/www.lyrics.com\\/album\\/575718\"},{\"song\":\"You Are My Treasure\",\"song-link\":\"https:\\/\\/www.lyrics.com\\/lyric\\/5944351\",\"artist\":\"Jack Greene\",\"artist-link\":\"https:\\/\\/www.lyrics.com\\/artist\\/page\\/1634\",\"album\":\"Jack Greene's Greatest Hits\",\"album-link\":\"https:\\/\\/www.lyrics.com\\/album\\/575730\"},{\"song\":\"You Are My Treasure\",\"song-link\":\"https:\\/\\/www.lyrics.com\\/lyric\\/6124155\",\"artist\":\"Blessed Hope Chapel Praise Team\",\"artist-link\":\"https:\\/\\/www.lyrics.com\\/artist\\/page\\/572537\",\"album\":\"Enter In: Live Worship at Blessed Hope Chapel\",\"album-link\":\"https:\\/\\/www.lyrics.com\\/album\\/630584\"},{\"song\":\"You Are My Treasure\",\"song-link\":\"https:\\/\\/www.lyrics.com\\/lyric\\/6381761\",\"artist\":\"Jack Greene\",\"artist-link\":\"https:\\/\\/www.lyrics.com\\/artist\\/page\\/1634\",\"album\":\"20 All Time Greatest Hits\",\"album-link\":\"https:\\/\\/www.lyrics.com\\/album\\/646621\"},{\"song\":\"You Are My Treasure\",\"song-link\":\"https:\\/\\/www.lyrics.com\\/lyric\\/7655251\",\"artist\":\"Jack Greene\",\"artist-link\":\"https:\\/\\/www.lyrics.com\\/artist\\/page\\/1634\",\"album\":\"The Best of Jack Greene : Statue of a Fool\",\"album-link\":\"https:\\/\\/www.lyrics.com\\/album\\/735709\"},{\"song\":\"You Are My Treasure\",\"song-link\":\"https:\\/\\/www.lyrics.com\\/lyric\\/15046623\",\"artist\":\"Chris Tomlin\",\"artist-link\":\"https:\\/\\/www.lyrics.com\\/artist\\/page\\/460622\",\"album\":\"Authentic\",\"album-link\":\"https:\\/\\/www.lyrics.com\\/album\\/1450780\"},{\"song\":\"You Are My Treasure\",\"song-link\":\"https:\\/\\/www.lyrics.com\\/lyric\\/15521249\",\"artist\":\"Jack Greene\",\"artist-link\":\"https:\\/\\/www.lyrics.com\\/artist\\/page\\/1634\",\"album\":\"Best of the Best of Jack Greene\",\"album-link\":\"https:\\/\\/www.lyrics.com\\/album\\/1383152\"},{\"song\":\"You Are My Treasure\",\"song-link\":\"https:\\/\\/www.lyrics.com\\/lyric\\/24012752\",\"artist\":\"Matt Hammitt\",\"artist-link\":\"https:\\/\\/www.lyrics.com\\/artist\\/page\\/556484\",\"album\":\"Every Falling Tear\",\"album-link\":\"https:\\/\\/www.lyrics.com\\/album\\/2231963\"},{\"song\":\"You Are My Treasure\",\"song-link\":\"https:\\/\\/www.lyrics.com\\/lyric\\/30790679\",\"artist\":\"Kenny Rogers\",\"artist-link\":\"https:\\/\\/www.lyrics.com\\/artist\\/page\\/93355\",\"album\":\"Les Plus Grands Tubes: Country\",\"album-link\":\"https:\\/\\/www.lyrics.com\\/album\\/2916466\"},{\"song\":\"You Are My Treasure\",\"song-link\":\"https:\\/\\/www.lyrics.com\\/lyric\\/35521158\",\"artist\":\"Matt Hammitt\",\"artist-link\":\"https:\\/\\/www.lyrics.com\\/artist\\/page\\/556484\",\"album\":\"Every Falling Tear\",\"album-link\":\"https:\\/\\/www.lyrics.com\\/album\\/3729592\"},{\"song\":\"You Are My Treasure\",\"song-link\":\"https:\\/\\/www.lyrics.com\\/lyric\\/35681896\",\"artist\":\"Jack Greene\",\"artist-link\":\"https:\\/\\/www.lyrics.com\\/artist\\/page\\/1634\",\"album\":\"The Very Best of Jack Greene\",\"album-link\":\"https:\\/\\/www.lyrics.com\\/album\\/3747878\"}]}";


                    JObject songData = JObject.Parse(content); // create JObject from string
                    JArray songArray = (JArray)songData["result"]; // parse object to an array of songs

                    if ((songArray != null) && (songArray.SelectTokens("$.[?(@.artist== '" + artistName + "')]").FirstOrDefault() != null))
                    {
                        JToken srchItem = songArray.SelectTokens("$.[?(@.artist== '" + artistName + "')]").FirstOrDefault(); // get first instance of song with name artist anme as media file
                        song.SongLink = srchItem.Value<string>("song-link");
                        song.ArtistLink = srchItem.Value<string>("artist-link");
                        song.AlbumLink = srchItem.Value<string>("album-link");
                    }
                    else
                    {
                        song.AlbumLink = null;
                        song.SongLink = null;
                        song.ArtistLink = null;
                    }
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

        }
    }

    

    

}





