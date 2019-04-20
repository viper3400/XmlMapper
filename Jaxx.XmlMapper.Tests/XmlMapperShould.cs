using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Jaxx.XmlMapper.Tests
{
    public class XmlMapperShould
    {
        [Fact]
        public void SimpleMappingTest()
        {
            var SUT = new ObjectMapper("./TestAssets/Example.xml");
            var actual = SUT.Map("srcString1");
            var expected = "destStringX";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void OfdbMovieMappingTest()
        {
            var SUT = new ObjectMapper("./TestAssets/ofdbtovideodbgenremapping.xml");
            //var testData = new List<string>() { "Abenteuer", "Komödie", "Drama" };
            var actual = SUT.Map("Abenteuer");
            var expected = "2";

            Assert.Equal(expected, actual);

        }

        [Fact]
        public void SourceNotInMapTableTest()
        {
            var SUT = new ObjectMapper("./TestAssets/Example.xml");
            var expected = "";
            var actual = SUT.Map("notinmaptable");

            Assert.Equal(expected, actual);
        }
    }
}
