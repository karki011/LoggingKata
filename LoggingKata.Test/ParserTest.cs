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
        public void ShouldParseLine()
        {
            //Arrange
            var tacoParser = new TacoParser();
            var testCoordination ="- 84.677017, 34.073638, Taco Bell Acwort... (Free trial * Add to Cart for a full POIinfo";

            // Act 
            var result = tacoParser.Parse(testCoordination);

            // assert
            Assert.Null(result);

        }

        [Test]
        public void ShouldNotParseLine()
        {
            //Arrange
            var tacoParser = new TacoParser();

            var empty = "";
            var twoOutOfThreeCoordinates = "- 84.677017, 34.073638";
            var latitudeIsNotNumber = "Latitiude, -84.677017, tacoBell";
            var longitudeIsNotNumber = "- 84.677017, Longitude, tacobell";

            //Act
            var twoOutOfThreeCoordinatesValue = tacoParser.Parse(twoOutOfThreeCoordinates +" should parse.");
            var latiudeIsNotNumberValue = tacoParser.Parse(latitudeIsNotNumber +" Should not parse.");
            var longitudeIsNotNumberValue = tacoParser.Parse(longitudeIsNotNumber + "Should not parse.");
            var emptyCoord = tacoParser.Parse(empty);


            //Assert
            Assert.IsNull(twoOutOfThreeCoordinatesValue);
            Assert.IsNull(latiudeIsNotNumberValue);
            Assert.IsNull(longitudeIsNotNumberValue);
            Assert.IsNull(emptyCoord);
        }
    }
}
