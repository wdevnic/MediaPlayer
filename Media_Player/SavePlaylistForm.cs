using System;
using System.Windows.Forms;

namespace Media_Player
{
    public partial class SavePlaylistForm : Form
    {
        private string playlistName;

        public SavePlaylistForm()
        {
            InitializeComponent();

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            PlaylistName = fileNameTextBox.Text;
        }


        public string PlaylistName
        {
            get { return playlistName; }
            set { playlistName = value; }
        }
       
    }
}
