using System;
using System.Collections;
using System.Collections.Generic;
using log4net;
using System.Linq;

namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the TacoBells
    /// </summary>
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
                    Name = cells[2],
                    Location = new Point(double.Parse(cells[0]), double.Parse(cells[1]))
                };

                return tacoBell;
            }
            catch (Exception e)
            {
                Logger.Error("Check to see if cells.Lenght < 3.");
                return null;
            }
        }
    }
}