using BeatDealer21.Game;
using BeatDealer21.Game.Infrastructrue;
using Moq;
using System;
using Xunit;

namespace BeatDealer21.Test
{
    public class TwoPlayerBlackJackGameTest
    {
        [Fact]
        public void It_Should_Not_StartGame()
        {
            // Arrange
            var player = new Player { Name = "Test Player" };
            var mockClass = new Mock<TwoPlayerBlackJackGame>(player);

            mockClass.Setup(mock => mock.StartGame());

            // Act

            // Verify
            mockClass.Verify(mock => mock.StartGame(), Times.Never());
        }

        [Fact]
        public void It_Should_StartGame()
        {
            // Arrange
            var player = new Player { Name = "Test Player" };
            var mockClass = new Mock<TwoPlayerBlackJackGame>(player);

            mockClass.Setup(mock => mock.StartGame());

            // Act
            mockClass.Object.StartGame();

            // Verify
            mockClass.Verify(mock => mock.StartGame(), Times.Once());
        }
    }
}
