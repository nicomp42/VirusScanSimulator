using System;

namespace VirusScanResultNamespace
{
    public class VirusScanResult
    {
        private String mVirusName;

        public String virusName
        {
            get { return mVirusName; }
            set { mVirusName = value; }
        }
        public VirusScanResult(String virusName)
        {
            this.virusName = virusName;
        }

    }
}
