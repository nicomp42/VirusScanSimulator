using System;

namespace VirusScanResultNamespace
{
    public class VirusScanResult
    {
        private String mVirusName;
        private String mInfectedFile;
        private double mVersion;

        public String virusName
        {
            get { return mVirusName; }
            set { mVirusName = value; }
        }
        public VirusScanResult(String virusName, String infectedFile, double version)
        {
            this.virusName = virusName;
            this.infectedFile = infectedFile;
            this.version = version;
        }
        public String infectedFile
        {
            get { return mInfectedFile; }
            set { mInfectedFile = value; }
        }
        public double version
        {
            get { return mVersion; }
            set { mVersion = value; }
        }

    }
}
