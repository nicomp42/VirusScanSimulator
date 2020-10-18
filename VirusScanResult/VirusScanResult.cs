using System;

namespace VirusScanResultNamespace
{
    public class VirusScanResult
    {
        private String mVirusName;
        private String mFilename;
        private double mVersion;
        public enum enumDisposition { clean, removed, quarrantined, unknown, FBIAlerted};
        private enumDisposition mDisposition;
        private String mDescription;

        public String description
        {
            get { return mDescription; }
            set { mDescription = value; }
        }
        public enumDisposition disposition
        {
            get { return mDisposition; }
            set { mDisposition = value; }
        }
        public String virusName
        {
            get { return mVirusName; }
            set { mVirusName = value; }
        }
        public VirusScanResult(String virusName, String infectedFile, double version, enumDisposition disposition, String description)
        {
            this.virusName = virusName;
            this.fileName = infectedFile;
            this.version = version;
            this.disposition = disposition;
            this.description = description;
        }
        public String fileName
        {
            get { return mFilename; }
            set { mFilename = value; }
        }
        public double version
        {
            get { return mVersion; }
            set { mVersion = value; }
        }

    }
}
