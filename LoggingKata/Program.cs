using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using System.IO;
using Geolocation;

namespace LoggingKata
{
    class Program
    {
        private static readonly ILog Logger =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            Console.WriteLine("Program started");
            Logger.Info("Logging Started");
            var path = Environment.CurrentDirectory + "\\Taco_Bell-US-AL-Alabama.csv";
            var lines = File.ReadAllLines(path);

            if (lines.Length == 0)
            {
                Console.WriteLine("You must provide a filename as an argument");
                Logger.Fatal("Cannot import without filename specified as an argument");
                return;
            }
            if (lines.Length == 1)
            {
                Console.WriteLine("You must provide a filename as an argument");
                Logger.Fatal("Cannot import without filename specified as an argument");
                return;
            }

            var parser = new TacoParser();
            var locations = lines.Select(line => parser.Parse(line)).ToList();

            ITrackable locationA = null;
            ITrackable locationB = null;

            double distance = 0;

            foreach (var locA in locations)
            {
                var origin = new Coordinate
                {
                    Longitude = locA.Location.Longitude,
                    Latitude = locA.Location.Latitude
                };

                foreach (var locB in locations)
                {
                    var dest = new Coordinate
                    {
                        Longitude = locB.Location.Longitude,
                        Latitude = locB.Location.Latitude
                    };

                    var nDistance = GeoCalculator.GetDistance(origin, dest);

                    if (!(nDistance > distance))
                    {
                        continue;
                    }

                    locationA = locA;
                    locationB = locB;
                    distance = nDistance;
                }
            }

            if (locationA == null || locationB == null)
            {
                Logger.Error("failed to find locations");
                Console.WriteLine("Sorry, try aging. Failed to find the locations.");
                Console.ReadLine();
                return;
            }
            Logger.Info("Write furthest Taco.");
            Console.WriteLine($"The furthest Tacobell are: {locationA.Name} and  {locationB.Name}.");
            Console.WriteLine($"They are {distance} miles apart.");
            Console.ReadLine();
        }
    }
}

