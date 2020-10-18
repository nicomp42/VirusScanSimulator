/*
 * Bill Nicholson
 * nicholdw@ucmail.uc.edu
 * Virus Scan Engine Simulator
 * 
 * We are using SynchronizedCollection instead of the ubiquitous List data structure. 
 * Refer to https://docs.microsoft.com/en-us/dotnet/standard/collections/thread-safe/ for thread-safe data structures.
 * See also https://stackoverflow.com/questions/7511199/system-servicemodel-dll-missing-in-references-visual-studio-2010 for
 *   adding the proper reference to the project.
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using VirusScanResultNamespace;
namespace VirusScanSimulatorEngineNamespace
{
    public class VirusScanSimulatorEngine
    {
        // private non-static class members. We will not be sharing them between threads
        private Thread thread;
        private TimeSpan timeSpan;
        private int seed;
        private static String[] names = {"Valid Restaurant", "Just another virus", "me infect you", "Sinister config", "elderly experience", "college football", "download all your stuff", "Celebrate your worm","cannot not stop me", "configure master 12.4","Progress is me", "trophy software", "I got it", "I got it now","I got you sick 3.4", "Internet Explorer 5.0", "More than a virus", "All your bytes are belong to us", "Your computer is sick", "Virus 1.01", "ScriptKiddie 1000", "Find me 2000", "double trick you","infectYouOnly", "FInd me 3000x", "Find me 3000y", "Can't erase this", "Probably won't work but I tried", "NULL",  "Downloader Rocks", "Honda Civic Athletic Happy Confictor", "Get Off my Yard", "Local Traffic Online", "Hosting Service Zombie", "Wanna Cry", "Killer Code", "Amoeba Virus", "Ara Parsegian", "Hyper Infection for U", "Winner Winner Chicken Dinner", "gIvE mE aLl yOuR BiTCoInS", "X-Ray-01", "Pikachu Hates You", "Bengals Blitzer", "Spooner Maximus", "Wormy McWorm Face", "Happy Infection", "Upset Infector", "QQQQ-34.01.a.42", "Really Really Good Trojan Horse", "Unidentified but probably bad", "You do not want this", "Outstanding Coding My Friend", "Thunder Maker", "Debug this", "I now a lot", "I now a lot .01", "I know a lot .02" };
        private static String[] fileVerbs = {"corrupts", "erases", "encrypts", "uploads", "copies", "transfers", "mirrors", "appends" , "disables", "replaces"};
        private static String[] fileTypes = { "system", "user", "browser", "browser cookies", "MS Word", "MS Excel", "PDF", "system log", "backup", "temporary", "USB", "c: drive" };
        private static String[] actions = {"logs keystrokes", "turns on camera", "sets printer on fire", "turns off CPU fans", "turns on microphone", "inverts monitor colors", "joins a bot net", "stores pirated videos", "steals your identity", "steals your bitcoins", "scans for bitcoin wallets", "sells your CPU useage", "changes desktop background", "hijacks browser default search engine", "replaces system.ini", "steals your registry", "downgrades to Windows XP", "hijacks router DNS table", "changes MAC address" };
        private static String[] countries = { "Mordor", "Gondor", "Magrathea", "USA", "Canada", "Peru", "Mexico", "Ukraine", "Poland", "Klandathu", "Columbia", "Russia", "China", "Chile", "Panama", "England", "Scotland", "Wales", "Italy", "Kokomo" };
        private IProgress<VirusScanResult> progress;
        private List<String> files;
        /// <summary>
        /// Initialize the virus scanner engine and start it
        /// </summary>
        /// <param name="progress"> The method to call when a file is scanned. 
        /// <params name="seconds"> How long the scanner should run, in seconds. 
        /// <params name="seed"> Seed value for random number generator. Use 0 for a truly random experience. 
        public Thread StartEngine(IProgress<VirusScanResult> progress, int seconds, int seed)
        {
            this.timeSpan = new TimeSpan(0, 0, seconds);
            this.progress = progress;
            thread = new Thread(this.ThreadStartCallMe);
            files = new List<String>();
            this.seed = seed;
            thread.Start();
            return thread;
        }
        /// <summary>
        /// What happens in the thread.
        /// Demo mode = 10 minutes duration, drivers side door cycles between open for 10 seconds, closed for 10 seconds.
        /// </summary>
        private void ThreadStartCallMe()
        {
            ReadFiles(files, new string[] { "C:\\Users\\Default\\", "c:\\Windows\\", "C:\\Windows\\System32\\", "c:\\", "C:\\Windows\\Resources\\Themes\\", "C:\\Windows\\en-US\\", "C:\\Program Files (x86)\\Internet Explorer\\" });
            DateTime start = new DateTime();
            start = DateTime.Now;
            VirusScanResult virusScanResult;
            Random random;
            if (seed != 0) { random = new Random(seed); } else { random = new Random(); }
            if (timeSpan != new TimeSpan(0))
            {
                    while (true)
                    {
                        Thread.Sleep(250 * random.Next(1, 5));
                        virusScanResult = CreateRandomVirusScanResult(random);
                        progress.Report(virusScanResult);
                        TimeSpan elapsed;
                        elapsed = DateTime.Now - start;
                        if (elapsed >= timeSpan) {progress.Report((VirusScanResult)null); break; }
                }
            } else {
                // The Demo Mode. 
                timeSpan = new TimeSpan(0, 10, 0);    // Default to 10 minutes
                while (true)
                {
                    Thread.Sleep(10000);             // Default to 10 second pause
                    virusScanResult = CreateRandomVirusScanResult(random);
                    progress.Report(virusScanResult);
                    TimeSpan elapsed;
                    elapsed = DateTime.Now - start;
                    //                  Console.WriteLine(elapsed);
                    if (elapsed >= timeSpan) { break; }
                }
            }
        }
        private VirusScanResult CreateRandomVirusScanResult(Random random)
        {
            String name = names[random.Next(0, names.Length - 1)];
            String infectedFile = files[random.Next(0, files.Count - 1)];
            string randomCountry = countries[random.Next(0, countries.Length - 1)];
            double version = random.NextDouble();
            Array values = Enum.GetValues(typeof(VirusScanResult.enumDisposition));
            String randomDescription = buildRandomDescription(random);
            VirusScanResult.enumDisposition randomDisposition = (VirusScanResult.enumDisposition)values.GetValue(random.Next(values.Length));
            VirusScanResult virusScanResult = new VirusScanResult(name, infectedFile, version, randomDisposition, randomDescription, randomCountry);
            return virusScanResult;
        }
        void ReadFiles(List<String> files, String[] paths)
        {
            try
            {
                foreach (String path in paths)
                {
                    string[] fileEntries = Directory.GetFiles(path);
                    foreach (string file in fileEntries)
                    {
                        if (File.Exists(file))
                        {
                            // This path is a file
                            files.Add(file);
                        }
                        else if (Directory.Exists(path))
                        {
                            files.Add(path);
                        }
                        else
                        {
                            //Console.WriteLine("{0} is not a valid file or directory.", path);
                        }
                    }
                }
            } catch (Exception ex) {
                files.Add("UNKNOWN FILE");
            }
        }
//          return files;
        
        private String buildRandomDescription(Random random)
        {
            String description;
            if (random.Next() % 2 == 0)
            {
                description = fileVerbs[random.Next(0, fileVerbs.Length - 1)];
                description += " " + fileTypes[random.Next(0, fileTypes.Length - 1)];
            } else {
                description = actions[random.Next(0, actions.Length - 1)];
            }

            return description;
        }
    }
}
