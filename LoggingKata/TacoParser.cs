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
            if (string.IsNullOrEmpty(line))
            {
                return null;
            }
          
            if (cells.Length < 3)
            {
                Logger.Error("Length is less than 3, something went wrong");
                return null;
            }

            Logger.Info("About to initialize object to get name and location of tacobell.");

            try
            {
                var lon = double.Parse(cells[0]);
                var lat = double.Parse(cells[1]);
                return new TacoBell
                {
                    Name = cells.Length > 2 ? cells[2]: null,
                    Location = new Point(lat, lon)
                };
            }
            catch (Exception e)
            {
                Logger.Error("Check to see if cells.Length < 3.");
                return null;
            }
        }
    }
}