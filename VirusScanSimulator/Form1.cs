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
            txtResults.Text = "";
            lblDescription.Text = "";
            lblVirusName.Text = "";
            lblScanStatus.Text = "Scan in progress...";
            var progress = new Progress<VirusScanResult>(virusScanResult => {processData(virusScanResult);}) ;
            VirusScanSimulatorEngine virusScanSimulatorEngine = new VirusScanSimulatorEngine();
            virusScanSimulatorEngine.StartEngine(progress, 30, 42);
        }
        /// <summary>
        /// This is called by the virus scanning engine.
        /// </summary>
        /// <param name="virusScanResult">The last file processed or null if the scan is finished</param>
        private void processData(VirusScanResult virusScanResult )
        {
            if (virusScanResult == null) {
                lblScanStatus.Text = "Scan complete";
            } else {
                if (virusScanResult.disposition != VirusScanResult.enumDisposition.clean) {
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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
