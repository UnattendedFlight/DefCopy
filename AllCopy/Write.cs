using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefCopy
{
    class Write
    {
        static public void At(string text, bool tf = true)
        {
            if (tf == true)
            {
                Console.Write(text);
                File.AppendAllText("log.txt", text + "\n");
            } else if (tf == false)
            {
                Console.WriteLine(text);
                File.AppendAllText("log.txt", text + "\n");
            }
            return;
            
        }
    }
}
