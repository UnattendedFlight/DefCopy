using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace ConsoleApplication12
{
    class Program
    {

        string pathFrom = Directory.GetCurrentDirectory();
        string pathTo = @"J:\G\Flm";
        static string LogText = string.Empty;
        static void Main()
        {
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
                    } else
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
                    } else if (ynd == true)
                    {
                        File.AppendAllText("copy.txt", ";" + defOut);
                    }
                    re++;
                }
                
            }
            int read = 1;
            string pathFrom;
            string pathTo;
            char[] delimiterChars = { ' ', ';' };
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
                            if (File.Exists("from" + o + ".txt"))
                            {
                                o++;
                            }
                            pathF = k;
                            File.WriteAllText("from" + o + ".txt", k);
                            i++;
                            o++;
                        }
                        else if (i == 1)
                        {
                            if (File.Exists("to" + o + ".txt"))
                            {
                                o++;
                            }
                            File.WriteAllText("to" + o + ".txt", k);
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
            Console.WriteLine("{0} things will be copied", copies);
            read = 1;
            int rr = 0;
            System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();
            while ("l" == "l")
            {
                if (File.Exists("from" + read + ".txt"))
                {
                    string pathF = File.ReadAllText("from" + read + ".txt");
                    read++;
                    rr++;
                    string pathT = File.ReadAllText("to" + read + ".txt");

                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Copy NUMBER: {0}/{1}", rr, copies);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine();
                    string pathNew = new DirectoryInfo(pathF).Name;
                    string pathRec = pathNew;
                    pathNew = pathT + @"\" + pathNew;
                    Console.WriteLine("Input: " + pathF + ", Output: " + pathT);
                    //pathT = pathT + @"\Copy" + rr;
                    //string pathNew = Path.GetFileName(Path.GetDirectoryName(pathF));
                    System.Diagnostics.Stopwatch ew = System.Diagnostics.Stopwatch.StartNew();
                    DirectoryCopy(pathF, pathNew, true);
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
                } else
                {

                    CleanUp();
                    File.Delete("copy.txt");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine();
                    Console.WriteLine("DONE!");
                    sw.Stop();
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
        static string CleanUp()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Cleaning up..");
            Thread.Sleep(1700);
            string rootFolderPath = Directory.GetCurrentDirectory();
            string filesToDelete = @"from*.txt";
            string[] fileList = System.IO.Directory.GetFiles(rootFolderPath, filesToDelete);
            foreach (string file in fileList)
            {
                Console.WriteLine(file + "has been deleted");
                File.Delete(file);
            }
            filesToDelete = @"to*.txt";
            fileList = System.IO.Directory.GetFiles(rootFolderPath, filesToDelete);
            foreach (string file in fileList)
            {
                Console.WriteLine(file + "has been deleted");
                File.Delete(file);
            }
            Console.ForegroundColor = ConsoleColor.White;
            return null;
        }

        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
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
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine();
                    string time = DateTime.Now.ToString("HH:mm:ss");
                    Console.Write("[{0}]", time);
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write(" --> ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Copying file '");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(temppath);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("'... ");
                    file.CopyTo(temppath, false);
                }
                catch (Exception)
                {
                    //Write Files to Log whicht couldn't be copy
                    LogText += DateTime.Now.ToString() + ": " + file.FullName;
                }
            }

            // If copying subdirectories, copy them and their contents to new location. 
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
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
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }
    }
}
