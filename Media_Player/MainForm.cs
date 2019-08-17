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

        public MainForm()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();
        }

        private async void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            open.Filter = "Music| *.mp3";
            open.Multiselect = true;

            if (open.ShowDialog() == DialogResult.OK)
            {
               songs  = await SetupCurrentPlaylist(open.FileNames, playlistListBox, MediaPlayer);
               
            }
            playlistListBox.SelectedIndex = 0;
            MediaPlayer.Ctlcontrols.play();
            webBrowserLyrics.AllowNavigation = false;
        }

        private SongModel getLyrics(string title, List<SongModel> songs)
        {
            SongModel song = songs.Where(s => s.MediaFile.getItemInfo("Title") == title).ToList().First();
            string lyricsLink = song.SongLink;
            return song;
        }

        private async Task<SongModel> GetLyricData(IWMPMedia mediaFile)
        {            
            SongModel songData = await LyricsProcessor.GetSongDataAsync(mediaFile.getItemInfo("Title"), mediaFile.getItemInfo("Artist"), mediaFile);
            return songData;
        }


        private void webBrowserLyrics_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
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

      
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel.LinkVisited = true;
            System.Diagnostics.Process.Start("http://www.lyrics.com");
        }


        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MediaPlayer.close();
        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void playlistListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string currentTitle = playlistListBox.SelectedItem.ToString();
            SongModel song = getLyrics(currentTitle, songs);
            webBrowserLyrics.AllowNavigation = true;
            webBrowserLyrics.Navigate(new Uri(song.SongLink));
        }


        private void savePlaylistToolStripMenuItem_Click(object sender, EventArgs e)
        {

            SavePlaylistForm saveForm = new SavePlaylistForm();
            saveForm.StartPosition = FormStartPosition.CenterParent;
            saveForm.ShowDialog();

            if(saveForm.DialogResult == DialogResult.OK)
            {

                playlist = MediaPlayer.currentPlaylist;
                playlist.name = saveForm.PlaylistName;
                playListLabel.Text = saveForm.PlaylistName;
                MediaPlayer.playlistCollection.importPlaylist(playlist);
                libraryListBox.Items.Clear();
                SetupLibrary(libraryListBox, MediaPlayer);
            }
          
        }


        public async Task<List<SongModel>> SetupCurrentPlaylist(string[] files, ListBox playList,  AxWMPLib.AxWindowsMediaPlayer player)
        {
            List<SongModel> tempSongs = new List<SongModel>();

            foreach (string file in files)
            {

                IWMPMedia mediaItem = MediaPlayer.newMedia((file));
                Console.WriteLine(mediaItem.name);
                SongModel song = await GetLyricData(mediaItem);
                player.currentPlaylist.appendItem(song.MediaFile); //  player.PlayStateChange 

                playList.Items.Add(song.MediaFile.getItemInfo("Title"));
                tempSongs.Add(song);
            }

            return tempSongs;
        }


        public IWMPPlaylistArray SetupLibrary(ListBox libraryListBox, AxWMPLib.AxWindowsMediaPlayer player)
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


        private void MediaPlayer_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            AxWindowsMediaPlayer t = sender as AxWindowsMediaPlayer;

            if ((MediaPlayer.currentMedia != null) && (t.playState != WMPPlayState.wmppsTransitioning))
            {
                playlistListBox.SelectedIndex = playlistListBox.FindStringExact(MediaPlayer.currentMedia.getItemInfo("Title"));
            }
        }


        private void playlistListBox_Click(object sender, EventArgs e)
        {
            MediaPlayer.Ctlcontrols.playItem(MediaPlayer.currentPlaylist.Item[playlistListBox.SelectedIndex]);
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            SetupLibrary(libraryListBox, MediaPlayer);
        }

        private void deletePlaylistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IWMPPlaylist playlistForDeletion = MediaPlayer.playlistCollection.getByName(libraryListBox.GetItemText(libraryListBox.SelectedItem)).Item(0);
            MediaPlayer.playlistCollection.remove(playlistForDeletion);

            MediaPlayer.close();
            MediaPlayer.currentPlaylist.clear();
            libraryListBox.Items.Clear();
            playlistListBox.Items.Clear();
            playListLabel.Text = "Unsaved Playlist";
            IWMPPlaylistArray allPlaylists = SetupLibrary(libraryListBox, MediaPlayer);
        }

        private async void libraryListBox_Click(object sender, EventArgs e)
        {
            
            IWMPPlaylist playlistToPlay = MediaPlayer.playlistCollection.getByName(libraryListBox.GetItemText(libraryListBox.SelectedItem)).Item(0);
            MediaPlayer.close();
            playlistListBox.Items.Clear();
            MediaPlayer.currentPlaylist.clear();

            string[] filez = new string[playlistToPlay.count];

            for (int j = 0; j < playlistToPlay.count; j++)
            {

                filez[j] = playlistToPlay.Item[j].sourceURL;

            }
            songs = await SetupCurrentPlaylist(filez, playlistListBox, MediaPlayer);
            playListLabel.Text = playlistToPlay.name;
            MediaPlayer.Ctlcontrols.play();
        }
    }
}
