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
        private String mCountryOfOrigin;
        /// <summary>
        /// Where the virus probably originated. 
        /// </summary>
        public String countryOfOrigin
        {
            get { return mCountryOfOrigin; }
            set { mCountryOfOrigin = value; }
        }
        /// <summary>
        /// Description of what the virus does, if a virus was found
        /// </summary>
        public String description
        {
            get { return mDescription; }
            set { mDescription = value; }
        }
        /// <summary>
        /// Disposition of the file that was scanned
        /// </summary>
        public enumDisposition disposition
        {
            get { return mDisposition; }
            set { mDisposition = value; }
        }
        /// <summary>
        /// Name of the virus, if a virus was found
        /// </summary>
        public String virusName
        {
            get { return mVirusName; }
            set { mVirusName = value; }
        }
        public VirusScanResult(String virusName, String fileName, double version, enumDisposition disposition, String description, String countryOfOrigin)
        {
            this.virusName = virusName;
            this.fileName = fileName;
            this.version = version;
            this.disposition = disposition;
            this.description = description;
            this.countryOfOrigin = countryOfOrigin;
        }
        /// <summary>
        /// File that was scanned
        /// </summary>
        public String fileName
        {
            get { return mFilename; }
            set { mFilename = value; }
        }
        /// <summary>
        /// Version of the virus, if any
        /// </summary>
        public double version
        {
            get { return mVersion; }
            set { mVersion = value; }
        }

    }
}
