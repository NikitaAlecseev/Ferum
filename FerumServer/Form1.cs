using FerumServer.Core;
using FerumServer.Core.Interface;
using FerumServer.Tiles;
using MaterialSkin.Controls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FerumServer
{
    public partial class Form1 : MaterialForm
    {
        private List<HostInfoObject> hostsInfo = new List<HostInfoObject>();
        private List<ITilePC> tilePCs = new List<ITilePC>();
        private ListenerClient listenerClient = new ListenerClient();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            EventSystem.EventHostInfo += addHostInfo;
        }

        private void addHostInfo(string _json)
        {
            try
            {
                if (!_json.Contains("HostName")) return; // если пришел не тот json

                var _hostInfo = JsonConvert.DeserializeObject<HostInfoObject>(_json);
                if (_hostInfo == null) return;

                for (int i = 0;i<hostsInfo.Count;i++)
                {
                    if (hostsInfo[i].HostName == _hostInfo.HostName)
                    {
                        Invoke(new Action(() =>
                        {
                            tilePCs[i].UpdateInformation(_hostInfo);
                        }));
                        return;
                    }
                }

                TilePC tilePC = new TilePC(_hostInfo);
                hostsInfo.Add(_hostInfo);
                Invoke(new Action(() =>
                {
                    flowLayoutPanel1.Controls.Add(tilePC);
                    lCountClient.Text = $"Клиентов: {hostsInfo.Count}";
                }));
                tilePCs.Add(tilePC);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }
    }
}
