using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_2023_05.Test
{
    public class MapGroupShould
    {
        readonly MapGroup mapGroup = new("seed-to-soil map:\n50 98 2\n52 50 48");
        [Fact]
        public void CorrectlyReadGroupDataString()
        {
            Assert.Equal("seed-to-soil", mapGroup.name);
            Assert.Equal(2, mapGroup.maps[0].length);
            Assert.Equal(50, mapGroup.maps[1].source);
        }
        [Theory]
        [InlineData(  0,  0)]
        [InlineData( 14, 14)]
        [InlineData( 49, 49)]
        [InlineData( 50, 52)]
        [InlineData( 96, 98)]
        [InlineData( 97, 99)]
        [InlineData( 98, 50)]
        [InlineData( 99, 51)]
        [InlineData(100, 100)]
        public void CorrectlyMapInputs(long inputNumber,long expected)
        {
            Assert.Equal(expected, mapGroup.ApplyMapping(inputNumber));
        }
        [Fact]
        public void ThrowsWhenInvalidInput()
        {
            _ = Assert.ThrowsAny<Exception>(() => new MapGroup("dsadsadsa"));
        }

    }
}
