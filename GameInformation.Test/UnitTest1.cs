using System;
using Xunit;
using Gaming.GameService.DataType;

namespace Gaming.GameService.Test
{
    public class UnitTest1
    {
        private readonly GameService _gameService;

        public UnitTest1()
        {
            _gameService = new GameService();
        }

        [Fact]
        public void Test1()
        {
            Game randomGame =_gameService.GetRandomGame();

            Assert.True(true);
        }
    }
}
