using Newtonsoft.Json;
using WMPLib;

public  class SongModel
{
    public SongModel()
    {        
    }

    public SongModel(IWMPMedia mediaFile)
    {
        MediaFile = mediaFile;
    }

    [JsonProperty("song-link")]
    public string SongLink { get; set; }

    [JsonProperty("artist-link")]
    public string ArtistLink { get; set; }

    [JsonProperty("album-link")]
    public string AlbumLink { get; set; }

    public IWMPMedia MediaFile { get; set; }
}
