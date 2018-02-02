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
        public void ShouldReturnNullForEmptyString()
        {
            //TODO: Complete ShouldParseLine
            //Arrange
            var line = "";
            var parser = new TacoParser();

            // Act
            var result = parser.Parse(line);

            // assert
            Assert.IsNull(result);
        }

        [Test]
        public void ShouldParseLine()
        {
            //Arrange
            var tacoParser = new TacoParser();
            var tacoCoordinates = "-84.677017, 34.073638, Taco Bell Acwort... (Free trial * Add to Cart for a full POIinfo";

            //Act
            var resultTaco = tacoParser.Parse(tacoCoordinates);

            //Assert
            Assert.IsNotNull(resultTaco);
        }
    }
}
