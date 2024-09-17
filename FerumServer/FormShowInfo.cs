using FerumServer.Core;
using FerumServer.Entity;
using FerumServer.Tiles;
using MaterialSkin.Controls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static FerumServer.Core.EventSystem;

namespace FerumServer
{
    public partial class FormShowInfo : MaterialForm
    {
        private HostInfoObject host;
        public FormShowInfo()
        {
            InitializeComponent();

            EventSystem.EventHostInfo += getListProcess;
        }

        private void getListProcess(string _json)
        {
            try
            {
                if (!_json.Contains("TitleProcess")) return; // если пришел не тот json

                var _hostInfo = JsonConvert.DeserializeObject<List<ProcessEntity>>(_json);
                if (_hostInfo == null) return;

                for(int i  = 0; i < _hostInfo.Count; i++)
                {
                    Invoke(new Action(() =>
                    {
                        lCountProcess.Text = $"{_hostInfo.Count} активных процессов";
                        listProcess.Items.Add(new MaterialSkin.MaterialListBoxItem(_hostInfo[i].TitleProcess));
                    }));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void LoadData(HostInfoObject _host)
        {
            host = _host;

            lHost.Text = _host.HostName;
            lMotherboard.Text = _host.PCInfo.Model;
            lProcessor.Text = _host.PCInfo.Manufacturer;
            lOnPc.Text = _host.Uptime;
            lOffPc.Text = _host.LastShutdown;
            lMemory.Text = _host.PCInfo.TotalPhysicalMemory + " мб";
            lUser.Text = _host.LastUser;
            lVideoCard.Text = _host.ModelGPU;


            // загружаем диски
            for(int i = 0; i < _host.HardDisk.Count; i++)
            {
                TileDisk tileDisk = new TileDisk();
                tileDisk.LoadData(_host.HardDisk[i]);
                flowPanelDisks.Controls.Add(tileDisk);
            }

            // загружаем список программ
            if (_host.InstalledPrograms == null) return;

            lCountPrograms.Text = $"{_host.InstalledPrograms.Count} установленных программ";
            for (int i = 0; i < _host.InstalledPrograms.Count; i++)
            {
                listPrograms.Items.Add(new MaterialSkin.MaterialListBoxItem(_host.InstalledPrograms[i]));
            }
        }

        private void btnGetProcess_Click(object sender, EventArgs e)
        {
            listProcess.Items.Clear();
            SendCommand.Send(host.HostName, "Get Process");
        }

        private void завершитьПроцессToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendCommand.Send(host.HostName, "Kill Process", listProcess.Items[listProcess.SelectedIndex].Text);
        }

        private void FormShowInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            EventSystem.EventHostInfo -= getListProcess;
        }
    }
}
