using System;
using Xunit;
using System.Linq;
using api.Controllers;

namespace tests
{
    public class RangeTests
    {
        [Fact]
        public void CountShouldControlNumberOfResults()
        {
            var range = new Range { Count = 3 };
            var generated = range.Of(() => "");
            Assert.Equal(3, generated.Count());
        }
        [Fact]
        public void SortShouldOrderResults()
        {
            //Given
            var range = new Range { Count = 3, Sort = true };
            var values = new[] { "a", "c", "b" };
            var counter = 0;

            //When
            var generated = range.Of(() => values[counter++]);

            //Then
            Assert.Equal(new[] { "a", "b", "c" }, generated.ToArray());
        }
    }
}
