using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Id3Lib;
using Mp3Lib;


namespace Media_Player
{
    public partial class MainForm : Form
    {
        OpenFileDialog open = new OpenFileDialog();
        string filePath;

        public MainForm()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();
            Console.WriteLine(playListLabel.Parent);
        }

        private async void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(open.ShowDialog() == DialogResult.OK)
            {
                filePath = open.FileName;
                MediaPlayer.URL = filePath;
                await GetLyricData();
       
            }
       //     webBrowserLyrics.AllowNavigation = false;
        }

        private async Task GetLyricData()
        {
            webBrowserLyrics.AllowNavigation = true;
            Mp3File track = new Mp3File(filePath);
            SongModel songData = await LyricsProcessor.GetSongDataAsync(track.TagHandler.Title, track.TagHandler.Artist);            
            webBrowserLyrics.Navigate(new Uri(songData.SongLink));
            
            
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
    }
}
