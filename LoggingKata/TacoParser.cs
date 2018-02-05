using System;
using System.Collections;
using System.Collections.Generic;
using log4net;
using System.Linq;

namespace LoggingKata
{

    public class TacoParser
    {
        private static readonly ILog Logger =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ITrackable Parse(string line)
        {
            var cells = line.Split(',');
            if (cells.Length < 3)
            {
                Logger.Error("Length is less than 3, something went wrong");
                return null;
            }

            Logger.Info("About to initialize object to get name and location of tacobell.");

            try
            {
                var tacoBell = new TacoBell
                {
                    Name = cells[2].Split('.')[0].Replace("/", "").Replace("\"", ""),
                    Location = new Point(double.Parse(cells[0]), double.Parse(cells[1]))
                };
                Logger.Info("Should return Taco location and name.");
                return tacoBell;
            }
            catch (Exception e)
            {
                Logger.Error("Check to see if cells.Length < 3.");
                return null;
            }
        }
    }
}