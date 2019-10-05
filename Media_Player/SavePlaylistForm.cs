using System;
using System.Windows.Forms;

namespace Media_Player
{
    // save form class
    public partial class SavePlaylistForm : Form
    {
        public SavePlaylistForm()
        {
            InitializeComponent();

        }

        // gets playlist name from lext box
        private void SaveButton_Click(object sender, EventArgs e)
        {
            PlaylistName = fileNameTextBox.Text;
        }

        // allows playlist name to be accessable outside the class
        public string PlaylistName { get; set; }

    }
}
