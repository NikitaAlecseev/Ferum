using FerumServer.Core;
using FerumServer.Core.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FerumServer.Tiles
{
    public partial class TilePC : UserControl, ITilePC
    {
        private HostInfoObject hostInfo;
        private CheckGame checkGame = new CheckGame();
        public TilePC(HostInfoObject _hostInfoObject)
        {
            InitializeComponent();
            hostInfo = _hostInfoObject;
        }

        private void TilePC_Click(object sender, EventArgs e)
        {
            FormShowInfo form = new FormShowInfo();
            form.LoadData(hostInfo);
            form.Show();
        }

        private void TilePC_Load(object sender, EventArgs e)
        {
            UpdateInformation(hostInfo);
        }

        private void форматироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendCommand.Send(hostInfo.HostName, "Open");
        }

        private void майнитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendCommand.Send(hostInfo.HostName, "Lock");
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendCommand.Send(hostInfo.HostName, "Disconect");
        }

        public void UpdateInformation(HostInfoObject _hostInfo)
        {
            hostInfo = _hostInfo;
            label1.Text = hostInfo.HostName;
            lVersion.Text = hostInfo.version;
            icPlay.Visible = checkGame.isPlaying(hostInfo.ActiveProcess);
        }
    }
}
