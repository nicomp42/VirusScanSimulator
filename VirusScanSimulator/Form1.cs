using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VirusScanResultNamespace;
using VirusScanSimulatorEngineNamespace;

namespace VirusScanSimulator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var progress = new Progress<VirusScanResult>(virusScanResult => {processData(virusScanResult);}) ;
            VirusScanSimulatorEngine virusScanSimulatorEngine = new VirusScanSimulatorEngine();
            virusScanSimulatorEngine.StartEngine(progress, 30);
        }
        private void processData(VirusScanResult virusScanResult )
        {
            if (virusScanResult.disposition != VirusScanResult.enumDisposition.clean)
            {
                txtResults.Text = (virusScanResult.fileName + " : " + virusScanResult.virusName + Environment.NewLine + txtResults.Text);
                lblVirusName.Text = virusScanResult.virusName;
                lblDescription.Text = virusScanResult.description;
            } else {
                txtResults.Text = (virusScanResult.fileName + Environment.NewLine + txtResults.Text);
                lblVirusName.Text = "";
                lblDescription.Text = "";
            }
        }

    }
}
