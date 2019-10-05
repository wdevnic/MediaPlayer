using AxWMPLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace Media_Player
{
    /// <summary>
    /// Constains variour helper methods needed to manipulated song list
    /// </summary>
    public class MediaPlayerHelper
    {
        /// <summary>
        /// Processes Playlist Changes
        /// </summary>
        /// <param name="files">lists of audio file paths</param>
        /// <param name="songs">List of songs</param>
        /// <param name="playlistListBox">Playlist listbox</param>
        /// <param name="MediaPlayer">Media Player</param>
        /// <returns>list of song objects</returns>
        public static List<SongModel> ProcessPlaylistChanges(string[] files, List<SongModel> songs, ListBox playlistListBox, AxWindowsMediaPlayer MediaPlayer)
        {
            List<SongModel> songList = new List<SongModel>();

            if ((songs == null) || (!songs.Any())) //list is null or empty
            {
                songs = UpdatePlaylist(files, playlistListBox, MediaPlayer); // sets up new playlist
            }
            else
            {
                List<SongModel> songsTemp = new List<SongModel>(); // create temp playlist
                songsTemp = UpdatePlaylist(files, playlistListBox, MediaPlayer);  // sets up new playist
                songs = songs.Concat(songsTemp).ToList(); // adds new playlist to existing playlist
            }
            
            return songs;
        }

        /// <summary>
        /// Updates playlist changes
        /// </summary>
        /// <param name="files">lists of audio file paths</param>
        /// <param name="playListBox">Playlist listbox</param>
        /// <param name="MediaPlayer">Media Player</param>
        /// <returns>Updated list of song objects</returns>
        public static List<SongModel> UpdatePlaylist(string[] files, ListBox playListBox, AxWindowsMediaPlayer MediaPlayer)
        {
            List<SongModel> updatedSongs = new List<SongModel>();

            foreach (string file in files) // gets file paths
            {
                IWMPMedia mediaItem = MediaPlayer.newMedia((file)); // creates media files                                                                  
                SongModel song = new SongModel(mediaItem);
              
                MediaPlayer.currentPlaylist.appendItem(song.MediaFile); //  player.PlayStateChange 
                playListBox.Items.Add(song.MediaFile.getItemInfo("Title"));
                updatedSongs.Add(song);
            }

            return updatedSongs;
        }

        /// <summary>
        /// Retrieves song data from the API
        /// </summary>
        /// <param name="songs">list of song objects</param>
        public async static Task PopulateLyricsData(List<SongModel> songs)
        {
            foreach(SongModel song in songs)
            {
                await LyricsProcessor.GetSongDataAsync(song); // use title and artist to get song data
            }
        }

        /// <summary>
        /// Finds song media in list based on name
        /// </summary>
        /// <param name="title">Song title</param>
        /// <param name="songs">list of song objects</param>
        /// <returns>song object</returns>
        public static SongModel GetSelectedSong(string title, List<SongModel> songs)
        {
            SongModel song = songs.Where(s => s.MediaFile.getItemInfo("Title") == title).ToList().First(); // select media file that has the same name
            return song;
        }

        /// <summary>
        /// Sets up Library
        /// </summary>
        /// <param name="libraryListBox">library listbox</param>
        /// <param name="player">Media Player</param>
        /// <returns>playlist array</returns>
        public static IWMPPlaylistArray SetupLibrary(ListBox libraryListBox, AxWindowsMediaPlayer player)
        {
            IWMPPlaylistArray playlists = player.playlistCollection.getAll();
            
            for (int i = 0; i < playlists.count; i++)
            {
                try
                {
                    if (playlists.Item(i) != null && playlists.Item(i).getItemInfo("PlaylistType") == "wpl") // retrives playlist
                    {
                        libraryListBox.Items.Add(playlists.Item(i).name);
                    }
                }
                catch (System.IO.FileNotFoundException)  
                {
                    // skip playlists that have been deleted
                }
            }

            return playlists;
        }

        /// <summary>
        /// Zooms webpage
        /// </summary>
        /// <param name="webBrowserLyrics">Web browser used to display lyrics</param>
        public static void BrowserZoom(WebBrowser webBrowserLyrics)
        {
            HtmlElement top = webBrowserLyrics.Document.GetElementById("content-top");
            top.Style = "zoom:85%";
            HtmlElement main = webBrowserLyrics.Document.GetElementById("content-main");
            main.Style = "zoom:65%";
            HtmlElement aside = webBrowserLyrics.Document.GetElementById("content-aside");
            aside.Style = "zoom:55%";
            HtmlElement footer = webBrowserLyrics.Document.GetElementById("footer");
            footer.Style = "zoom:30%";

        }

        /// <summary>
        /// Playd plsy list from library
        /// </summary>
        /// <param name="mediaPlayer">Media Player</param>
        /// <param name="libraryListBox">library list box</param>
        /// <param name="playListLabel">playlist title label</param>
        /// <returns></returns>
        public static string[] PlayLibraryList(AxWindowsMediaPlayer mediaPlayer, ListBox libraryListBox, Label playListLabel)
        {           
            IWMPPlaylist playlistToPlay = mediaPlayer.playlistCollection.getByName(libraryListBox.GetItemText(libraryListBox.SelectedItem)).Item(0); // get selected library
            string[] filePaths = new string[playlistToPlay.count];

            // get file paths for media files
            for (int j = 0; j < playlistToPlay.count; j++)
            {
                filePaths[j] = playlistToPlay.Item[j].sourceURL;
            }

            playListLabel.Text = playlistToPlay.name;

            return filePaths;
            
        }

        /// <summary>
        /// Checks for song object for valid URL
        /// </summary>
        /// <param name="song">song object</param>
        /// <param name="webBrowserLyrics">lyrics web browser</param>
        /// <returns>bool</returns>
        public static bool CheckURL(SongModel song, WebBrowser webBrowserLyrics)
        {
            bool defaultURL = true;

           
            if (!string.IsNullOrEmpty(song.SongLink)) // checks if song has lyrics data
            {
                defaultURL = false; //will use default lyrics page flag
                webBrowserLyrics.Navigate(new Uri(song.SongLink)); // browser goes to lyrics page
            
            }
            else
            {
                defaultURL = true; // will use default lyrics page ie "No Lyrics found"
                string html = Properties.Resources.DefaultPage; // gets html from default page in resources
                webBrowserLyrics.DocumentText = html;          // display html in browser
            }
            
            return defaultURL;
        }

    }
       
}
