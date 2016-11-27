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
using System.Text.RegularExpressions;

namespace ConsoleApplication12
{
    class Program
    {
        static bool move = false;
        static string locTemp = Path.GetTempPath();
        string pathFrom = Directory.GetCurrentDirectory();
        string pathTo = @"J:\G\Flm";
        static string LogText = string.Empty;
        static int loc;

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
                bool ynds = false;
                string output;
                string defOut = @"J:\G\Flm";
                Console.WriteLine("Is this a move job? (Y/N)");
                while (ynds == false)
                {
                    ConsoleKeyInfo choice = Console.ReadKey();
                    switch (choice.Key)
                    {
                        case ConsoleKey.Y:
                            ynds = true;
                            move = true;
                            File.AppendAllText(locTemp + "move.c", "y");
                            break;
                        case ConsoleKey.N:
                            ynds = true;
                            if (File.Exists(locTemp + "move.c"))
                            {
                                File.Delete(locTemp + "move.c");
                            }
                            move = false;
                            break;
                        default:
                            break;
                    }
                }

                while (kfc == "tasty")
                {
                Input:
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("Enter input folder nr {0}. Type 'done' if finished.", re);
                    input = Console.ReadLine();
                    input = input.Replace("\"", "");
                    if (input != "done")
                    {
                        if (!Directory.Exists(input))
                        {
                            if (!File.Exists(input))
                            {
                                Console.WriteLine("That is not a file nor a directory. Please check for spelling errors and try again");
                                Thread.Sleep(2400);
                                goto Input;
                            }
                        }
                    }
                    else if (input == "done")
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
                    Output:
                        Console.WriteLine("Enter output folder nr {0}.", re);
                        output = Console.ReadLine();
                        output = output.Replace("\"", "");
                        defOut = output;
                        if (!Directory.Exists(output))
                        {
                            if (File.Exists(output))
                            {
                                string morc = "copy";
                                if (move == true)
                                {
                                    morc = "move";
                                }
                                else if (move == false)
                                {
                                    morc = "copy";
                                }

                                Console.WriteLine("That is not a directory, but a file. Please specify a directory to copy to.");
                                Console.WriteLine("You can rename your file yourself after the {0}. Don't try to do that here.", morc);
                                Console.WriteLine();
                                Console.WriteLine("Press any key to continue..");
                                Console.ReadKey();
                                Console.Clear();
                                goto Output;
                            }
                        }
                        File.AppendAllText("copy.txt", ";" + output);

                        if (re == 1)
                        {
                            Console.WriteLine("Use {0} as output on all copies?", re);
                            Console.WriteLine("Y/N");
                            ConsoleKeyInfo choice = Console.ReadKey();
                            switch (choice.Key)
                            {
                                case ConsoleKey.Y:
                                    ynd = true;
                                    break;
                                case ConsoleKey.N:
                                    ynd = false;
                                    break;
                                default:
                                    break;
                            }
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
                if (File.Exists(locTemp + "move.c"))
                {
                    move = true;
                }
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
            int countdoku = 0;
            int folders = 0;

            while (rrUno == 0)
            {
                if (File.Exists(locTemp + "from" + readUno + ".txt"))
                {
                    folders = folders + 1;
                    string pathFUno = File.ReadAllText(locTemp + "from" + readUno + ".txt");
                    readUno++;

                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(pathFUno);
                    count = dir.GetFiles("*.*", SearchOption.AllDirectories).Length;
                    countdoku = countdoku + dir.GetFiles("*.*", SearchOption.AllDirectories).Length;
                    folders = folders + dir.GetDirectories("*", SearchOption.AllDirectories).Length;
                    
                }
                else
                {
                    rrUno++;
                    break;
                }
            }
            loc = countdoku;
            if (move == true)
            {
                Console.WriteLine("{0} files inside {1} folders will be moved", countdoku, folders);
            }
            else if (move == false)
            {
                Console.WriteLine("{0} files inside {1} folders will be copied", countdoku, folders);
            }

            read = 1;
            int rr = 0;
            IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
            System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();
            while ("l" == "l")
            {
                TaskbarProgress.SetState(handle, TaskbarProgress.TaskbarStates.Indeterminate);
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
                    if (move == true)
                    {
                        Console.WriteLine("Moving job: {0}/{1} containing {2} files..", rr, copies, count);
                    }
                    else if (move == false)
                    {
                        Console.WriteLine("Copy job: {0}/{1} containing {2} files..", rr, copies, count);
                    }

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
                    bool isFile = false;
                    if (!Directory.Exists(pathF))
                    {
                        if (File.Exists(pathF))
                        {
                            isFile = true;
                            Console.WriteLine("Not a directory, but a file: " + pathF);
                            File.Copy(pathF, pathNew);
                        }
                        else
                        {
                            Console.WriteLine("{0} doesn't exist, skipping", pathF);
                            isFile = true;
                        }
                    }
                    if (isFile == false)
                    {

                        DirectoryCopy(pathF, pathNew, true, count, 1, countdoku);
                    }

                    DirectoryInfo filesg = new DirectoryInfo(pathF);
                    int torrent = filesg.GetFiles("*", SearchOption.AllDirectories).Length;
                    if (torrent == 0)
                    {
                        Directory.Delete(pathF, true);
                    }

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
                        if (move == true)
                        {
                            Console.Write("Move of {0} took ", pathRec);
                        }
                        else if (move == false)
                        {
                            Console.Write("Copy of {0} took ", pathRec);
                        }

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
                        if (move == true)
                        {
                            Console.Write("Move took a total of ");
                        }
                        else if (move == false)
                        {
                            Console.Write("Copy took a total of ");
                        }

                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("{0} seconds", answer);
                        Console.WriteLine();

                        TaskbarProgress.SetValue(handle, 100, 100);
                        TaskbarProgress.SetState(handle, TaskbarProgress.TaskbarStates.Indeterminate);
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
            IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
            TaskbarProgress.SetState(handle, TaskbarProgress.TaskbarStates.Indeterminate);
            int read = 1;
            int rr = 0;
            int count = 0;
            while ("l" == "l")
            {
                if (File.Exists(locTemp + "from" + read + ".txt"))
                {


                    string pathF = File.ReadAllText(locTemp + "from" + read + ".txt");
                    read++;
                    rr++;
                    string pathT = File.ReadAllText(locTemp + "to" + read + ".txt");
                    string pathNew = new DirectoryInfo(pathF).Name;
                    string pathRec = pathNew;
                    pathNew = pathT + @"\" + pathNew;
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(pathNew);
                    count = count + dir.GetFiles("*.r*",SearchOption.AllDirectories).Length;
                    Console.WriteLine("Counting.."); /////////////////////////////////////////////
                    Console.WriteLine(count + " rar files");
                    int totalAmountOfRars = count;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine();
                    System.Diagnostics.Stopwatch ew = System.Diagnostics.Stopwatch.StartNew();


                    // --------------------------------------------------------------------------------

                    string source = pathNew;
                    DirectoryInfo dire = new DirectoryInfo(pathNew);
                    bool k = false;
                    int nm = 1;
                    while (k == false)
                    {
                        int fileCount = dire.GetFiles("*.rar", SearchOption.AllDirectories).Length;
                        string[] myList = new string[fileCount + 1];
                        string[] myListFull = new string[fileCount + 1];
                        foreach (FileInfo torre in dire.GetFiles("*.rar", SearchOption.AllDirectories))
                        {
                            Console.WriteLine(torre.Name);
                            myListFull[nm] = (Path.GetFileNameWithoutExtension(torre.Name));
                            myList[nm++] = torre.FullName;
                        }
                        nm = 1;
                        try
                        {
                                foreach (FileInfo f in dire.GetFiles("*.rar", SearchOption.AllDirectories))
                                {
                                    source = f.FullName;
                                    string sourcealt = f.Directory.FullName;
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
                                    Console.Write(myListFull[nm]);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write("'... ");
                                    Process myProcess = new Process();
                                    myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                                    myProcess.StartInfo.CreateNoWindow = false;
                                    myProcess.StartInfo.UseShellExecute = false;
                                    myProcess.StartInfo.FileName = "cmd.exe";
                                    string pthso = sourcealt;
                                    string pfiles = "C:\\Program Files\\WinRAR\\winrar.exe";
                                    string command = "/c \"\"" + pfiles + "\"\" x " + myList[nm] + " *.* " + pthso;
                                    //Console.WriteLine(command);
                                    //Console.ReadLine();
                                    ConsoleSpiner spin = new ConsoleSpiner();
                                    bool ffk = true;
                                    myProcess.StartInfo.Arguments = command;
                                    TaskbarProgress.SetValue(handle, totalAmountOfRars - count, totalAmountOfRars);
                                    TaskbarProgress.SetState(handle, TaskbarProgress.TaskbarStates.Normal);
                                    myProcess.Start();
                                    myProcess.WaitForExit();
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

                                    //string dirtoDel = sourcealt + "\\*.r*";
                                        
                                    count--;
                                nm++;
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
                    File.Delete(pathNew + "\\*.r*");
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
            IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
            TaskbarProgress.SetState(handle, TaskbarProgress.TaskbarStates.Indeterminate);
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
            if (!File.Exists("copy.txt"))
            {
                if (File.Exists(locTemp + "move.c"))
                {
                    File.Delete(locTemp + "move.c");
                }
            }
            
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
            if (value == 0) { return "0.0bytes"; }

            int mag = (int)Math.Log(value, 1024);
            decimal adjustedSize = (decimal)value / (1L << (mag * 10));

            return string.Format("{0:n1}{1}", adjustedSize, SizeSuffixes[mag]);
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

        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs, int count, int fcount, int totalPerc)
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
                string dd = Path.Combine(destDirName, file.Name);
                if (File.Exists(dd))
                {
                    loc--;
                }
            }
            IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
            foreach (FileInfo file in files)
            {
                if (totalPerc - loc == 0)
                {
                    TaskbarProgress.SetValue(handle, totalPerc - loc, totalPerc);
                    TaskbarProgress.SetState(handle, TaskbarProgress.TaskbarStates.Indeterminate);
                } else
                {
                    TaskbarProgress.SetValue(handle, totalPerc - loc, totalPerc);
                    TaskbarProgress.SetState(handle, TaskbarProgress.TaskbarStates.Normal);
                }
                try
                {
                    string temppath = Path.Combine(destDirName, file.Name);
                    string alttemppath = Path.Combine(sourceDirName, file.Name);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine();
                    string time = DateTime.Now.ToString("HH:mm:ss");
                    Console.Write("[{0}]", time);
                    var spacer = GetFileSizeOnDisk(alttemppath);
                    var space = SizeSuffix(spacer);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" ({0}/{1}) | {2}", fcount, dcount, space);
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write(" --> ");
                    Console.ForegroundColor = ConsoleColor.White;
                    if (move == true)
                    {
                        Console.Write("Moving file '");
                    }
                    else if (move == false)
                    {
                        Console.Write("Copying file '");
                    }
                    
                    Console.ForegroundColor = ConsoleColor.Green;
                    //Console.Write(temppath);
                    Console.Write(file.Name);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("'... ");
                    Console.Title = "Files left: " + loc + " | (" + fcount + "/" + dcount + ") | " + space + "  " + file.Name;
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
                    if (move == true)
                    {
                        file.MoveTo(temppath);
                    } else if (move == false)
                    {
                        file.CopyTo(temppath, false);
                    }
                    fcount++;
                    count--;
                    loc--;
                }
                catch (FileNotFoundException)
                {
                    TaskbarProgress.SetValue(handle, totalPerc - loc, totalPerc);
                    TaskbarProgress.SetState(handle, TaskbarProgress.TaskbarStates.Error);
                    //Write Files to Log whicht couldn't be copy
                    LogText += DateTime.Now.ToString() + ": " + file.FullName;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine();
                    Console.Write("ERROR: ");
                    //Console.ForegroundColor = ConsoleColor.Cyan;
                    //Console.Write(file.Name);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("File not found");
                    Console.Title = Console.Title + " ERROR: File Not Found";
                    Console.WriteLine();
                    fcount++;
                    count--;
                    loc--;
                }
                catch (Exception)
                {
                    TaskbarProgress.SetValue(handle, totalPerc - loc, totalPerc);
                    TaskbarProgress.SetState(handle, TaskbarProgress.TaskbarStates.Error);
                    //Write Files to Log whicht couldn't be copy
                    LogText += DateTime.Now.ToString() + ": " + file.FullName;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine();
                    Console.Write("ERROR: ");
                    //Console.ForegroundColor = ConsoleColor.Cyan;
                    //Console.Write(file.Name);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("File already exist");
                    Console.Title = Console.Title + " ERROR: File already exists";
                    Console.WriteLine();
                    fcount++;
                    count--;
                    loc--;
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
                    int rrUno = 0;
                    int readUno = 1;
                    int countdoku = 0;
                    while (rrUno == 0)
                    {
                        if (File.Exists(locTemp + "from" + readUno + ".txt"))
                        {
                            string pathFUno = File.ReadAllText(locTemp + "from" + readUno + ".txt");
                            readUno++;
                            System.IO.DirectoryInfo dirh = new System.IO.DirectoryInfo(pathFUno);
                            countdoku = countdoku + Directory.GetFileSystemEntries(pathFUno, "*", SearchOption.AllDirectories).Length;
                        }
                        else
                        {
                            rrUno++;
                            break;
                        }
                    }
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs, count, fcount, countdoku);
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