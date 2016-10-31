using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.IO.Compression;
using System.Diagnostics;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ConsoleApplication12
{
    class Program
    {

        static string locTemp = Path.GetTempPath();
        string pathFrom = Directory.GetCurrentDirectory();
        string pathTo = @"J:\G\Flm";
        static string LogText = string.Empty;

        public static object Cursor { get; private set; }

        static void Main()
        {
            string pathToRec = null;
            CleanUp();
            if (!File.Exists("copy.txt"))
            {
                int re = 1;
                string kfc = "tasty";
                string input;
                bool ynd = false;
                string output;
                string defOut = @"J:\G\Flm";
                while (kfc == "tasty")
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("Enter input folder nr {0}. Type 'done' if finished.", re);
                    input = Console.ReadLine();
                    if (input == "done")
                    {
                        break;
                    }
                    if (!File.Exists("copy.txt"))
                    {
                        File.AppendAllText("copy.txt", input);
                    }
                    else
                    {
                        File.AppendAllText("copy.txt", ";" + input);
                    }

                    Console.WriteLine();
                    if (ynd == false)
                    {
                        Console.WriteLine("Enter output folder nr {0}.", re);
                        output = Console.ReadLine();
                        defOut = output;
                        File.AppendAllText("copy.txt", ";" + output);

                        if (re == 1)
                        {
                            Console.WriteLine("Use {0} as output on all copies?", re);
                            Console.WriteLine("Y/N");

                            string yn = Console.ReadLine();
                            if (yn == "y") { ynd = true; }
                        }
                    }
                    else if (ynd == true)
                    {
                        File.AppendAllText("copy.txt", ";" + defOut);
                    }
                    re++;
                }

            }
            int read = 1;
            string pathFrom;
            string pathTo;
            char[] delimiterChars = { ';' };
            string text = File.ReadAllText("copy.txt");
            System.Console.WriteLine("Original text: '{0}'", text);
            string[] words = text.Split(delimiterChars);
            System.Console.WriteLine("{0} words in text:", words.Length);
            if (File.Exists("copy.txt"))
            {
                string k;
                int i = 0;
                int o = 1;
                read = 1;
                foreach (string s in words)
                {
                    k = s;
                    Console.WriteLine(k);
                    if ("k" == "k")
                    {
                        string pathT;
                        string pathF;
                        pathF = k;
                        pathT = k;
                        if (i == 0)
                        {
                            if (File.Exists(locTemp + "from" + o + ".txt"))
                            {
                                o++;
                            }
                            pathF = k;
                            File.WriteAllText(locTemp + "from" + o + ".txt", k);
                            i++;
                            o++;
                        }
                        else if (i == 1)
                        {
                            if (File.Exists(locTemp + "to" + o + ".txt"))
                            {
                                o++;
                            }
                            File.WriteAllText(locTemp + "to" + o + ".txt", k);
                            pathT = k;
                            i--;
                            o--;
                        }
                        Console.WriteLine();
                        //DirectoryCopy(pathF, pathT, true);
                    }
                }
            }
            read = 1;

            Console.Clear();
            Console.WriteLine();
            int copies = words.Length / 2;
            int readUno = 1;
            int rrUno = 0;
            int count = 0;
            while (rrUno == 0)
            {
                if (File.Exists(locTemp + "from" + readUno + ".txt"))
                {
                    string pathFUno = File.ReadAllText(locTemp + "from" + readUno + ".txt");
                    readUno++;

                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(pathFUno);
                    count = count + dir.GetFiles().Length;
                }
                else
                {
                    rrUno++;
                    break;
                }
            }

            Console.WriteLine("{0} files will be copied", count);
            read = 1;
            int rr = 0;

            System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();
            while ("l" == "l")
            {
                if (File.Exists(locTemp + "from" + read + ".txt"))
                {
                    string pathF = File.ReadAllText(locTemp + "from" + read + ".txt");
                    read++;
                    rr++;
                    string pathT = File.ReadAllText(locTemp + "to" + read + ".txt");
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(pathF);
                    count = dir.GetFiles().Length;
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Copy job: {0}/{1} containing {2} files..", rr, copies, count);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine();
                    string pathNew = new DirectoryInfo(pathF).Name;
                    string pathRec = pathNew;
                    pathToRec = pathT;
                    pathNew = pathT + @"\" + pathNew;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Input: " + pathF + ", Output: " + pathT);
                    Console.ForegroundColor = ConsoleColor.White;
                    //pathT = pathT + @"\Copy" + rr;
                    //string pathNew = Path.GetFileName(Path.GetDirectoryName(pathF));
                    System.Diagnostics.Stopwatch ew = System.Diagnostics.Stopwatch.StartNew();
                    DirectoryCopy(pathF, pathNew, true, count, 1);
                    ew.Stop();
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    TimeSpan t = TimeSpan.FromSeconds(ew.Elapsed.TotalSeconds);

                    string answer = string.Format("{1:D2}m:{2:D2}s",
                                    t.Hours,
                                    t.Minutes,
                                    t.Seconds,
                                    t.Milliseconds);
                    Console.WriteLine();
                    Console.Write("Copy of {0} took ", pathRec);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("{0} seconds", answer);
                    Console.WriteLine();
                }
                else
                {
                    if (pathToRec == null)
                    {
                        pathToRec = Directory.GetCurrentDirectory();
                    }
                    RunUnrar(pathToRec);
                    CleanUp();
                    File.Delete("copy.txt");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine();
                    Console.WriteLine("DONE!");
                    sw.Stop();
                    Console.Beep();
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    TimeSpan t = TimeSpan.FromSeconds(sw.Elapsed.TotalSeconds);

                    string answer = string.Format("{0:D2}h:{1:D2}m:{2:D2}s",
                                    t.Hours,
                                    t.Minutes,
                                    t.Seconds,
                                    t.Milliseconds);
                    Console.WriteLine();
                    Console.Write("Copy took a total of ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("{0} seconds", answer);
                    Console.WriteLine();
                    Console.ReadKey();
                    break;
                }

            }
            /*while ("k" == "k")
            { 
            pathFrom = Directory.GetCurrentDirectory();
                Console.WriteLine("Enter input location.");
            pathFrom = Console.ReadLine();
            if (pathFrom == "")
            {
                pathFrom = Directory.GetCurrentDirectory();
            }
            else if (pathFrom == null)
            {
                pathFrom = Directory.GetCurrentDirectory();
            }

            Console.WriteLine("Input location: " + pathFrom);
            Console.WriteLine("Enter output location.");
            pathTo = Console.ReadLine();
            if (pathTo == "")
            {
                pathTo = @"J:\G\Flm";
            }
            else if (pathTo == null)
            {
                pathTo = @"J:\G\Flm";
            }
            string LogText = string.Empty;
            // Copy from the current directory, include subdirectories.
            Directory.CreateDirectory(pathTo + @"\CopiedFiles");
            pathTo = pathTo + @"\CopiedFiles";
            Console.Clear();
            Console.WriteLine("Input location: " + pathFrom);
            Console.WriteLine();
            Console.WriteLine("Output location: " + pathTo);
            Console.WriteLine();
            Console.WriteLine("Copying... ");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;

            DirectoryCopy(pathFrom, pathTo, true);

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("D");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("o");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("n");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("e");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("!");
            Console.WriteLine();
            }*/
        }
        static string RunUnrar(string pth)
        {
            int read = 1;
            int rr = 0;
            int count = 0;
            while ("l" == "l")
            {
                if (File.Exists("from" + read + ".txt"))
                {
                    string pathF = File.ReadAllText("from" + read + ".txt");
                    read++;
                    rr++;
                    string pathT = File.ReadAllText("to" + read + ".txt");
                    string pathNew = new DirectoryInfo(pathF).Name;
                    string pathRec = pathNew;
                    pathNew = pathT + @"\" + pathNew;
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(pth);
                    count = count + dir.GetFiles("*.rar").Length;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine();
                    System.Diagnostics.Stopwatch ew = System.Diagnostics.Stopwatch.StartNew();

                    // --------------------------------------------------------------------------------

                    string source = pathNew;
                    DirectoryInfo dire = new DirectoryInfo(pth);
                    bool k = false;
                    while (k == false)
                    {
                        try
                        {
                            foreach (string d in Directory.GetDirectories(pth))
                            {
                                foreach (string f in Directory.GetFiles(d, "*.rar"))
                                {
                                    source = f;
                                    string sourcealt = d;
                                    //Console.WriteLine(d);
                                    //Console.WriteLine(f);
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    Console.WriteLine();
                                    string time = DateTime.Now.ToString("HH:mm:ss");
                                    Console.Write("[{0}]", time);
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.Write(" --> ");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write("Extracting files '");
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.Write(f);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write("'... ");
                                    Process myProcess = new Process();
                                    myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                                    myProcess.StartInfo.CreateNoWindow = false;
                                    myProcess.StartInfo.UseShellExecute = false;
                                    myProcess.StartInfo.FileName = "cmd.exe";
                                    string pthso = sourcealt;
                                    string pfiles = "C:\\Program Files\\WinRAR\\winrar.exe";
                                    string command = "/c \"\"" + pfiles + "\"\" x " + f + " *.* " + pthso;
                                    //Console.WriteLine(command);
                                    //Console.ReadLine();
                                    ConsoleSpiner spin = new ConsoleSpiner();
                                    bool ffk = true;
                                    myProcess.StartInfo.Arguments = command;
                                    myProcess.Start();
                                    //myProcess.WaitForExit();
                                    while (ffk == true)
                                    {
                                        bool isRunning = !myProcess.HasExited;
                                        if (isRunning == false)
                                        {
                                            ffk = false;
                                            break;
                                        }
                                        spin.Turn();
                                    }

                                    System.IO.DirectoryInfo di = new DirectoryInfo(d);
                                    //string dirtoDel = sourcealt + "\\*.r*";

                                    foreach (FileInfo file in di.GetFiles("*.r*"))
                                    {
                                        file.Delete();
                                    }
                                }
                            }

                        }
                        catch (System.Exception excpt)
                        {
                            Console.WriteLine(excpt.Message);
                        }
                        k = true;
                        break;
                    }

                    /*foreach (FileInfo file in dire.GetFiles("*.rar"))
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine();
                        string time = DateTime.Now.ToString("HH:mm:ss");
                        Console.Write("[{0}]", time);
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write(" --> ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("Extracting files '");
                        Console.ForegroundColor = ConsoleColor.Green;
                        string temppath = Path.Combine(file.Name);
                        Console.Write(pth);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("'... ");
                        Process myProcess = new Process();
                        //myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        myProcess.StartInfo.CreateNoWindow = true;
                        myProcess.StartInfo.UseShellExecute = false;
                        myProcess.StartInfo.FileName = "cmd.exe";
                        myProcess.StartInfo.Arguments = "C:\\Program Files\\WinRAR\\winrar.exe e - s " + source + " *.* ";
                        myProcess.Start();
                        myProcess.WaitForExit();
                        Console.WriteLine("CMD DONE!");
                        Console.ReadLine();
                        System.Threading.Thread.Sleep(200);
                        
                    }*/
                    // --------------------------------------------------------------------------------

                    ew.Stop();
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    TimeSpan t = TimeSpan.FromSeconds(ew.Elapsed.TotalSeconds);

                    string answer = string.Format("{1:D2}m:{2:D2}s",
                                    t.Hours,
                                    t.Minutes,
                                    t.Seconds,
                                    t.Milliseconds);
                    Console.WriteLine();
                    if (count == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Couldn't find any (more) rar files to extract.");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine();
                        return null;
                    }
                    else
                    {
                        Console.Write("Extraction of {0} files took ", count);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("{0} seconds", answer);
                        Console.WriteLine();
                        return null;
                    }

                }
                else
                {
                    break;
                }
                return "0";
            }
            return "0";

        }
        static string CleanUp()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Cleaning up..");
            Thread.Sleep(1700);
            string rootFolderPath = locTemp;
            string filesToDelete = @"from*.txt";
            string[] fileList = System.IO.Directory.GetFiles(rootFolderPath, filesToDelete);
            foreach (string file in fileList)
            {
                Console.WriteLine(file + " has been deleted");
                File.Delete(file);
            }
            filesToDelete = @"to*.txt";
            fileList = System.IO.Directory.GetFiles(rootFolderPath, filesToDelete);
            foreach (string file in fileList)
            {
                Console.WriteLine(file + " has been deleted");
                File.Delete(file);
            }
            Console.ForegroundColor = ConsoleColor.White;
            return null;
        }

        public static long GetFileSizeOnDisk(string file)
        {
            FileInfo info = new FileInfo(file);
            uint dummy, sectorsPerCluster, bytesPerSector;
            int result = GetDiskFreeSpaceW(info.Directory.Root.FullName, out sectorsPerCluster, out bytesPerSector, out dummy, out dummy);
            if (result == 0) throw new Win32Exception();
            uint clusterSize = sectorsPerCluster * bytesPerSector;
            uint hosize;
            uint losize = GetCompressedFileSizeW(file, out hosize);
            long size;
            size = (long)hosize << 32 | losize;
            return ((size + clusterSize - 1) / clusterSize) * clusterSize;
        }

        [DllImport("kernel32.dll")]
        static extern uint GetCompressedFileSizeW([In, MarshalAs(UnmanagedType.LPWStr)] string lpFileName,
           [Out, MarshalAs(UnmanagedType.U4)] out uint lpFileSizeHigh);

        [DllImport("kernel32.dll", SetLastError = true, PreserveSig = true)]
        static extern int GetDiskFreeSpaceW([In, MarshalAs(UnmanagedType.LPWStr)] string lpRootPathName,
           out uint lpSectorsPerCluster, out uint lpBytesPerSector, out uint lpNumberOfFreeClusters,
           out uint lpTotalNumberOfClusters);

        static readonly string[] SizeSuffixes =
                   { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
        static string SizeSuffix(Int64 value)
        {
            if (value < 0) { return "-" + SizeSuffix(-value); }
            if (value == 0) { return "0.0 bytes"; }

            int mag = (int)Math.Log(value, 1024);
            decimal adjustedSize = (decimal)value / (1L << (mag * 10));

            return string.Format("{0:n1} {1}", adjustedSize, SizeSuffixes[mag]);
        }
        static string WriteNow(long spacer)
        {
            if (File.Exists("sizes.txt"))
            {
                StreamReader r = new StreamReader("sizes.txt");
                StreamWriter w = new StreamWriter("sizes.txt");
                string amn = r.ReadLine();
                long am = Convert.ToInt64(amn);
                long rite = am + spacer;
                w.WriteLine(rite);
                /*Console.WriteLine(amn);
                Console.WriteLine(am);
                Console.WriteLine(spacer);
                Console.ReadLine();*/
            }
            else
            {
                StreamWriter w = new StreamWriter("sizes.txt");
                w.WriteLine(spacer);
            }
            return null;
        }

        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs, int count, int fcount)
        {
            int dcount = count;
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            DirectoryInfo[] dirs = dir.GetDirectories();

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            // If the destination directory doesn't exist, create it. 
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                try
                {
                    string temppath = Path.Combine(destDirName, file.Name);
                    string alttemppath = Path.Combine(sourceDirName, file.Name);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine();
                    string time = DateTime.Now.ToString("HH:mm:ss");
                    Console.Write("[{0}]", time);
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write(" --> ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Copying file '");
                    Console.ForegroundColor = ConsoleColor.Green;
                    //Console.Write(temppath);
                    Console.Write(file.Name);
                    Console.ForegroundColor = ConsoleColor.White;
                    var spacer = GetFileSizeOnDisk(alttemppath);
                    var space = SizeSuffix(spacer);
                    Console.Write("'... ({0}/{1}) | {2}", fcount, dcount, space);
                    //if (!File.Exists("sizes.txt"))
                    //{
                    //    StreamWriter de = new StreamWriter("sizes.txt");
                    //    de.WriteLine(0);
                    //}
                    //StreamReader r = new StreamReader("sizes.txt");
                    //StreamWriter d = new StreamWriter("sizes.txt");
                    //string AmountCopiede = r.ReadLine();
                    //long AmountCopied = Convert.ToInt64(AmountCopiede);
                    //AmountCopied = AmountCopied + spacer;
                    //d.WriteLine(AmountCopied);
                    //Console.WriteLine(AmountCopied);
                    file.CopyTo(temppath, false);

                    fcount++;
                    count--;

                }
                catch (Exception)
                {
                    //Write Files to Log whicht couldn't be copy
                    LogText += DateTime.Now.ToString() + ": " + file.FullName;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine();
                    Console.Write("ERROR: ");
                    //Console.ForegroundColor = ConsoleColor.Cyan;
                    //Console.Write(file.Name);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("File already exist");
                    Console.WriteLine();
                    fcount++;
                    count--;
                }
            }

            // If copying subdirectories, copy them and their contents to new location. 
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    string temppathk = Path.Combine(sourceDirName, subdir.Name);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine();
                    string time = DateTime.Now.ToString("HH:mm:ss");
                    Console.Write("[{0}]", time);
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write(" --> ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Creating directory ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(temppath);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("... ");
                    Console.WriteLine();
                    System.IO.DirectoryInfo dirf = new System.IO.DirectoryInfo(temppathk);
                    count = dirf.GetFiles().Length;
                    fcount = 1;
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs, count, fcount);
                }
            }
        }
    }

    public class ConsoleSpiner
    {
        int counter;
        public ConsoleSpiner()
        {
            counter = 0;
        }
        public void Turn()
        {
            counter++;
            Thread.Sleep(100);
            switch (counter % 4)
            {
                case 0: Console.Write("/"); break;
                case 1: Console.Write("-"); break;
                case 2: Console.Write("\\"); break;
                case 3: Console.Write("|"); break;
            }
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
        }
    }
}