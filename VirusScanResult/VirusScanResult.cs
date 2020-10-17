using System;

namespace VirusScanResultNamespace
{
    public class VirusScanResult
    {
        private String mVirusName;
        private String mInfectedFile;

        public String virusName
        {
            get { return mVirusName; }
            set { mVirusName = value; }
        }
        public VirusScanResult(String virusName, String infectedFile)
        {
            this.virusName = virusName;
            this.infectedFile = infectedFile;
        }
        public String infectedFile
        {
            get { return mInfectedFile; }
            set { mInfectedFile = value; }
        }

    }
}
