using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using System.IO;

namespace LoggingKata
{
    class Program
    {
        //Why do you think we use ILog?
        private static readonly ILog Logger =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
       
        static void Main(string[] args)
        {
            Logger.Info("Logging Started");
            var path = Environment.CurrentDirectory + "\\Taco_Bell-US-AL-Alabama.csv";

            Logger.Debug("Created a path to cvs file");
            var filePath = File.ReadAllLines(path);

            if (args.Length == 0)
            {
                Console.WriteLine("You must provide a filename as an argument");
                Logger.Fatal("Cannot import without filename specified as an argument");
                return;
            }

            Logger.Info("Log initialized");
            var lines = File.ReadAllLines(args[0]);
            var parser = new TacoParser();
            var locations = lines.Select(line => parser.Parse(line));

            //TODO:  Find the two TacoBells in Alabama that are the furthurest from one another.
            //HINT:  You'll need two nested forloops

        }
    }
}