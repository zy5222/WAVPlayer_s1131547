using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WAVPlayer_s1131547
{
    public partial class frmWAVPlayer : Form
    {
        public frmWAVPlayer()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            this.ofdWAVFile.Filter = "WAV Files(*.wav)|*.wav";
            if (this.ofdWAVFile.ShowDialog() == DialogResult.OK)
            {
                this.txtPath.Text = this.ofdWAVFile.FileName;
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            SoundPlayer player1 = new SoundPlayer(); 
            player1.SoundLocation = txtPath.Text;
            player1.Load();
            player1.Play();
        }

        private void btnLoop_Click(object sender, EventArgs e)
        {
            SoundPlayer player2 = new SoundPlayer(txtPath.Text);
            player2.PlayLooping();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            FileStream fsWAV = new FileStream(txtPath.Text, FileMode.Open);
            SoundPlayer player3 = new SoundPlayer(fsWAV);
            player3.Stop();
            fsWAV.Close();
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmWAVPlayer_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show("確定要關閉應用程式嗎？", "關閉確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true; // 取消關閉
            }
        }
    }
}
