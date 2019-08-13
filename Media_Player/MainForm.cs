using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mp3Lib;
using WMPLib;
using System.Linq;


namespace Media_Player
{
    public partial class MainForm : Form
    {
        OpenFileDialog open = new OpenFileDialog();
        IWMPPlaylist myPlayList;
        List<SongModel> songs = new List<SongModel>();
        



        string filePath;

        public MainForm()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();
            Console.WriteLine(playListLabel.Parent);
        }

        private async void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myPlayList = MediaPlayer.playlistCollection.newPlaylist("MyPlayList");
            open.Filter = "Music| *.mp3";
            open.Multiselect = true;

            if (open.ShowDialog() == DialogResult.OK)
            {

                foreach (string file in open.FileNames)
                {
                    IWMPMedia mediaItem = MediaPlayer.newMedia(file);
                    SongModel song = await GetLyricData(mediaItem);      
                    myPlayList.appendItem(song.MediaFile);
                    playlistListBox.Items.Add(song.MediaFile.getItemInfo("Title"));
                    songs.Add(song);
                }

            }

            playlistListBox.SelectedIndex = 0;
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
            Console.Write(mediaFile.getItemInfo("Title"));
            Console.Write(mediaFile.getItemInfo("Artist"));

            
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

    //        webBrowserLyrics.AllowNavigation = false;

            MediaPlayer.URL = song.MediaFile.sourceURL;

            


        }
    }
}
