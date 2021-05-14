using System;
using Xunit;

namespace Enigma.Core.Tests
{
    public class PlugBoardTests
    {
        [Theory]
        [InlineData("AB CD EF", "BADCFEGHIJKLMNOPQRSTUVWXYZ")]
        [InlineData("AY", "YBCDEFGHIJKLMNOPQRSTUVWXAZ")]
        [InlineData("HZ", "ABCDEFGZIJKLMNOPQRSTUVWXYH")]
        [InlineData("ZH", "ABCDEFGZIJKLMNOPQRSTUVWXYH")]
        [InlineData("", "ABCDEFGHIJKLMNOPQRSTUVWXYZ")]
        public void PluggedCharactersAreValid(string jumpers, string expected)
        {
            //Arrange
            var plugBoard = new PlugBoard();

            //Act
            plugBoard.PlugJumpers(jumpers);

            //Assert
            Assert.Equal(expected, plugBoard.WiredSequence);
        }

        [Theory]
        [InlineData("5A -A5", "Invalid input of jumpers")]
        [InlineData("A6", "Invalid input of jumpers")]
        [InlineData("AAA BB CC", "Invalid input of jumpers")]
        [InlineData("AA B-B CC DD", "Invalid input of jumpers")]
        [InlineData("AB CD EF GHI", "Invalid input of jumpers")]
        [InlineData("AB CD EF AH", "Cannot use the same character more than 1 time")]
        public void PluggedCharactersInvalidMustThrowException(string jumpers, string expectedError)
        {
            //Arrange
            var plugBoard = new PlugBoard();

            //Act & Assert
            var exception =
                Assert.Throws<Exception>(() => plugBoard.PlugJumpers(jumpers));

            Assert.Equal(expectedError, exception.Message);
        }
    }
}
