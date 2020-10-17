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
//            var progress = new Progress<string>(s => txtResults.Text += (s + Environment.NewLine));
            var progress = new Progress<VirusScanResult>(s => txtResults.Text += (s.virusName + Environment.NewLine));
//            await Task.Factory.StartNew(() => SecondThreadConcern.LongWork(progress),
//                                        TaskCreationOptions.LongRunning);
            VirusScanSimulatorEngine virusScanSimulatorEngine = new VirusScanSimulatorEngine();
            virusScanSimulatorEngine.StartEngine(progress, CallMe, 30);
        }
        private void CallMe(VirusScanResult virusScanResult)
        {
            txtResults.AppendText(virusScanResult.virusName + "\n");
        }
    }
}
