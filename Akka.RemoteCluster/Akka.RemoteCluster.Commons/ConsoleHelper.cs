using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akka.RemoteCluster.Commons
{
    public class ConsoleHelper
    {
        public static void Write(string format, params object[] arg)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(format, arg);
            Console.ResetColor();
        }

        public static void WriteGreen(string format, params object[] arg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(format, arg);
            Console.ResetColor();
        }

        public static void WriteCyan(string format, params object[] arg)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(format, arg);
            Console.ResetColor();
        }

        public static void WriteRed(string format, params object[] arg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(format, arg);
            Console.ResetColor();
        }

        public static void WriteYellow(string format, params object[] arg)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(format, arg);
            Console.ResetColor();
        }
    }
}
