using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
using System.Linq;
using AxWMPLib;


namespace Media_Player
{
    public partial class MainForm : Form
    {
        OpenFileDialog open = new OpenFileDialog();
        IWMPPlaylist playlist;
        List<SongModel> songs = new List<SongModel>();
        bool defaultPage = false;

        public MainForm()
        {
            InitializeComponent();
            ApiHelper.InitializeClient(); // initalize http client
        }

        //File > Open menu option
        private async void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            open.Filter = "Music| *.mp3"; 
            open.Multiselect = true; 

            if (open.ShowDialog() == DialogResult.OK)
            {
                if((songs != null) && (!songs.Any())) //list is null or empty
                {
                    songs = await SetupCurrentPlaylist(open.FileNames, playlistListBox, MediaPlayer); // sets up new playlist
                }
                else
                {
                    List<SongModel> songsTemp = new List<SongModel>(); // create temp playlist
                    songsTemp = await SetupCurrentPlaylist(open.FileNames, playlistListBox, MediaPlayer);  // sets up new playist
                    songs = songs.Concat(songsTemp).ToList(); // adds new playlist to existing playlist
                }               
            }
            playlistListBox.SelectedIndex = 0; // start from the first song in list *
            MediaPlayer.Ctlcontrols.play();
            webBrowserLyrics.AllowNavigation = false; 
        }

        //gets SongModel object by title name
        private SongModel getSelectedSong(string title, List<SongModel> songs)
        {
            SongModel song = songs.Where(s => s.MediaFile.getItemInfo("Title") == title).ToList().First(); // select media file that has the same name
            return song;
        }

        // creates SongModel object
        private async Task<SongModel> getSongData(IWMPMedia mediaFile)
        {
            //reach out to API to get song data, lyrics based on properties from media file
            SongModel song = await LyricsProcessor.GetSongDataAsync(mediaFile.getItemInfo("Title"), mediaFile.getItemInfo("Artist"), mediaFile); // use title and artist to get song data
            return song; 
        }

        // resizes browser if lyrics page found
        private void webBrowserLyrics_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (!defaultPage)
            {
                HtmlElement top = webBrowserLyrics.Document.GetElementById("content-top");
                top.Style = "zoom:85%";
                HtmlElement main = webBrowserLyrics.Document.GetElementById("content-main");
                main.Style = "zoom:65%";
                HtmlElement aside = webBrowserLyrics.Document.GetElementById("content-aside");
                aside.Style = "zoom:55%";
                HtmlElement footer = webBrowserLyrics.Document.GetElementById("footer");
                footer.Style = "zoom:30%";
                webBrowserLyrics.AllowNavigation = false;
            }

        }

        // credit link to API site
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel.LinkVisited = true;
            System.Diagnostics.Process.Start("http://www.lyrics.com");
        }

        // close Media player
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MediaPlayer.close();
        }

        // exit media player
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // handles selection changes in playlist
        private void playlistListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //gets the song selected in playlist
            string currentTitle = playlistListBox.SelectedItem.ToString();
            SongModel song = getSelectedSong(currentTitle, songs);
            webBrowserLyrics.AllowNavigation = true;

            if(song.SongLink != "NA") // checks if song has lyrics data
            {
                defaultPage = false; //will use default lyrics page flag
                webBrowserLyrics.Navigate(new Uri(song.SongLink)); // browser goes to lyrics page
            }
            else
            {
                defaultPage = true; // will use default lyrics page ie "No Lyrics found"
                string html = Properties.Resources.DefaultPage; // gets html from default page in resources
                webBrowserLyrics.DocumentText = html;          // display html in browser
            }
           
        }

        // saves playlist
        private void savePlaylistToolStripMenuItem_Click(object sender, EventArgs e)
        {

            SavePlaylistForm saveForm = new SavePlaylistForm(); // launches save form
            saveForm.StartPosition = FormStartPosition.CenterParent;
            saveForm.ShowDialog();

            if(saveForm.DialogResult == DialogResult.OK) 
            {
                // saves current playlist 
                playlist = MediaPlayer.currentPlaylist;
                playlist.name = saveForm.PlaylistName;
                playListLabel.Text = saveForm.PlaylistName; // get playlist name
                MediaPlayer.playlistCollection.importPlaylist(playlist); // adds playlist to library

                //refresh library
                libraryListBox.Items.Clear(); 
                SetupLibrary(libraryListBox, MediaPlayer);  
            }
          
        }

        //sets up playlist
        public async Task<List<SongModel>> SetupCurrentPlaylist(string[] files, ListBox playList,  AxWindowsMediaPlayer player)
        {
            List<SongModel> tempSongs = new List<SongModel>();

            foreach (string file in files) // gets file paths
            {
                
                IWMPMedia mediaItem = MediaPlayer.newMedia((file)); // creates media files
                SongModel song = await getSongData(mediaItem); 


                player.currentPlaylist.appendItem(song.MediaFile); //  player.PlayStateChange 

                playList.Items.Add(song.MediaFile.getItemInfo("Title"));
                tempSongs.Add(song);
              

                
            }

            return tempSongs;
        }

        // axWindowsMediaPlayer
        public IWMPPlaylistArray SetupLibrary(ListBox libraryListBox, AxWindowsMediaPlayer player)
        {
            IWMPPlaylistArray playlists = MediaPlayer.playlistCollection.getAll();

            for(int i = 0; i< playlists.count; i++)
            {
                if (playlists.Item(i) != null && playlists.Item(i).getItemInfo("PlaylistType") == "wpl")
                {                
                    libraryListBox.Items.Add(playlists.Item(i).name);
                }                
            }

            return playlists;
        }

       // _WMPOCXEvents_PlayStateChangeEvent
        private void mediaPlayer_PlayStateChange(object sender, _WMPOCXEvents_PlayStateChangeEvent e)
        {
            AxWindowsMediaPlayer t = sender as AxWindowsMediaPlayer;  

            if ((MediaPlayer.currentMedia != null) && (t.playState != WMPPlayState.wmppsTransitioning)) // checks that current media is valid and ensures that media is not transitioning before it switches to next item
            {
                playlistListBox.SelectedIndex = playlistListBox.FindStringExact(MediaPlayer.currentMedia.getItemInfo("Title")); // play media with same name as the playlist item selected
            }
        }


        private void playlistListBox_Click(object sender, EventArgs e)
        {
            MediaPlayer.Ctlcontrols.playItem(MediaPlayer.currentPlaylist.Item[playlistListBox.SelectedIndex]); // play media that has the same name as the list box item selected
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            SetupLibrary(libraryListBox, MediaPlayer); // setup playlist on load
        }

        private void deletePlaylistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IWMPPlaylist playlistForDeletion = MediaPlayer.playlistCollection.getByName(libraryListBox.GetItemText(libraryListBox.SelectedItem)).Item(0); // find playlist for deletion
            MediaPlayer.playlistCollection.remove(playlistForDeletion); // delete selected playlist

            MediaPlayer.close(); 
            MediaPlayer.currentPlaylist.clear();
            libraryListBox.Items.Clear();
            playlistListBox.Items.Clear();
            playListLabel.Text = "Unsaved Playlist";
            IWMPPlaylistArray allPlaylists = SetupLibrary(libraryListBox, MediaPlayer); // refresh libarary
        }

        private async void libraryListBox_Click(object sender, EventArgs e)
        {
            
            IWMPPlaylist playlistToPlay = MediaPlayer.playlistCollection.getByName(libraryListBox.GetItemText(libraryListBox.SelectedItem)).Item(0); // get selected library
            MediaPlayer.close();
            playlistListBox.Items.Clear();
            MediaPlayer.currentPlaylist.clear();

            
            string[] filez = new string[playlistToPlay.count];

            // get file paths for media files
            for (int j = 0; j < playlistToPlay.count; j++)
            {

                filez[j] = playlistToPlay.Item[j].sourceURL;

            }
            songs = await SetupCurrentPlaylist(filez, playlistListBox, MediaPlayer); // setup playlist
            playListLabel.Text = playlistToPlay.name; // update playlist name
            MediaPlayer.Ctlcontrols.play(); // play playlist
        }
    }
}
