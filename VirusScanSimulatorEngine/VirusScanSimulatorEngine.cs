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
        private Action<VirusScanResult> CallMe;
        private TimeSpan timeSpan;
        private static String[] names = {"Valid Restaurant", "Celebrate your worm","cannot not stop me", "configure master 12.4","Progress is me", "trophy software", "I got it", "I got it now","I got you sick 3.4", "Internet Explorer 5.0", "More than a virus", "All your bytes are belong to us", "Your computer is sick", "Virus 1.01", "ScriptKiddie 1000", "Can't erase this", "Probably won't work but I tried", "NULL",  "Downloader Rocks", "Honda Civic Athletic Happy Confictor", "Get Off my Yard", "Local Traffic Online", "Hosting Service Zombie", "Wanna Cry", "Killer Code", "Amoeba Virus", "Ara Parsegian", "Hyper Infection for U", "Winner Winner Chicken Dinner", "gIvE mE aLl yOuR BiTCoInS", "X-Ray-01", "Pikachu Hates You", "Bengals Blitzer", "Spooner Maximus", "Wormy McWorm Face", "Happy Infection", "Upset Infector", "QQQQ-34.01.a.42", "Really Really Good Trojan Horse", "Unidentified but probably bad", "You do not want this", "Outstanding Coding My Friend", "Thunder Maker", "Debug this", "I now a lot", "I now a lot .01", "I know a lot .02" };
        private IProgress<VirusScanResult> progress;
        private List<String> files;
        /// <summary>
        /// Initialize the door sensor array and start it running
        /// </summary>
        /// <param name="CallMe"> The method to call when a door status changes. 
        /// The method will be passed the list of all doors 
        /// or leaving (negative number) the sensor in real time.</param>
        /// <params name="seconds"> How long the sensor should run, in seconds. 
        ///  Use 0 for Test Mode: All doors set to Unknown for 5 seconds, then 30-second duration, All door toggle between open and closed every 5 seconds for 30 seconds.</params>
        /// <returns></returns>
        public Thread StartEngine(IProgress<VirusScanResult> progress, Action<VirusScanResult> CallMe, int seconds)
        {
            this.CallMe = CallMe;
            this.timeSpan = new TimeSpan(0, 0, seconds);
            this.progress = progress;
            thread = new Thread(this.ThreadStartCallMe);
            files = new List<String>();
            thread.Start();
            return thread;
        }
        /// <summary>
        /// What happens in the thread.
        /// Demo mode = 10 minutes duration, drivers side door cycles between open for 10 seconds, closed for 10 seconds.
        /// </summary>
        private void ThreadStartCallMe()
        {
            ReadFiles(files, "c:\\Windows\\");
            ReadFiles(files, "C:\\Windows\\System32\\");
            DateTime start = new DateTime();
            start = DateTime.Now;
            VirusScanResult virusScanResult;
            Random random = new Random();
            if (timeSpan != new TimeSpan(0))
            {
                    while (true)
                    {
                        Thread.Sleep(250 * random.Next(1, 5));
                        virusScanResult = CreateRandomVirusScanResult(random);
                        progress.Report(virusScanResult);

    //                  CallMe(virusScanResult);
                        TimeSpan elapsed;
                        elapsed = DateTime.Now - start;
                        if (elapsed >= timeSpan) { break; }
                }
            } else {
                // The Demo Mode. 
                timeSpan = new TimeSpan(0, 10, 0);    // Default to 10 minutes
                while (true)
                {
                    Thread.Sleep(10000);             // Default to 10 second pause
                    virusScanResult = CreateRandomVirusScanResult(random);
                    CallMe(virusScanResult);               // Default to something
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
            double version = random.NextDouble();
            VirusScanResult virusScanResult = new VirusScanResult(name, infectedFile, version);
            return virusScanResult;
        }
        void ReadFiles(List<String> files, String path)
        {
            try
            {
                string[] fileEntries = Directory.GetFiles(path);
                foreach (string file in fileEntries) {
                    if (File.Exists(file)) {
                        // This path is a file
                        files.Add(file);
                    } else if (Directory.Exists(path)) {
                    }
                    else
                    {
                        //Console.WriteLine("{0} is not a valid file or directory.", path);
                    }
                }
            } catch (Exception ex) {
                files.Add("UNKNOWN FILE");
            }
//          return files;
        }
    }
}
