using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Net.Http;
using Newtonsoft.Json;
using WMPLib;

public  class SongModel
{
    //   public string Song { get; set; }

    

    [JsonProperty("song-link")]
    public string SongLink { get; set; }

//    public string Artist { get; set; }

    [JsonProperty("artist-link")]
    public string ArtistLink { get; set; }

//    public string Album { get; set; }

    [JsonProperty("album-link")]
    public string AlbumLink { get; set; }


    public IWMPMedia MediaFile { get; set; }

}
