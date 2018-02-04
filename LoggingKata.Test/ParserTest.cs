using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using LoggingKata;

namespace LoggingKata.Test
{
    [TestFixture]
    public class TacoParserTestFixture
    {
        [Test]
        public void ShouldNotParseLine()
        {
            //Arrange
            var tacoParser = new TacoParser();
            var testCoordination ="- 84.677017, 34.073638, Taco Bell Acwort... (Free trial * Add to Cart for a full POIinfo";

            // Act 
            var result = tacoParser.Parse(testCoordination);

            // assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void ShouldParseLine()
        {
            //Arrange
            var tacoParser = new TacoParser();

            var twoOutOfThreeCoordinates = "- 84.677017, 34.073638";
            var lattitudeIsNotNumber = "Latitiude, -84.677017, tacoBell";
            var longitudeIsNotNumber = "- 84.677017, Longitude, tacobell";

            //Act
            var twoOutOfThreeCoordinatesValue = tacoParser.Parse(twoOutOfThreeCoordinates);
            var lattiudeIsNotNumberValue = tacoParser.Parse(lattitudeIsNotNumber);
            var longitudeIsNotNumberValue = tacoParser.Parse(longitudeIsNotNumber);

            //Assert
            Assert.IsNull(twoOutOfThreeCoordinatesValue);
            Assert.IsNull(lattiudeIsNotNumberValue);
            Assert.IsNull(longitudeIsNotNumberValue);
        }
    }
}
