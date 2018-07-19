using System;
using Xunit;
using Gaming.GameService.DataType;

namespace Gaming.GameService.Test
{
    public class UnitTest1
    {
        private readonly GameInformation _gameService;

        public UnitTest1()
        {
            _gameService = new GameInformation();
        }

        [Fact]
        public void Test1()
        {
            Game randomGame =_gameService.GetRandomGame();

            Assert.True(true);
        }
    }
}
