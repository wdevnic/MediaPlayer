using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WMPLib;
using AxWMPLib;


namespace Media_Player
{
    public partial class MainForm : Form
    {

        IWMPPlaylist playlist;
        List<SongModel> songs = new List<SongModel>();
        bool defaultPage = false;
       
        

        public MainForm()
        {
            InitializeComponent();
            ApiHelper.InitializeClient(); // initalize http client
        }

        //File > Open menu option
        private async void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {

            OpenFileDialog open = new OpenFileDialog
            {
                Filter = "Music| *.mp3",
                Multiselect = true
            };

            if (open.ShowDialog() == DialogResult.OK)
            {
                songs = MediaPlayerHelper.ProcessPlaylistChanges(open.FileNames, songs, playlistListBox, MediaPlayer);
            }
           
            MediaPlayer.Ctlcontrols.play();

            await MediaPlayerHelper.PopulateLyricsData(songs);
        }

        // resizes browser if lyrics page found
        private void WebBrowserLyrics_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (!defaultPage)
            {
                MediaPlayerHelper.BrowserZoom(webBrowserLyrics);
                
            }

            webBrowserLyrics.AllowNavigation = false;

        }

        // credit link to API site
        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel.LinkVisited = true;
            System.Diagnostics.Process.Start("http://www.lyrics.com");
        }

        // close Media player
        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MediaPlayer.close();
        }

        // exit media player
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // handles selection changes in playlist
        private void PlaylistListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
           // gets the song selected in playlist
            string currentTitle = playlistListBox.SelectedItem.ToString();
            SongModel song = MediaPlayerHelper.GetSelectedSong(currentTitle, songs);
            webBrowserLyrics.AllowNavigation = true;
            defaultPage = MediaPlayerHelper.CheckURL(song, webBrowserLyrics); // checks if link URL found
        }

        // saves playlist
        private void SavePlaylistToolStripMenuItem_Click(object sender, EventArgs e)
        {

            SavePlaylistForm saveForm = new SavePlaylistForm
            {
                StartPosition = FormStartPosition.CenterParent
            }; // launches save form
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
                MediaPlayerHelper.SetupLibrary(libraryListBox, MediaPlayer);  
            }
          
        }

       // _WMPOCXEvents_PlayStateChangeEvent
        private void MediaPlayer_PlayStateChange(object sender, _WMPOCXEvents_PlayStateChangeEvent e)
        {
            AxWindowsMediaPlayer t = sender as AxWindowsMediaPlayer;

            if ((MediaPlayer.currentMedia != null) && (t.playState != WMPPlayState.wmppsTransitioning) && (t.playState != WMPPlayState.wmppsReady)) // checks that current media is valid and ensures that media is not transitioning before it switches to next item
            {
                playlistListBox.SelectedIndex = int.Parse(MediaPlayer.currentMedia.getItemInfo("PlaylistIndex")); // ensures that correct listbox item is selected when next song starts
            }
        }

        private void PlaylistListBox_Click(object sender, EventArgs e)
        {
            if(playlistListBox.Items.Count > 0)
            {
                MediaPlayer.Ctlcontrols.playItem(MediaPlayer.currentPlaylist.Item[playlistListBox.SelectedIndex]); // play media that has the same name as the list box item selected
            }
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            MediaPlayerHelper.SetupLibrary(libraryListBox, MediaPlayer); // setup playlist on load         
        }

        private void DeletePlaylistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IWMPPlaylist playlistForDeletion = MediaPlayer.playlistCollection.getByName(libraryListBox.GetItemText(libraryListBox.SelectedItem)).Item(0); // find playlist for deletion
            MediaPlayer.playlistCollection.remove(playlistForDeletion); // delete selected playlist

            MediaPlayer.close(); 
            MediaPlayer.currentPlaylist.clear();
            libraryListBox.Items.Clear();
            playlistListBox.Items.Clear();
            playListLabel.Text = "Unsaved Playlist";
            IWMPPlaylistArray allPlaylists = MediaPlayerHelper.SetupLibrary(libraryListBox, MediaPlayer); // refresh libarary
        }

        private async void LibraryListBox_Click(object sender, EventArgs e)
        {
            if(libraryListBox.SelectedItem !=  null)
            {
                MediaPlayer.close();
                playlistListBox.Items.Clear();
                MediaPlayer.currentPlaylist.clear();

                string[] filePaths = MediaPlayerHelper.PlayLibraryList(MediaPlayer, libraryListBox, playListLabel);
                songs = MediaPlayerHelper.ProcessPlaylistChanges(filePaths, songs, playlistListBox, MediaPlayer); // setup playlist
                MediaPlayer.Ctlcontrols.play(); // play playlist

                await MediaPlayerHelper.PopulateLyricsData(songs);
            }       
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MediaPlayer.Ctlcontrols.stop();
            string currentTitle = playlistListBox.SelectedItem.ToString(); // current list box item selected
            SongModel song = MediaPlayerHelper.GetSelectedSong(currentTitle, songs); 

            songs.Remove(song); // remove song 
            MediaPlayer.currentPlaylist.clear();
            playlistListBox.Items.Clear();

            foreach (SongModel songItems in songs)
            {
                MediaPlayer.currentPlaylist.appendItem(songItems.MediaFile);
                playlistListBox.Items.Add(songItems.MediaFile.getItemInfo("Title"));
            }

            if(playListLabel.Text != "Unsaved Playlist") // check if saved playlist needs to be modified as well
            {
                IWMPPlaylist playlistForDeletion = MediaPlayer.playlistCollection.getByName(playListLabel.Text).Item(0); // find old playlist for deletion
                MediaPlayer.playlistCollection.remove(playlistForDeletion); // delete selected playlist

                // save current updated playlist
                playlist = MediaPlayer.currentPlaylist; 
                playlist.name = playListLabel.Text;
                MediaPlayer.playlistCollection.importPlaylist(playlist); // adds playlist to library

            }
            MediaPlayer.Ctlcontrols.play();
        }

            
        
    }
}
