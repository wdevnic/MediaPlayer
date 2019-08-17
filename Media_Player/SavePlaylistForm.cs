using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
