using FerumServer.Entity;
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
    public partial class TileDisk : UserControl
    {
        public TileDisk()
        {
            InitializeComponent();
        }

        public void LoadData(HardInfo hardInfo)
        {
            float freeTotal = float.Parse(hardInfo.TotalFree) / (1024 * 1024 * 1024);
            float total = float.Parse(hardInfo.TotalSize) / (1024 * 1024 * 1024);
            lName.Text = $"{hardInfo.Name} ({hardInfo.Symbol})";
            lTotal.Text = $"{freeTotal} ГБ свободно из {total} ГБ";

            double usedSpacePercent = (total - freeTotal) / total * 100;
            progressBar.Value = Convert.ToInt32(usedSpacePercent);
        }

        private void lTotal_Click(object sender, EventArgs e)
        {

        }
    }
}
