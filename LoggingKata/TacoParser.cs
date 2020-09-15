﻿namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing");

            // Take your line and use line.Split(',') to split it up into an array of strings, separated by the char ','
            var cells = line.Split(',');

            // If your array.Length is less than 3, something went wrong
            if (cells.Length < 3)
            {
                // Log that and return null
                logger.LogError("Less than 3 elements in file");
                // Do not fail if one record parsing fails, return null
                return null; // TODO Implement
            }


            // grab the latitude from your array at index 0

            // grab the longitude from your array at index 1
            // grab the name from your array at index 2

            // Your going to need to parse your string as a `double`
            // which is similar to parsing a string as an `int`

            // DONE -You'll need to create a TacoBell class
            // DONE - that conforms to ITrackable

            // Then, you'll need an instance of the TacoBell class
            // With the name and point set correctly
            var tacoBell = new TacoBell();

            double number;
            Point pnt = new Point();

            if (double.TryParse(cells[0], out number))
                pnt.Latitude = number;
            else
                logger.LogError("Couldn't parse latitude");

            if (double.TryParse(cells[1], out number))
                pnt.Longitude = number;
            else
            {
                logger.LogError("Couldn't parse longitude");
                return null;
            }

            tacoBell.Location = pnt;
            tacoBell.Name = cells[2];


            // Then, return the instance of your TacoBell class
            // Since it conforms to ITrackable

            return null;
        }
    }
}